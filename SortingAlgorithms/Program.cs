using System.Diagnostics;
using System.Threading.Channels;
using SortingAlgorithms.Algorithms;
using SortingAlgorithms.Utils;

namespace SortingAlgorithms;

internal static class Program
{
    private static void Main(string[] args)
    {
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string projectDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"../../../"));

        FileManager fileManager = new(projectDirectory);
        
        int[] array = fileManager.LoadIntegerArrayFromFile("numbers.txt");

        Console.WriteLine("---------> sorting algorithms <---------");
        Console.WriteLine("1. Bubble Sort");
        Console.WriteLine("2. Selection Sort");
        Console.WriteLine("3. Insertion Sort");
        Console.WriteLine("4. Merge Sort");
        Console.WriteLine("5. Quick Sort");
        Console.WriteLine("0. Exit");
        Console.WriteLine("----------------------------------------");
        Console.Write("Enter your choice: ");
        int choice = int.Parse(Console.ReadLine() ?? string.Empty);

        long elapsedTime;
        switch (choice)
        {
            case 1:
                elapsedTime = MeasureExecutionTime(() => BubbleSortAlgorithm.Sort(array, array.Length));
                Console.WriteLine($"Sorting took {elapsedTime} milliseconds.");
                fileManager.SaveIntegerArrayToFile(array, "sorted_numbers.txt");
                break;
            case 2:
                elapsedTime = MeasureExecutionTime(() => SelectionSortAlgorithm.Sort(array, array.Length));
                Console.WriteLine($"Sorting took {elapsedTime} milliseconds.");
                fileManager.SaveIntegerArrayToFile(array, "sorted_numbers.txt");
                break;
            case 3:
                elapsedTime = MeasureExecutionTime(() => InsertionSortAlgorithm.Sort(array, array.Length));
                Console.WriteLine($"Sorting took {elapsedTime} milliseconds.");
                fileManager.SaveIntegerArrayToFile(array, "sorted_numbers.txt");
                break;
            case 4:
                elapsedTime = MeasureExecutionTime(() => MergeSortAlgorithm.Sort(array, array.Length));
                Console.WriteLine($"Sorting took {elapsedTime} milliseconds.");
                fileManager.SaveIntegerArrayToFile(array, "sorted_numbers.txt");
                break;
            case 5:
                elapsedTime = MeasureExecutionTime(() => QuickSortAlgorithm.Sort(array, 0, array.Length - 1));
                Console.WriteLine($"Sorting took {elapsedTime} milliseconds.");
                fileManager.SaveIntegerArrayToFile(array, "sorted_numbers.txt");
                break;
            case 0:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
        
    }
    
    private static long MeasureExecutionTime(Action sortingFunction)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        sortingFunction();
        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }
}