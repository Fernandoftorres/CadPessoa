Tecnologias Utilizadas
 - Net Core 2.0
 - Angular 8
 - Entity Framework Core
 - Mediator

1. Pré-requisitos
 
 1.1 - Ter uma base SQL Server
 
 1.2 - Net Core 2.1
 
 1.3 - Node

2. Instalação
 
 2.1 - Alterar a conexão do banco SQL server nos arquivos abaixo:
    - \server\src\CadSage.Infra.Data\appsettings.json
    - \server\src\CadSage.Services.Api\appsettings.json
 
 2.2 - Acessar a pasta \server\src\CadSage.Infra.Data e executar o comando: dotnet ef database update
      (o banco de dados será criado com a tabela)
 
 2.3 - No visual Studio, abrir a solution \server\CadSage.Project.sln. Selecionar o projeto CadSage.Api como "Startup Project" e rodar.

 2.4 - Acessar a pasta client, e digitar o comando: npm i (baixar as depdências do Angular)

 2.5 - Ao final executar o comando ng s

 2.6 - Para acessar a aplicação basta digitar: http://localhost:4200/pessoas

 2.7 - Alguns prints na pasta prints
