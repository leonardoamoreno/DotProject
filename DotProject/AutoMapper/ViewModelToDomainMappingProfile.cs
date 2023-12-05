using AutoMapper;
using DotProject.Domain.Commands.Project;
using DotProject.Domain.Commands.Task;
using DotProject.ViewModels;

namespace DotProject.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProjectViewModel, RegisterNewProjectCommand>()
                .ConstructUsing(c => new RegisterNewProjectCommand(c.Name, c.UserId));
            CreateMap<ProjectViewModel, UpdateProjectCommand>()
                .ConstructUsing(c => new UpdateProjectCommand(c.Id, c.Name));

            CreateMap<TaskViewModel, RegisterNewTaskCommand>()
                .ConstructUsing(c => new RegisterNewTaskCommand(c.Title, c.Description, c.ExpirationDate, c.Status, c.ProjectId));
            CreateMap<TaskViewModel, UpdateTaskCommand>()
                .ConstructUsing(c => new UpdateTaskCommand(c.Title, c.Description, c.ExpirationDate, c.Status, c.ProjectId));
        }
    }
}
