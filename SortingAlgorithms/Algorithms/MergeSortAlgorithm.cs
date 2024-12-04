namespace SortingAlgorithms.Algorithms;


public class MergeSortAlgorithm
{
    public static void Sort(int[] array, int length)
    {
        if (length <= 1) return;

        int mid = length / 2;
        int[] left = new int[mid];
        int[] right = new int[length - mid];
        
        for (int i = 0; i < mid; i++)
        {
            left[i] = array[i];
        }
        
        for (int i = mid; i < length; i++)
        {
            right[i - mid] = array[i];
        }
        
        Sort(left, mid);
        Sort(right, length - mid);
        
        Merge(array, left, right, mid, length - mid);
    }

    private static void Merge(int[] array, int[] left, int[] right, int lengthLeft, int lengthRight)
    {
        int i = 0, j = 0, k = 0;
        
        while (i < lengthLeft && j < lengthRight)
        {
            if (left[i] <= right[j])
            {
                array[k++] = left[i++];
            }
            else
            {
                array[k++] = right[j++];
            }
        }
         
        while (i < lengthLeft)
        {
            array[k++] = left[i++];
        }

        while (j < lengthRight)
        {
            array[k++] = right[j++];
        }
    }
}
