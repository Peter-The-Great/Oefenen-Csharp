using Calc;
using Sort;
namespace Test;

public class Tests
{
    [Theory]
    [InlineData(6)]
    [InlineData(5)]
    [InlineData(10)]
    public void TestCalc()
    {
        // Arrange
        int getal1 = 5;
        int getal2 = 6;
        int expected = 11;

        // Act
        SomInt resultaat1 = new SomInt(getal1, getal2);

        // Assert
        Assert.Equal(expected, resultaat1.Waarde);
    }
    public void TestOverflow()
    {
        SomInt resultaat1 = new SomInt(int.MaxValue, 1);
    }
    [Fact]
    public void TestSorting()
    {
        // Create a Sorter object
        Sorter sorter = new Sorter();

        // Define an array of strings to be sorted
        List<string> names = ["Banana", "Apple", "Orange", "Grape", "Pineapple", "Mango"];
        names.Add("Strawberry");

        // Call the BubbleSort method to sort the array
        sorter.BubbleSort(names);

        // Check if the array is sorted
        Assert.Equal(new List<string> { "Apple", "Banana", "Grape", "Mango", "Orange", "Pineapple", "Strawberry" }, names);
    }
}