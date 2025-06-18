namespace Sun
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points)
        { }

        public override int RecordEvent()
        {
            // Never “completes,” just gives points each time
            return _points;
        }

        public override bool IsComplete() => false;

        public override string GetStringRepresentation()
        {
            // Format: EternalGoal:Name,Description,Points
            return $"EternalGoal:{_name},{_description},{_points}";
        }
    }
}
