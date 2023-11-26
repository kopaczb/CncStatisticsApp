using StatisticsApp;

namespace StatisticsApp.Tests
{
    public class EmployeeTests
    {
        [Test]
        public void WhenProgramsAreAdded_ShouldRetursMaxProgram()
        {
            // arrange
            var employee = new EmployeeInMemory("Jan", "Kowalski", "45");
            employee.AddProgram(3000d);
            employee.AddProgram(3001f);
            employee.AddProgram("3002");
            employee.AddProgram(3003);

            // act
            var statistics = employee.GetStatistics();

            // assert
            Assert.AreEqual(3003, statistics.maxProgram);
        }

        [Test]
        public void WhenProgramsAreAdded_ShouldRetursMinProgram()
        {
            // arrange
            var employee = new EmployeeInMemory("Jan", "Kowalski", "45");
            employee.AddProgram(3000);
            employee.AddProgram(3001);
            employee.AddProgram(3002);
            employee.AddProgram(3003);

            // act
            var statistics = employee.GetStatistics();

            // assert
            Assert.AreEqual(3000, statistics.minProgram);
        }

        [Test]
        public void WhenProgramsAreAdded_ShouldRetursAveragePrograms()
        {
            // arrange
            var employee = new EmployeeInMemory("Jan", "Kowalski", "45");
            employee.AddProgram(3000);
            employee.AddProgram(3001);
            employee.AddProgram(3002);
            employee.AddProgram(3003);
            employee.AddProgram(3004);

            // act
            var statistics = employee.GetStatistics();

            // assert
            Assert.AreEqual(1, statistics.averagePrograms);
        }

        [Test]
        public void WhenProgramsAreAdded_ShouldRetursCountPrograms()
        {
            // arrange
            var employee = new EmployeeInMemory("Jan", "Kowalski", "45");
            employee.AddProgram(3000);
            employee.AddProgram(3001);
            employee.AddProgram(3002);
            employee.AddProgram(3003);
            employee.AddProgram(3004);

            // act
            var statistics = employee.GetStatistics();

            // assert
            Assert.AreEqual(5, statistics.countPrograms);
        }
    }
}