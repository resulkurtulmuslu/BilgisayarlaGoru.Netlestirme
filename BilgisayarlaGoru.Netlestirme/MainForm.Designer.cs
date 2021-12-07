
namespace BilgisayarlaGoru.Netlestirme
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_Select = new System.Windows.Forms.ToolStripButton();
            this.btn_Process = new System.Windows.Forms.ToolStripButton();
            this.cmb_FilterValue = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picture_Smooth = new System.Windows.Forms.PictureBox();
            this.picture_Original = new System.Windows.Forms.PictureBox();
            this.picture_Edge = new System.Windows.Forms.PictureBox();
            this.picture_Sharp = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txt_k = new System.Windows.Forms.ToolStripTextBox();
            this.btn_Filter = new System.Windows.Forms.ToolStripDropDownButton();
            this.btn_MeanFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_MedianFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Smooth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Original)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Edge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Sharp)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_Select,
            this.btn_Process,
            this.txt_k,
            this.toolStripLabel1,
            this.cmb_FilterValue,
            this.toolStripLabel2,
            this.btn_Filter});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_Select
            // 
            this.btn_Select.Image = ((System.Drawing.Image)(resources.GetObject("btn_Select.Image")));
            this.btn_Select.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(80, 22);
            this.btn_Select.Text = "Resim Seç";
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // btn_Process
            // 
            this.btn_Process.Image = ((System.Drawing.Image)(resources.GetObject("btn_Process.Image")));
            this.btn_Process.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Process.Name = "btn_Process";
            this.btn_Process.Size = new System.Drawing.Size(71, 22);
            this.btn_Process.Text = "Netleştir";
            this.btn_Process.Click += new System.EventHandler(this.btn_Process_Click);
            // 
            // cmb_FilterValue
            // 
            this.cmb_FilterValue.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmb_FilterValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_FilterValue.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cmb_FilterValue.Items.AddRange(new object[] {
            "3",
            "5",
            "7",
            "9"});
            this.cmb_FilterValue.Name = "cmb_FilterValue";
            this.cmb_FilterValue.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(143, 22);
            this.toolStripLabel1.Text = "k ( Keskinleştirme Değeri )";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.picture_Smooth, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.picture_Original, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.picture_Edge, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.picture_Sharp, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 425);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(403, 404);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(394, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Netleştirilmiş Görüntü";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(3, 404);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(394, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Kenar Görüntüsü";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(403, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(394, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Yumuşatılmış Görüntü";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picture_Smooth
            // 
            this.picture_Smooth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_Smooth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picture_Smooth.Location = new System.Drawing.Point(403, 3);
            this.picture_Smooth.Name = "picture_Smooth";
            this.picture_Smooth.Size = new System.Drawing.Size(394, 186);
            this.picture_Smooth.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_Smooth.TabIndex = 1;
            this.picture_Smooth.TabStop = false;
            // 
            // picture_Original
            // 
            this.picture_Original.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_Original.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picture_Original.Location = new System.Drawing.Point(3, 3);
            this.picture_Original.Name = "picture_Original";
            this.picture_Original.Size = new System.Drawing.Size(394, 186);
            this.picture_Original.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_Original.TabIndex = 0;
            this.picture_Original.TabStop = false;
            // 
            // picture_Edge
            // 
            this.picture_Edge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_Edge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picture_Edge.Location = new System.Drawing.Point(3, 215);
            this.picture_Edge.Name = "picture_Edge";
            this.picture_Edge.Size = new System.Drawing.Size(394, 186);
            this.picture_Edge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_Edge.TabIndex = 2;
            this.picture_Edge.TabStop = false;
            // 
            // picture_Sharp
            // 
            this.picture_Sharp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture_Sharp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picture_Sharp.Location = new System.Drawing.Point(403, 215);
            this.picture_Sharp.Name = "picture_Sharp";
            this.picture_Sharp.Size = new System.Drawing.Size(394, 186);
            this.picture_Sharp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture_Sharp.TabIndex = 3;
            this.picture_Sharp.TabStop = false;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(3, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(394, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Orijinal Görüntü";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(113, 22);
            this.toolStripLabel2.Text = "Filtre Şablon Boyutu";
            // 
            // txt_k
            // 
            this.txt_k.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txt_k.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_k.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_k.Name = "txt_k";
            this.txt_k.Size = new System.Drawing.Size(100, 25);
            this.txt_k.Text = "0,2";
            this.txt_k.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            // 
            // btn_Filter
            // 
            this.btn_Filter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_MeanFilter,
            this.btn_MedianFilter});
            this.btn_Filter.Image = ((System.Drawing.Image)(resources.GetObject("btn_Filter.Image")));
            this.btn_Filter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Filter.Name = "btn_Filter";
            this.btn_Filter.Size = new System.Drawing.Size(137, 22);
            this.btn_Filter.Text = "Yumuşatma Filtresi";
            this.btn_Filter.Click += new System.EventHandler(this.btn_Filter_Click);
            // 
            // btn_MeanFilter
            // 
            this.btn_MeanFilter.Name = "btn_MeanFilter";
            this.btn_MeanFilter.Size = new System.Drawing.Size(180, 22);
            this.btn_MeanFilter.Text = "Mean Filtre";
            this.btn_MeanFilter.Click += new System.EventHandler(this.btn_MeanFilter_Click);
            // 
            // btn_MedianFilter
            // 
            this.btn_MedianFilter.Name = "btn_MedianFilter";
            this.btn_MedianFilter.Size = new System.Drawing.Size(180, 22);
            this.btn_MedianFilter.Text = "Median Filtre";
            this.btn_MedianFilter.Click += new System.EventHandler(this.btn_MedianFilter_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Görüntü Netleştirme";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picture_Smooth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Original)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Edge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_Sharp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox picture_Smooth;
        private System.Windows.Forms.PictureBox picture_Original;
        private System.Windows.Forms.PictureBox picture_Edge;
        private System.Windows.Forms.PictureBox picture_Sharp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton btn_Select;
        private System.Windows.Forms.ToolStripButton btn_Process;
        private System.Windows.Forms.ToolStripComboBox cmb_FilterValue;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txt_k;
        private System.Windows.Forms.ToolStripDropDownButton btn_Filter;
        private System.Windows.Forms.ToolStripMenuItem btn_MeanFilter;
        private System.Windows.Forms.ToolStripMenuItem btn_MedianFilter;
    }
}