namespace Sun
{
    public class ChecklistGoal : Goal
    {
        private int _amountCompleted;
        private int _target;
        private int _bonus;

        // New checklist starts at zero progress
        public ChecklistGoal(string name, string description, int points, int target, int bonus)
            : base(name, description, points)
        {
            _target = target;
            _bonus = bonus;
            _amountCompleted = 0;
        }

        // Overload for loading from file
        public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted)
            : this(name, description, points, target, bonus)
        {
            _amountCompleted = amountCompleted;
        }

        public override int RecordEvent()
        {
            _amountCompleted++;
            var total = _points;
            if (_amountCompleted >= _target)
            {
                total += _bonus;
            }
            return total;
        }

        public override bool IsComplete() => _amountCompleted >= _target;

        public override string GetDetailsString()
        {
            var status = IsComplete() ? "[X]" : "[ ]";
            return $"{status} {_name} ({_description}) -- Completed: {_amountCompleted}/{_target}";
        }

        public override string GetStringRepresentation()
        {
            // Format: ChecklistGoal:Name,Description,Points,AmountCompleted,Target,Bonus
            return $"ChecklistGoal:{_name},{_description},{_points},{_amountCompleted},{_target},{_bonus}";
        }
    }
}
