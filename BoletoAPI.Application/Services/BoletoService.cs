using AutoMapper;
using BoletoAPI.Application.Dtos;
using BoletoAPI.Application.Interfaces;
using BoletoAPI.Domain.Entities;
using BoletoAPI.Domain.Interfaces;

namespace BoletoAPI.Application.Services
{
    public class BoletoService : IBoletoService
    {
        private readonly IBoletoRepository _iBoletoRepository;
        private readonly IMapper _mapper;

        public BoletoService(IBoletoRepository iBoletoRepository, IMapper mapper)
        {
            _iBoletoRepository = iBoletoRepository;
            _mapper = mapper;
        }

        public string? GerarHTMLBoleto(DadosBoletoDto dadosBoletoDto)
        {
            var mapearDadosBoleto = _mapper.Map<DadosBoleto>(dadosBoletoDto);
            return _iBoletoRepository.RetornarHTML(mapearDadosBoleto);
        }
        public string? GerarLinhaDigitavelBoleto(DadosBoletoDto dadosBoletoDto)
        {
            var mapearDadosBoleto = _mapper.Map<DadosBoleto>(dadosBoletoDto);
            return _iBoletoRepository.RetornarLinhaDigitavel(mapearDadosBoleto);
        }

        public string? GerarArquivoRemessa(DadosRemessaDto dadosRemessaDto)
        {
            var mapearRemessa = _mapper.Map<DadosRemessa>(dadosRemessaDto);
            return _iBoletoRepository.RetornarRemessa(mapearRemessa);
        }
        public string? ProcessarArquivoRetorno(DadosRetornoDto dadosRetornoDto)
        {
            var mapearRetorno = _mapper.Map<DadosRetorno>(dadosRetornoDto);
            return _iBoletoRepository.RetornarArquivoRetorno(mapearRetorno);
        }
    }
}