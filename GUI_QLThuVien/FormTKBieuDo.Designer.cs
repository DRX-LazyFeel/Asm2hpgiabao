namespace GUI_QLThuVien
{
    partial class FormTKBieuDo
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            label1 = new Label();
            cbNV = new Guna.UI2.WinForms.Guna2ComboBox();
            btTK = new Guna.UI2.WinForms.Guna2Button();
            chartTK = new System.Windows.Forms.DataVisualization.Charting.Chart();
            guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            dtTuNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            dtDenNgay = new Guna.UI2.WinForms.Guna2DateTimePicker();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartTK).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dtDenNgay);
            panel1.Controls.Add(dtTuNgay);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(cbNV);
            panel1.Location = new Point(42, 37);
            panel1.Name = "panel1";
            panel1.Size = new Size(476, 271);
            panel1.TabIndex = 108;
            panel1.Paint += panel1_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Cambria", 10.8F);
            label1.ForeColor = Color.FromArgb(37, 57, 67);
            label1.Location = new Point(40, 22);
            label1.Name = "label1";
            label1.Size = new Size(123, 21);
            label1.TabIndex = 97;
            label1.Text = "Tên Nhân Viên";
            // 
            // cbNV
            // 
            cbNV.BackColor = Color.Transparent;
            cbNV.BorderRadius = 5;
            cbNV.CustomizableEdges = customizableEdges11;
            cbNV.DrawMode = DrawMode.OwnerDrawFixed;
            cbNV.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNV.FocusedColor = Color.FromArgb(94, 148, 255);
            cbNV.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbNV.Font = new Font("Segoe UI", 10F);
            cbNV.ForeColor = Color.FromArgb(68, 88, 112);
            cbNV.ItemHeight = 30;
            cbNV.Location = new Point(62, 46);
            cbNV.Name = "cbNV";
            cbNV.ShadowDecoration.CustomizableEdges = customizableEdges12;
            cbNV.Size = new Size(336, 36);
            cbNV.TabIndex = 100;
            // 
            // btTK
            // 
            btTK.BorderRadius = 5;
            btTK.CustomizableEdges = customizableEdges13;
            btTK.DisabledState.BorderColor = Color.DarkGray;
            btTK.DisabledState.CustomBorderColor = Color.DarkGray;
            btTK.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btTK.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btTK.Font = new Font("Segoe UI", 9F);
            btTK.ForeColor = Color.White;
            btTK.Location = new Point(181, 417);
            btTK.Name = "btTK";
            btTK.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btTK.Size = new Size(158, 56);
            btTK.TabIndex = 107;
            btTK.Text = "Thống Kê";
            btTK.Click += guna2Button1_Click;
            // 
            // chartTK
            // 
            chartArea2.Name = "ChartArea1";
            chartTK.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chartTK.Legends.Add(legend2);
            chartTK.Location = new Point(535, 37);
            chartTK.Name = "chartTK";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chartTK.Series.Add(series2);
            chartTK.Size = new Size(949, 770);
            chartTK.TabIndex = 109;
            chartTK.Text = "chart1";
            // 
            // guna2Button1
            // 
            guna2Button1.BorderRadius = 5;
            guna2Button1.CustomizableEdges = customizableEdges15;
            guna2Button1.DisabledState.BorderColor = Color.DarkGray;
            guna2Button1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2Button1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2Button1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2Button1.Font = new Font("Segoe UI", 9F);
            guna2Button1.ForeColor = Color.White;
            guna2Button1.Location = new Point(12, 751);
            guna2Button1.Name = "guna2Button1";
            guna2Button1.ShadowDecoration.CustomizableEdges = customizableEdges16;
            guna2Button1.Size = new Size(225, 56);
            guna2Button1.TabIndex = 111;
            guna2Button1.Text = "Thống Kê Dữ Liệu Chi Tiết";
            guna2Button1.Click += guna2Button1_Click_1;
            // 
            // dtTuNgay
            // 
            dtTuNgay.Checked = true;
            dtTuNgay.CustomizableEdges = customizableEdges17;
            dtTuNgay.Font = new Font("Segoe UI", 9F);
            dtTuNgay.Format = DateTimePickerFormat.Long;
            dtTuNgay.Location = new Point(62, 108);
            dtTuNgay.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtTuNgay.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtTuNgay.Name = "dtTuNgay";
            dtTuNgay.ShadowDecoration.CustomizableEdges = customizableEdges18;
            dtTuNgay.Size = new Size(250, 45);
            dtTuNgay.TabIndex = 103;
            dtTuNgay.Value = new DateTime(2025, 8, 11, 14, 47, 40, 964);
            // 
            // dtDenNgay
            // 
            dtDenNgay.Checked = true;
            dtDenNgay.CustomizableEdges = customizableEdges19;
            dtDenNgay.Font = new Font("Segoe UI", 9F);
            dtDenNgay.Format = DateTimePickerFormat.Long;
            dtDenNgay.Location = new Point(62, 188);
            dtDenNgay.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            dtDenNgay.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            dtDenNgay.Name = "dtDenNgay";
            dtDenNgay.ShadowDecoration.CustomizableEdges = customizableEdges20;
            dtDenNgay.Size = new Size(250, 45);
            dtDenNgay.TabIndex = 104;
            dtDenNgay.Value = new DateTime(2025, 8, 11, 14, 47, 40, 964);
            // 
            // FormTKBieuDo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1496, 927);
            Controls.Add(guna2Button1);
            Controls.Add(chartTK);
            Controls.Add(panel1);
            Controls.Add(btTK);
            Name = "FormTKBieuDo";
            Text = "Biểu_Đồ_Thống_Kê";
            TopMost = true;
            Load += FormTKBieuDo_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartTK).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cbNV;
        private Guna.UI2.WinForms.Guna2Button btTK;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTK;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtDenNgay;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtTuNgay;
    }
}