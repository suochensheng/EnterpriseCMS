using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ApplicationUtility
{
    public class ImageHelper
    {
        public static string Resize(string fullpath, int width, int height)
        {
            string extension = Path.GetExtension(fullpath);
            string fn = Path.GetFileNameWithoutExtension(fullpath);
            string newDirectory = Path.GetDirectoryName(fullpath).Replace("\\", "/");
            string old_image = fullpath;
            //string new_image = newDirectory + "/" + fn + '-' + width + 'x' + height + extension;
            string new_image = newDirectory + "/" + fn + extension;

            Bitmap original = new Bitmap(old_image);

            //int originalAspectRadio = (int)((float)original.Width / (float)original.Height * 100L);
            //int destAspectRadio = (int)((float)width / (float)height * 100L);

            //int nwidth;
            //int nheight;

            //int x, y;

            //if (originalAspectRadio > destAspectRadio)
            //{
            //    nwidth = width;
            //    nheight = (int)((float)height / originalAspectRadio * 100L);

            //    x = 0;
            //    y = (height - nheight) / 2;
            //}
            //else
            //{
            //    nheight = height;
            //    nwidth = (int)((float)width * originalAspectRadio / 100L);

            //    x = (width - nwidth) / 2;
            //    y = 0;
            //}
            Bitmap scaled = new Bitmap(width, height, original.PixelFormat);
            Graphics newImage = Graphics.FromImage(scaled);

            newImage.Clear(Color.White);


            //newImage.DrawImage(original, x, y, nwidth, nheight);
            newImage.DrawImage(original, 0, 0, width, height);

            var tempdir = Path.GetDirectoryName(new_image);
            if (!Directory.Exists(tempdir))
                Directory.CreateDirectory(tempdir);
            original.Dispose();
            File.Delete(old_image);
            scaled.Save(new_image);

            scaled.Dispose();

            newImage.Dispose();
         
            return new_image;
        }


        public static string Resize(string fullpath, int width, int height, string newDirectory)
        {
            string extension = Path.GetExtension(fullpath);
            string fn = Path.GetFileName(fullpath);
            newDirectory = newDirectory.Replace("\\", "/");
            string old_image = fullpath;
            string new_image = newDirectory + "/" + fn;

            Bitmap original = new Bitmap(old_image);

            //int originalAspectRadio = (int)((float)original.Width / (float)original.Height * 100L);
            //int destAspectRadio = (int)((float)width / (float)height * 100L);

            //int nwidth;
            //int nheight;

            //int x, y;

            //if (originalAspectRadio > destAspectRadio)
            //{
            //    nwidth = width;
            //    nheight = (int)((float)height / originalAspectRadio * 100L);

            //    x = 0;
            //    y = (height - nheight) / 2;
            //}
            //else
            //{
            //    nheight = height;
            //    nwidth = (int)((float)width * originalAspectRadio / 100L);

            //    x = (width - nwidth) / 2;
            //    y = 0;
            //}
            Bitmap scaled = new Bitmap(width, height, original.PixelFormat);
            Graphics newImage = Graphics.FromImage(scaled);

            newImage.Clear(Color.White);


            newImage.DrawImage(original, 0, 0, width, height);

            var tempdir = Path.GetDirectoryName(new_image);
            if (!Directory.Exists(tempdir))
                Directory.CreateDirectory(tempdir);
            scaled.Save(new_image);


            original.Dispose();

            scaled.Dispose();

            newImage.Dispose();

            return new_image;
        }

    }
}
