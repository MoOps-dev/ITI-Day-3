/**************************************
Written by Mohamed Khaled Tawfeek
mohamed.ibraham98@gmail.com
ITI Intensive Code Camp 2025-2026 R2
Full Stack .NET Zagazig DAY 3 C#
***************************************/

using System.Text.RegularExpressions; // Required for regex-based input validation

namespace ITI_Day_3;

partial class Program
{
    // Program control flag: controls whether the main loop keeps running
    private static bool IsRunning = true;

    // Regex instance for validating numeric input (integers, positive or negative)
    private static readonly Regex NumRegex = MyRegexNum();

    static void Main(string[] args)
    {
        // Main program loop
        // Continues to display the menu until the user presses ESC
        while (IsRunning)
        {
            Console.Clear();

            // Display menu options to the user
            Console.WriteLine(@"
*******************************************************
*** Welcome to Day-3, Choose an action to continue: ***
*******************************************************
** 1. One Dimension Array Operations                **
** 2. Two Dimension Array Operations.               **
** Or press ESC to exit the program.                **
*******************************************************
            ");

            // Read a single key from the user without displaying it
            ConsoleKeyInfo MenuInput = Console.ReadKey(true);

            // Handle the menu selection
            switch(MenuInput.Key)
            {
                case ConsoleKey.D1:
                    // User selected 1: One-Dimensional Array Operations
                    Console.Clear();
                    Console.WriteLine(@"
**************************************
*** One Dimension Array Operations ***
**************************************
                    ");
                    InitOperation1(); // Call method to handle 1D array operations
                    break;

                case ConsoleKey.D2:
                    // User selected 2: Two-Dimensional Array Operations
                    Console.Clear();
                    Console.WriteLine(@"
**************************************
*** Two Dimension Array Operations ***
**************************************
                    ");
                    InitOperation2(); // Call method to handle 2D array operations
                    break;

                default:
                    // If ESC is pressed, exit the program
                    if (MenuInput.Key == ConsoleKey.Escape)
                        IsRunning = false;
                    break;
            }
        }

        // ====================== Feature Methods ======================

        // Initialize and handle one-dimensional array operations
        static void InitOperation1()
        {
            int[] arr = new int[5]; // Create array of 5 elements
            
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"Please Enter array element {i+1}: ");

                String? input = Console.ReadLine();

                // Validate input using regex
                if (!ValidateNumber(input!))
                {
                    InitOperation1(); // Recursive call if input is invalid
                    return;
                }
            
                arr[i] = int.Parse(input!); // Store the validated integer
            }

            // Compute sum, min, max and display results
            Console.WriteLine(OneDimensionArray(arr));

            // Wait for user to return to main menu
            ToMainMenu();
        }

        // Compute sum, min, and max of a 1D array
        static string OneDimensionArray(int[] args)
        {
            int sum = 0, min = int.MaxValue, max = int.MinValue;
            
            for (int i = 0; i < args.Length; i++)
            {
                sum += args[i]; // Sum all elements

                if (args[i] < min)
                    min = args[i]; // Find minimum
                    
                if (args[i] > max)
                    max = args[i]; // Find maximum
            }

            // Return formatted string with results
            return @$"
                Array Sum = {sum}
                Array Min = {min}
                Array Max = {max}
            ";
        }

        // Initialize and handle two-dimensional array operations
        static void InitOperation2()
        {
            int[,] arr = new int[3, 3]; // Create 3x3 array
            
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    Console.Write($"Please Enter degree {col+1} for student {row+1}: ");
                    String? input = Console.ReadLine();

                    // Validate input
                    if (!ValidateNumber(input!))
                    {
                        InitOperation2(); // Recursive call if input is invalid
                        return;
                    }

                    arr[row, col] = int.Parse(input!); // Store validated integer
                }
            }

            // Process the 2D array: calculate sum, min, max, averages
            (int[,] stats, int[,] calc, int[] avg) = TwoDimensionArray(arr);

            // Display results
            Console.WriteLine("\n******** Degree1 - Degree2 - Degree3 ********\n");
            PrintTable(stats, "Student"); // Original grades table
            Console.WriteLine("************** SUM - MIN - MAX **************\n");
            PrintTable(calc, "Student"); // Calculated statistics table
            Console.WriteLine("**** Average:Degree1 - Degree2 - Degree3 ****\n");
            PrintAverage(avg, "Average"); // Display average per column

            ToMainMenu(); // Wait for user to return to main menu
        }

        // Calculate sum, min, max per row and average per column in 2D array
        static (int[,] stats, int[,] calc, int[] avg) TwoDimensionArray(int[,] stats)
        {
            int[,] calc = new int[3, 3]; // Array to store sum, min, max per student
            
            for (int row = 0; row < stats.GetLength(0); row++)
            {
                calc[row, 1] = int.MaxValue; // Initialize min
                calc[row, 2] = int.MinValue; // Initialize max

                for (int col = 0; col < stats.GetLength(1); col++)
                {
                    calc[row, 0] += stats[row, col]; // Sum of each row

                    if (stats[row, col] < calc[row, 1])
                        calc[row, 1] = stats[row, col]; // Min of row

                    if (stats[row, col] > calc[row, 2])
                        calc[row, 2] = stats[row, col]; // Max of row
                }
            }

            int[] avg = new int[stats.GetLength(1)]; // Column averages

            for (int c = 0; c < stats.GetLength(1); c++)
            {
                for (int r = 0; r < stats.GetLength(0); r++)
                {
                    avg[c] += stats[r, c]; // Sum per column
                }

                avg[c] /= stats.GetLength(0); // Compute average per column
            }

            return (stats, calc, avg); // Return original data, row stats, and column averages
        }

        // Print a 2D array in a table format
        static void PrintTable(int[,] arr, string RowId = "Undefined")
        {
            for (int row = 0; row < arr.GetLength(0); row++)
            {
                Console.Write($"{RowId}{row+1}\t"); // Row header
                for (int col = 0; col < arr.GetLength(1); col++)
                {
                    Console.Write($"{arr[row, col]}\t"); // Print each cell
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // Print a 1D array (averages) in table format
        static void PrintAverage(int[] arr, string RowId = "Undefined")
        {
            Console.Write($"{RowId} \t"); // Row header
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]}\t"); // Print each average
            }
            Console.WriteLine();
        }

        // Wait for user to press ESC to return to main menu
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