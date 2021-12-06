using System;
using System.Drawing;
using System.Windows.Forms;

namespace BilgisayarlaGoru.Netlestirme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_ImageSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

            if (open.ShowDialog() == DialogResult.OK)
            {
                image_Select.Image = new Bitmap(open.FileName);
            }
        }

        private void btn_Sharpening_Click(object sender, EventArgs e)
        {
            Bitmap selectImage = new Bitmap(image_Select.Image);

            Bitmap blurryImage = MeanFilter(selectImage);

            image_Blur.Image = blurryImage;

            Bitmap edgeViewImage = PictureExtraction(selectImage, blurryImage);

            image_Edge.Image = edgeViewImage;

            Bitmap sharpeImage = PictureAdd(selectImage, edgeViewImage);

            image_Shape.Image = sharpeImage;
        }

        private Bitmap SetGrayImage(Bitmap image)
        {
            Color OkunanRenk, DonusenRenk;

            int ResimGenisligi = image.Width; //GirisResmi global tanımlandı. Fonksiyonla gelmedi.
            int ResimYuksekligi = image.Height;
            Bitmap outputImage = new Bitmap(ResimGenisligi, ResimYuksekligi);

            int GriDeger = 0;
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = image.GetPixel(x, y);
                    double R = OkunanRenk.R;
                    double G = OkunanRenk.G;
                    double B = OkunanRenk.B;

                    GriDeger = Convert.ToInt16(R * 0.3 + G * 0.6 + B * 0.1);
                    DonusenRenk = Color.FromArgb(GriDeger, GriDeger, GriDeger);
                    outputImage.SetPixel(x, y, DonusenRenk);
                }
            }

            return outputImage;
        }

        private Bitmap MeanFilter(Bitmap image)
        {
            Color readColor;

            Bitmap outputImage;

            int w = image.Width;
            int h = image.Height;

            outputImage = new Bitmap(w, h);

            int template = (int)nmbr_1.Value;

            int x, y, i, j, sumR, sumG, sumB, averageR, averageG, averageB;

            for (x = (template - 1) / 2; x < w - (template - 1) / 2; x++)
            {
                for (y = (template - 1) / 2; y < h - (template - 1) / 2; y++)
                {
                    sumR = 0;
                    sumG = 0;
                    sumB = 0;

                    for (i = -((template - 1) / 2); i <= (template - 1) / 2; i++)
                    {
                        for (j = -((template - 1) / 2); j <= (template - 1) / 2; j++)
                        {
                            readColor = image.GetPixel(x + i, y + j);

                            sumR += readColor.R;
                            sumG += readColor.G;
                            sumB += readColor.B;
                        }
                    }

                    averageR = sumR / (template * template);
                    averageG = sumG / (template * template);
                    averageB = sumB / (template * template);

                    outputImage.SetPixel(x, y, Color.FromArgb(averageR, averageG, averageB));
                }
            }

            return outputImage;
        }

        public Bitmap PictureExtraction(Bitmap originalImage, Bitmap image)
        {
            Color readColor_1, readColor_2, color; 
            Bitmap outputImage;

            int w = originalImage.Width; 
            int h = originalImage.Height;

            outputImage = new Bitmap(w, h);

            int R, G, B; 

            double scaling = (double)nmbr_2.Value; //Keskin kenaları daha iyi görmek için değerini artırıyoruz.

            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    readColor_1 = originalImage.GetPixel(x, y);
                    readColor_2 = image.GetPixel(x, y);

                    R = Convert.ToInt16(scaling * Math.Abs(readColor_1.R - readColor_2.R));
                    G = Convert.ToInt16(scaling * Math.Abs(readColor_1.G - readColor_2.G));
                    B = Convert.ToInt16(scaling * Math.Abs(readColor_1.B - readColor_2.B));

                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;

                    if (R < 0) R = 0;
                    if (G < 0) G = 0;
                    if (B < 0) B = 0;

                    color = Color.FromArgb(R, G, B); 
                    outputImage.SetPixel(x, y, color);
                }
            }
            return outputImage;
        }

        public Bitmap PictureAdd(Bitmap originalImage, Bitmap image)
        {
            Color readColor_1, readColor_2, color;
            Bitmap outputImage;

            int w = originalImage.Width;
            int h = originalImage.Height;

            outputImage = new Bitmap(w, h);

            int R, G, B;

            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    readColor_1 = originalImage.GetPixel(x, y);
                    readColor_2 = image.GetPixel(x, y);

                    R = readColor_1.R + readColor_2.R;
                    G = readColor_1.G + readColor_2.G;
                    B = readColor_1.B + readColor_2.B;

                    //Renkler sınırların dışına çıktıysa, sınır değer alınacak.
                    //DİKKAT: Burada sınırı aşan değerler NORMALİZASYON yaparak programlanmalıdır.

                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;

                    if (R < 0) R = 0;
                    if (G < 0) G = 0;
                    if (B < 0) B = 0;

                    color = Color.FromArgb(R, G, B);
                    outputImage.SetPixel(x, y, color);
                }
            }
            return outputImage;
        }
    }
}
