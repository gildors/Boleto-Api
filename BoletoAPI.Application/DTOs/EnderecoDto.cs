﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BoletoAPI.Application.Dtos
{
    public class EnderecoDto
    {
        #region Propriedades



        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("CEP")]
        public string? CEP { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string? Logradouro { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string? Numero { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string? Bairro { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string? Cidade { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string? Estado { get; set; } = string.Empty;

        #endregion Propriedades
    }
}