using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BoletoAPI.Application.Dtos
{
    public class BeneficiarioDto
    {
        #region Propriedades

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Código")]
        public string Codigo { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Código DV")]
        public string CodigoDV { get; set; } = string.Empty;

        public string CodigoFormatado { get; set; } = string.Empty;
        public string CodigoTransmissao { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("CPF/CNPJ")]
        public string CpfCnpj { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Nome")]
        public string Nome { get; set; } = string.Empty;

        [DisplayName("Observações")]
        public string Observacoes { get; set; } = string.Empty;

        #endregion

        #region Propriedades de navegação

        public ContaBancariaDto ContaBancaria { get; set; } = new ContaBancariaDto();

        #endregion
    }
}