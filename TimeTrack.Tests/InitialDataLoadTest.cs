using System.Collections.Generic;
using System.Linq;
using Moq;
using TimeTrack.Data;
using TimeTrack.Models.Database;
using TimeTrack.TestData;
using TImeTrack.Repository;
using Xunit;

namespace TimeTrack.Tests
{
    public class InitialDataLoadTest
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
        public void TestMoq()
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
    }
}