using System;
using System.Collections.Generic;
namespace Mindfulness
{
    public class ListingActivity : Activity
    {
        private List<string> _prompts;
        private List<string> _responses = new List<string>();
        private Random _random = new Random();

        public ListingActivity(int duration, List<string> prompts)
            : base("Listing Activity",
                   "This activity will help you reflect on the good things in your life by listing as many things as you can.",
                   duration)
        {
            _prompts = prompts;
        }

        public override void Run()
        {
            Console.WriteLine(GetRandomPrompt());
            Console.Write("Press ENTER to begin listing items: ");
            Console.ReadLine();
            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                string resp = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(resp))
                    _responses.Add(resp);
            }
            Console.WriteLine($"You listed {_responses.Count} items.");
        }

        private string GetRandomPrompt() => _prompts[_random.Next(_prompts.Count)];
    }
}
