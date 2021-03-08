﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    enum Operation:byte
    {
        Resize=1,
        Rename
        Exit
    }
    class Program
    {
        private static string path = @"D:\MyImage";
        private static string path2 = @"D:\MyImageSize";
        static int width, height;
        static int count = 0;
        public string Name { get; set; }
        //static object locker = new object();
        public void ActionMenu()
        {
            Console.WriteLine("Press enter 1 - Resize all image");
            Console.WriteLine("Press enter 2 - Rename all image");
            Console.WriteLine("Press enter 3 - Exit");
        }

        public void ResizeParametrs()
        {
            Console.WriteLine("Enter width");
            Console.WriteLine("Enter height");

            int.TryParse(Console.ReadLine(), out width);
            int.TryParse(Console.ReadLine(), out height);

        }
        static void Main(string[] args)
        {
            Program start = new Program();
            start.ActionMenu();

            Operation op;
            Enum.TryParse(Console.ReadLine(), out op);
            switch (op)
            {
                case Operation.Resize:
                    {
                        start.ResizeParametrs();
                        Thread myThread = new Thread(new ThreadStart(Resize));
                        myThread.IsBackground = true;
                        Console.WriteLine(myThread.Name);
                        myThread.Start();
                    }

                    break;
                case Operation.Rename:
                    {
                        Console.WriteLine("Enter new name");
                        start.Name = Console.ReadLine();
                        Thread myThreadRename = new Thread(new ParameterizedThreadStart(Rename));
                        myThreadRename.IsBackground = true;
                        Console.WriteLine(myThreadRename.Name);
                        myThreadRename.Start(start.Name);
                    }

                    break;
                case Operation.Exit:
                    Environment.Exit(0);
                    break;
            }

            if (!Directory.Exists(path2))
            {
                Directory.CreateDirectory(path2);
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            Console.ReadKey();
        }
        public static void Resize()
        {
            //lock (locker)
            //{
                string[] files = Directory.GetFiles(path);
                foreach (string image in files)
                {
                    Bitmap images = new Bitmap(image);
                    Bitmap img = new Bitmap(images, new Size(width, height));
                    count++;
                    Console.WriteLine($"name {image}  images count {count}");
                    img.Save($"{path2}\\final {count} .jpg");
                }
            //}
        }
        public static void Rename(object x)
        {
            int count = 0;
            string[] images = Directory.GetFiles(path2);
            foreach (var item in images)
            {
                count++;
                File.Move(item, $"{path2}\\{x} {count} .jpg");
            }
        }
    }
}