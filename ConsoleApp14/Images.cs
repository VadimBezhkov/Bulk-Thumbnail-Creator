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
        public delegate void InfoUser();
        public event InfoUser EventActionMenu, EventResultInfo, EventResultRenameInfo;

        //My variables
        public static int width { get; set; }
        public static int height { get; set; }

        static int count = 0;

        internal static string path { get; set; }
        internal static string path2 { get; set; }
        public string Name { get; set; }

        internal void ResizeParametrs(int width, int height)
        {
            Images.width = width;
            Images.height = height;
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
        public void Resize(CancellationToken token)
        {
            string[] files = Directory.GetFiles(path);

            foreach (string image in files)
            {
                if (token.IsCancellationRequested)
                {
                    if (EventActionMenu != null)
                        EventActionMenu();
                    return;
                }

                Bitmap images = new Bitmap(image);
                Bitmap img = new Bitmap(images, new Size(width, height));
                count++;
                img.Save($"{path2}\\final {count} .jpg");
            }

            if (EventResultInfo != null)
                EventResultInfo();      
        }

        //Method rename my images
        public void Rename(object name)
        {
            int count = 0;
            string[] images = Directory.GetFiles(path2);

            foreach (var item in images)
            {
                count++;
                File.Move(item, $"{path2}\\{(string)name} {count} .jpg");
            }

                EventResultRenameInfo?.Invoke();
        }
    }
}
