using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Unit6
{
    internal class DressingRoom
    {
        int totalRooms;
        Semaphore semaphore;
        long waitTime;
        long runTime;

        public DressingRoom(int totalRooms)
        {
            semaphore = new Semaphore(totalRooms, totalRooms);
        }

        internal long GetRunTime()
        {
            return runTime;
        }

        internal long GetWaitTime()
        {
            return waitTime;
        }

        internal async Task RequestRoom(Customer customer, int customerNumber)
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine($"Customer {customerNumber + 1} is waiting");

            stopwatch.Start();
            semaphore.WaitOne();
            stopwatch.Stop();
            waitTime += stopwatch.ElapsedTicks;

            int roomWaitTime = GetRandomNumber(1, 3);
            stopwatch.Start();
            Thread.Sleep(roomWaitTime * customer.GetNumberOfItems());
            stopwatch.Stop();
            runTime += stopwatch.ElapsedTicks;

            Console.WriteLine($"Customer {customerNumber + 1} finished trying to items in room");
            semaphore.Release();

        }

        private static readonly Random random = new Random();
        public static int GetRandomNumber(int min, int max)
        {
            lock (random) { return random.Next(min, max); }
        }
    }
}
