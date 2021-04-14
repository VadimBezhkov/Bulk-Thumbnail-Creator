using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class ManagerProgramm
    {
        public void StartProgramm()
        {
            Images image = new Images(true);
            image.EventActionMenu += WorkWithText.ActionMenu;
            image.EventResultInfo += WorkWithText.ResultInfo;
            image.EventResultRenameInfo += WorkWithText.ResultRenameInfo;

            WorkWithText.Info();

            while (true)
            {
                WorkWithText.ActionMenu();
                CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
                CancellationToken token = cancelTokenSource.Token;

                Operation op;
                Enum.TryParse(Console.ReadLine(), out op);

                switch (op)
                {
                    // Choise resize my images
                    case Operation.Resize:
                        {
                            WorkWithText.ResizeParametrs(out int width, out int height);
                            image.ResizeParametrs(width, height);

                            Task task = new Task(() => image.Resize(token));
                            task.Start();

                            WorkWithText.CancelInfo();
                            string s = WorkWithText.ReceiveValue();
                            if (s == "Y" || s == "y")
                            {
                                cancelTokenSource.Cancel();
                                WorkWithText.OperationCancel();
                            }
                        }

                        break;
                    //Choise rename my images
                    case Operation.Rename:
                        {
                            WorkWithText.NewNameInfo();
                            image.Name = WorkWithText.ReceiveValue();

                            Task task2 = new Task(image.Rename, image.Name);
                            task2.Start();
                        }

                        break;
                    //exit this programm
                    case Operation.Exit:
                        Environment.Exit(0);

                        break;
                    default:
                        WorkWithText.Default();
                        break;
                }
            }
        }
    }
}
