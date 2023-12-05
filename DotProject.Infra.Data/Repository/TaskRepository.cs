using DotProject.Domain.Interfaces;
using DotProject.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotProject.Infra.Data.Repository
{
    public  class TaskRepository : ITaskRepository
    {
        protected readonly DotProjectContext Db;
        protected readonly DbSet<DotProject.Domain.Models.Task> DbSet;

        public TaskRepository(DotProjectContext context)
        {
            Db = context;
            DbSet = Db.Set<DotProject.Domain.Models.Task>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<DotProject.Domain.Models.Task> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<DotProject.Domain.Models.Task>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<DotProject.Domain.Models.Task>> GetByProjectId(Guid projectId)
        {
            return await DbSet.Where(x => x.ProjectId == projectId).ToListAsync();
        }

        public void Add(DotProject.Domain.Models.Task task)
        {
            DbSet.Add(task);
        }

        public void Update(DotProject.Domain.Models.Task task)
        {
            DbSet.Update(task);
        }

        public void Remove(DotProject.Domain.Models.Task task)
        {
            DbSet.Remove(task);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
