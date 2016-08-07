using System.Collections.Generic;
using System.Linq;
using TimeTrack.Models.Database;
using TimeTrack.TestData;
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
    }
}