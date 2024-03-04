using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BoletoAPI.Application.Dtos
{
    public class ContaBancariaDto
    {
        #region Propriedades

        [Key]
        [DisplayName("Conta bancária Id")]
        public int ContaBancariaDtoId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Agencia { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Conta { get; set; } = string.Empty;        
        
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string DigitoAgencia { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string DigitoConta { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string CarteiraPadrao { get; set; } = string.Empty;

        #endregion Propriedades
    }
}