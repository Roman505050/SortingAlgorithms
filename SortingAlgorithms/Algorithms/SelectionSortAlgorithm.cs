namespace SortingAlgorithms.Algorithms;

public static class SelectionSortAlgorithm
{
    public static int[] Sort(int[] array)
    {
        var n = array.Length;
        for (var i = 0; i < n - 1; i++)
        {
            var minIndex = i;
            for (var j = i + 1; j < n; j++)
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
        return array;
    }
}