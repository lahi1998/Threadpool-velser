using System;
using System.Threading;
using System.Diagnostics;
namespace ThreadPooling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch mywatch = new Stopwatch();
            Console.WriteLine("Thread Pool Execution");
            mywatch.Start();
            ProcessWithThreadPoolMethod();
            mywatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadPoolMethod is : " + mywatch.ElapsedTicks.ToString());
            mywatch.Reset();
            Console.WriteLine("Thread Execution");
            mywatch.Start();
            ProcessWithThreadMethod();
            mywatch.Stop();
            Console.WriteLine("Time consumed by ProcessWithThreadMethod is : " + mywatch.ElapsedTicks.ToString());
        }
        static void ProcessWithThreadPoolMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Process);
            }
        }
        static void ProcessWithThreadMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread obj = new Thread(Process);
                obj.Start();
            }
        }

        //This indicates that the thread pool was approximately 62% faster than normal threads in completing the workload.

        //static void Process(object callback)
        //{
        //    for (int i = 0; i < 100000; i++)
        //    {
        //    }
        //}

        // Therefore, threadpool is approximately 99.68% faster than thread.
        static void Process(object callback)
        {
            for (int i = 0; i < 100000; i++)
            {
                for (int j = 0; j < 100000; j++)
                {
                }
            }
        }

    }
}