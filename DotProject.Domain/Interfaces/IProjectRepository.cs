using DotProject.Domain.Models;
using NetDevPack.Data;

namespace DotProject.Domain.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<Project> GetById(Guid id);        
        Task<IEnumerable<Project>> GetAll();
        Task<IEnumerable<Project>> GetByUserId(Guid userId);
        Task<IEnumerable<TaskReport>> GetReport();
        void Add(Project project);
        void Update(Project project);
        void Remove(Project project);
    }
}
