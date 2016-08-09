using System;
using System.Collections.Generic;
using System.Linq;
using TimeTrack.Data;
using TimeTrack.Models.Database;
using TimeTrack.TestData;

namespace TimeTrack.Tests
{
    public class TimeTrackTestDbFixture : IDisposable
    {

        public TimeTrackTestDbFixture()
        {
            using (var context = new TestContext())
            {
                IEnumerable<Project> projects = ProjectTestData.GetProjectsForDb(50);
                context.Projects.AddRange(projects);
                context.SaveChanges();
                List<int> ids = context.Projects.Select(i => i.Id).ToList();
                IEnumerable<ProjectTask> tasks = ProjectTestData.GetProjectTasksForDb(500, ids);
                context.ProjectTasks.AddRange(tasks);
                context.SaveChanges();
            }
        }

        public void Dispose()
        {
            using (var context = new TestContext())
            {
                context.ProjectTasks.RemoveRange(context.ProjectTasks);
                context.Projects.RemoveRange(context.Projects);
            }
        }
    }
}