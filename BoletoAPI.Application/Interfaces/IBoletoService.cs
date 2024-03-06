using BoletoAPI.Application.Dtos;

namespace BoletoAPI.Application.Interfaces
{
    public interface IBoletoService
    {
        string? GerarHTMLBoleto(DadosBoletoDto dadosBoletoDto);
        string? GerarLinhaDigitavelBoleto(DadosBoletoDto dadosBoletoDto);
        string? GerarArquivoRemessa(DadosRemessaDto dadosRemessaDto);
    }
}