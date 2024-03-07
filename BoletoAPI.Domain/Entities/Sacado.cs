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

        private void ValidacaoEntidade(string nome, string cpfCnpj)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException($"Campo {nameof(Nome)} é obrigatório");

            if (cpfCnpj != null)
                cpfCnpj.Replace(".", string.Empty).Replace("-", string.Empty);

            if (string.IsNullOrWhiteSpace(cpfCnpj) || (cpfCnpj.Length > 14))
                throw new ArgumentException($"{nameof(CpfCnpj)} inválido: Utilize 11 dígitos para CPF ou 14 para CNPJ.");

            Nome = nome;
            CpfCnpj = cpfCnpj;
        }

        #endregion Métodos
    }
}