using System;
using System.Collections.Generic;
using System.Linq;
using TimeTrack.Data;
using TimeTrack.Models.Database;
using TimeTrack.TestData;
using TImeTrack.Repository;
using Xunit;

namespace TimeTrack.Tests
{
    public class ProjectRepositoryTest : IDisposable
    {
        public ProjectRepository repo;
        public TestContext context;

        public ProjectRepositoryTest()
        {
            context = new TestContext();
            repo = new ProjectRepository(context);

            using (context = new TestContext())
            {
                IEnumerable<Project> projects = ProjectTestData.GetProjectsForDb(10);
                context.Projects.AddRange(projects);
                context.SaveChanges();
                List<int> ids = context.Projects.Select(i => i.Id).ToList();
                IEnumerable<ProjectTask> tasks = ProjectTestData.GetProjectTasksForDb(100, ids);
                context.ProjectTasks.AddRange(tasks);
                context.SaveChanges();
            }
        }

        public void Dispose()
        {
            using (context = new TestContext())
            {
                context.ProjectTasks.RemoveRange(context.ProjectTasks);
                context.Projects.RemoveRange(context.Projects);
            }
        }
        [Fact]
        public void projectrepo_add()
        {
            using (context = new TestContext())
            {
                //Arrange
                var newProject = ProjectTestData.GetProjectsForDb(1).SingleOrDefault();

                //Act
                int beforeCount = context.Projects.Count();

                repo.Add(newProject);

                int afterCount = context.Projects.Count();

                //Assert
                Assert.Equal(beforeCount + 1, afterCount);
            }
        }
    }
}