using static StatisticsApp.EmployeeBase;

namespace StatisticsApp
{
    public interface IEmployee
    {
        string Name { get; }
        string Surname { get; }
        string WeekNumber { get; }
        void AddProgram(float program);
        void AddProgram(int program);
        void AddProgram(double program);
        void AddProgram(string program);
        Statistics GetStatistics();        
        void ShowStatistics();
        event StatisticsAddedDelegated StatisticsAdded;
    }
}