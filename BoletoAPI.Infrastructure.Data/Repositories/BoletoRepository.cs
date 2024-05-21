using BoletoAPI.Domain.Entities;
using BoletoAPI.Domain.Interfaces;
using BoletoNetCore;
using BoletoNetCore.Enums;
using System.Text;

namespace BoletoAPI.Infrastructure.Data.Repositories
{
    public class BoletoRepository : IBoletoRepository
    {
        public string? RetornarHTML(DadosBoleto dadosBoleto)
        {
            var boleto = GerarBoleto(dadosBoleto);

            var boletoBancario = new BoletoBancario { Boleto = boleto };

            return boletoBancario.MontaHtmlEmbedded();
        }
        public string? RetornarLinhaDigitavel(DadosBoleto dadosBoleto)
        {
            var boleto = GerarBoleto(dadosBoleto);

            return boleto?.CodigoBarra.LinhaDigitavel;
        }
        private static Boleto? GerarBoleto(DadosBoleto dadosBoleto)
        {
            if (dadosBoleto is null || 
                dadosBoleto.Sacado is null || 
                dadosBoleto.Sacado.Endereco is null ||
                dadosBoleto.Beneficiario is null || 
                dadosBoleto.Beneficiario.ContaBancaria is null)
            {
                return null;
            }

            IBanco _banco = ObterTipoBanco(dadosBoleto.TipoBanco);

            _banco.Beneficiario = PreencherDadosBeneficiario(dadosBoleto.Beneficiario, dadosBoleto.Beneficiario.ContaBancaria);

            _banco.FormataBeneficiario();

            var boleto = GerarLayoutBoleto(_banco, dadosBoleto, dadosBoleto.Sacado, dadosBoleto.Sacado.Endereco);

            return boleto;
        }

        private static IBanco ObterTipoBanco(string tipoBanco)
        {
            switch (tipoBanco)
            {
                case "001":
                case "BancoDoBrasil":
                    return Banco.Instancia(Bancos.BancoDoBrasil);

                case "004":
                case "BancoDoNordeste":
                    return Banco.Instancia(Bancos.BancoDoNordeste);

                case "033":
                case "Santander":
                    return Banco.Instancia(Bancos.Santander);

                case "041":
                case "Banrisul":
                    return Banco.Instancia(Bancos.Banrisul);

                case "084":
                case "UniprimeNortePR":
                    return Banco.Instancia(Bancos.UniprimeNortePR);

                case "085":
                case "Cecred":
                    return Banco.Instancia(Bancos.Cecred);

                case "104":
                case "Caixa":
                    return Banco.Instancia(Bancos.Caixa);

                case "237":
                case "Bradesco":
                    return Banco.Instancia(Bancos.Bradesco);

                case "422":
                case "Safra":
                    return Banco.Instancia(Bancos.Safra);

                case "748":
                case "Sicredi":
                    return Banco.Instancia(Bancos.Sicredi);

                case "756":
                case "Sicoob":
                    return Banco.Instancia(Bancos.Sicoob);

                case "097":
                case "CrediSIS":
                    Banco.Instancia(Bancos.CrediSIS);
                    return Banco.Instancia(Bancos.CrediSIS);

                case "341":
                case "Itau":
                    return Banco.Instancia(Bancos.Itau);

                default:
                    throw new ArgumentException($"Banco não implementado.");
            }
        }

        private static Beneficiario PreencherDadosBeneficiario(DadosBeneficiario dadosBeneficiario, DadosContaBancaria dadosContaBancaria)
        {
            return new Beneficiario() 
            {
                CPFCNPJ = dadosBeneficiario.CpfCnpj,
                Nome = dadosBeneficiario.Nome,
                Codigo = dadosBeneficiario.Codigo,
                CodigoDV = dadosBeneficiario.CodigoDV,
                CodigoTransmissao = dadosBeneficiario.CodigoTransmissao,
                CodigoFormatado = dadosBeneficiario.CodigoFormatado,
                ContaBancaria = new ContaBancaria()
                {
                    Agencia = dadosContaBancaria.Agencia,
                    DigitoAgencia = dadosContaBancaria.DigitoAgencia,
                    Conta = dadosContaBancaria.Conta,
                    DigitoConta = dadosContaBancaria.DigitoConta,
                    CarteiraPadrao = dadosContaBancaria.CarteiraPadrao,
                    TipoCarteiraPadrao = TipoCarteira.CarteiraCobrancaSimples,
                    TipoFormaCadastramento = TipoFormaCadastramento.ComRegistro,
                    TipoImpressaoBoleto = TipoImpressaoBoleto.Empresa,
                }
            };
        }

