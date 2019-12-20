using System;
using System.Threading;
namespace RaceCondition
{
    class Akshay
    {
        int result = 0;
        AutoResetEvent event1 = new AutoResetEvent(false);
        AutoResetEvent event2 = new AutoResetEvent(false);
        AutoResetEvent event3 = new AutoResetEvent(false);
        void Work1()
        {
            WaitHandle.WaitAll(new WaitHandle[] { event2, event3 });
            result = 1;
            event1.Set();
        }
        void Work2() { result = 2; event2.Set(); }
        void Work3() { result = 3; event3.Set(); }
        static void Main(string[] args)
        {
            Akshay a = new Akshay();
            Thread worker1 = new Thread(a.Work1);
            Thread worker2 = new Thread(a.Work2);
            Thread worker3 = new Thread(a.Work3);
            WaitHandle[] waitHandles = new WaitHandle[] { a.event2 ,a.event3 };
            worker1.Start();
            worker2.Start();
            worker3.Start();
           // WaitHandle.WaitAny(new WaitHandle[] { a.event1 });
            Console.WriteLine(a.result);
            Console.WriteLine();
        }
    }
}