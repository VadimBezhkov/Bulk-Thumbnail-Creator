using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class WorkWithText
    {
        public static void Info()
        {
            Console.WriteLine(new string('-', 119));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t \t \t \t \t Homework Bulk Thumbnail  Creator");
            Console.WriteLine("\t \t \t \t \t         By Vadim Bezhkov");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(new string('-', 120));
        }

        //Result operation Rename
        public static void ResultRenameInfo()
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All image rename!!!!");
            Console.WriteLine();
            Console.ResetColor();
            ActionMenu();
        }

        //Result operation Resize
        public static void ResultInfo()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All image resize!!!!!!!!");
            Console.WriteLine("press any button to continue");
            Console.ResetColor();
        }

        // Text menu info
        public static void ActionMenu()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Press enter 1 - Resize all image");
            Console.WriteLine("Press enter 2 - Rename all image");
            Console.WriteLine("Press enter 3 - Exit");
        }

        //Checking and setting the image size
        public static void ResizeParametrs(out int width, out int height)
        {
            Console.WriteLine("Enter width");
            int.TryParse(Console.ReadLine(), out width);

            Console.WriteLine("Enter height");
            int.TryParse(Console.ReadLine(), out height);
        }

        // Incorrect choice
        public static void Default()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("Error enter number 1 or 2 or 3");
            Console.WriteLine();
            Console.ResetColor();
        }

        // Display text Cancel Operation
        public static void OperationCancel()
        {
            Console.Clear();
            Console.WriteLine(new string('-', 119));
            Console.WriteLine("Task canceled");
            Console.WriteLine(new string('-', 119));
        }

        // Key info to cancel the operation
        public static void CancelInfo()
        {
            Console.WriteLine("Enter Y to cancel the operation:");
        }

        //Info new name Images
        public static void NewNameInfo()
        {
            Console.WriteLine("Enter new name");
        }

        public static string ReceiveValue() => Console.ReadLine();
    }
}
