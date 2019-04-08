using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloSingelton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hallo Singelton");

            for (int i = 0; i < 10; i++)
            {
                Task.Run(() => Logger.Instance.Log($"Hallo Logger {i}"));
            }
            Logger.Instance.Log("Mehr Logs");

            Console.ReadKey();
        }
    }

    class Logger
    {
        private static Logger instance = null;
        public static Logger Instance
        {
            get
            {
                lock (syncObj)
                {
                    if (instance == null)
                        instance = new Logger();
                }
                return instance;
            }
        }
        static object syncObj = new object();
        static int count = 0;
        private Logger()
        {
            count++;
        }

        public void Log(string msg)
        {
            Console.WriteLine($"({count}) [{DateTime.Now:T}] {msg}");
            //Console.WriteLine(string.Format("[{0:T}] {1}", DateTime.Now, msg));
        }
    }
}
