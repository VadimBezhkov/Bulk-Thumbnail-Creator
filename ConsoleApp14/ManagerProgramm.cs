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
        //Default constructor
        public ManagerProgramm() { }

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

        //Result operation Rename
        public void ResultRenameInfo()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All image rename!!!!");
            Console.WriteLine();
            Console.ResetColor();
        }

        //Result operation Resize
        internal void ResultInfo()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All image resize!!!!!!!!");
            Console.WriteLine();
            Console.ResetColor();
        }

        // Text menu info
        internal void ActionMenu()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Press enter 1 - Resize all image");
            Console.WriteLine("Press enter 2 - Rename all image");
            Console.WriteLine("Press enter 3 - Exit");
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
    }
}
