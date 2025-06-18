using System;

namespace Sun
{
    public class NegativeGoal : Goal
    {
        // points aquí es la magnitud de la penalización (positivo)
        public NegativeGoal(string name, string description, int penaltyPoints)
            : base(name, description, penaltyPoints)
        { }

        public override int RecordEvent()
        {
            // resta puntos
            return -_points;
        }

        public override bool IsComplete() => false;  // nunca “termina”

        public override string GetDetailsString()
        {
            return $"[!] {_name} ({_description}) — Penalty: {_points} pts";
        }

        public override string GetStringRepresentation()
        {
            // NegativeGoal:Name,Description,Points
            return $"NegativeGoal:{_name},{_description},{_points}";
        }
    }
}
