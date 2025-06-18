using System;
namespace Mindfulness
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity(int duration)
            : base("Breathing Activity",
                   "This activity will help you relax by walking you through breathing in and out slowly.",
                   duration)
        {}

        public override void Run()
        {
            int half = _duration / 2;
            for (int i = 0; i < half; i++)
            {
                Console.Write("Breathe in...");
                ShowCountDown(4);
                Console.Write("Breathe out...");
                ShowCountDown(4);
            }
        }
    }
}