using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using Moq;
using TimeTrack.Data;
using TimeTrack.Models.Database;
using TimeTrack.TestData;
using TImeTrack.Repository;
using Xunit;

namespace TimeTrack.Tests
{
    public class ProjectRepositoryTest
    {
        [Fact]
        public void TestProjectTestDataLoad()
        {
            //Arrange
            IEnumerable<Project> sut = ProjectTestData.Get(20, 7);
            //Assert
            Assert.NotEmpty(sut.Select(t => t.Tasks).ToList());
        }

        [Fact]
        public void Projects_GetAll()
        {
            //Arrange
            IEnumerable<Project> sut = ProjectTestData.Get(20, 7);

            //Act
            var mockedContext = new Mock<TimeTrackContext>();
            mockedContext.Setup(c => c.Projects).ReturnsDbSet(sut);
            var repository = new ProjectRepository(mockedContext.Object);
            var result = repository.GetAll();

            //Assert
            Assert.Equal(sut.Count(), result.Count());
        }
        public static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();

            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));

            return dbSet.Object;
        }

        [Fact]
        public void Projects_Add()
        {
            //Arrange
            IEnumerable<Project> sut = ProjectTestData.Get(20, 7);

            Project newProject = ProjectTestData.Get(1, 5).SingleOrDefault();

            DbSet<Project> myDbSet = GetQueryableMockDbSet(sut.ToList());

            //Act
            int preCount = myDbSet.Count();
            myDbSet.Add(newProject);
            int postCount = myDbSet.Count();
       
           
            var mockedContext = new Mock<TimeTrackContext>();
            mockedContext.Setup(c => c.Projects).ReturnsDbSet(sut);
            var repository = new ProjectRepository(mockedContext.Object);

            var addedProject = repository.Add(newProject);

            //Assert
            Assert.Equal(21,ProjectTestData.Projects.Count());
            Assert.Equal(7, ProjectTestData.Projects.ToArray()[21].Tasks.Count);
            Assert.NotEqual(addedProject.Id,0);

        }

        [Fact]
        public void use_real_context()
        {
            TimeTrackContext context = new TimeTrackContext();

        }
    }
}