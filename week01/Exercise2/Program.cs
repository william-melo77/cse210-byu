using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Please enter your grade percentage: ");
        string gradeInput = Console.ReadLine();

        if (!double.TryParse(gradeInput, out double gradePercentage))
        {
            Console.WriteLine("Invalid input. Please enter a numerical percentage.");
            return;
        }

        string letterGrade;
        if (gradePercentage >= 90)
        {
            letterGrade = "A";
        }
        else if (gradePercentage >= 80)
        {
            letterGrade = "B";
        }
        else if (gradePercentage >= 70)
        {
            letterGrade = "C";
        }
        else if (gradePercentage >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        string sign = "";
        int lastDigit = (int)gradePercentage % 10;

        if (letterGrade != "F")
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        if (letterGrade == "A" && sign == "+")
        {
            sign = "";
        }

        Console.WriteLine($"Your letter grade is {letterGrade}{sign}.");

        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Better luck next time! Keep up the effort.");
        }
    }
}