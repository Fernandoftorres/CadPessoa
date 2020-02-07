using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CadSage.Services.Api.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "CadSage API",
                    Description = "API do site CadSage",
                    TermsOfService = "Nenhum",
                    Contact = new Contact { Name = "Desenvolvedor X", Email = "email@CadSage", Url = "http://CadSage" },
                    License = new License { Name = "MIT", Url = "http://CadSage/licensa" }
                });

                //s.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
            });

            services.ConfigureSwaggerGen(opt =>
            {
                //opt.OperationFilter<AuthorizationHeaderParameterOperationFilter>();
            });
        }
    }
}