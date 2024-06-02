using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowMeter
{
    internal class BitmapOperations
    {
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        extern public static bool DestroyIcon(IntPtr handle);

        public static void ConvertToIco(Image img, string file, int size)
        {
            Icon icon;
            using (var msImg = new MemoryStream())
            using (var msIco = new MemoryStream())
            {
                img.Save(msImg, ImageFormat.Png);
                using (var bw = new BinaryWriter(msIco))
                {
                    bw.Write((short)0);           //0-1 reserved
                    bw.Write((short)1);           //2-3 image type, 1 = icon, 2 = cursor
                    bw.Write((short)1);           //4-5 number of images
                    bw.Write((byte)size);         //6 image width
                    bw.Write((byte)size);         //7 image height
                    bw.Write((byte)0);            //8 number of colors
                    bw.Write((byte)0);            //9 reserved
                    bw.Write((short)0);           //10-11 color planes
                    bw.Write((short)32);          //12-13 bits per pixel
                    bw.Write((int)msImg.Length);  //14-17 size of image data
                    bw.Write(22);                 //18-21 offset of image data
                    bw.Write(msImg.ToArray());    // write image data
                    bw.Flush();
                    bw.Seek(0, SeekOrigin.Begin);
                    icon = new Icon(msIco);
                }
            }
            using (var fs = new FileStream(file, FileMode.Create, FileAccess.Write))
            {
                icon.Save(fs);
            }
        }

        public static void SaveIconWithDepth(Bitmap bitmap, string outputPath)
        {
            // Assuming bitmap is already in the correct format
            Icon icon = Icon.FromHandle(bitmap.GetHicon());

            using (FileStream fs = new FileStream(outputPath, FileMode.Create))
            {
                // Write to output stream as .ico
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    // ICONDIR structure
                    writer.Write((short)0);    // Reserved must be 0
                    writer.Write((short)1);    // Image type, 1 for icon
                    writer.Write((short)1);    // Number of images

                    // ICONDIRENTRY structure for each image
                    writer.Write((byte)bitmap.Width);
                    writer.Write((byte)bitmap.Height);
                    writer.Write((byte)0);     // Colors; 0 means no palette
                    writer.Write((byte)0);     // Reserved must be 0
                    writer.Write((short)0);    // Color planes
                    writer.Write((short)32);   // Bits per pixel
                    writer.Write((int)bitmap.Width * bitmap.Height * 4);  // Size of data in bytes

                    // Write pixel data
                    BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                        ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

                    byte[] pixelData = new byte[bmpData.Stride * bmpData.Height];
                    System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, pixelData, 0, pixelData.Length);
                    bitmap.UnlockBits(bmpData);

                    writer.Write(pixelData);  // Pixel data
                }
            }
            // Cleanup native icon
            DestroyIcon(icon.Handle);
        }

        public static void ConvertBitmapToIcon(Bitmap bitmap, string outputPath)
        {

            Bitmap clone = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format64bppPArgb);

            using (Graphics g = Graphics.FromImage(clone))
            {
                g.DrawImage(bitmap, new Rectangle(0, 0, clone.Width, clone.Height));
            }

            //bitmap.MakeTransparent(Color.White);  
            Icon icon = Icon.FromHandle(clone.GetHicon());

            using (FileStream fs = new FileStream(outputPath, FileMode.Create))
            {
                icon.Save(fs);
            }

            DestroyIcon(icon.Handle);
        }

        public static Bitmap ResizeImage(Bitmap image, int width, int height, bool maintainAspectRatio = true)
        {
            if (maintainAspectRatio)
            {

                double aspectRatio = (double)image.Width / image.Height;
                if (width / (double)height > aspectRatio)
                    width = (int)(height * aspectRatio);
                else
                    height = (int)(width / aspectRatio);
            }

            Bitmap resizedImage = new Bitmap(width, height);


            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.DrawImage(image, 0, 0, width, height);
            }

            return resizedImage;
        }

        public static Bitmap CropToCenter(Bitmap image, int targetWidth, int targetHeight)
        {
            int startX = (image.Width - targetWidth) / 2;
            int startY = (image.Height - targetHeight) / 2;

            startX = Math.Max(startX, 0);
            startY = Math.Max(startY, 0);

            int width = Math.Min(targetWidth, image.Width);
            int height = Math.Min(targetHeight, image.Height);

            Rectangle cropArea = new Rectangle(startX, startY, width, height);

            Bitmap croppedImage = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(croppedImage))
            {
                graphics.DrawImage(image, 0, 0, cropArea, GraphicsUnit.Pixel);
            }

            return croppedImage;
        }

    }
}
