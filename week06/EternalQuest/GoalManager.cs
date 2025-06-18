using System;
using System.Collections.Generic;
using System.IO;

namespace Sun
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0;
        }

        public void Start()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine($"You have {_score} points.");
                Console.WriteLine("Menu Options:");
                Console.WriteLine("  1. Create New Goal");
                Console.WriteLine("  2. List Goals");
                Console.WriteLine("  3. Save Goals");
                Console.WriteLine("  4. Load Goals");
                Console.WriteLine("  5. Record Event");
                Console.WriteLine("  6. Quit");
                Console.Write("Select a choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": CreateGoal();       break;
                    case "2": ListGoals();        break;
                    case "3": SaveGoals();        break;
                    case "4": LoadGoals();        break;
                    case "5": RecordEvent();      break;
                    case "6": exit = true;        break;
                    default:  Console.WriteLine("Invalid choice."); break;
                }
            }
        }

        private void CreateGoal()
        {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("  1. Simple Goal");
            Console.WriteLine("  2. Eternal Goal");
            Console.WriteLine("  3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            var typeChoice = Console.ReadLine();

            Console.Write("Enter the name of your goal: ");
            var name = Console.ReadLine();
            Console.Write("Enter a short description: ");
            var desc = Console.ReadLine();
            Console.Write("Enter the point value: ");
            var pts = int.Parse(Console.ReadLine());

            switch (typeChoice)
            {
                case "1":
                    _goals.Add(new SimpleGoal(name, desc, pts));
                    break;
                case "2":
                    _goals.Add(new EternalGoal(name, desc, pts));
                    break;
                case "3":
                    Console.Write("Enter the target number of times: ");
                    var target = int.Parse(Console.ReadLine());
                    Console.Write("Enter the bonus for completing: ");
                    var bonus = int.Parse(Console.ReadLine());
                    _goals.Add(new ChecklistGoal(name, desc, pts, target, bonus));
                    break;
                case "4":
                    Console.Write("Enter points per unit of progress: ");
                      var ppu = int.Parse(Console.ReadLine());
                      Console.Write("Enter the target number of units: ");
                    var tgt = int.Parse(Console.ReadLine());
                    _goals.Add(new ProgressGoal(name, desc, ppu, tgt));
                    break;
                case "5":
                    Console.Write("Enter penalty points (positive number): ");
                    var pen = int.Parse(Console.ReadLine());
                    _goals.Add(new NegativeGoal(name, desc, pen));
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    break;
            }
        }

        private void ListGoals()
        {
            Console.WriteLine("Your Goals:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i+1}. {_goals[i].GetDetailsString()}");
            }
        }

        private void SaveGoals()
        {
            Console.Write("Enter filename to save goals: ");
            var filename = Console.ReadLine();
            using (var writer = new StreamWriter(filename))
            {
                writer.WriteLine(_score);
                foreach (var goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("Goals saved.");
        }

        private void LoadGoals()
        {
            Console.Write("Enter filename to load goals: ");
            var filename = Console.ReadLine();
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            _goals.Clear();
            var lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                var parts = lines[i].Split(':');
                var type = parts[0];
                var data = parts[1].Split(',');

        switch (type)
        {
          case "SimpleGoal":
            var isComplete = bool.Parse(data[3]);
            _goals.Add(
                new SimpleGoal(
                    data[0], data[1],
                    int.Parse(data[2]),
                    isComplete
                )
            );
            break;

          case "EternalGoal":
            _goals.Add(
                new EternalGoal(
                    data[0], data[1],
                    int.Parse(data[2])
                )
            );
            break;

          case "ChecklistGoal":
            _goals.Add(
                new ChecklistGoal(
                    data[0], data[1],
                    int.Parse(data[2]),
                    int.Parse(data[4]),
                    int.Parse(data[5]),
                    int.Parse(data[3])
                )
            );
            break;
          case "ProgressGoal":
                // data = [Name,Desc,PointsPerUnit,Current,Target]
                _goals.Add(new ProgressGoal(
                    data[0], data[1],
                    int.Parse(data[2]),
                    int.Parse(data[4]),
                    int.Parse(data[3])
                ));
                break;
            case "NegativeGoal":
                // data = [Name,Desc,Points]
                _goals.Add(new NegativeGoal(
                    data[0], data[1],
                    int.Parse(data[2])
                ));
                break;
                }
            }

            Console.WriteLine("Goals loaded.");
        }

        private void RecordEvent()
        {
            Console.WriteLine("Which goal did you accomplish?");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i+1}. {_goals[i].GetDetailsString()}");
            }

            var idx = int.Parse(Console.ReadLine()) - 1;
            if (idx < 0 || idx >= _goals.Count)
            {
                Console.WriteLine("Invalid choice.");
                return;
            }

            var earned = _goals[idx].RecordEvent();
            _score += earned;
            Console.WriteLine($"You earned {earned} points!");
        }
    }
}
