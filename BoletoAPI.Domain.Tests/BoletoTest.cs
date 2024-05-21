using BoletoAPI.Domain.Entities;
using FluentAssertions;
using System.Drawing;

namespace BoletoAPI.Domain.Tests
{
    public class BoletoTest
    {

        [Theory(DisplayName = "Dados do boleto válido")]
        [InlineData("4316", "2023-08-12", "109", 20.00, 2, 0.5, "2023-08-12", "2023-08-12", "Itau", 0, 0)]
        public void ConstrutorBoleto_PassarDadosValidos_RetornaSucesso(string nossoNumero, DateTime vencimento, string numeroDocumento, decimal valor, decimal percentualMulta, decimal percentualJurosDia, DateTime dataEmissao, DateTime dataProcessamento, string tipoBanco, int? codigoProtesto, int? diasProtesto)
        {
            Action action = () => new DadosBoleto(nossoNumero, vencimento, numeroDocumento, valor, percentualMulta, percentualJurosDia, dataEmissao, dataProcessamento, tipoBanco, codigoProtesto, diasProtesto, null, null, null, null);
            action.Should().NotThrow();
        }

        [InlineData(null, "2023-08-12", "109", 20.00, 2, 0.5, "2023-08-12", "2023-08-12", "Itau", 0, 0)]
        [InlineData("", "2023-08-12", "109", 20.00, 2, 0.5, "2023-08-12", "2023-08-12", "Itau", 0, 0)]
        [Theory(DisplayName = "Dados do boleto nulo ou vazio")]
        public void ConstrutorBoleto_PassarNossoNumeroNuloOuVazio_RetornaException(string nossoNumero, DateTime vencimento, string numeroDocumento, decimal valor, decimal percentualMulta, decimal percentualJurosDia, DateTime dataEmissao, DateTime dataProcessamento, string tipoBanco, int? codigoProtesto, int? diasProtesto)
        {
                       Action action = () => new DadosBoleto(nossoNumero, vencimento, numeroDocumento, valor, percentualMulta, percentualJurosDia, dataEmissao, dataProcessamento, tipoBanco, codigoProtesto, diasProtesto, null, null, null, null);
            action.Should().Throw<ArgumentException>().WithMessage("NossoNumero inválido: Campo obrigatório.");
        }

        [InlineData("4316", "2023-08-12", null, 20.00, 2, 0.5, "2023-08-12", "2023-08-12", "Itau", 0, 0)]
        [InlineData("4316", "2023-08-12", "", 20.00, 2, 0.5, "2023-08-12", "2023-08-12", "Itau", 0, 0)]
        [Theory(DisplayName = "Dados do boleto nulo ou vazio")]
        public void ConstrutorBoleto_PassarNumeroDocumentoNuloOuVazio_RetornaException(string nossoNumero, DateTime vencimento, string numeroDocumento, decimal valor, decimal percentualMulta, decimal percentualJurosDia, DateTime dataEmissao, DateTime dataProcessamento, string tipoBanco, int? codigoProtesto, int? diasProtesto)
        {
                       Action action = () => new DadosBoleto(nossoNumero, vencimento, numeroDocumento, valor, percentualMulta, percentualJurosDia, dataEmissao, dataProcessamento, tipoBanco, codigoProtesto, diasProtesto, null, null, null, null);
            action.Should().Throw<ArgumentException>().WithMessage("NumeroDocumento inválido: Campo obrigatório.");
        }

        [InlineData("4316", "2023-08-12", "138", 20.00, 2, 0.5, "2023-08-12", "2023-08-12", "Itau", 0, 0)]
        [Theory(DisplayName = "Dados do boleto nulo ou vazio")]
        public void ConstrutorBoleto_PassarDataInvalida_RetornaException(string nossoNumero, DateTime vencimento, string numeroDocumento, decimal valor, decimal percentualMulta, decimal percentualJurosDia, DateTime dataEmissao, DateTime dataProcessamento, string tipoBanco, int? codigoProtesto, int? diasProtesto)
        {
            vencimento = DateTime.MinValue;

                       Action action = () => new DadosBoleto(nossoNumero, vencimento, numeroDocumento, valor, percentualMulta, percentualJurosDia, dataEmissao, dataProcessamento, tipoBanco, codigoProtesto, diasProtesto, null, null, null, null);
            action.Should().Throw<ArgumentException>().WithMessage($"Vencimento inválido: Campo obrigatório.");
        }

