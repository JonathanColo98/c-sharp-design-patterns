using System;
using System.Threading;

namespace Singleton_Thread_Safe
{
    public class Singleton
    {
        private static Singleton _instance;
        private static readonly object _lock = new object();

        public string Value { get; set; }
       
        private Singleton() { }

        public static Singleton GetInstance(string value)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Singleton();
                        _instance.Value = value;
                    }
                }
            }
            return _instance;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Thread process = new Thread( () =>
            {
                Program.TestSingleton("Test Singleton 1");
            });

            Thread process2 = new Thread(() =>
            {
                Program.TestSingleton("Test Singleton 2");
            });

            process.Start();
            process2.Start();

            process.Join();
            process2.Join();
        }

        private static void TestSingleton(string value)
        {
            Singleton s = Singleton.GetInstance(value);
            Console.WriteLine(s.Value);
        }
    }
}
