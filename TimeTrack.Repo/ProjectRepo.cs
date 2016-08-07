using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TimeTrack.Common.ServiceInterfaces;
using TimeTrack.Data;
using TimeTrack.Models.Database;

namespace TimeTrack.Repo
{
    public class ProjectRepo : IDataRepo<Project>
    {
        private readonly DbContext context;
        public ProjectRepo(DbContext context)
        {
            this.context = context;
        }

        public Project Add(Project t)
        {
            context.Set<Project>().Add(t);
            context.SaveChanges();
            return t;
        }

        public Task<Project> AddAsync(Project t)
        {
            throw new NotImplementedException();
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync()
        {
            throw new NotImplementedException();
        }

        public void Delete(Project t)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Project t)
        {
            throw new NotImplementedException();
        }

        public Project Find(Expression<Func<Project, bool>> match)
        {
            throw new NotImplementedException();
        }

        public ICollection<Project> FindAll(Expression<Func<Project, bool>> match)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Project>> FindAllAsync(Expression<Func<Project, bool>> match)
        {
            throw new NotImplementedException();
        }

        public Task<Project> FindAsync(Expression<Func<Project, bool>> match)
        {
            throw new NotImplementedException();
        }

        public Project Get(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Project> GetAll()
        {
            return context.Set<Project>().ToList();
        }

        public async Task<ICollection<Project>> GetAllAsync()
        {
            return await context.Set<Project>().ToListAsync();
        }

        public Task<Project> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Project Update(Project updated, int key)
        {
            throw new NotImplementedException();
        }

        public Task<Project> UpdateAsync(Project updated, int key)
        {
            throw new NotImplementedException();
        }
    }
}
