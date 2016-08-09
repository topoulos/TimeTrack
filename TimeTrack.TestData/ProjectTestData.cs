using System;
using System.Collections.Generic;
using System.Linq;
using Bogus;
using Newtonsoft.Json.Linq;
using Omu.ValueInjecter;
using TimeTrack.Models.Database;

namespace TimeTrack.TestData
{
    public class ProjectTestData
    {
        public static IEnumerable<Project> Projects { get; set; } 
        public ProjectTestData(int numberOfProjects, int numberOfTasksPerProject)
        {
            Projects = Get(numberOfProjects, numberOfTasksPerProject);
        }
        public static IEnumerable<Project> Get(int numberOfprojects, int numberOfTasksPerProject)
        {
            Randomizer.Seed = new Random(3897234);

            int projectTaskIds = 1;
            Faker<ProjectTask> fakeProjectTasks = new Faker<ProjectTask>()
                .StrictMode(false)
                .RuleFor(o => o.Id, f => projectTaskIds++)
                .RuleFor(o => o.Name, f => f.Lorem.Sentence(5))
                .RuleFor(o => o.Description, f => f.Lorem.Sentence(8));


            var fakerProjectNames = new[] { "VacuumSellersProject", "EvilCorpProject", "SuperHeroProject", "WeylandYutaniProject", "MovieTheaterProject" };

            int projectIds = 1;
            Faker<Project> fakeProjects = new Faker<Project>()
                .StrictMode(false)
                .RuleFor(o => o.Id, f => projectIds++)
                .RuleFor(o => o.Name, f => f.PickRandom(fakerProjectNames))
                .RuleFor(o => o.Description, f => f.Company.CompanyName())
                .RuleFor(o => o.Tasks, f => fakeProjectTasks.Generate(numberOfTasksPerProject).ToList());

            IEnumerable<Project> generatedProjects = fakeProjects.Generate(numberOfprojects);

            List<Project> projects = generatedProjects.Select(o => new Project().InjectFrom(o)).Cast<Project>().ToList();

            foreach (Project p in projects)
            {
                foreach (ProjectTask t in p.Tasks)
                {
                    t.ProjectId = p.Id;
                    t.Project = new Project().InjectFrom(p) as Project;
                }
            }
            return projects;
             
        }

        public static IEnumerable<Project> GetProjectsForDb(int numberOfProjects)
        {
            Randomizer.Seed = new Random(3897234);

            int projectIds = 1;
            Faker<Project> fakeProjects = new Faker<Project>()
                .StrictMode(false)
                .RuleFor(o => o.Id, f => projectIds++)
                .RuleFor(o => o.Name, f => f.Company.CompanyName())
                .RuleFor(o => o.Description, f => f.Lorem.Sentence(5));

            return fakeProjects.Generate(numberOfProjects);

        }

        public static IEnumerable<ProjectTask> GetProjectTasksForDb(int numberOfTasks, List<int> IdRange)
        {
            Randomizer.Seed = new Random(3897234);

            int taskIds = 1;
            Faker<ProjectTask> fakeTasks = new Faker<ProjectTask>()
                .StrictMode(false)
                .RuleFor(o => o.Id, f => taskIds++)
                .RuleFor(o => o.Name, f => f.Hacker.Phrase())
                .RuleFor(o => o.ProjectId, f => f.PickRandom(IdRange))
                .RuleFor(o => o.Description, f => f.Lorem.Sentence(8));

            return fakeTasks.Generate(numberOfTasks);

        }
    }
}