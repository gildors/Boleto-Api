using BoletoAPI.Domain.Entities;
using BoletoAPI.Domain.Enum;

namespace BoletoAPI.Domain.Interfaces
{
    public interface IBoletoRepository
    {
        string? RetornarRemessa(DadosRemessa dadosRemessa);
        string? RetornarHTML(DadosBoleto dadosBoleto);
    }
}