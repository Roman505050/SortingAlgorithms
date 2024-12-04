namespace SortingAlgorithms.Algorithms;

public static class SelectionSortAlgorithm
{
    public static void Sort(int[] array, int length)
    {
        for (var i = 0; i < length - 1; i++)
        {
            var minIndex = i;
            for (var j = i + 1; j < length; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }

            if (minIndex != i)
            {
                (array[i], array[minIndex]) = (array[minIndex], array[i]);
            }
        }
    }
}