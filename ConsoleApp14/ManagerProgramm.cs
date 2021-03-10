using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    enum Operation : byte
    {
        Resize = 1,
        Rename,
        Exit
    }
    internal class ManagerProgramm
    {
        static object locker = new object();
        static int width, height;
        static int count = 0;
        internal static string path { get; set; }
        internal static string path2 { get; set; }

        public string Name { get; set; }
        public ManagerProgramm()
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
        public void Info()
        {
            Console.WriteLine(new string('-', 119));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t \t \t \t \t Homework Bulk Thumbnail  Creator");
            Console.WriteLine("\t \t \t \t \t         By Vadim Bezhkov");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(new string('-', 120));
        }
        public void ActionMenu()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Press enter 1 - Resize all image");
            Console.WriteLine("Press enter 2 - Rename all image");
            Console.WriteLine("Press enter 3 - Exit");
        }

        public void ResizeParametrs()
        {
            Console.WriteLine("Enter width");
            int.TryParse(Console.ReadLine(), out width);

            Console.WriteLine("Enter height");
            int.TryParse(Console.ReadLine(), out height);

        }
        public static void Resize(object state)
        {
            lock (locker)
            {
                string[] files = Directory.GetFiles(path);

                foreach (string image in files)
                {
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
        }
        public static void Rename(object x)
        {
            lock (locker)
            {
                int count = 0;
                string[] images = Directory.GetFiles(path2);

                foreach (var item in images)
                {
                    count++;
                    File.Move(item, $"{path2}\\{x} {count} .jpg");
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("All image rename!!!!");
                Console.WriteLine();
                Console.ResetColor();
            }
        }
    }
}
