using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using TimeTrack.Common.ServiceInterfaces;
using TimeTrack.Models.Database;

namespace TimeTrack.Services
{
    public class ProjectService
    {
        private readonly DbContext context;
        private readonly IDataRepo<Project> projectRepo; 
        public ProjectService(DbContext context, IDataRepo<Project> projectRepo)
        {
            this.context = context;
            this.projectRepo = projectRepo;
        }

        public IEnumerable<Project> GetAll()
        {
            try
            {
                return projectRepo.GetAll();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            try
            {
                return await projectRepo.GetAllAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        } 
    }
}