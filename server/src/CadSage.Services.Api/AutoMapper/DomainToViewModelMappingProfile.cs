using AutoMapper;
using CadSage.Domain.Core.ViewModels;
using CadSage.Domain.Entidades;

namespace CadSage.Services.Api.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Pessoa, PessoaViewModel>();
        }
    }
}