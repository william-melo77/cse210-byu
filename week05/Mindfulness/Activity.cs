using System;
using System.Threading;

namespace Mindfulness
{
    public abstract class Activity
    {
        protected string _name;
        protected string _description;
        protected int _duration;

        public Activity(string name, string description, int duration)
        {
            _name = name;
            _description = description;
            _duration = duration;
        }

        public void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"=== {_name} ===");
            Console.WriteLine(_description);
            Console.WriteLine($"Duration: {_duration} seconds");
            Console.WriteLine("Get ready...");
            ShowSpinner(3);
        }

        public void DisplayEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Well done!");
            ShowSpinner(3);
            Console.WriteLine($"You have completed {_name} for {_duration} seconds.");
            Console.WriteLine();
            Thread.Sleep(1000);
        }

        public void ShowSpinner(int seconds)
        {
            string[] spinner = {"|", "/", "-", "\\"};
            for (int i = 0; i < seconds * 4; i++)
            {
                Console.Write(spinner[i % spinner.Length]);
                Thread.Sleep(250);
                Console.Write("\b");
            }
            Console.WriteLine();
        }

        public void ShowCountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b ");
                Console.Write("\b");
            }
            Console.WriteLine();
        }

        public abstract void Run();
    }
}