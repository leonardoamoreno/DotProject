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
            return await DbSet.Include(x=> x.Tasks).FirstOrDefaultAsync(i => i.Id == id);
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

        public async Task<IEnumerable<TaskReport>> GetReport()
        {
            string sql = @"select tabelaFinal.Name as UserName,
                ROUND(((CAST(Done as DECIMAL)*100)/(CAST(Total AS DECIMAL))),1) as PercentageComplete,
                Done,
                NotCompleted,
                Total
                FROM(
                SELECT
	                u.Name, 	
	                SUM(CASE WHEN Status = 1 THEN 1 ELSE 0 END) as Done,
	                SUM(CASE WHEN Status = 0 THEN 1 ELSE 0 END) as NotCompleted,
	                count(*) as Total
	                from Tasks t 
	                inner join Projects p on t.ProjectId = p.Id
	                inner join Users u on p.UserId = u.Id
	                --where t.Status = 1
	                group by u.Name
                ) tabelaFinal";
            return await Db.Database.SqlQueryRaw<TaskReport>(sql).ToListAsync();
                //DbSet.FromSqlRaw <IEnumerable<TaskReport>>(sql);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
