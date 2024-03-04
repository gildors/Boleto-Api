using BoletoAPI.Domain.Enum;

namespace BoletoAPI.Domain.Entities
{
    public sealed class DadosRemessa : Base
    {
        #region Propriedades

        public string TipoBanco { get; set; } = string.Empty;
        public int? NumeroArquivoRemessaNoDia { get; set; } = null;
        public int NumeroArquivoRemessa { get; set; } = 0;
        public TipoArquivo TipoArquivo { get; set; }

        // Propriedades de navegação publica
        public List<DadosBoleto> DadosBoletos { get; set; } = new List<DadosBoleto>();

        #endregion Propriedades

        #region Construtores

        public DadosRemessa(List<DadosBoleto> dadosBoletos, string tipoBanco, TipoArquivo tipoArquivo, int numeroArquivoRemessa, int? numeroArquivoRemessaNoDia)
        {
            ValidacaoEntidade(dadosBoletos, tipoBanco, tipoArquivo, numeroArquivoRemessa, numeroArquivoRemessaNoDia);
        }

        #endregion Construtores

        #region Métodos

        private void ValidacaoEntidade(List<DadosBoleto> dadosBoletos, string tipoBanco, TipoArquivo tipoArquivo, int numeroArquivoRemessa, int? numeroArquivoRemessaNoDia)
        {

            if (numeroArquivoRemessa == 0)
                throw new ArgumentException($"{nameof(NumeroArquivoRemessa)} inválido, o campo é obrigatório.");

            if (dadosBoletos == null || dadosBoletos.Count == 0)
                throw new ArgumentException($"{nameof(DadosBoletos)} inválido, o campo é obrigatório.");

            if (!System.Enum.IsDefined(typeof(TipoArquivo), tipoArquivo))
                throw new ArgumentException($"{nameof(TipoArquivo)} inválido, o campo é obrigatório.");

            if (string.IsNullOrEmpty(tipoBanco))
                throw new ArgumentException($"{nameof(TipoBanco)} inválido, o campo é obrigatório.");

            TipoBanco = tipoBanco;
            DadosBoletos = dadosBoletos;
            TipoArquivo = tipoArquivo;
            NumeroArquivoRemessa = numeroArquivoRemessa;
            NumeroArquivoRemessaNoDia = numeroArquivoRemessaNoDia;
        }

        #endregion Métodos
    }
}