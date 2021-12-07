using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilgisayarlaGoru.Netlestirme
{
    public partial class MainForm : Form
    {
        Bitmap originalBitmap;
        Bitmap smoothBitmap;

        int[,,] originalImageBuffer;
        int[,,] smoothImageBuffer;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

            if (open.ShowDialog() == DialogResult.OK)
            {
                originalBitmap = new Bitmap(open.FileName);

                originalImageBuffer = new int[3, originalBitmap.Height, originalBitmap.Width];

                smoothBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);
                smoothImageBuffer = new int[3, originalBitmap.Height, originalBitmap.Width];

                ReadPixel();

                picture_Original.Image = originalBitmap;
            }
        }

        private void ReadPixel()
        {
            for (int row = 0; row < originalBitmap.Height; row++)
            {
                for (int column = 0; column < originalBitmap.Width; column++)
                {
                    Color color = originalBitmap.GetPixel(column, row);

                    originalImageBuffer[0, row, column] = color.R;
                    originalImageBuffer[1, row, column] = color.G;
                    originalImageBuffer[2, row, column] = color.B;
                }
            }
        }

        private void btn_Process_Click(object sender, EventArgs e)
        {
            MeanFilter();
        }

        private void MeanFilter()
        {
            int value = Convert.ToInt16(cmb_MeanValue.SelectedItem);

            for (int x = (value - 1) / 2; x < originalBitmap.Width - (value - 1) / 2; x++)
            {
                for (int y = (value - 1) / 2; y < originalBitmap.Height - (value - 1) / 2; y++)
                {
                    int sumR = 0, sumG = 0, sumB = 0;

                    for (int i = -((value - 1) / 2); i <= (value - 1) / 2; i++)
                    {
                        for (int j = -((value - 1) / 2); j <= (value - 1) / 2; j++)
                        {
                            Color color = originalBitmap.GetPixel(x + i, y + j);

                            sumR += color.R;
                            sumG += color.G;
                            sumB += color.B;
                        }
                    }

                    int averageR = sumR / (value * value);
                    int averageG = sumG / (value * value);
                    int averageB = sumB / (value * value);

                    Color avarageColor = Color.FromArgb(averageR, averageG, averageB);

                    smoothBitmap.SetPixel(x, y, avarageColor);

                    smoothImageBuffer[0, y, x] = avarageColor.R;
                    smoothImageBuffer[1, y, x] = avarageColor.G;
                    smoothImageBuffer[2, y, x] = avarageColor.B;

                    picture_Smooth.Image = smoothBitmap;
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cmb_MeanValue.SelectedIndex = 3;
        }
    }
}
