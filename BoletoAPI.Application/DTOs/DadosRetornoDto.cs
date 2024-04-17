using BoletoAPI.Domain.Enum;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BoletoAPI.Application.Dtos
{
    public class DadosRetornoDto
    {

        #region Propriedades

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [DisplayName("Banco")]
        public string? TipoBanco { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [DisplayName("Tipo Arquivo")]
        public TipoArquivo? TipoArquivo { get; set; } = null;

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [DisplayName("Arquivo Retorno")]
        public IFormFile? ArquivoRetorno { get; set; } = null;

        #endregion
    }
}
