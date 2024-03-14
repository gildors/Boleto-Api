using BoletoAPI.Domain.Entities;
using FluentAssertions;

namespace BoletoAPI.Domain.Tests
{
    public class EnderecoTest
    {
        [Theory(DisplayName = "Endereço com dados válidos")]
        [InlineData("78149-218", "Rua Santa Mônica", "222", "Novo Mundo", "Várzea Grande", "MT")]
        public void ConstrutorEndereco_PassarDadosValidos_RetornaSucesso(string cep, string logradouro, string numero, string bairro, string cidade, string estado)
        {
            Action action = () => new DadosEndereco(cep, logradouro, numero, bairro, cidade, estado);
            action.Should().NotThrow();
        }

        [Theory(DisplayName = "Endereço com CEP vazio ou nulo")]
        [InlineData(null, "Rua Santa Mônica", "222", "Novo Mundo", "Várzea Grande", "MT")]
        public void ContrutorEndereco_PassarCEPVazioNulo_RetornarExceprion(string cep, string logradouro, string numero, string bairro, string cidade, string estado)
        {
            Action action = () => new DadosEndereco(cep, logradouro, numero, bairro, cidade, estado);
            action.Should().Throw<ArgumentException>().WithMessage("CEP inválido: Campo obrigatório.");
        }

        [Theory(DisplayName = "Endereço com logradouro vazio ou nulo")]
        [InlineData("12402-010", null, "222", "Novo Mundo", "Várzea Grande", "MT")]
        public void ContrutorEndereco_PassarLogradouroVazioOuNulo_RetornarExceprion(string cep, string logradouro, string numero, string bairro, string cidade, string estado)
        {
            Action action = () => new DadosEndereco(cep, logradouro, numero, bairro, cidade, estado);
            action.Should().Throw<ArgumentException>().WithMessage("Logradouro inválido: Campo obrigatório.");
        }

        [Theory(DisplayName = "Endereço com número com valor null ou vazio")]
        [InlineData("12402-010", "Rua Santa Mônica", null, "Novo Mundo", "Várzea Grande", "MT")]
        public void ContrutorEndereco_PassarNumeroValorNullOuVazio_RetornarExceprion(string cep, string logradouro, string numero, string bairro, string cidade, string estado)
        {
            Action action = () => new DadosEndereco(cep, logradouro, numero, bairro, cidade, estado);
            action.Should().Throw<ArgumentException>().WithMessage("Numero inválido: Campo obrigatório.");
        }

        [Theory(DisplayName = "Endereço com bairro com valor nulo ou vazio")]
        [InlineData("12402-010", "Rua Santa Mônica", "430", null, "Várzea Grande", "MT")]
        public void ContrutorEndereco_PassarBairroValorNuloOuVazio_RetornarExceprion(string cep, string logradouro, string numero, string bairro, string cidade, string estado)
        {
            Action action = () => new DadosEndereco(cep, logradouro, numero, bairro, cidade, estado);
            action.Should().Throw<ArgumentException>().WithMessage("Bairro inválido: Campo obrigatório.");
        }

        [Theory(DisplayName = "Endereço cidade com valor nulo ou vazio")]
        [InlineData("12402-010", "Rua Santa Mônica", "430", "Rua Vicência Cotinha de Carvalho Valadares", null, "MT")]
        public void ContrutorEndereco_PassarCidadeNulaOuVazia_RetornarExceprion(string cep, string logradouro, string numero, string bairro, string cidade, string estado)
        {
            Action action = () => new DadosEndereco(cep, logradouro, numero, bairro, cidade, estado);
            action.Should().Throw<ArgumentException>().WithMessage("Cidade inválido: Campo obrigatório.");
        }

        [Theory(DisplayName = "Endereço estado com valor nulo ou vazio")]
        [InlineData("12402-010", "Rua Santa Mônica", "430", "Rua Vicência Cotinha de Carvalho Valadares", "Pindamonhangaba", null)]
        public void ContrutorEndereco_PassarEstadoNullOuVazio_RetornarExceprion(string cep, string logradouro, string numero, string bairro, string cidade, string estado)
        {
            Action action = () => new DadosEndereco(cep, logradouro, numero, bairro, cidade, estado);
            action.Should().Throw<ArgumentException>().WithMessage("Estado inválido: Campo obrigatório.");
        }
    }
}
