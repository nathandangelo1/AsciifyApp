using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;


namespace AsciifyApp
{

    //PUBLIC METHODS
    class BitmapAscii
    {
        public static string Asciitize(BitmapMaker img, int kernelSize)
        {
            //Dictionary<double, string> Map = new Dictionary<double, string> { { .16, "#" }, { 0.33, "=" }, { .50, "*" }, { .66, ":" }, { .83, "," }, { 1, " " } };

            List<Color> colors;
            double avgColor = 0;
            string stringImage = "";
            //int kHincr =0;
            //int kWincr =0;
            //int offset = (kernelSize) - 1 / 2;

            for (int H = 0; H < img.Height; H += kernelSize)
            {
                for (int W = 0; W < img.Width; W += kernelSize)
                {

                    colors = new List<Color>();
                    int khIncr = H + kernelSize;
                    if (khIncr >= img.Height)
                    {
                        khIncr = img.Height;
                    }
                    int kwIncr = W + kernelSize;
                    if (kwIncr >= img.Height)
                    {
                        khIncr = img.Height;
                    }

                    for (int kH = H; kH < khIncr; kH++)
                    {
                        
                        for (int kW = W; kW < kwIncr; kW++)
                        {
                            colors.Add(img.GetPixelColor(kW, kH));
                        }
                    }
                    avgColor = AverageColor(colors);
                    avgColor = Normalize(avgColor);
                    string icon = GrayToString(avgColor);
                    stringImage += icon;
                }
                
                
                stringImage += "\n";
            }
            return stringImage;
        }//END FUNCTION
        public string Asciitize2(BitmapMaker img, int kernelSize)
        {
            //Dictionary<double, string> Map = new Dictionary<double, string> { { .16, "#" }, { 0.33, "=" }, { .50, "*" }, { .66, ":" }, { .83, "," }, { 1, " " } };

            List<Color> colors;
            double avgColor = 0;
            string stringImage = "";
            //int kHincr =0;
            //int kWincr =0;
            //int offset = (kernelSize) - 1 / 2;

            for (int H = 0; H < img.Height; H += kernelSize)
            {
                for (int W = 0; W < img.Width; W += kernelSize)
                {

                    colors = new List<Color>();
                    int khIncr = H + kernelSize;
                    if (khIncr >= img.Height)
                    {
                        khIncr = img.Height;
                    }
                    int kwIncr = W + kernelSize;
                    if (kwIncr >= img.Height)
                    {
                        khIncr = img.Height;
                    }

                    for (int kH = H; kH < khIncr; kH++)
                    {

                        for (int kW = W; kW < kwIncr; kW++)
                        {
                            colors.Add(img.GetPixelColor(kW, kH));
                        }
                    }
                    avgColor = AverageColor(colors);
                    avgColor = Normalize(avgColor);
                    string icon = GrayToString(avgColor);
                    stringImage += icon;
                }


                stringImage += "\n";
            }
            return stringImage;
        }//END FUNCTION
        //public override string ToString() 
        //{

        //}//End Function


        //PRIVATE METHODS
        private static double AveragePixel(int a, int b, int c) 
        {

            double avg = (a + b + c) / 3;
            return avg;

        }//End Function

        private static double AveragePixel(Color color)
        {
            int r = color.R;
            int g = color.G;
            int b = color.B;

            double avg = AveragePixel(r, g, b);

            return avg;
        }//Function
        
        
        private static double AverageColor(List<Color> colors)
        {
            double total = 0;
            int count = 0;
            double avg;

            foreach (Color color in colors)
            {
                total += AveragePixel(color);
                count++;
            }
            avg = total / count;
            return avg;

        }//Function

        private static double Normalize(double avg)
        {
            return avg / 255;
        }


        private static string GrayToString(double grey)
        {
           // Dictionary<double, string> Map = new Dictionary<double, string> { { .16, "#" }, { 0.33, "=" }, { .50, "*" }, { .66, ":" }, { .83, "," }, { 1, " " } };
            string icon = "";

            if (grey <= .16)
            {
                icon = "#";
            }
            else if (grey <= .33)
            {
                icon = "=";
            }
            else if (grey <= .5)
            {
                icon = "*";
            }
            else if (grey <= .66)
            {
                icon = ":";
            }
            else if (grey <= .83)
            {
                icon = ",";
            }
            else
            {
                icon = " ";
            }

            return icon;

        }//Funtion





    }
}
