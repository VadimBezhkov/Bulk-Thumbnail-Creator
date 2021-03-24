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
    internal class ManagerProgramm
    {
        //My variables
        static object locker = new object();
        static int width, height;
        static int count = 0;

        internal static string path { get; set; }
        internal static string path2 { get; set; }
        public string Name { get; set; }

        // Add Constructor
        public ManagerProgramm(bool str)
        {
            path = System.Configuration.ConfigurationManager.AppSettings["mypath"];
            path2 = System.Configuration.ConfigurationManager.AppSettings["resultpath"];

            if (!Directory.Exists(path2))
            {
                Directory.CreateDirectory(path2);
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        //Default constructor
        public ManagerProgramm() 
        { }

        //Homework information
        internal void Info()
        {
            Console.WriteLine(new string('-', 119));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t \t \t \t \t Homework Bulk Thumbnail  Creator");
            Console.WriteLine("\t \t \t \t \t         By Vadim Bezhkov");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(new string('-', 120));
        }

        // Text menu info
        internal void ActionMenu()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Press enter 1 - Resize all image");
            Console.WriteLine("Press enter 2 - Rename all image");
            Console.WriteLine("Press enter 4 - Exit");
        }

        //Checking and setting the image size
        internal void ResizeParametrs()
        {
            Console.WriteLine("Enter width");
            int.TryParse(Console.ReadLine(), out width);

            Console.WriteLine("Enter height");
            int.TryParse(Console.ReadLine(), out height);

        }

        // Incorrect choice
        internal void Default()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("Error enter number 1 or 2 or 3");
            Console.WriteLine();
            Console.ResetColor();
        }

        //Method change the image and copy to the selected folder
        public static void Resize(CancellationToken token)
        {
            string[] files = Directory.GetFiles(path);

            foreach (string image in files)
            {
                if (token.IsCancellationRequested)
                {
                    Console.Clear();
                    Console.WriteLine(new string('-', 119));
                    Console.WriteLine("Task canceled");
                    Console.WriteLine(new string('-', 119));

                    ManagerProgramm asd = new ManagerProgramm();
                    asd.ActionMenu();
                    return;
                }

                Bitmap images = new Bitmap(image);
                Bitmap img = new Bitmap(images, new Size(width, height));
                count++;
                img.Save($"{path2}\\final {count} .jpg");

            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All image resize!!!!!!!!");
            Console.WriteLine();
            Console.ResetColor();
        }

        //Method rename my images
        public static void Rename(object name)
        {
            int count = 0;
            string[] images = Directory.GetFiles(path2);

            foreach (var item in images)
            {
                count++;
                File.Move(item, $"{path2}\\{(string)name} {count} .jpg");
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All image rename!!!!");
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
