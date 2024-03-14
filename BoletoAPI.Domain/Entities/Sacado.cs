namespace BoletoAPI.Domain.Entities
{
    public sealed class Sacado : Base
    {
        #region Propriedades

        public string Nome { get; private set; } = string.Empty;
        public string CpfCnpj { get; private set; } = string.Empty;

        // Propriedades de navegação
        public DadosEndereco? Endereco { get; private set; }

        #endregion Propriedades

        #region Construtores

        public Sacado(string nome, string cpfCnpj)
        {
            ValidacaoEntidade(nome, cpfCnpj);
        }

        #endregion Construtores

        #region Métodos

        private void ValidacaoEntidade(string? nome, string? cpfCnpj)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException($"{nameof(Nome)} do pagador inválido: Campo obrigatório.");

            if (string.IsNullOrEmpty(cpfCnpj))
                throw new ArgumentException($"{nameof(CpfCnpj)} do pagador inválido: Campo obrigatório.");
            else
                cpfCnpj = cpfCnpj.Replace(".", string.Empty).Replace("-", string.Empty);

            Nome = nome;
            CpfCnpj = cpfCnpj;
        }

        #endregion Métodos
    }
}