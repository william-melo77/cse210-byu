using System.IO;
namespace Mindfulness
{
    public static class ActivityLogger
    {
        private static readonly string _logPath = "activity_log.txt";
        public static void Log(string activityName)
        {
            File.AppendAllText(_logPath, $"{DateTime.Now:u} - {activityName}\n");
        }
        public static string[] ReadLog() => File.Exists(_logPath)
            ? File.ReadAllLines(_logPath)
            : new string[0];
    }
}
