using DotProject.Domain.Interfaces;
using DotProject.Domain.Models;
using DotProject.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;

namespace DotProject.Infra.Data.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        protected readonly DotProjectContext Db;
        protected readonly DbSet<DotProject.Domain.Models.Project> DbSet;
        public ProjectRepository(DotProjectContext context)
        {
            Db = context;
            DbSet = Db.Set<Project>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<Project> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetByUserId(Guid userId)
        {
            return await DbSet.Where(x=> x.UserId == userId).ToListAsync();
        }

        public void Add(Project project)
        {
            DbSet.Add(project);
        }

        public void Update(Project project)
        {
            DbSet.Update(project);
        }

        public void Remove(Project project)
        {
            DbSet.Remove(project);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
