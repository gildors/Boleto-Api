using BoletoAPI.Domain.Entities;
using FluentAssertions;

namespace BoletoAPI.Domain.Tests
{
    public class DadosContaBancariaTest
    {
        [Theory(DisplayName = "Conta bancária com dados válidos")]
        [InlineData("4316", "33180", "", "1", "109")]
        public void ConstrutorDadosContaBancaria_PassarDadosValidos_RetornaSucesso(string agencia, string conta, string digitoAgencia, string digitoConta, string carteiraPadrao)
        {
            Action action = () => new DadosContaBancaria(agencia, conta, digitoAgencia, digitoConta, carteiraPadrao);
            action.Should().NotThrow();
        }

        [Theory(DisplayName = "Conta bancária com agencia vazio ou nulo")]
        [InlineData(null, "33180", "", "2", "109")]
        public void ContrutorEndereco_PassarAgenciaVazioNulo_RetornarException(string agencia, string conta, string digitoAgencia, string digitoConta, string carteiraPadrao)
        {
            Action action = () => new DadosContaBancaria(agencia, conta, digitoAgencia, digitoConta, carteiraPadrao);
            action.Should().Throw<ArgumentException>().WithMessage("Agencia inválida: O campo deve ter um tamanho de 4 a 5 digitos.");
        }

        [InlineData("258456", "33180", "", "2", "109")]
        [InlineData("000", "33180", "", "2", "109")]
        [Theory(DisplayName = "Conta bancária com agencia maior que 5 e menor que 4")]
        public void ContrutorEndereco_PassarAgenciaComValorMaiorQue5EMenorQue4_RetornarException(string agencia, string conta, string digitoAgencia, string digitoConta, string carteiraPadrao)
        {
            Action action = () => new DadosContaBancaria(agencia, conta, digitoAgencia, digitoConta, carteiraPadrao);
            action.Should().Throw<ArgumentException>().WithMessage("Agencia inválida: O campo deve ter um tamanho de 4 a 5 digitos.");
        }

        [InlineData("0000", null, "", "2", "109")]
        [Theory(DisplayName = "Conta bancária com conta nula ou vazia")]
        public void ContrutorEndereco_PassarContaComValorNullouVazio_RetornarException(string agencia, string conta, string digitoAgencia, string digitoConta, string carteiraPadrao)
        {
            Action action = () => new DadosContaBancaria(agencia, conta, digitoAgencia, digitoConta, carteiraPadrao);
            action.Should().Throw<ArgumentException>().WithMessage("Conta inválido: Campo obrigatório.");
        }

        [InlineData("0000", "33180", "", "2", null)]
        [Theory(DisplayName = "Conta bancária com carteira padrão nula ou vazia")]
        public void ContrutorEndereco_PassarCarteiraPadraoComValorNullouVazio_RetornarException(string agencia, string conta, string digitoAgencia, string digitoConta, string carteiraPadrao)
        {
            Action action = () => new DadosContaBancaria(agencia, conta, digitoAgencia, digitoConta, carteiraPadrao);
            action.Should().Throw<ArgumentException>().WithMessage("CarteiraPadrao inválido: O campo é obrigatório");
        }

        [InlineData("0000", "33180", "", "", "109")]
        [Theory(DisplayName = "Conta bancária com digito da conta nula ou vazia")]
        public void ContrutorEndereco_PassarDigitoContaComValorNullouVazio_RetornarException(string agencia, string conta, string digitoAgencia, string digitoConta, string carteiraPadrao)
        {
            Action action = () => new DadosContaBancaria(agencia, conta, digitoAgencia, digitoConta, carteiraPadrao);
            action.Should().Throw<ArgumentException>().WithMessage("DigitoConta inválido: O campo é obrigatório");
        }
    }
}
