
namespace BilgisayarlaGoru.Netlestirme
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.image_Select = new System.Windows.Forms.PictureBox();
            this.btn_ImageSelect = new System.Windows.Forms.Button();
            this.image_Shape = new System.Windows.Forms.PictureBox();
            this.btn_Sharpening = new System.Windows.Forms.Button();
            this.image_Blur = new System.Windows.Forms.PictureBox();
            this.image_Edge = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nmbr_2 = new System.Windows.Forms.NumericUpDown();
            this.nmbr_1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.image_Select)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_Shape)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_Blur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_Edge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmbr_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmbr_1)).BeginInit();
            this.SuspendLayout();
            // 
            // image_Select
            // 
            this.image_Select.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.image_Select.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.image_Select.Location = new System.Drawing.Point(12, 41);
            this.image_Select.Name = "image_Select";
            this.image_Select.Size = new System.Drawing.Size(400, 400);
            this.image_Select.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.image_Select.TabIndex = 0;
            this.image_Select.TabStop = false;
            // 
            // btn_ImageSelect
            // 
            this.btn_ImageSelect.Location = new System.Drawing.Point(12, 12);
            this.btn_ImageSelect.Name = "btn_ImageSelect";
            this.btn_ImageSelect.Size = new System.Drawing.Size(109, 23);
            this.btn_ImageSelect.TabIndex = 1;
            this.btn_ImageSelect.Text = "Resim Seç";
            this.btn_ImageSelect.UseVisualStyleBackColor = true;
            this.btn_ImageSelect.Click += new System.EventHandler(this.btn_ImageSelect_Click);
            // 
            // image_Shape
            // 
            this.image_Shape.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.image_Shape.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.image_Shape.Location = new System.Drawing.Point(424, 485);
            this.image_Shape.Name = "image_Shape";
            this.image_Shape.Size = new System.Drawing.Size(400, 400);
            this.image_Shape.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.image_Shape.TabIndex = 2;
            this.image_Shape.TabStop = false;
            // 
            // btn_Sharpening
            // 
            this.btn_Sharpening.Location = new System.Drawing.Point(719, 12);
            this.btn_Sharpening.Name = "btn_Sharpening";
            this.btn_Sharpening.Size = new System.Drawing.Size(105, 23);
            this.btn_Sharpening.TabIndex = 3;
            this.btn_Sharpening.Text = "Netleştir";
            this.btn_Sharpening.UseVisualStyleBackColor = true;
            this.btn_Sharpening.Click += new System.EventHandler(this.btn_Sharpening_Click);
            // 
            // image_Blur
            // 
            this.image_Blur.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.image_Blur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.image_Blur.Location = new System.Drawing.Point(424, 41);
            this.image_Blur.Name = "image_Blur";
            this.image_Blur.Size = new System.Drawing.Size(400, 400);
            this.image_Blur.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.image_Blur.TabIndex = 4;
            this.image_Blur.TabStop = false;
            // 
            // image_Edge
            // 
            this.image_Edge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.image_Edge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.image_Edge.Location = new System.Drawing.Point(12, 485);
            this.image_Edge.Name = "image_Edge";
            this.image_Edge.Size = new System.Drawing.Size(400, 400);
            this.image_Edge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.image_Edge.TabIndex = 5;
            this.image_Edge.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 444);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 30);
            this.label1.TabIndex = 6;
            this.label1.Text = "Orjinal Resim";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(421, 444);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(400, 30);
            this.label2.TabIndex = 7;
            this.label2.Text = "Bulanık Resim";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 888);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(400, 30);
            this.label3.TabIndex = 8;
            this.label3.Text = "Kenar Görüntüsü";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(421, 888);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(400, 30);
            this.label4.TabIndex = 9;
            this.label4.Text = "Netleşmiş Resim";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nmbr_2
            // 
            this.nmbr_2.Location = new System.Drawing.Point(593, 15);
            this.nmbr_2.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nmbr_2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmbr_2.Name = "nmbr_2";
            this.nmbr_2.Size = new System.Drawing.Size(120, 20);
            this.nmbr_2.TabIndex = 10;
            this.nmbr_2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nmbr_1
            // 
            this.nmbr_1.Location = new System.Drawing.Point(292, 15);
            this.nmbr_1.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nmbr_1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmbr_1.Name = "nmbr_1";
            this.nmbr_1.Size = new System.Drawing.Size(120, 20);
            this.nmbr_1.TabIndex = 11;
            this.nmbr_1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(165, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Bulanıklaştırma Katsayısı";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(466, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Resim Çıkarma Katsayısı";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 939);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nmbr_1);
            this.Controls.Add(this.nmbr_2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.image_Edge);
            this.Controls.Add(this.image_Blur);
            this.Controls.Add(this.btn_Sharpening);
            this.Controls.Add(this.image_Shape);
            this.Controls.Add(this.btn_ImageSelect);
            this.Controls.Add(this.image_Select);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.image_Select)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_Shape)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_Blur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.image_Edge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmbr_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmbr_1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox image_Select;
        private System.Windows.Forms.Button btn_ImageSelect;
        private System.Windows.Forms.PictureBox image_Shape;
        private System.Windows.Forms.Button btn_Sharpening;
        private System.Windows.Forms.PictureBox image_Blur;
        private System.Windows.Forms.PictureBox image_Edge;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nmbr_2;
        private System.Windows.Forms.NumericUpDown nmbr_1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

