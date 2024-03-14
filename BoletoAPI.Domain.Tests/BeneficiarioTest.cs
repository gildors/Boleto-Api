
using BoletoAPI.Domain.Entities;
using FluentAssertions;

namespace BoletoAPI.Domain.Tests
{
    public class BeneficiarioTest
    {
        [Theory(DisplayName = "Dados do beneficiario válidos")]
        [InlineData("1245", "1", "14", "25", "778.310.986-15", "Jorge Antonio Santos", "Observações de teste")]
        public void ConstrutorBeneficiario_PassarDadosValidos_RetornaSucesso(string codigo, string codigoDV, string codigoFormatado, string codigoTransmissao, string cpfCnpj, string nome, string observacoes)
        {
            Action action = () => new DadosBeneficiario(codigo, codigoDV, codigoFormatado, codigoTransmissao, cpfCnpj, nome, observacoes);
            action.Should().NotThrow();
        }

        [InlineData(null, "1", "14", "25", "778.310.986-15", "Jorge Antonio Santos", "Observações de teste")]
        [InlineData("", "1", "14", "25", "778.310.986-15", "Jorge Antonio Santos", "Observações de teste")]
        [Theory(DisplayName = "Dados do beneficiario com código nulo ou vazio")]
        public void ConstrutorBeneficiario_PassarCodigoValorNuloOuVazio_RetornaException(string codigo, string codigoDV, string codigoFormatado, string codigoTransmissao, string cpfCnpj, string nome, string observacoes)
        {
            Action action = () => new DadosBeneficiario(codigo, codigoDV, codigoFormatado, codigoTransmissao, cpfCnpj, nome, observacoes);
            action.Should().Throw<ArgumentException>().WithMessage("Codigo do beneficiario inválido: Campo obrigatório.");
        }

        [InlineData("1245", "1", "25", "11", null, "Jorge Antonio Santos", "Observações de teste")]
        [InlineData("1245", "1", "25", "11", "", "Jorge Antonio Santos", "Observações de teste")]
        [Theory(DisplayName = "Dados do beneficiario com CPF/CNPJ nulo ou vazio")]
        public void ConstrutorBeneficiario_PassarCPFCNPJValorNuloOuVazio_RetornaException(string codigo, string codigoDV, string codigoFormatado, string codigoTransmissao, string cpfCnpj, string nome, string observacoes)
        {
            Action action = () => new DadosBeneficiario(codigo, codigoDV, codigoFormatado, codigoTransmissao, cpfCnpj, nome, observacoes);
            action.Should().Throw<ArgumentException>().WithMessage("CpfCnpj do beneficiario inválido: Campo obrigatório.");
        }


        [InlineData("1245", "1", "25", "11", "778.310.986-15", null, "Observações de teste")]
        [InlineData("1245", "1", "25", "11", "778.310.986-15", "", "Observações de teste")]
        [Theory(DisplayName = "Dados do beneficiario com nome vazio ou nulo")]
        public void ConstrutorBeneficiario_PassarNomeVazioOuNulo_RetornaException(string codigo, string codigoDV, string codigoFormatado, string codigoTransmissao, string cpfCnpj, string nome, string observacoes)
        {
            Action action = () => new DadosBeneficiario(codigo, codigoDV, codigoFormatado, codigoTransmissao, cpfCnpj, nome, observacoes);
            action.Should().Throw<ArgumentException>().WithMessage("Nome do beneficiario inválido: Campo obrigatório.");
        }
    }
}
