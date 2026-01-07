/**************************************
Written by Mohamed Khaled Tawfeek
mohamed.ibraham98@gmail.com
ITI Intensive Code Camp 2025-2026 R2
Full Stack .NET Zagazig DAY 3 C#
***************************************/

using System.Text.RegularExpressions; // Needed for regex validation

namespace ITI_Day_3;

partial class Program
{
    // Program control flag
    private static bool IsRunning = true;

    // Regex for validating numeric input (integer numbers, positive or negative)
    private static readonly Regex NumRegex = MyRegexNum();

    static void Main(string[] args)
    {
        // Main program loop, keeps running until user presses ESC
        while (IsRunning)
        {
            Console.Clear();

            // Display menu options
            Console.WriteLine(@"
*******************************************************
*** Welcome to Day-3, Choose an action to continue: ***
*******************************************************
** 1. One Dimension Array Operations                ***
** 2. Two Dimension Array Operations.               ***
** Or press ESC to exit the program.                ***
*******************************************************
            ");

            // Read a single key from the user without displaying it
            ConsoleKeyInfo MenuInput = Console.ReadKey(true);

            // Handle the menu selection using a switch statement
            switch(MenuInput.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    Console.WriteLine(@"
**************************************
*** One Dimension Array Operations ***
**************************************
                    ");
                    InitOperation1();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    Console.WriteLine(@"
**************************************
*** Two Dimension Array Operations ***
**************************************
                    ");
                    InitOperation2();
                    break;
                default:
                    // If ESC is pressed, exit program
                    if (MenuInput.Key == ConsoleKey.Escape)
                        IsRunning = false;
                    break;
            }
        }

        // ====================== Feature Methods ======================

        static void InitOperation1()
        {
            int[] arr = new int[5];
            
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"Please Enter array element {i+1}: ");

                String? input = Console.ReadLine();

                if (!ValidateNumber(input!))
                {
                    InitOperation1(); // Recursive call on invalid input
                    return;
                }
            
                arr[i] = int.Parse(input!);
            }

            Console.WriteLine(OneDimensionArray(arr));

            ToMainMenu();
            
        }

        static string OneDimensionArray(int[] args)
        {
            int sum = 0, min = int.MaxValue, max = int.MinValue;
            
            for (int i = 0; i < args.Length; i++)
            {
                sum += args[i];

                if (args[i] < min)
                    min = args[i];
                    
                if (args[i] > max)
                    max = args[i];
            }

            return @$"
                Array Sum = {sum}
                Array Min = {min}
                Array Max = {max}
            ";
            
        }

        static void InitOperation2()
        {
            int[,] arr = new int[3, 3];
            
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    Console.Write($"Please Enter degree {col+1} for student {row+1}: ");
                    String? input = Console.ReadLine();

                    if (!ValidateNumber(input!))
                    {
                        InitOperation2(); // Recursive call on invalid input
                        return;
                    }

                    arr[row, col] = int.Parse(input!);
                }
            }

            (int[,] stats, int[,] calc, int[] avg) = TwoDimensionArray(arr);

            Console.WriteLine("\n******** Degree1 - Degree2 - Degree3 ********\n");
            PrintTable(stats, "Student");
            Console.WriteLine("************** SUM - MIN - MAX **************\n");
            PrintTable(calc, "Student");
            Console.WriteLine("**** Average:Degree1 - Degree2 - Degree3 ****\n");
            PrintAverage(avg, "Average");

            ToMainMenu();
            
        }

        static (int[,] stats, int[,] calc, int[] avg) TwoDimensionArray(int[,] stats)
        {
            int[,] calc = new int[3, 3];
            
            for (int row = 0; row < stats.GetLength(0); row++)
            {
                calc[row, 1] = int.MaxValue;
                calc[row, 2] = int.MinValue;

                for (int col = 0; col < stats.GetLength(1); col++)
                {
                    calc[row, 0] += stats[row, col];

                    if (stats[row, col] < calc[row, 1])
                        calc[row, 1] = stats[row, col];

                    if (stats[row, col] > calc[row, 2])
                        calc[row, 2] = stats[row, col];
                }
            }

            int[] avg = new int[stats.GetLength(1)];

            for (int c = 0; c < stats.GetLength(1); c++)
            {
                for (int r = 0; r < stats.GetLength(0); r++)
                {
                    avg[c] += stats[r, c];
                }

                avg[c] /= stats.GetLength(0);
            }

            return (stats, calc, avg);
  
        }

        static void PrintTable(int[,] arr, string RowId = "Undefined")
        {
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                Console.Write($"{RowId}{row+1}\t");
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    Console.Write($"{arr[row, col]}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void PrintAverage(int[] arr, string RowId = "Undefined")
        {
            Console.Write($"{RowId} \t");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]}\t");
            }
            Console.WriteLine();
        }

        // Wait for ESC key to return to main menu
        static void ToMainMenu()
        {
            ConsoleKeyInfo key;

            do
            {
                Console.WriteLine("\nPress ESC to return to the main menu...");
                key = Console.ReadKey(true);

            } while (key.Key != ConsoleKey.Escape);
        }

    }

    // ====================== Validation Methods ======================

    // Validate numeric input using regex
    static bool ValidateNumber(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("The required input cannot be empty.");
            return false;
        }
        else if (!NumRegex.IsMatch(input))
        {
            Console.WriteLine("The required input can only accept numbers.");
            return false;
        }
        return true;
    }

    // ====================== Regex Definitions ======================

    // Regex for integers, including negative numbers
    [GeneratedRegex(@"^-?[0-9]+$")]
    private static partial Regex MyRegexNum();
}
