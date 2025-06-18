using System;
using System.Collections.Generic;
namespace Mindfulness
{
    public class ActivityMenu
    {
        public void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Activity");
            Console.WriteLine("5. View Activity Log");
            Console.WriteLine("0. Quit");
            Console.Write("Choose an option: ");
        }

        public int GetChoice()
        {
            return int.TryParse(Console.ReadLine(), out int choice) ? choice : -1;
        }

        public void HandleChoice(int choice)
        {
            switch (choice)
            {
                case 1: RunActivity(new BreathingActivity(ReadDuration())); break;
                case 2: RunActivity(new ReflectingActivity(ReadDuration(), ReflectingPrompts, ReflectingQuestions)); break;
                case 3: RunActivity(new ListingActivity(ReadDuration(), ListingPrompts)); break;
                case 4: RunActivity(new GratitudeActivity(ReadDuration())); break;
                case 5: DisplayLog(); break;
                case 0: Console.WriteLine("Goodbye!"); break;
                default: Console.WriteLine("Invalid choice. Press ENTER."); Console.ReadLine(); break;
            }
        }

        private int ReadDuration()
        {
            Console.Write("Enter duration in seconds: ");
            return int.TryParse(Console.ReadLine(), out int d) ? d : 0;
        }

        private void RunActivity(Activity activity)
        {
            activity.DisplayStartingMessage();
            activity.Run();
            activity.DisplayEndingMessage();
            ActivityLogger.Log(activity.GetType().Name);
            Console.WriteLine("Press ENTER to return to menu."); Console.ReadLine();
        }

        private void DisplayLog()
        {
            Console.Clear();
            foreach (var line in ActivityLogger.ReadLog())
                Console.WriteLine(line);
            Console.WriteLine("Press ENTER to continue."); Console.ReadLine();
        }

        private static List<string> ReflectingPrompts => new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something selfless."
        };

        private static List<string> ReflectingQuestions => new List<string>
        {
            "Why was this meaningful to you?",
            "Have you done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?"
        };

        private static List<string> ListingPrompts => new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who have you helped this week?"
        };
    }
}
