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
        [DisplayName("Agencia")]
        public string Agencia { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Conta bancária")]
        public string Conta { get; set; } = string.Empty;        
        
        [DisplayName("Dígito Verificador da Agencia")]
        public string DigitoAgencia { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Digito Verificador da Conta bancária")]
        public string DigitoConta { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Carteira padrão")]
        public string CarteiraPadrao { get; set; } = string.Empty;

        #endregion Propriedades
    }
}