namespace BoletoAPI.Domain.Entities
{
    public sealed class DadosEndereco : Base
    {
        #region Propriedades

        public string CEP { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;

        #endregion Propriedades

        #region Contrutores

        public DadosEndereco(string? cep, string? logradouro, string? numero, string? bairro, string? cidade, string? estado)
        {
            ValidacaoEntidade(cep, logradouro, numero, bairro, cidade, estado);
        }

        #endregion Contrutores

        #region Métodos

        private void ValidacaoEntidade(string? cep, string? logradouro, string? numero, string? bairro, string? cidade, string? estado)
        {
            if (string.IsNullOrWhiteSpace(cep))
                throw new ArgumentException($"{nameof(CEP)} inválido: Campo obrigatório.");

            if (string.IsNullOrWhiteSpace(logradouro))
                throw new ArgumentException($"{nameof(Logradouro)} inválido: Campo obrigatório.");

            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException($" {nameof(Numero)} inválido: Campo obrigatório.");

            if (string.IsNullOrWhiteSpace(bairro))
                throw new ArgumentException($"{nameof(Bairro)} inválido: Campo obrigatório.");

            if (string.IsNullOrWhiteSpace(cidade))
                throw new ArgumentException($"{nameof(Cidade)} inválido: Campo obrigatório.");

            if (string.IsNullOrWhiteSpace(estado))
                throw new ArgumentException($"{nameof(Estado)} inválido: Campo obrigatório.");

            CEP = cep;
            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }

        #endregion Métodos
    }
}