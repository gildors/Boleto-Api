using BoletoAPI.Domain.Entities;
using BoletoAPI.Domain.Enum;

namespace BoletoAPI.Domain.Interfaces
{
    public interface IBoletoRepository
    {
        string? RetornarLinhaDigitavel(DadosBoleto dadosBoleto);
        string? RetornarHTML(DadosBoleto dadosBoleto);
        string? RetornarRemessa(DadosRemessa dadosRemessa);
        string? RetornarArquivoRetorno(DadosRetorno dadosRetorno);
    }
}