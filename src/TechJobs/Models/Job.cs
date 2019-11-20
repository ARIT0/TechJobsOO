namespace TechJobs.Models
{
    public class Job
    {
        public int ID { get; set; }
        private static int nextId = 1;

        public string Name { get; set; }
        public Employer Employer { get; set; }
        public Location Location { get; set; }
        public CoreCompetency CoreCompetency { get; set; }
        public PositionType PositionType { get; set; }

        public Job()
        {
            ID = nextId;
            nextId++;
        }

        public Job (string name, Employer employer, Location location, CoreCompetency coreCompetency, PositionType positionType)
        {
            Name = name;
            Employer = employer;
            Location = location;
            CoreCompetency = coreCompetency;
            PositionType = positionType;
            ID = nextId;
            nextId++;
        }

    }
}
