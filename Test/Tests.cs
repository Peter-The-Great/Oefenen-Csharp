using Calc;
using Hex;
using Sort;
using Moq;
namespace Test
{
    public class Tests
    {
        [Theory]
        [InlineData(1324)]
        public void TestHex(int value)
        {
            var mockHexaDecimaal = new Mock<HexaDecimaal>();
            mockHexaDecimaal.Setup(x => x.GetHex()).Returns(value.ToString("X"));
            var result = mockHexaDecimaal.Object.GetHex();
            Assert.Equal(value.ToString("X"), result);
            mockHexaDecimaal.Verify(x => x.GetHex(), Times.Once);
        }
        [Theory]
        [InlineData(1324)]
        public void TestByte(int value)
        {
            var mockHexaDecimaal = new Mock<HexaDecimaal>();
            mockHexaDecimaal.Setup(x => x.GetByte()).Returns(Convert.ToString(value, 2));
            var result = mockHexaDecimaal.Object.GetByte();
            Assert.Equal(Convert.ToString(value, 2), result);
            mockHexaDecimaal.Verify(x => x.GetByte(), Times.Once);
        }
        [Theory]
        [InlineData(1324)]
        public void TestDec(int value)
        {
            var mockHexaDecimaal = new Mock<HexaDecimaal>();
            mockHexaDecimaal.Setup(x => x.GetDec()).Returns(value);
            var result = mockHexaDecimaal.Object.GetDec();
            Assert.Equal(value, result);
            mockHexaDecimaal.Verify(x => x.GetDec(), Times.Once);
        }
        [Theory]
        [InlineData(80000)]
        public void TestLimit(int value)
        {
            HexaDecimaal test = new HexaDecimaal();
            Assert.Throws<ArgumentOutOfRangeException>(() => test.SetHex(value));
        }
        [Theory]
        [InlineData(13, 15)]
        public void TestCalc(int value1, int value2)
        {
            SomInt test1 = new SomInt(value1);
            SomInt test2 = new SomInt(value2);
            SomInt som = new SomInt(value1, value2);
            Assert.Equal(som.Waarde, test1 + test2);
        }
        [Fact]
        public void TestBubbleSort()
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
        [Fact]
        public void TestInsertSort()
        {
            // Create a Sorter object
            Sorter sorter = new Sorter();

            // Define an array of strings to be sorted
            List<string> names = ["Banana", "Apple", "Orange", "Grape", "Pineapple", "Mango"];
            names.Add("Strawberry");

            // Call the BubbleSort method to sort the array
            sorter.InsertSort(names);

            // Check if the array is sorted
            Assert.Equal(new List<string> { "Apple", "Banana", "Grape", "Mango", "Orange", "Pineapple", "Strawberry" }, names);
        }
    }
}