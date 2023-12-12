
# Teste Técnico

Teste técnico de criação de uma API de gerenciamento de Projetos e suas Tarefas.

## Tecnologias implementadas:

- ASP.NET 8.0 
- Entity Framework Core 8.0
- .NET Core Native DI
- AutoMapper
- FluentValidator
- MediatR
- Swagger UI 
- .NET DevPack
- SQL Server 2022


## Arquitetura:

- Arquitetura completa com preocupações de separação de responsabilidades, SOLID e Clean Code
- Domain Driven Design (Layers and Domain Model Pattern)
- Domain Events
- Domain Notification
- Domain Validations
- CQRS (Imediate Consistency)
- Event Sourcing
- Unit of Work
- Repository
## Rodando localmente

Gerando certificado e validando

```bash
  dotnet dev-certs https -ep "$env:USERPROFILE\.aspnet\https\aspnetapp.pfx"  -p $CREDENTIAL_PLACEHOLDER$
```
```bash
  dotnet dev-certs https --trust   
```

Docker build e up

```bash
  docker-compose build   
```
```bash
  docker-compose up
```


## Melhorias

Avaliando a capacidade e escalabilidade do projeto, poderíamos criar 2 microserviços para tornar os 2 contextos (Projeto e Tarefa), independentes