using BoletoAPI.Domain.Entities;
using BoletoAPI.Domain.Interfaces;
using BoletoNetCore;
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

        private Boleto? GerarBoleto(DadosBoleto dadosBoleto)
        {
            if (dadosBoleto == null || 
                dadosBoleto.Sacado == null || 
                dadosBoleto.Sacado.Endereco == null ||
                dadosBoleto.Beneficiario == null || 
                dadosBoleto.Beneficiario.ContaBancaria == null)
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

        private Beneficiario PreencherDadosBeneficiario(DadosBeneficiario beneficiario, Domain.Entities.ContaBancaria contaBancaria)
        {
            Beneficiario beneficiarioLibNetCore = new Beneficiario();

            beneficiarioLibNetCore.CPFCNPJ = beneficiario.CpfCnpj;
            beneficiarioLibNetCore.Nome = beneficiario.Nome;
            beneficiarioLibNetCore.ContaBancaria.Agencia = contaBancaria.Agencia;
            beneficiarioLibNetCore.ContaBancaria.DigitoAgencia = contaBancaria.DigitoAgencia;
            beneficiarioLibNetCore.ContaBancaria.Conta = contaBancaria.Conta;
            beneficiarioLibNetCore.ContaBancaria.DigitoConta = contaBancaria.DigitoConta;
            beneficiarioLibNetCore.ContaBancaria.CarteiraPadrao = contaBancaria.CarteiraPadrao;
            beneficiarioLibNetCore.ContaBancaria.TipoCarteiraPadrao = TipoCarteira.CarteiraCobrancaSimples;
            beneficiarioLibNetCore.ContaBancaria.TipoFormaCadastramento = TipoFormaCadastramento.ComRegistro;
            beneficiarioLibNetCore.ContaBancaria.TipoImpressaoBoleto = TipoImpressaoBoleto.Empresa;

            return beneficiarioLibNetCore;
        }

        private Boleto GerarLayoutBoleto(IBanco banco, DadosBoleto dadosBoleto, Sacado sacado, DadosEndereco endereco)
        {
            var boleto = new Boleto(banco)
            {
                NossoNumero = dadosBoleto.NossoNumero,
                Pagador = DadosSacado(sacado, endereco),
                DataEmissao = dadosBoleto.DataEmissao,
                DataProcessamento = dadosBoleto.DataProcessamento,
                DataVencimento = dadosBoleto.Vencimento,
                ValorTitulo = dadosBoleto.Valor,
                NumeroDocumento = dadosBoleto.NumeroDocumento,
                EspecieDocumento = TipoEspecieDocumento.DS,
                ImprimirValoresAuxiliares = true,
            };

            boleto.ValidarDados(); // DADOS DE PRODUÇÃO ESSA LINHA DEVE SER DESCOMENTADA
            return boleto;
        }

        private static Pagador DadosSacado(Sacado sacado, DadosEndereco dadosEndereco)
        {
            return new Pagador
            {
                Nome = sacado.Nome,
                CPFCNPJ = sacado.Cpf,

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
    }
}