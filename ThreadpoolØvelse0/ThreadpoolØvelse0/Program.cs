using System;
using System.Threading;

class ThreadpoolØvelse0
{


    // i stedet for at erstatte har jeg tilføjet ThreadPool.QueueUserWorkItem(tpd.task1); og ThreadPool.QueueUserWorkItem(tpd.task2);.
    // lavet commentar for det






    // Method for executing thread 1
    public void task1(object obj)
    {
        // Prints a message three times to the console window
        for (int i = 0; i <= 2; i++)
        {
            Console.WriteLine("Task 1 is being executed");
        }
    }

    // Method for executing thread 2
    public void task2(object obj)
    {
        // Prints a message three times to the console window
        for (int i = 0; i <= 2; i++)
        {
            Console.WriteLine("Task 2 is being executed");
        }
    }

    static void Main()
    {
        // Create an instance of the ThreadpoolØvelse0 class
        ThreadpoolØvelse0 tpd = new ThreadpoolØvelse0();

        // Part 1: Execute the task1 and task2 methods using the ThreadPool.QueueUserWorkItem method
        for (int i = 0; i < 2; i++)
        {
            // Add task1 and task2 to the thread pool queue to be executed when a thread becomes available
            ThreadPool.QueueUserWorkItem(tpd.task1);
            ThreadPool.QueueUserWorkItem(tpd.task2);
        }

        // Part 2: Execute the task1 and task2 methods using the ThreadPool.QueueUserWorkItem method with the WaitCallback delegate
        for (int i = 0; i < 2; i++)
        {
            // Wrap task1 and task2 in the WaitCallback delegate and add them to the thread pool queue
            ThreadPool.QueueUserWorkItem(new WaitCallback(tpd.task1));
            ThreadPool.QueueUserWorkItem(new WaitCallback(tpd.task2));
        }

        
        Console.Read();
    }
}