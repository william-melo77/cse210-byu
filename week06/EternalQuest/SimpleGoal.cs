namespace Sun
{
    public class SimpleGoal : Goal
    {
        private bool _isComplete;

        // New goal starts incomplete
        public SimpleGoal(string name, string description, int points)
            : base(name, description, points)
        {
            _isComplete = false;
        }

        // Overload for loading from file
        public SimpleGoal(string name, string description, int points, bool isComplete)
            : this(name, description, points)
        {
            _isComplete = isComplete;
        }

        public override int RecordEvent()
        {
            if (!_isComplete)
            {
                _isComplete = true;
                return _points;
            }
            return 0;
        }

        public override bool IsComplete() => _isComplete;

        public override string GetStringRepresentation()
        {
            // Format: SimpleGoal:Name,Description,Points,IsComplete
            return $"SimpleGoal:{_name},{_description},{_points},{_isComplete}";
        }
    }
}
