// Assignment.cs
namespace HomeworkInheritance
{
    public class Assignment
    {
        // Variables privadas
        private string _studentName;
        private string _topic;

        // Constructor
        public Assignment(string studentName, string topic)
        {
            _studentName = studentName;
            _topic = topic;
        }

        // Método común
        public string GetSummary()
        {
            return $"{_studentName} - {_topic}";
        }

        // (Opcional) Getter para _studentName, si prefieres no usar protected
        public string GetStudentName()
        {
            return _studentName;
        }
    }
}
