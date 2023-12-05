using NetDevPack.Data;

namespace DotProject.Domain.Interfaces
{
    public interface ITaskRepository : IRepository<DotProject.Domain.Models.Task>
    {
        Task<DotProject.Domain.Models.Task> GetById(Guid id);
        Task<IEnumerable<DotProject.Domain.Models.Task>> GetAll();
        Task<IEnumerable<DotProject.Domain.Models.Task>> GetByProjectId(Guid projectId);
        void Add(DotProject.Domain.Models.Task task);
        void Update(DotProject.Domain.Models.Task task);
        void Remove(DotProject.Domain.Models.Task task);
    }
}
