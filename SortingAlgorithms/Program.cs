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
        Console.WriteLine("0. Exit");
        Console.WriteLine("----------------------------------------");
        Console.Write("Enter your choice: ");
        int choice = int.Parse(Console.ReadLine() ?? string.Empty);
        
        switch (choice)
        {
            case 1:
                var (sortedArray, elapsedTime) = MeasureExecutionTime(() => BubbleSortAlgorithm.Sort(array));
                Console.WriteLine($"Sorting took {elapsedTime} milliseconds.");
                fileManager.SaveIntegerArrayToFile(sortedArray.ToArray(), "sorted_numbers.txt");
                break;
            case 2:
                (sortedArray, elapsedTime) = MeasureExecutionTime(() => SelectionSortAlgorithm.Sort(array));
                Console.WriteLine($"Sorting took {elapsedTime} milliseconds.");
                fileManager.SaveIntegerArrayToFile(sortedArray.ToArray(), "sorted_numbers.txt");
                break;
            case 3:
                (sortedArray, elapsedTime) = MeasureExecutionTime(() => InsertionSortAlgorithm.Sort(array));
                Console.WriteLine($"Sorting took {elapsedTime} milliseconds.");
                fileManager.SaveIntegerArrayToFile(sortedArray.ToArray(), "sorted_numbers.txt");
                break;
            case 0:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
        
    }
    
    private static (int[] SortedArray, long ElapsedMilliseconds) MeasureExecutionTime(Func<int[]> sortingFunction)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        int[] sortedArray = sortingFunction();
        stopwatch.Stop();
        return (sortedArray, stopwatch.ElapsedMilliseconds);
    }
}