using System;
using System.Collections.Generic;
namespace Mindfulness
{
    public class ReflectingActivity : Activity
    {
        private List<string> _prompts;
        private List<string> _questions;
        private Random _random = new Random();

        public ReflectingActivity(int duration, List<string> prompts, List<string> questions)
            : base("Reflecting Activity",
                   "This activity will help you reflect on times in your life when you have shown strength and resilience.",
                   duration)
        {
            _prompts = prompts;
            _questions = questions;
        }

        public override void Run()
        {
            Console.WriteLine(GetRandomPrompt());
            ShowSpinner(3);
            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            while (DateTime.Now < endTime)
            {
                Console.WriteLine(GetRandomQuestion());
                ShowSpinner(5);
            }
        }

        private string GetRandomPrompt() => _prompts[_random.Next(_prompts.Count)];
        private string GetRandomQuestion() => _questions[_random.Next(_questions.Count)];
    }
}
