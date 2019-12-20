using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

class Test
{
    static void Main()
    {
        ManualResetEvent[] events = new ManualResetEvent[10];
        for (int i = 0; i < events.Length; i++)
        {
            events[i] = new ManualResetEvent(false);
            Runner r = new Runner(events[i], i);
            new Thread(new ThreadStart(r.Run)).Start();
        }

        int index = WaitHandle.WaitAny(events);

        Console.WriteLine("***** The winner is {0} *****",
                           index);

        WaitHandle.WaitAll(events);
        Console.WriteLine("All finished!");
    }
}

class Runner
{
    static readonly object rngLock = new object();
    static Random rng = new Random();

    ManualResetEvent ev;
    int id;

    internal Runner(ManualResetEvent ev, int id)
    {
        this.ev = ev;
        this.id = id;
    }

    internal void Run()
    {
        for (int i = 0; i < 10; i++)
        {
            int sleepTime;
            // Not sure about the thread safety of Random...
            lock (rngLock)
            {
                sleepTime = rng.Next(2000);
            }
            Thread.Sleep(sleepTime);
            Console.WriteLine("Runner {0} at stage {1}",
                               id, i);
        }
        ev.Set();
    }
}