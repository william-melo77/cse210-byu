using System;
namespace Mindfulness
{
    public class GratitudeActivity : Activity
    {
        public GratitudeActivity(int duration)
            : base("Gratitude Activity",
                   "This activity will help you focus on things you are grateful for.",
                   duration)
        {}

        public override void Run()
        {
            Console.Write("Press ENTER to begin listing things you are grateful for: ");
            Console.ReadLine();
            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            int count = 0;
            while (DateTime.Now < endTime)
            {
                Console.Write($"{++count}. ");
                Console.ReadLine();
            }
            Console.WriteLine($"You expressed gratitude for {count} items.");
        }
    }
}