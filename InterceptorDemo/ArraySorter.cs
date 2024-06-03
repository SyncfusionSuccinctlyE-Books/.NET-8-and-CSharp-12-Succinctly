namespace InterceptorDemo;

public class ArraySorter
{
    public void Sort(int[] array)
    {
        Console.WriteLine($"Sorting array using Bubble Sort to sort {array.Length} elements");
        
        bool swapped;
        do
        {
            swapped = false;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    int temp = array[i + 1];
                    array[i + 1] = array[i];
                    array[i] = temp;
                    swapped = true;
                }
            }
        } while (swapped);
    }
}
