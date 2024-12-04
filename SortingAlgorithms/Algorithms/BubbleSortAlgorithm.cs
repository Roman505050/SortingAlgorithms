namespace SortingAlgorithms.Algorithms;

public static class BubbleSortAlgorithm
{
    public static void Sort(int[] array, int length)
    {
        for (var i = 0; i < length - 1; i++)
        {
            for (var j = 0; j < length - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }
    }
}