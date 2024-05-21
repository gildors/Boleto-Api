using BoletoNetCore;
using BoletoNetCore.Enums;

namespace BoletoAPI.Domain.Entities
{
    public sealed class DadosBoleto : Base
    {
        #region Propriedades

        public string NossoNumero { get; private set; } = string.Empty;
        public string MensagemInstrucoesCaixa { get; private set; } = string.Empty;
        public DateTime Vencimento { get; private set; } = DateTime.MinValue;
        public string NumeroDocumento { get; private set; } = string.Empty;
        public string? CampoLivre { get; private set; }
        public decimal Valor { get; private set; } = decimal.Zero;
        public decimal PercentualMulta { get; private set; } = decimal.Zero;
        public TipoCodigoMulta? TipoCodigoMulta { get; set; } = BoletoNetCore.Enums.TipoCodigoMulta.Percentual;
        public DateTime? DataMulta { get; set; } 
        public decimal PercentualJurosDia { get; private set; } = decimal.Zero;
        public DateTime? DataJuros { get; set; } 
        public TipoJuros? TipoJuros { get; set; } = BoletoNetCore.TipoJuros.Simples;
        
        public DateTime DataEmissao { get; private set; } = DateTime.MinValue;
        public DateTime DataProcessamento { get; private set; } = DateTime.MinValue;
        public string TipoBanco { get; set; } = string.Empty;
        public int CodigoProtesto { get; set; } = 0;
        public int DiasProtesto { get; set; } = 0;
        

        // Propriedades de navegação publica
        public Sacado? Sacado { get; private set; }

        public DadosBeneficiario? Beneficiario { get; private set; }

        #endregion Propriedades

        #region Construtores

        public DadosBoleto(
            string? nossoNumero, 
            DateTime? vencimento, 
            string? numeroDocumento, 
            decimal? valor, 
            decimal? percentualMulta, 
            decimal? percentualJurosDia, 
            DateTime? dataEmissao,
            DateTime? dataProcessamento, 
            string? tipoBanco,
            int? codigoProtesto,
            int? diasProtesto,
            DateTime? dataMulta,
            DateTime? dataJuros,
            TipoJuros? tipoJuros,
            TipoCodigoMulta? tipoCodigoMulta)
        {
            ValidacaoEntidade(
                nossoNumero, 
                vencimento, 
                numeroDocumento, 
                valor, 
                percentualMulta, 
                percentualJurosDia, 
                dataEmissao, 
                dataProcessamento, 
                tipoBanco,
                codigoProtesto,
                diasProtesto,
                dataJuros,
                dataMulta,
                tipoCodigoMulta,
                tipoJuros);
        }

        #endregion Construtores

        #region Métodos

        private void ValidacaoEntidade(
            string? nossoNumero, 
            DateTime? vencimento, 
            string? numeroDocumento, 
            decimal? valor, 
            decimal? percentualMulta, 
            decimal? percentualJurosDia, 
            DateTime? dataEmissao, 
            DateTime? dataProcessamento, 
            string? tipoBanco,
            int? codigoProtesto,
            int? diasProtesto,
            DateTime? dataMulta,
            DateTime? dataJuros,
            TipoCodigoMulta? tipoCodigoMulta,
            TipoJuros? tipoJuros
           )
        {
            if (string.IsNullOrEmpty(nossoNumero))
                throw new ArgumentException($"{nameof(NossoNumero)} inválido: Campo obrigatório.");

            if (string.IsNullOrEmpty(numeroDocumento))
                throw new ArgumentException($"{nameof(NumeroDocumento)} inválido: Campo obrigatório.");

            if (vencimento == null || vencimento == DateTime.MinValue)
                throw new ArgumentException($"{nameof(Vencimento)} inválido: Campo obrigatório.");

            if (valor == null || valor <= 0)
                throw new ArgumentException($"{nameof(Valor)} inválido: Campo obrigatório.");

            if (dataEmissao == null || dataEmissao == DateTime.MinValue)
                throw new ArgumentException($"{nameof(DataEmissao)} inválido: Campo obrigatório.");

            if (dataProcessamento == DateTime.MinValue)
                throw new ArgumentException($"{nameof(DataProcessamento)} inválido: Campo obrigatório.");

            if (string.IsNullOrWhiteSpace(tipoBanco))
                throw new ArgumentException($"{nameof(TipoBanco)} inválido: Campo obrigatório.");

            NossoNumero = nossoNumero;
            TipoBanco = tipoBanco;
            Vencimento = vencimento.Value;
            NumeroDocumento = numeroDocumento;
            Valor = valor.Value;
            DataEmissao = dataEmissao.Value;
            PercentualMulta = percentualMulta ?? 0;
            TipoJuros = tipoJuros ?? BoletoNetCore.TipoJuros.Simples;
            TipoCodigoMulta = tipoCodigoMulta ?? BoletoNetCore.Enums.TipoCodigoMulta.Percentual;
            DataJuros = dataJuros;
            DataMulta = dataMulta;
            PercentualJurosDia = percentualJurosDia ?? 0;
            CodigoProtesto = codigoProtesto ?? 0;
            DiasProtesto = diasProtesto ?? 0 ;
        }

        #endregion Métodos
    }
}