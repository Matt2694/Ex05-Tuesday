using System;
using System.Threading;

namespace Ex05_Tuesday
{
    class Program
    {
        private static Random _random = new Random();
        private static int _temp;
        private static bool _cont = true;
        private static int _alarm = 0;
        static void Main(string[] args)
        {
            Thread myThread1 = new Thread(new ThreadStart(Thread1));
            myThread1.Start();
            while (myThread1.IsAlive)
            {
                Thread.Sleep(10000);
            }
            Console.WriteLine("Alarm-wire terminated");
            Console.ReadKey();
        }
        static void Thread1()
        {
            while (_cont)
            {
                _temp = _random.Next(141) - 20;
                Console.WriteLine(_temp + "°C");
                Thread.Sleep(2000);
                if (_temp < 0 || _temp > 100)
                {
                    _alarm++;
                    Console.WriteLine("Warning: Temperature outside limits!");
                    Thread.Sleep(2000);

                }
                if (_alarm >= 3)
                {
                    _cont = false;
                }
            }
        }
    }
}
