using BoletoAPI.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace BoletoAPI.Application.Dtos
{
    public class DadosRemessaDto
    {

        #region Propriedades

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [DisplayName("Banco")]
        public string? TipoBanco { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [DisplayName("Tipo Arquivo")]
        public TipoArquivo? TipoArquivo { get; set; } = null;

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [DisplayName("Numero Arquivo Remessa")]
        public int? NumeroArquivoRemessa { get; set; } = null;

        [DisplayName("Numero Arquivo Remessa No Dia")]
        public int? NumeroArquivoRemessaNoDia { get; set; } = null;

        #endregion

        #region Propriedades de navegação

        [DisplayName("Dados dos Boletos")]
        public List<DadosBoletoDto> DadosBoletos { get; set; } = [];

        #endregion
    }
}
