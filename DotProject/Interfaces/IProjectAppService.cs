using DotProject.EventSourceNormalizers.Project;
using DotProject.ViewModels;
using FluentValidation.Results;

namespace DotProject.Interfaces
{
    public interface IProjectAppService : IDisposable
    {
        Task<IEnumerable<ProjectViewModel>> GetAll();
        Task<ProjectViewModel> GetById(Guid id);
        Task<IEnumerable<ProjectViewModel>> GetByUserId(Guid userId);

        Task<ValidationResult> Register(ProjectViewModel projectViewModel);
        Task<ValidationResult> Update(ProjectViewModel projectViewModel);
        Task<ValidationResult> Remove(Guid id);

        Task<IList<ProjectHistoryData>> GetAllHistory(Guid id);
    }
}
