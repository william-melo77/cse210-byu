using System;
namespace Mindfulness
{
    class Program
    {
        static void Main()
        {
            var menu = new ActivityMenu();
            int choice;
            do
            {
                menu.DisplayMenu();
                choice = menu.GetChoice();
                menu.HandleChoice(choice);
            }
            while (choice != 0);
        }
    }
}
