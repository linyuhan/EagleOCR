using E.AppServices.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.AppServices
{
    public class ImageServices : IImageServices
    {

        private string pathString = System.Configuration.ConfigurationManager.AppSettings["applicationpath"] +"\\Images\\";

        public ImageServices()
        {

        }

        public string SaveImage(Image image, string name)
        {
            string imagePath = "";
            try
            {
                if (System.IO.Directory.Exists(pathString))
                {
                    name = name.Split('.')[0];
                    string pathImg = pathString + name + ".png";
                    image.Save(pathImg);
                    image.Dispose();
                    imagePath = "/Images/" + name + ".png";
                }
                return imagePath;
            }
            catch (Exception e)
            {

                return e.Message.ToString();
            }
        }


        public string GrayScale(Image img, string name)
        {
            
            string imagePath = "";
            try
            {
                if (System.IO.Directory.Exists(pathString))
                {
                    name = name.Split('.')[0]+"-gray";
                    string pathImg = pathString + name + ".png";


                    //gray
                    Bitmap bmpInverted = new Bitmap(img.Width, img.Height);
                    ImageAttributes ia = new ImageAttributes();
                    ColorMatrix cmPicture = new ColorMatrix(new float[][]
                        {
                            new float[] {0.299f, 0.299f, 0.299f, 0, 0},
                            new float[] {0.587f, 0.587f, 0.587f, 0, 0},
                            new float[] {0.114f, 0.114f, 0.114f, 0, 0},
                            new float[] {     0,      0,      0, 1, 0},
                            new float[] {     0,      0,      0, 0, 0}
                        });
                    ia.SetColorMatrix(cmPicture);
                    Graphics g = Graphics.FromImage(bmpInverted);
                    g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, ia);
                    g.Dispose();



                    bmpInverted.Save(pathImg);
                    bmpInverted.Dispose();
                    imagePath = "/Images/" + name + ".png";
                }
                return imagePath;
            }
            catch (Exception e)
            {

                return e.Message.ToString();
            }
        }
    }
}
