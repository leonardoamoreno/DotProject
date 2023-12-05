using DotProject.Domain.Commands.Project;
using DotProject.Domain.Commands.Task;
using DotProject.Domain.Core.Events;
using DotProject.Domain.Events.Project;
using DotProject.Domain.Events.Task;
using DotProject.Domain.Interfaces;
using DotProject.Infra.CrossCutting.Bus;
using DotProject.Infra.Data.Context;
using DotProject.Infra.Data.EventSourcing;
using DotProject.Infra.Data.Repository;
using DotProject.Infra.Data.Repository.EventSourcing;
using DotProject.Interfaces;
using DotProject.Services;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Mediator;

namespace DotProject.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services) 
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<IProjectAppService, ProjectAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<ProjectRegisteredEvent>, ProjectEventHandler>();
            services.AddScoped<INotificationHandler<ProjectUpdatedEvent>, ProjectEventHandler>();
            services.AddScoped<INotificationHandler<ProjectRemovedEvent>, ProjectEventHandler>();

            services.AddScoped<INotificationHandler<TaskRegisteredEvent>, TaskEventHandler>();
            services.AddScoped<INotificationHandler<TaskUpdatedEvent>, TaskEventHandler>();
            services.AddScoped<INotificationHandler<TaskRemovedEvent>, TaskEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewProjectCommand, ValidationResult>, ProjectCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProjectCommand, ValidationResult>, ProjectCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveProjectCommand, ValidationResult>, ProjectCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewTaskCommand, ValidationResult>, TaskCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateTaskCommand, ValidationResult>, TaskCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveTaskCommand, ValidationResult>, TaskCommandHandler>();

            // Infra - Data
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<DotProjectContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSqlContext>();
        }
    }
}
