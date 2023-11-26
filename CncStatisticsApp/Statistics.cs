namespace StatisticsApp
{
    public class Statistics
    {
        public float workingDays { get; private set; }
        public float minProgram { get; private set; }
        public float maxProgram { get; private set; }
        public float countPrograms { get; private set; }
        public float sumPrograms { get; private set; }
        public float averagePrograms
        {
            get
            {
                return this.countPrograms / workingDays;
            }
        }
        public Statistics()
        {
            this.workingDays = 5;
            this.countPrograms = 0;
            this.minProgram = float.MaxValue;
            this.maxProgram = float.MinValue;
        }
        public void AddProgram(float program)
        {
            this.countPrograms++;
            this.minProgram = Math.Min(program, this.minProgram);
            this.maxProgram = Math.Max(program, this.maxProgram);
        }
    }
}
