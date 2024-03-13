using AutoMapper;
using BoletoAPI.Application.Dtos;
using BoletoAPI.Domain.Entities;

namespace BoletoAPI.Application.Mappings
{
    public class DtoParaDomain : Profile
    {
        public DtoParaDomain()
        {
            #region Dados do boleto

            CreateMap<DadosBoletoDto, DadosBoleto>();

            #endregion Dados do boleto

            #region Beneficiários

            CreateMap<BeneficiarioDto, DadosBeneficiario>();

            #endregion Beneficiários

            #region Conta Bancária

            CreateMap<DadosContaBancariaDto, DadosContaBancaria>();

            #endregion Conta Bancária

            #region Endereço

            CreateMap<EnderecoDto, DadosEndereco>();

            #endregion Endereço

            #region Sacado

            CreateMap<SacadoDto, Sacado>();

            #endregion Sacado

            #region Dados da Remessa

            CreateMap<DadosRemessaDto, DadosRemessa>();

            #endregion Dados da Remessa
        }
    }
}