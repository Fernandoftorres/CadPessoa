using AutoMapper;
using CadSage.Domain.Commands.Pessoa;
using CadSage.Domain.Core.ViewModels;

namespace CadSage.Services.Api.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {

            CreateMap<PessoaViewModel, RegistrarPessoaCommand>()
                .ConstructUsing(c => new RegistrarPessoaCommand(c));

            CreateMap<PessoaViewModel, AtualizarPessoaCommand>()
                .ConstructUsing(c => new AtualizarPessoaCommand(c));

            CreateMap<PessoaViewModel, ExcluirPessoaCommand>()
                .ConstructUsing(c => new ExcluirPessoaCommand(c.Id.Value));

        }
    }
}