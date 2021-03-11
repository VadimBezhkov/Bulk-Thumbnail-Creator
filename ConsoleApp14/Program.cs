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
            ManagerProgramm start = new ManagerProgramm(true);
            start.Info();

            while (true)
            {
                start.ActionMenu();
                CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
                CancellationToken token = cancelTokenSource.Token;

                Operation op;
                Enum.TryParse(Console.ReadLine(), out op);

                switch (op)
                {
                    case Operation.Resize:
                        {
                            start.ResizeParametrs();
                            Task task = new Task(() => ManagerProgramm.Resize(token));
                            task.Start();
                            Console.WriteLine("Enter Y to cancel the operation:");
                            string s = Console.ReadLine();
                            if (s == "Y" || s == "y")
                                cancelTokenSource.Cancel();
                        }

                        break;
                    case Operation.Rename:
                        {
                            Console.WriteLine("Enter new name");
                            start.Name = Console.ReadLine();
                            Task task2 = new Task(ManagerProgramm.Rename, start.Name);
                            task2.Start();
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