using AutoMapper;
using DotProject.Application.ViewModels;
using DotProject.Domain.Commands.Project;
using DotProject.Domain.Interfaces;
using DotProject.EventSourceNormalizers.Project;
using DotProject.Infra.Data.Repository.EventSourcing;
using DotProject.Interfaces;
using DotProject.ViewModels;
using FluentValidation.Results;
using NetDevPack.Mediator;

namespace DotProject.Services
{
    public class ProjectAppService : IProjectAppService
    {
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public ProjectAppService(
                IMapper mapper,
                IProjectRepository projectRepository,
                IEventStoreRepository eventStoreRepository,
                IMediatorHandler mediator) 
        {
            _mapper = mapper;
            _projectRepository = projectRepository;
            _mediator = mediator;
            _eventStoreRepository = eventStoreRepository;
        }

        public async Task<IEnumerable<ProjectViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProjectViewModel>>(await _projectRepository.GetAll());
        }

        public async Task<ProjectViewModel> GetById(Guid id)
        {
            return _mapper.Map<ProjectViewModel>(await _projectRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(ProjectViewModel projectViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewProjectCommand>(projectViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var removeCommand = new RemoveProjectCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public async Task<ValidationResult> Update(ProjectViewModel projectViewModel)
        {
            var updateCommand = _mapper.Map<UpdateProjectCommand>(projectViewModel);
            return await _mediator.SendCommand(updateCommand);
        }
        public async Task<IEnumerable<ProjectViewModel>> GetByUserId(Guid userId)
        {
            return _mapper.Map<IEnumerable<ProjectViewModel>>(await _projectRepository.GetByUserId(userId));
        }

        public async Task<IList<ProjectHistoryData>> GetAllHistory(Guid id)
        {
            return ProjectHistory.ToJavaScriptCustomerHistory(await _eventStoreRepository.All(id));
        }

        public async Task<IEnumerable<ReportViewModel>> GetReport()
        {
            return _mapper.Map<IEnumerable<ReportViewModel>>(await _projectRepository.GetReport());
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
