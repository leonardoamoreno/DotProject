using AutoMapper;
using DotProject.Application.ViewModels;
using DotProject.ViewModels;

namespace DotProject.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile() 
        { 
            CreateMap<Domain.Models.Project, ProjectViewModel>();
            CreateMap<Domain.Models.Task, TaskViewModel>();
            CreateMap<Domain.Models.TaskReport, ReportViewModel>();
        }
    }
}
