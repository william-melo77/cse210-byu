using System;

namespace Sun
{
    public abstract class Goal
    {
        protected string _name;
        protected string _description;
        protected int _points;

        protected Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
        }

        // Record the event and return the points earned
        public abstract int RecordEvent();

        // Is this goal complete?
        public abstract bool IsComplete();

        // For displaying in the list: “[X] Name (Desc)”
        public virtual string GetDetailsString()
        {
            var status = IsComplete() ? "[X]" : "[ ]";
            return $"{status} {_name} ({_description})";
        }

        // For saving/loading to file
        public abstract string GetStringRepresentation();
    }
}
