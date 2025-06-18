using System;

namespace Sun
{
    class Program
    {
        static void Main(string[] args)
        {   
            // 🚀 Extra features added: ProgressGoal (accumulative progress) and NegativeGoal (penalty for bad habits)
            var manager = new GoalManager();
            manager.Start();
        }
    }
}
