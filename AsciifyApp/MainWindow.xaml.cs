using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsciifyApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BitmapImage bmpImage;
        BitmapMaker bmpMaker;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void muiOpen_Click(object sender, RoutedEventArgs e)
        {
            // CREATE OPEN FILE DIALOG
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // SETUP PARAMETERS 
            openFileDialog.DefaultExt = ".png";
            openFileDialog.Filter = "Image Files (.png)|*.png";


            // SHOW FILE DIALOG
            bool? result = openFileDialog.ShowDialog();

            //PROCESS OPEN DIALOG RESULTS
            if (result == true)
            {
                string selectedFile = openFileDialog.FileName;
                LoadImage(selectedFile);
            }

        }// End Event
        private void LoadImage(string path)
        {
            // CREATE BITMAP FOR IMAGE DATA
            bmpImage = new BitmapImage();

            bmpMaker = new BitmapMaker(path);


            // CREATE URI TO REFERENCE PATH TO IMAGE
            Uri uriImage = new Uri(path);

            // INIT BITMAP TO LOAD DATA
            bmpImage.BeginInit();
            bmpImage.UriSource = uriImage; // tell bitmap where to find via uri
            bmpImage.EndInit();

            // SETS IMAGE CONTROL TO DISPLAY THE IMAGE
            imgMain.Source = bmpImage;

        }// end LoadImage

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            bool success;
            do
            {
                success = int.TryParse(txtKernelSize.Text, out int kSize);

                if (success)
                {
                    //string textImage = BitmapAscii.Asciitize(bmpMaker, kSize);
                    //txtAsciiImage.Text = textImage;

                    BitmapAscii bmpAscii = new BitmapAscii();
                    string textImage = bmpAscii.Asciitize2(bmpMaker, kSize);
                    txtAsciiImage.Text = textImage;
                }
                else txtAsciiImage.Text = "";

            } while (success == false);
            
        }//end click

    }//end class
}// end namespace
