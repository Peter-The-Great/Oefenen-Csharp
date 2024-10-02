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
        for (int i = 1; i < array.Count; i++)
        {
            int insertIndex = i;
            string currentValue = array[i];

            for (int j = i - 1; j >= 0; j--)
            {
                // Use string.Compare to compare strings lexicographically
                if (string.Compare(array[j], currentValue) > 0)
                {
                    array[j + 1] = array[j];
                    insertIndex = j;
                }
                else
                {
                    break;
                }
            }
            array[insertIndex] = currentValue;
        }
    }
}