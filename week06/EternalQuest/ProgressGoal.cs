using System;

namespace Sun
{
    public class ProgressGoal : Goal
    {
        private int _current;
        private int _target;

        // points aquí es el valor que ganas por cada unidad de progreso
        public ProgressGoal(string name, string description, int pointsPerUnit, int target)
            : base(name, description, pointsPerUnit)
        {
            _current = 0;
            _target = target;
        }

        // para cargar desde archivo
        public ProgressGoal(string name, string description, int pointsPerUnit, int target, int current)
            : this(name, description, pointsPerUnit, target)
        {
            _current = current;
        }

        public override int RecordEvent()
        {
            if (_current < _target)
            {
                _current++;
                return _points;       // heredado, equivale a pointsPerUnit
            }
            return 0;
        }

        public override bool IsComplete() => _current >= _target;

        public override string GetDetailsString()
        {
            var status = IsComplete() ? "[X]" : "[ ]";
            return $"{status} {_name} ({_description}) — Progreso: {_current}/{_target}";
        }

        public override string GetStringRepresentation()
        {
            // ProgressGoal:Name,Description,PointsPerUnit,Current,Target
            return $"ProgressGoal:{_name},{_description},{_points},{_current},{_target}";
        }
    }
}
