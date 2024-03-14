using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BoletoAPI.Application.Dtos
{
    public class SacadoDto
    {
        #region Propriedades

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Nome")]
        public string? Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("CPF/CNPJ")]
        public string? CpfCnpj { get; set; } = string.Empty;

        #endregion Propriedades

        #region Propriedades de navegação

        public EnderecoDto Endereco { get; set; } = new EnderecoDto();

        #endregion Propriedades de navegação
    }
}