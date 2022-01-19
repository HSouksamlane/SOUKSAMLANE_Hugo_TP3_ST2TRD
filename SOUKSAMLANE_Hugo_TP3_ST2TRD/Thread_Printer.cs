using System;
using System.Threading;

namespace SOUKSAMLANE_Hugo_TP3_ST2TRD
{
    public class Thread_Printer
    {
        private static Mutex mutex1 = new Mutex(); 
        private const int NbThreads = 3;
        public void run_threads() 
        {
            Console.WriteLine("\n*** Exercise 2 ***\n");

        for (int i = 0; i<NbThreads; i++) 
        {
            Thread newThread = new Thread(new ThreadStart(ThreadProcessor));
            newThread.Name = String.Format("Thread {0}", i + 1);
            newThread.Start();
        }
        }

        private static void ThreadProcessor()
    {
        Thread_Printer obj = new Thread_Printer();
        DateTime beginning_time = DateTime.Now;
        DateTime finishing_time1 = beginning_time.AddSeconds(10);
        DateTime finishing_time2 = beginning_time.AddSeconds(9);
        DateTime finishing_time3 = beginning_time.AddSeconds(11);

        switch (Thread.CurrentThread.Name)
        {
            case "Thread 1":
                Console.WriteLine("[{0}] - Starting time : {1} | Ending time : {2} | Duration : {3}s",
                    Thread.CurrentThread.Name, beginning_time.ToString("mm:ss.fff"),finishing_time1.ToString("mm:ss.fff"),(finishing_time1 - beginning_time));
                break;
            case "Thread 2":
                Console.WriteLine("[{0}] - Starting time : {1} | Ending time : {2} | Duration : {3}s", 
                    Thread.CurrentThread.Name, beginning_time.ToString("mm:ss.fff"), finishing_time2.ToString("mm:ss.fff"),(finishing_time2 - beginning_time));
                break;
            case "Thread 3":
                Console.WriteLine("[{0}] - Starting time : {1} | Ending time : {2} | Duration : {3}s",
                    Thread.CurrentThread.Name, beginning_time.ToString("mm:ss.fff"), finishing_time3.ToString("mm:ss.fff"),(finishing_time3 - beginning_time));
                break;
            
        }
        
        int finish1= DateTime.Compare(finishing_time1, DateTime.Now);
        int finish2 = DateTime.Compare(finishing_time1, DateTime.Now);
        int finish3 = DateTime.Compare(finishing_time1, DateTime.Now);
        bool isAlive = true; 

        while (isAlive)
        {
            isAlive = false;
            switch (Thread.CurrentThread.Name)
            {
                case "Thread 1":
                    if (finish1 > 0)
                    {
                        isAlive = true;
                        Thread.Sleep(50);
                        finish1 = DateTime.Compare(finishing_time1, DateTime.Now);
                    }
                    break;
                case "Thread 2":
                    if (finish2 > 0)
                    {
                        isAlive = true;
                        Thread.Sleep(40);
                        finish2 = DateTime.Compare(finishing_time2, DateTime.Now);
                    }
                    break;
                case "Thread 3":
                    if (finish3 > 0)
                    {
                        isAlive = true;
                        Thread.Sleep(20);
                        finish3 = DateTime.Compare(finishing_time3, DateTime.Now);
                    }
                    break;
            }
            if (isAlive)
            {
                Thread_Printer.Printing_Character();
            }  
        }
    }
        
    private static void Printing_Character() 
    {
        mutex1.WaitOne(); 
        
        switch (Thread.CurrentThread.Name) 
        {
            case "Thread 1":
                Console.Write(" ");
                
                break;
            case "Thread 2":
                Console.Write("°");
             
                break;
            case "Thread 3":
                Console.Write("*");
                break;
        }
        mutex1.ReleaseMutex(); 
    }
    }
}