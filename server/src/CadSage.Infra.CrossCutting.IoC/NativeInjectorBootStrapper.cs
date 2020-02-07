using AutoMapper;
using CadSage.Domain.Core.Notifications;
using CadSage.Domain.Handlers;
using CadSage.Domain.Interfaces;
using CadSage.Infra.Data.Context;
using CadSage.Infra.Data.Repository;
using CadSage.Infra.Data.UoW;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using CadSage.Domain.Interfaces.Repository;
using CadSage.Domain.Commands.Pessoa;
using Seven.Domain.Handlers;
using Microsoft.AspNetCore.Http;

namespace CadSage.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Domain - Commands
            services.AddScoped<INotificationHandler<RegistrarPessoaCommand>, PessoaCommandHandler>();
            services.AddScoped<INotificationHandler<AtualizarPessoaCommand>, PessoaCommandHandler>();
            services.AddScoped<INotificationHandler<ExcluirPessoaCommand>, PessoaCommandHandler>();
            // Domain - Eventos
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Infra - Data
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<CadSageContext>();
            
        }
    }
}