using System;
using System.Threading.Tasks;
using System.Threading;
using AsyncBreakfast.AsyncBreakfast;
class Program
{
    static async Task Main(string[] args)
    {
        await AsyncBreakfast.Hoofd();
        //await Method1();
        //await Method2();
        //await Method3();
    }

    public static async Task Method1()
    {
        await Task.Run(() =>
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(" Method 1");
                // Do something
                Task.Delay(100).Wait();
            }
        });
    }


    public static async Task Method2()
    {
        await Task.Run(() =>
        {
            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine(" Method 1");
                // Do something
                Task.Delay(100).Wait();
            }
        });
    }
    
    public static async Task Method3()
    {
        ConsoleWriteLine($"Start Program");
      
        Task<int> taskA = MethodAAsync();
    
        for (int i = 0; i < 5; i++) {
            ConsoleWriteLine($" B{i}");
            Task.Delay(50).Wait();
        }
    
        ConsoleWriteLine("Wait for taskA termination");
    
        await taskA;
    
        ConsoleWriteLine($"The result of taskA is {taskA.Result}");
    }
    static async Task<int> MethodAAsync() {
        for (int i = 0; i < 5; i++) {
            ConsoleWriteLine($" A{i}");
            await Task.Delay(100);
        }
        int result = 123;
        ConsoleWriteLine($" A returns result {result}");
        return result;
    }
    
    // Convenient helper to print colorful threadId on console
    static void ConsoleWriteLine(string str) {
        int threadId = Thread.CurrentThread.ManagedThreadId;
        Console.ForegroundColor = threadId == 1 ? ConsoleColor.White : ConsoleColor.Cyan;
        Console.WriteLine(
            $"{str}{new string(' ', 26 - str.Length)}   Thread {threadId}");
    }
}