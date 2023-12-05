using AutoMapper;
using DotProject.Domain.Commands.Project;
using DotProject.Domain.Interfaces;
using DotProject.EventSourceNormalizers.Task;
using DotProject.Infra.Data.Repository.EventSourcing;
using DotProject.Interfaces;
using DotProject.ViewModels;
using DotTask.EventSourceNormalizers.Task;
using FluentValidation.Results;
using NetDevPack.Mediator;

namespace DotProject.Services
{
    public class TaskAppService : ITaskAppService
    {
        private readonly IMapper _mapper;
        private readonly ITaskRepository _taskRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public TaskAppService(
                IMapper mapper,
                ITaskRepository taskRepository,
                IEventStoreRepository eventStoreRepository,
                IMediatorHandler mediator) 
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
            _mediator = mediator;
            _eventStoreRepository = eventStoreRepository;
        }

        public async Task<IEnumerable<TaskViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<TaskViewModel>>(await _taskRepository.GetAll());
        }

        public async Task<TaskViewModel> GetById(Guid id)
        {
            return _mapper.Map<TaskViewModel>(await _taskRepository.GetById(id));
        }

        public async Task<IEnumerable<TaskViewModel>> GetByProjectId(Guid projectId)
        {
            return _mapper.Map<IEnumerable<TaskViewModel>>(await _taskRepository.GetByProjectId(projectId));
        }

        public async Task<ValidationResult> Register(TaskViewModel TaskViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewProjectCommand>(TaskViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var removeCommand = new RemoveProjectCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public async Task<ValidationResult> Update(TaskViewModel TaskViewModel)
        {
            var updateCommand = _mapper.Map<UpdateProjectCommand>(TaskViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<IList<TaskHistoryData>> GetAllHistory(Guid id)
        {
            return TaskHistory.ToJavaScriptCustomerHistory(await _eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
