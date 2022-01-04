using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilgisayarlaGoru.Netlestirme
{
    public enum Filter
    {
        Mean = 0,
        Median = 1,
        Gaussian = 2
    }

    public enum NormalizationType
    {
        Single = 0,
        Multiple = 1
    }
    public enum ImageColor
    {
        RGB = 0,
        Gray = 1
    }

    public partial class MainForm : Form
    {
        Filter selectFilter = Filter.Mean;
        NormalizationType normalizationType = NormalizationType.Multiple;
        ImageColor imageColor = ImageColor.RGB;

        Bitmap originalBitmap = null;
        Bitmap smoothBitmap = null;
        Bitmap edgeBitmap = null;
        Bitmap sharpBitmap = null;

        int[,,] originalImageBuffer;
        int[,,] smoothImageBuffer;
        int[,,] edgeImageBuffer;
        int[,,] edgeNormalizationImageBuffer;
        int[,,] sharpImageBuffer;
        int[,,] sharpNormalizationImageBuffer;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            cmb_FilterValue.SelectedIndex = 1;
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

            if (open.ShowDialog() == DialogResult.OK)
            {
                originalBitmap = new Bitmap(open.FileName);

                originalImageBuffer = ReadPixel(originalBitmap);

                smoothBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);

                picture_Original.Image = originalBitmap;
            }
        }

        private void btn_Process_Click(object sender, EventArgs e)
        {
            if (originalBitmap is null)
            {
                MessageBox.Show("İşlenecek öğe bulunamadı !", "Görüntü Netleştirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            toolStrip1.Enabled = false;
            btn_Loading.Visible = true;

            switch (imageColor)
            {
                case ImageColor.RGB:
                    switch (selectFilter)
                    {
                        case Filter.Mean:
                            smoothBitmap = MeanFilter(originalBitmap);
                            break;
                        case Filter.Median:
                            smoothBitmap = MedianFilter(originalBitmap);
                            break;
                        case Filter.Gaussian:
                            smoothBitmap = GaussianFilter(originalBitmap);
                            break;
                    }

                    smoothImageBuffer = ReadPixel(smoothBitmap);

                    picture_Smooth.Image = smoothBitmap;

                    edgeImageBuffer = PictureExtraction(originalBitmap, smoothBitmap);

                    switch (normalizationType)
                    {
                        case NormalizationType.Single:
                            edgeNormalizationImageBuffer = SingleNormalization(edgeImageBuffer);
                            break;
                        case NormalizationType.Multiple:
                            edgeNormalizationImageBuffer = Normalization(edgeImageBuffer);
                            break;
                    }

                    edgeBitmap = BufferToImage(edgeNormalizationImageBuffer);

                    picture_Edge.Image = edgeBitmap;

                    sharpImageBuffer = PictureAdd(originalBitmap, edgeBitmap);

                    switch (normalizationType)
                    {
                        case NormalizationType.Single:
                            sharpNormalizationImageBuffer = SingleNormalization(sharpImageBuffer);
                            break;
                        case NormalizationType.Multiple:
                            sharpNormalizationImageBuffer = Normalization(sharpImageBuffer);
                            break;
                    }

                    sharpBitmap = BufferToImage(sharpNormalizationImageBuffer);

                    picture_Sharp.Image = sharpBitmap;
                    break;
                case ImageColor.Gray:
                    Bitmap grayBitmap = RgbImageToGrayImage(originalBitmap);
                    ShowForm showForm = new ShowForm(grayBitmap);
                    showForm.Show();

                    switch (selectFilter)
                    {
                        case Filter.Mean:
                            smoothBitmap = MeanFilter(grayBitmap);
                            break;
                        case Filter.Median:
                            smoothBitmap = MedianFilter(grayBitmap);
                            break;
                        case Filter.Gaussian:
                            smoothBitmap = GaussianFilter(grayBitmap);
                            break;
                    }

                    smoothImageBuffer = ReadPixel(smoothBitmap);

                    picture_Smooth.Image = smoothBitmap;

                    edgeImageBuffer = PictureExtraction(grayBitmap, smoothBitmap);

                    switch (normalizationType)
                    {
                        case NormalizationType.Single:
                            edgeNormalizationImageBuffer = SingleNormalization(edgeImageBuffer);
                            break;
                        case NormalizationType.Multiple:
                            edgeNormalizationImageBuffer = Normalization(edgeImageBuffer);
                            break;
                    }

                    edgeBitmap = BufferToImage(edgeNormalizationImageBuffer);

                    picture_Edge.Image = edgeBitmap;

                    sharpImageBuffer = PictureAdd(grayBitmap, edgeBitmap);

                    switch (normalizationType)
                    {
                        case NormalizationType.Single:
                            sharpNormalizationImageBuffer = SingleNormalization(sharpImageBuffer);
                            break;
                        case NormalizationType.Multiple:
                            sharpNormalizationImageBuffer = Normalization(sharpImageBuffer);
                            break;
                    }

                    sharpBitmap = BufferToImage(sharpNormalizationImageBuffer);

                    picture_Sharp.Image = sharpBitmap;
                    break;
            }

            toolStrip1.Enabled = true;
            btn_Loading.Visible = false;
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            if (sharpBitmap is null)
            {
                MessageBox.Show("Çıktı alınacak öğe bulunamadı !", "Görüntü Netleştirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                sharpBitmap.Save($"{dialog.FileName}.jpeg", ImageFormat.Jpeg);
            }
        }

        /// <summary>
        /// Bitmap olarak gönderilen resmi int[,,] tipinde döndürür
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        private int[,,] ReadPixel(Bitmap bitmap)
        {
            int[,,] buffer = new int[3, bitmap.Height, bitmap.Width];

            for (int row = 0; row < bitmap.Height; row++)
            {
                for (int column = 0; column < bitmap.Width; column++)
                {
                    Color color = bitmap.GetPixel(column, row);

                    buffer[0, row, column] = color.R;
                    buffer[1, row, column] = color.G;
                    buffer[2, row, column] = color.B;
                }
            }

            return buffer;
        }

        private Bitmap RgbImageToGrayImage(Bitmap bitmap)
        {
            Bitmap outBitmap = new Bitmap(bitmap.Width, bitmap.Height);

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color color = bitmap.GetPixel(x, y);

                    int gray = Convert.ToInt16(color.R * 0.299 + color.G * 0.587 + color.B * 0.114); //Gri ton formülü

                    outBitmap.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }

            return outBitmap;
        }

        /// <summary>
        /// int[,,] tipinde olan resim değerlerini Bitmap tipinde döndürür
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        private Bitmap BufferToImage(int[,,] buffer)
        {
            var height = buffer.GetLength(1);
            var width = buffer.GetLength(2);

            Bitmap bitmap = new Bitmap(width, height);

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int R = buffer[0, i, j];
                    int G = buffer[1, i, j];
                    int B = buffer[2, i, j];

                    bitmap.SetPixel(j, i, Color.FromArgb(R, G, B));
                }
            }

            return bitmap;
        }

        /// <summary>
        /// Bitmap tipindeki resime mean filteresi uygular
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        private Bitmap MeanFilter(Bitmap bitmap)
        {
            int value = Convert.ToInt16(cmb_FilterValue.SelectedItem);
            Bitmap outBitmap = new Bitmap(bitmap.Width, bitmap.Height);

            for (int x = (value - 1) / 2; x < bitmap.Width - (value - 1) / 2; x++)
            {
                for (int y = (value - 1) / 2; y < bitmap.Height - (value - 1) / 2; y++)
                {
                    int sumR = 0, sumG = 0, sumB = 0;

                    for (int i = -((value - 1) / 2); i <= (value - 1) / 2; i++)
                    {
                        for (int j = -((value - 1) / 2); j <= (value - 1) / 2; j++)
                        {
                            Color color = bitmap.GetPixel(x + i, y + j);

                            sumR += color.R;
                            sumG += color.G;
                            sumB += color.B;
                        }
                    }

                    int averageR = sumR / (value * value);
                    int averageG = sumG / (value * value);
                    int averageB = sumB / (value * value);

                    Color avarageColor = Color.FromArgb(averageR, averageG, averageB);

                    outBitmap.SetPixel(x, y, avarageColor);
                }
            }

            return outBitmap;
        }

        /// <summary>
        /// Bitmap tipindeki resime median filteresi uygular
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        private Bitmap MedianFilter(Bitmap bitmap)
        {
            int value = Convert.ToInt16(cmb_FilterValue.SelectedItem);
            Bitmap outBitmap = new Bitmap(bitmap.Width, bitmap.Height);

            int numberOfElements = value * value;

            int[] R = new int[numberOfElements];
            int[] G = new int[numberOfElements];
            int[] B = new int[numberOfElements];
            int[] Gray = new int[numberOfElements];

            int x, y, i, j;

            for (x = (value - 1) / 2; x < bitmap.Width - (value - 1) / 2; x++)
            {
                for (y = (value - 1) / 2; y < bitmap.Height - (value - 1) / 2; y++)
                {
                    //Şablon bölgesi (çekirdek matris) içindeki pikselleri tarıyor.
                    int k = 0;
                    for (i = -((value - 1) / 2); i <= (value - 1) / 2; i++)
                    {
                        for (j = -((value - 1) / 2); j <= (value - 1) / 2; j++)
                        {
                            Color color = bitmap.GetPixel(x + i, y + j);
                            R[k] = color.R;
                            G[k] = color.G;
                            B[k] = color.B;

                            Gray[k] = Convert.ToInt16(R[k] * 0.299 + G[k] * 0.587 + B[k] * 0.114); //Gri ton formülü
                            k++;
                        }
                    }

                    //Gri tona göre sıralama yapıyor. Aynı anda üç rengide değiştiriyor.
                    int temp = 0;

                    for (i = 0; i < numberOfElements; i++)
                    {
                        for (j = i + 1; j < numberOfElements; j++)
                        {
                            if (Gray[j] < Gray[i])
                            {
                                temp = Gray[i];
                                Gray[i] = Gray[j];
                                Gray[j] = temp;
                                temp = R[i];
                                R[i] = R[j];
                                R[j] = temp;
                                temp = G[i];
                                G[i] = G[j];
                                G[j] = temp;
                                temp = B[i];
                                B[i] = B[j];
                                B[j] = temp;
                            }
                        }
                    }

                    outBitmap.SetPixel(x, y, Color.FromArgb(R[(numberOfElements - 1) / 2], G[(numberOfElements - 1) / 2], B[(numberOfElements - 1) / 2]));
                }
            }

            return outBitmap;
        }

        private Bitmap GaussianFilter(Bitmap bitmap)
        {
            int value = Convert.ToInt16(cmb_FilterValue.SelectedItem);

            int[] gauss = GaussianBlur(value, 1);

            int gaussSum = gauss.ToList().Sum();

            Bitmap outBitmap = new Bitmap(bitmap.Width, bitmap.Height);

            for (int x = (value - 1) / 2; x < bitmap.Width - (value - 1) / 2; x++)
            {
                for (int y = (value - 1) / 2; y < bitmap.Height - (value - 1) / 2; y++)
                {
                    long sumR = 0, sumG = 0, sumB = 0;
                    int k = 0;

                    for (int i = -((value - 1) / 2); i <= (value - 1) / 2; i++)
                    {
                        for (int j = -((value - 1) / 2); j <= (value - 1) / 2; j++)
                        {
                            Color color = bitmap.GetPixel(x + i, y + j);

                            sumR += color.R * gauss[k];
                            sumG += color.G * gauss[k];
                            sumB += color.B * gauss[k];

                            k++;
                        }
                    }

                    int averageR = (int)(sumR / gaussSum);
                    int averageG = (int)(sumG / gaussSum);
                    int averageB = (int)(sumB / gaussSum);

                    Color avarageColor = Color.FromArgb(averageR, averageG, averageB);

                    outBitmap.SetPixel(x, y, avarageColor);
                }
            }

            return outBitmap;
        }

        /// <summary>
        /// Resim çıkarma işlemi
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public int[,,] PictureExtraction(Bitmap image1, Bitmap image2)
        {
            int[,,] buffer = new int[3, image1.Height, image1.Width];

            for (int y = 0; y < image1.Height; y++)
            {
                for (int x = 0; x < image1.Width; x++)
                {
                    Color color_1 = image1.GetPixel(x, y);
                    Color color_2 = image2.GetPixel(x, y);

                    buffer[0, y, x] = Convert.ToInt16(Math.Abs(color_1.R - color_2.R));
                    buffer[1, y, x] = Convert.ToInt16(Math.Abs(color_1.G - color_2.G));
                    buffer[2, y, x] = Convert.ToInt16(Math.Abs(color_1.B - color_2.B));
                }
            }

            return buffer;
        }

        /// <summary>
        /// Resim toplama işlemi
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public int[,,] PictureAdd(Bitmap image1, Bitmap image2)
        {
            double scaling = Convert.ToDouble(txt_k.Text); //Keskin kenaları daha iyi görmek için değerini artırıyoruz.

            int[,,] buffer = new int[3, image1.Height, image1.Width];

            for (int y = 0; y < image1.Height; y++)
            {
                for (int x = 0; x < image1.Width; x++)
                {
                    Color color_1 = image1.GetPixel(x, y);
                    Color color_2 = image2.GetPixel(x, y);

                    int R = color_1.R + (int)(scaling * color_2.R);
                    int G = color_1.G + (int)(scaling * color_2.G);
                    int B = color_1.B + (int)(scaling * color_2.B);

                    buffer[0, y, x] = R;
                    buffer[1, y, x] = G;
                    buffer[2, y, x] = B;
                }
            }

            return buffer;
        }

        /// <summary>
        /// int[,,] tipindeki resim değerlerine normalizasyon uygular 
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public int[,,] Normalization(int[,,] buffer)
        {
            //Pout = ( Pin - MinValue ) * ( ( 255 - 0 ) / ( MaxValue - MinValue ) ) + 0
            int limitMinVal = 0;
            int limitMaxVal = 255;

            int min = BufferMin(buffer);
            int max = BufferMax(buffer);

            var lenght_1 = buffer.GetLength(0);
            var lenght_2 = buffer.GetLength(1);
            var lenght_3 = buffer.GetLength(2);

            int[,,] outBuffer = new int[lenght_1, lenght_2, lenght_3];

            for (int i = 0; i < lenght_1; i++)
            {
                for (int j = 0; j < lenght_2; j++)
                {
                    for (int k = 0; k < lenght_3; k++)
                    {
                        int inVal = buffer[i, j, k];

                        int outVal = (int)((inVal - min) * (decimal)((decimal)(limitMaxVal - limitMinVal) / (decimal)(max - min)) + limitMinVal);

                        outBuffer[i, j, k] = outVal;
                    }
                }
            }

            return outBuffer;
        }

        public int[,,] SingleNormalization(int[,,] buffer)
        {
            int lenght_1 = buffer.GetLength(1);
            int lenght_2 = buffer.GetLength(2);

            int[,] R = new int[lenght_1, lenght_2];
            int[,] G = new int[lenght_1, lenght_2];
            int[,] B = new int[lenght_1, lenght_2];

            for (int i = 0; i < lenght_1; i++)
            {
                for (int j = 0; j < lenght_2; j++)
                {
                    R[i, j] = buffer[0, i, j];
                    G[i, j] = buffer[1, i, j];
                    B[i, j] = buffer[2, i, j];
                }
            }

            int[,] Normalization_R = Normalization(R);
            int[,] Normalization_G = Normalization(G);
            int[,] Normalization_B = Normalization(B);

            int[,,] RGB = new int[3, lenght_1, lenght_2];

            for (int i = 0; i < lenght_1; i++)
            {
                for (int j = 0; j < lenght_2; j++)
                {
                    RGB[0, i, j] = Normalization_R[i, j];
                    RGB[1, i, j] = Normalization_G[i, j];
                    RGB[2, i, j] = Normalization_B[i, j];
                }
            }

            return RGB;
        }

        public int[,] Normalization(int[,] buffer)
        {
            //Pout = ( Pin - MinValue ) * ( ( 255 - 0 ) / ( MaxValue - MinValue ) ) + 0
            int limitMinVal = 0;
            int limitMaxVal = 255;

            int min = BufferMin(buffer);
            int max = BufferMax(buffer);

            var lenght_1 = buffer.GetLength(0);
            var lenght_2 = buffer.GetLength(1);

            int[,] outBuffer = new int[lenght_1, lenght_2];

            for (int i = 0; i < lenght_1; i++)
            {
                for (int j = 0; j < lenght_2; j++)
                {
                    int inVal = buffer[i, j];

                    int outVal = (int)((inVal - min) * (decimal)((decimal)(limitMaxVal - limitMinVal) / (decimal)(max - min)) + limitMinVal);

                    outBuffer[i, j] = outVal;
                }
            }

            return outBuffer;
        }

        /// <summary>
        /// int[,,] tipindeki resim değerlerinin minimum değerini döner
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public int BufferMin(int[,,] buffer)
        {
            bool first = true;
            int minValue = 0;

            var lenght_1 = buffer.GetLength(0);
            var lenght_2 = buffer.GetLength(1);
            var lenght_3 = buffer.GetLength(2);

            for (int i = 0; i < lenght_1; i++)
            {
                for (int j = 0; j < lenght_2; j++)
                {
                    for (int k = 0; k < lenght_3; k++)
                    {
                        int value = buffer[i, j, k];

                        if (first)
                        {
                            minValue = value;
                            first = false;
                        }
                        else
                        {
                            if (value < minValue)
                            {
                                minValue = value;
                            }
                        }
                    }
                }
            }

            return minValue;
        }

        public int BufferMin(int[,] buffer)
        {
            bool first = true;
            int minValue = 0;

            var lenght_1 = buffer.GetLength(0);
            var lenght_2 = buffer.GetLength(1);

            for (int i = 0; i < lenght_1; i++)
            {
                for (int j = 0; j < lenght_2; j++)
                {
                    int value = buffer[i, j];

                    if (first)
                    {
                        minValue = value;
                        first = false;
                    }
                    else
                    {
                        if (value < minValue)
                        {
                            minValue = value;
                        }
                    }
                }
            }

            return minValue;
        }

        /// <summary>
        /// int[,,] tipindeki resim değerlerinin maximum değerini döner
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public int BufferMax(int[,,] buffer)
        {
            bool first = true;
            int maxValue = 0;

            var lenght_1 = buffer.GetLength(0);
            var lenght_2 = buffer.GetLength(1);
            var lenght_3 = buffer.GetLength(2);

            for (int i = 0; i < lenght_1; i++)
            {
                for (int j = 0; j < lenght_2; j++)
                {
                    for (int k = 0; k < lenght_3; k++)
                    {
                        int value = buffer[i, j, k];

                        if (first)
                        {
                            maxValue = value;
                            first = false;
                        }
                        else
                        {
                            if (value > maxValue)
                            {
                                maxValue = value;
                            }
                        }
                    }
                }
            }

            return maxValue;
        }

        public int BufferMax(int[,] buffer)
        {
            bool first = true;
            int maxValue = 0;

            var lenght_1 = buffer.GetLength(0);
            var lenght_2 = buffer.GetLength(1);

            for (int i = 0; i < lenght_1; i++)
            {
                for (int j = 0; j < lenght_2; j++)
                {
                    int value = buffer[i, j];

                    if (first)
                    {
                        maxValue = value;
                        first = false;
                    }
                    else
                    {
                        if (value > maxValue)
                        {
                            maxValue = value;
                        }
                    }
                }
            }

            return maxValue;
        }

        public int[] GaussianBlur(int lenght, double weight)
        {
            List<int> kernel = new List<int>();

            int foff = (lenght - 1) / 2;

            double distance = 0;
            double constant = 1d / (Math.Sqrt((2 * Math.PI)) * weight * weight);
            double scale = 0d;

            for (int y = -foff; y <= foff; y++)
            {
                for (int x = -foff; x <= foff; x++)
                {
                    distance = Math.Exp(-(((y * y) + (x * x)) / (2 * weight * weight)));

                    if (scale == 0d)
                    {
                        scale = 1d / (constant * distance);
                        kernel.Add(1);
                    }
                    else
                    {
                        kernel.Add((int)Math.Round((constant * distance * scale)));
                    }

                }
            }

            return kernel.ToArray();
        }

        protected void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back
                & e.KeyChar != ',')
            {
                e.Handled = true;
            }

            base.OnKeyPress(e);
        }

        private void btn_Filter_Click(object sender, EventArgs e)
        {
            switch (selectFilter)
            {
                case Filter.Mean:
                    btn_MeanFilter.Checked = true;
                    btn_MedianFilter.Checked = false;
                    btn_GaussianFilter.Checked = false;
                    break;
                case Filter.Median:
                    btn_MeanFilter.Checked = false;
                    btn_MedianFilter.Checked = true;
                    btn_GaussianFilter.Checked = false;
                    break;
                case Filter.Gaussian:
                    btn_MeanFilter.Checked = false;
                    btn_MedianFilter.Checked = false;
                    btn_GaussianFilter.Checked = true;
                    break;
            }
        }

        private void btn_MeanFilter_Click(object sender, EventArgs e)
        {
            selectFilter = Filter.Mean;

            btn_MeanFilter.Checked = true;
            btn_MedianFilter.Checked = false;
            btn_GaussianFilter.Checked = false;
        }

        private void btn_MedianFilter_Click(object sender, EventArgs e)
        {
            selectFilter = Filter.Median;

            btn_MeanFilter.Checked = false;
            btn_MedianFilter.Checked = true;
            btn_GaussianFilter.Checked = false;
        }

        private void btn_GaussianFilter_Click(object sender, EventArgs e)
        {
            selectFilter = Filter.Gaussian;

            btn_MeanFilter.Checked = false;
            btn_MedianFilter.Checked = false;
            btn_GaussianFilter.Checked = true;
        }

        private void btn_Normalization_Click(object sender, EventArgs e)
        {
            switch (normalizationType)
            {
                case NormalizationType.Single:
                    btn_Normalization_Single.Checked = true;
                    btn_Normalization_Multiple.Checked = false;
                    break;
                case NormalizationType.Multiple:
                    btn_Normalization_Single.Checked = false;
                    btn_Normalization_Multiple.Checked = true;
                    break;
            }
        }

        private void btn_Normalization_Multiple_Click(object sender, EventArgs e)
        {
            normalizationType = NormalizationType.Multiple;

            btn_Normalization_Single.Checked = false;
            btn_Normalization_Multiple.Checked = true;
        }

        private void btn_Normalization_Single_Click(object sender, EventArgs e)
        {
            normalizationType = NormalizationType.Single;

            btn_Normalization_Single.Checked = true;
            btn_Normalization_Multiple.Checked = false;
        }

        private void btn_Image_Color_Click(object sender, EventArgs e)
        {
            switch (imageColor)
            {
                case ImageColor.RGB:
                    btn_Image_Color_RGB.Checked = true;
                    btn_Image_Color_Gray.Checked = false;
                    break;
                case ImageColor.Gray:
                    btn_Image_Color_RGB.Checked = false;
                    btn_Image_Color_Gray.Checked = true;
                    break;
            }
        }

        private void btn_Image_Color_RGB_Click(object sender, EventArgs e)
        {
            imageColor = ImageColor.RGB;

            btn_Image_Color_RGB.Checked = true;
            btn_Image_Color_Gray.Checked = false;
        }

        private void btn_Image_Color_Gray_Click(object sender, EventArgs e)
        {
            imageColor = ImageColor.Gray;

            btn_Image_Color_RGB.Checked = false;
            btn_Image_Color_Gray.Checked = true;
        }
    }
}
