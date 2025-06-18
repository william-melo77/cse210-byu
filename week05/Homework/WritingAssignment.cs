// WritingAssignment.cs
namespace HomeworkInheritance
{
    public class WritingAssignment : Assignment
    {
        private string _title;

        public WritingAssignment(string studentName, string topic, string title)
            : base(studentName, topic)
        {
            _title = title;
        }

        public string GetWritingInformation()
        {
            // Llamamos al getter de la base
            return $"{_title} by {GetStudentName()}";
        }
    }
}
