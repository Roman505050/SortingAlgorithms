namespace SortingAlgorithms.Algorithms;

public class InsertionSortAlgorithm
{
    public static void Sort(int[] array, int length)
    {
        for (var i = 1; i < length; i++)
        {
            var key = array[i];
            var j = i - 1;
            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = key;
        }
    }
}