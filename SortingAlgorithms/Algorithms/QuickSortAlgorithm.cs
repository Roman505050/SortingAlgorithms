namespace SortingAlgorithms.Algorithms;

public static class QuickSortAlgorithm
{
    public static void Sort(int[] array, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(array, low, high);
            Sort(array, low, pivotIndex - 1);
            Sort(array, pivotIndex + 1, high);
        }
    }

    private static int Partition(int[] array, int low, int high)
    {
        int pivot = array[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (array[j] < pivot)
            {
                i++;
                Swap(ref array[i], ref array[j]);
            }
        }

        Swap(ref array[i + 1], ref array[high]);
        return i + 1;
    }

    private static void Swap(ref int a, ref int b)
    {
        (a, b) = (b, a);
    }
}