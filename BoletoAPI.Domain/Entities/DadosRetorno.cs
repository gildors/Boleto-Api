using BoletoAPI.Domain.Enum;
using Microsoft.AspNetCore.Http;

namespace BoletoAPI.Domain.Entities
{
    public sealed class DadosRetorno : Base
    {
        #region Propriedades

        public string TipoBanco { get; set; } = string.Empty;
        public IFormFile? ArquivoRetorno { get; set; } = null;
        public TipoArquivo TipoArquivo { get; set; }

        #endregion Propriedades

        #region Construtores

        public DadosRetorno(string? tipoBanco, TipoArquivo? tipoArquivo, IFormFile? arquivoRetorno)
        {
            ValidacaoEntidade(tipoBanco, tipoArquivo, arquivoRetorno);
        }

        #endregion Construtores

        #region Métodos

        private void ValidacaoEntidade(string? tipoBanco, TipoArquivo? tipoArquivo, IFormFile? arquivoRetorno)
        {
            if (arquivoRetorno == null || arquivoRetorno.Length == 0)
                throw new ArgumentException($"{nameof(ArquivoRetorno)} inválido, o campo é obrigatório.");

            if (tipoArquivo == null || !System.Enum.IsDefined(typeof(TipoArquivo), tipoArquivo))
                throw new ArgumentException($"{nameof(TipoArquivo)} inválido, o campo é obrigatório.");

            if (string.IsNullOrEmpty(tipoBanco))
                throw new ArgumentException($"{nameof(TipoBanco)} inválido, o campo é obrigatório.");

            TipoBanco = tipoBanco;
            ArquivoRetorno = arquivoRetorno;
            TipoArquivo = tipoArquivo.Value;
        }

        #endregion Métodos
    }
}