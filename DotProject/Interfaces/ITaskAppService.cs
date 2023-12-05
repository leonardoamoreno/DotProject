using DotProject.EventSourceNormalizers.Task;
using DotProject.ViewModels;
using FluentValidation.Results;

namespace DotProject.Interfaces
{
    public interface ITaskAppService : IDisposable
    {
        Task<IEnumerable<TaskViewModel>> GetAll();
        Task<IEnumerable<TaskViewModel>> GetByProjectId(Guid projectId);
        Task<TaskViewModel> GetById(Guid id);

        Task<ValidationResult> Register(TaskViewModel TaskViewModel);
        Task<ValidationResult> Update(TaskViewModel TaskViewModel);
        Task<ValidationResult> Remove(Guid id);

        Task<IList<TaskHistoryData>> GetAllHistory(Guid id);
    }
}
