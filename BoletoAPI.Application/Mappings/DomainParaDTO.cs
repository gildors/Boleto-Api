using AutoMapper;
using BoletoAPI.Application.Dtos;
using BoletoAPI.Domain.Entities;

namespace BoletoAPI.Application.Mappings
{
    public class DomainParaDto : Profile
    {
        public DomainParaDto()
        {
            #region Dados do boleto

            CreateMap<DadosBoleto, DadosBoletoDto>();

            #endregion Dados do boleto

            #region Beneficiários

            CreateMap<DadosBeneficiario, BeneficiarioDto>();

            #endregion Beneficiários

            #region Conta Bancária

            CreateMap<DadosContaBancaria, DadosContaBancariaDto>();

            #endregion Conta Bancária

            #region Endereço

            CreateMap<DadosEndereco, EnderecoDto>();

            #endregion Endereço

            #region Sacado

            CreateMap<Sacado, SacadoDto>();

            #endregion Sacado

            #region Dados da Remessa

            CreateMap<DadosRemessa, DadosRemessaDto>();

            #endregion Dados da Remessa
        }
    }
}