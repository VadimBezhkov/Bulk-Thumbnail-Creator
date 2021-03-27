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
    internal class Images
    {
        //My variables
        static int width, height;
        static int count = 0;

        internal static string path { get; set; }
        internal static string path2 { get; set; }
        public string Name { get; set; }

        //Checking and setting the image size
        internal void ResizeParametrs()
        {
            Console.WriteLine("Enter width");
            int.TryParse(Console.ReadLine(), out width);

            Console.WriteLine("Enter height");
            int.TryParse(Console.ReadLine(), out height);
        }

        // Add Constructor
        public Images(bool str)
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

        //Method Resize images
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

            ManagerProgramm result = new ManagerProgramm();
            result.ResultInfo();
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

            ManagerProgramm result = new ManagerProgramm();
            result.ResultRenameInfo();
        }
    }
}
