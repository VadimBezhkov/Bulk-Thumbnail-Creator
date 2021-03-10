using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp14
{

    class Program
    {
        static void Main(string[] args)
        {
            ManagerProgramm start = new ManagerProgramm();
            start.Info();

            while (true)
            {
                start.ActionMenu();

                Operation op;
                Enum.TryParse(Console.ReadLine(), out op);

                switch (op)
                {
                    case Operation.Resize:
                        {
                            start.ResizeParametrs();

                            ThreadPool.QueueUserWorkItem(ManagerProgramm.Resize);
                            //Thread myThread = new Thread(new ThreadStart(Resize));
                                //myThread.IsBackground = true;
                                //myThread.Start();
                        }

                        break;
                    case Operation.Rename:
                        {
                            Console.WriteLine("Enter new name");
                            start.Name = Console.ReadLine();
                            ThreadPool.QueueUserWorkItem(ManagerProgramm.Rename, start.Name);
                            //Thread myThreadRename = new Thread(new ParameterizedThreadStart(Rename));
                            //myThreadRename.IsBackground = true;
                            //myThreadRename.Start(start.Name);
                        }

                        break;
                    case Operation.Exit:
                        Environment.Exit(0);

                        break;
                    default:
                        start.Default();
                        break;
                }
            }   
        }
    }
}