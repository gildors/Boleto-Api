using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoletoAPI.Application.Dtos
{
    public class DadosBoletoDto
    {
        #region Propriedades

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [DisplayName("Nosso Número")]
        public string NossoNumero { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [DisplayName("Data de vencimento")]
        public DateTime Vencimento { get; set; } = DateTime.MinValue;

        [DisplayName("Campo Livre")]
        public string? CampoLivre { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Valor")]
        public decimal Valor { get; set; } = decimal.Zero;

        [DisplayName("Percentual Juros por Dia")]
        public decimal PercentualJurosDia { get; set; } = decimal.Zero;

        [DisplayName("Percentual de Multa")]
        public decimal PercentualMulta { get; set; } = decimal.Zero;

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [DisplayName("Data Emissão")]
        public DateTime DataEmissao { get; set; } = DateTime.MinValue;

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [DisplayName("Data Processamento")]
        public DateTime DataProcessamento { get; set; } = DateTime.MinValue;

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [DisplayName("Banco")]
        public string TipoBanco { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [DisplayName("Número Documento")]
        public string NumeroDocumento { get; set; } = string.Empty;

        #endregion Propriedades

        #region Propriedades de navegação

        public SacadoDto Sacado { get; set; } = new SacadoDto();
        public BeneficiarioDto Beneficiario { get; set; } = new BeneficiarioDto();

        #endregion Propriedades de navegação
    }
}