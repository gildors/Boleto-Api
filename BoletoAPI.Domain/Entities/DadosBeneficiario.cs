namespace BoletoAPI.Domain.Entities
{
    public sealed class DadosBeneficiario : Base
    {
        #region Propriedades

        public string Codigo { get; private set; } = string.Empty;
        public string CodigoDV { get; private set; } = string.Empty;
        public string CodigoFormatado { get; private set; } = string.Empty;
        public string CodigoTransmissao { get; set; } = string.Empty;
        public string CpfCnpj { get; private set; } = string.Empty;
        public string Nome { get; private set; } = string.Empty;
        public string Observacoes { get; private set; } = string.Empty;
        public bool MostrarCnpj { get; private set; } = false;

        // Propriedade de navegação
        public DadosContaBancaria? ContaBancaria { get; private set; }

        #endregion Propriedades

        #region Contrutores

        public DadosBeneficiario(string? codigo, string? codigoDV, string? codigoFormatado, string? codigoTransmissao, string? cpfCnpj, string? nome, string? observacoes)
        {
            ValidacaoEntidade(codigo, codigoDV, codigoFormatado, codigoTransmissao, cpfCnpj, nome, observacoes);
        }

        #endregion Contrutores

        #region Metodos

        private void ValidacaoEntidade(string? codigo, string? codigoDV, string? codigoFormatado, string? codigoTransmissao, string? cpfCnpj, string? nome, string? observacoes)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException($"{nameof(Nome)} do beneficiario inválido: Campo obrigatório.");

            if (string.IsNullOrEmpty(cpfCnpj))
                throw new ArgumentException($"{nameof(CpfCnpj)} do beneficiario inválido: Campo obrigatório.");
            else
                cpfCnpj = cpfCnpj.Replace(".", string.Empty).Replace("-", string.Empty);

            if (string.IsNullOrEmpty(codigo))
                throw new ArgumentException($"{nameof(Codigo)} do beneficiario inválido: Campo obrigatório.");

            Codigo = codigo;
            CodigoDV = codigoDV ?? "";
            CodigoFormatado = codigoFormatado ?? "";
            CodigoTransmissao = codigoTransmissao ?? "";
            CpfCnpj = cpfCnpj;
            Nome = nome;
            Observacoes = observacoes ?? "";
        }

        #endregion Metodos
    }
}