        [InlineData("4316", "2023-08-12", "138", 0.00, 2, 0.5, "2023-08-12", "2023-08-12", "Itau", 0, 0)]
        [Theory(DisplayName = "Dados do boleto com valor menor que 10 ")]
        public void ConstrutorBoleto_PassarValorMenorQue10_RetornaException(string nossoNumero, DateTime vencimento, string numeroDocumento, decimal valor, decimal percentualMulta, decimal percentualJurosDia, DateTime dataEmissao, DateTime dataProcessamento, string tipoBanco, int? codigoProtesto, int? diasProtesto)
        {
                       Action action = () => new DadosBoleto(nossoNumero, vencimento, numeroDocumento, valor, percentualMulta, percentualJurosDia, dataEmissao, dataProcessamento, tipoBanco, codigoProtesto, diasProtesto, null, null, null, null);
            action.Should().Throw<ArgumentException>().WithMessage($"Valor inválido: Campo obrigatório.");
        }

        [InlineData("4316", "2023-08-12", "109", 20.00, 2, 0.5, "2023-08-12", "2023-08-12", "Itau", 0, 0)]
        [Theory(DisplayName = "Dados do boleto inválido, data emissão inválida")]
        public void ContrutorBoleto_PassarDataEmissaoInvalida_RetornaException(string nossoNumero, DateTime vencimento, string numeroDocumento, decimal valor, decimal percentualMulta, decimal percentualJurosDia, DateTime dataEmissao, DateTime dataProcessamento, string tipoBanco, int? codigoProtesto, int? diasProtesto)
        {
            dataEmissao = DateTime.MinValue;

                       Action action = () => new DadosBoleto(nossoNumero, vencimento, numeroDocumento, valor, percentualMulta, percentualJurosDia, dataEmissao, dataProcessamento, tipoBanco, codigoProtesto, diasProtesto, null, null, null, null);
            action.Should().Throw<ArgumentException>().WithMessage($"DataEmissao inválido: Campo obrigatório.");
        }

        [InlineData("4316", "2023-08-12", "109", 20.00, 2, 0.5, "2023-08-12", "2023-08-12", "Itau", 0, 0)]
        [Theory(DisplayName = "Dados do boleto inválido, data emissão inválida")]
        public void ContrutorBoleto_PassarDataProcessamentoInvalida_RetornaException(string nossoNumero, DateTime vencimento, string numeroDocumento, decimal valor, decimal percentualMulta, decimal percentualJurosDia, DateTime dataEmissao, DateTime dataProcessamento, string tipoBanco, int? codigoProtesto, int? diasProtesto)
        {
            dataProcessamento = DateTime.MinValue;

                       Action action = () => new DadosBoleto(nossoNumero, vencimento, numeroDocumento, valor, percentualMulta, percentualJurosDia, dataEmissao, dataProcessamento, tipoBanco, codigoProtesto, diasProtesto, null, null, null, null);
            action.Should().Throw<ArgumentException>().WithMessage($"DataProcessamento inválido: Campo obrigatório.");
        }

        [InlineData("4316", "2023-08-12", "109", 20.00, 2, 0.5, "2023-08-12", "2023-08-12", "", 0, 0)]
        [InlineData("4316", "2023-08-12", "109", 20.00, 2, 0.5, "2023-08-12", "2023-08-12", " ", 0, 0)]
        [InlineData("4316", "2023-08-12", "109", 20.00, 2, 0.5, "2023-08-12", "2023-08-12", null, 0, 0)]
        [Theory(DisplayName = "Dados do boleto inválido, data emissão inválida")]
        public void ContrutorBoleto_PassarTipoBancoInvalido_RetornaException(string nossoNumero, DateTime vencimento, string numeroDocumento, decimal valor, decimal percentualMulta, decimal percentualJurosDia, DateTime dataEmissao, DateTime dataProcessamento, string tipoBanco, int? codigoProtesto, int? diasProtesto)
        {
                       Action action = () => new DadosBoleto(nossoNumero, vencimento, numeroDocumento, valor, percentualMulta, percentualJurosDia, dataEmissao, dataProcessamento, tipoBanco, codigoProtesto, diasProtesto, null, null, null, null);
            action.Should().Throw<ArgumentException>().WithMessage($"TipoBanco inválido: Campo obrigatório.");
        }
    }
}
