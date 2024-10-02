namespace Sort;
public class Sorter
{
    /// <summary>
    /// BubbleSort method to sort an array of strings
    /// </summary>
    /// <param name="array"></param>
    /// <returns>De gesorteerde lijst van Strings</returns>
    public void BubbleSort(List<string> array)
    {
        int n = array.Count;
        bool swapped;

        // Outer loop for all passes through the array
        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;

            // Inner loop for comparing adjacent elements
            for (int j = 0; j < n - i - 1; j++)
            {
                // Compare two adjacent elements and swap if in wrong order
                if (string.Compare(array[j], array[j + 1]) > 0)
                {
                    // Swap array[j] and array[j + 1]
                    string temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                    swapped = true;
                }
            }

            // If no elements were swapped, the array is already sorted
            if (!swapped)
            {
                break;
            }
        }
    }
    /// <summary>
    /// InsertSort method to sort an array of strings
    /// </summary>
    /// <param name="array">Lijst van Strings</param>
    /// <returns>De gesorteerde lijst van Strings</returns>
    public void InsertSort(List<string> array)
    {
        for (int step = 1; step < array.Count; step++)
        {
            string key = array[step];
            int j = step - 1;

            // Move elements of array[0..i-1] that are greater than key
            // to one position ahead of their current position
            while (j >= 0 && string.Compare(array[j], key) > 0)
            {
                array[j + 1] = array[j];
                j = j - 1;
            }
            array[j + 1] = key;
        }
    }
}