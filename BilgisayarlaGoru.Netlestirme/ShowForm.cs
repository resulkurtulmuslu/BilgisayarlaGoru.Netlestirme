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
    public partial class ShowForm : Form
    {
        Bitmap _bitmap;

        public ShowForm(Bitmap bitmap)
        {
            _bitmap = bitmap;

            InitializeComponent();
            picture.Image = _bitmap;
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            if (_bitmap is null)
            {
                MessageBox.Show("Çıktı alınacak öğe bulunamadı !", "Görüntü Netleştirme", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _bitmap.Save($"{dialog.FileName}.jpeg", ImageFormat.Jpeg);
            }
        }
    }
}