        private static Boleto GerarLayoutBoleto(IBanco banco, DadosBoleto dadosBoleto, Sacado sacado, DadosEndereco endereco)
        {
            var boleto = new Boleto(banco)
            {
                ImprimirValoresAuxiliares = true,
                EspecieDocumento = TipoEspecieDocumento.DS,
                NossoNumero = dadosBoleto.NossoNumero,
                NumeroDocumento = dadosBoleto.NumeroDocumento,
                ValorTitulo = dadosBoleto.Valor,
                MensagemInstrucoesCaixa = dadosBoleto.MensagemInstrucoesCaixa,
                ImprimirMensagemInstrucao = true,
                CodigoProtesto = (TipoCodigoProtesto)dadosBoleto.CodigoProtesto,
                DiasProtesto =  dadosBoleto.DiasProtesto,
                DataEmissao = dadosBoleto.DataEmissao,
                DataProcessamento = dadosBoleto.DataProcessamento,
                DataVencimento = dadosBoleto.Vencimento,
                DataJuros = dadosBoleto.Vencimento.AddDays(1),
                ValorMulta = (dadosBoleto.PercentualMulta / 100) * dadosBoleto.Valor,
                ValorAbatimento = (dadosBoleto.PercentualMulta / 100) * dadosBoleto.Valor,
                ValorJurosDia = (dadosBoleto.PercentualJurosDia / 100) * dadosBoleto.Valor,
                PercentualJurosDia = dadosBoleto.PercentualJurosDia,
                TipoJuros = TipoJuros.Simples,
                DataMulta = dadosBoleto.Vencimento.AddDays(1),
                PercentualMulta = dadosBoleto.PercentualMulta,
                TipoCodigoMulta = TipoCodigoMulta.Valor,

                Pagador = DadosSacado(sacado, endereco),
            };
            
            
           

            boleto.ValidarDados();
            return boleto;
        }

        private static Pagador DadosSacado(Sacado sacado, DadosEndereco dadosEndereco)
        {
            return new Pagador
            {
                Nome = sacado.Nome,
                CPFCNPJ = sacado.CpfCnpj,

                Endereco = new Endereco
                {
                    LogradouroEndereco = dadosEndereco.Logradouro,
                    LogradouroNumero = dadosEndereco.Numero,
                    Bairro = dadosEndereco.Bairro,
                    Cidade = dadosEndereco.Cidade,
                    UF = dadosEndereco.Estado,
                    CEP = dadosEndereco.CEP
                }
            };
        }

        private static string GerarRemessa(IBanco banco, List<Boleto> boletos, TipoArquivo tipoArquivo, int numeroArquivoRemessa, int? numeroArquivoRemessaNoDia) 
        {
            var _boletos = new Boletos
            {
                Banco = banco,
            };

            _boletos.AddRange(boletos);

            var remittanceFile = new ArquivoRemessa(banco, tipoArquivo, numeroArquivoRemessa, numeroArquivoRemessaNoDia);
            using MemoryStream memoryStream = new();
            remittanceFile.GerarArquivoRemessa(_boletos, memoryStream);
            return Encoding.ASCII.GetString(memoryStream.ToArray());
        }

        public string? RetornarRemessa(DadosRemessa dadosRemessa)
        {
            List<Boleto> boletos = [];

            foreach (var dadosBoleto in dadosRemessa.DadosBoletos)
            {
                var boleto = GerarBoleto(dadosBoleto);
                
                if (boleto == null) 
                    return null;
                
                boletos.Add(boleto);
            }

            IBanco _banco = ObterTipoBanco(dadosRemessa.TipoBanco);

            return GerarRemessa(_banco, boletos, (TipoArquivo)dadosRemessa.TipoArquivo, dadosRemessa.NumeroArquivoRemessa, dadosRemessa.NumeroArquivoRemessaNoDia);
        }

        public string? RetornarArquivoRetorno(DadosRetorno dadosRetorno)
        {
            IBanco _banco = ObterTipoBanco(dadosRetorno.TipoBanco);

            if(dadosRetorno.ArquivoRetorno is null)
            {
                return null;
            }

            var boletos = ProcessarRetorno(_banco, (TipoArquivo)dadosRetorno.TipoArquivo, dadosRetorno.ArquivoRetorno.OpenReadStream());

            var serializerSettings = new Newtonsoft.Json.JsonSerializerSettings
            {
                ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
            };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(boletos, serializerSettings);

            return json;
        }

        private static Boletos ProcessarRetorno(IBanco banco, TipoArquivo tipoArquivo, Stream conteudoArquivoRetorno) 
        {
            ArquivoRetorno arquivoRetorno = new ArquivoRetorno(banco, tipoArquivo);

            var boletos = arquivoRetorno.LerArquivoRetorno(conteudoArquivoRetorno);

            return boletos;
        }
    }
}