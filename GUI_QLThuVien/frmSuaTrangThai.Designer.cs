using Guna.UI2.WinForms;

namespace GUI_QLThuVien
{
    partial class frmSuaTrangThai
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges25 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges26 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges27 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges28 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges29 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges30 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lbThemSach = new Label();
            btnHuy = new Guna2Button();
            btnThem = new Guna2Button();
            txtTen = new Guna2TextBox();
            label2 = new Label();
            txtMa = new Guna2TextBox();
            label1 = new Label();
            guna2CustomGradientPanel1 = new Guna2CustomGradientPanel();
            label3 = new Label();
            panel1 = new Panel();
            rdhoatdong = new RadioButton();
            rdtamdung = new RadioButton();
            guna2CustomGradientPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lbThemSach
            // 
            lbThemSach.BackColor = Color.FromArgb(37, 57, 67);
            lbThemSach.Dock = DockStyle.Top;
            lbThemSach.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbThemSach.ForeColor = Color.White;
            lbThemSach.Location = new Point(0, 0);
            lbThemSach.Name = "lbThemSach";
            lbThemSach.Size = new Size(519, 101);
            lbThemSach.TabIndex = 206;
            lbThemSach.Text = "SỬA TRẠNG THÁI";
            lbThemSach.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.Transparent;
            btnHuy.BorderRadius = 5;
            btnHuy.CustomizableEdges = customizableEdges21;
            btnHuy.DisabledState.BorderColor = Color.DarkGray;
            btnHuy.DisabledState.CustomBorderColor = Color.DarkGray;
            btnHuy.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnHuy.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnHuy.FillColor = Color.Firebrick;
            btnHuy.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(278, 392);
            btnHuy.Name = "btnHuy";
            btnHuy.ShadowDecoration.CustomizableEdges = customizableEdges22;
            btnHuy.Size = new Size(125, 56);
            btnHuy.TabIndex = 215;
            btnHuy.Text = "Hủy";
            btnHuy.Click += btnHuy_Click_1;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.Transparent;
            btnThem.BorderRadius = 5;
            btnThem.CustomizableEdges = customizableEdges23;
            btnThem.DisabledState.BorderColor = Color.DarkGray;
            btnThem.DisabledState.CustomBorderColor = Color.DarkGray;
            btnThem.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnThem.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnThem.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(136, 392);
            btnThem.Name = "btnThem";
            btnThem.ShadowDecoration.CustomizableEdges = customizableEdges24;
            btnThem.Size = new Size(125, 56);
            btnThem.TabIndex = 216;
            btnThem.Text = "Sửa";
            btnThem.Click += btnThem_Click;
            // 
            // txtTen
            // 
            txtTen.BackColor = Color.Transparent;
            txtTen.BorderRadius = 5;
            txtTen.CustomizableEdges = customizableEdges25;
            txtTen.DefaultText = "";
            txtTen.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtTen.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtTen.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtTen.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtTen.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTen.Font = new Font("Segoe UI", 9F);
            txtTen.ForeColor = Color.FromArgb(37, 57, 67);
            txtTen.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTen.Location = new Point(52, 169);
            txtTen.Margin = new Padding(3, 4, 3, 4);
            txtTen.Name = "txtTen";
            txtTen.PasswordChar = '\0';
            txtTen.PlaceholderText = "";
            txtTen.SelectedText = "";
            txtTen.ShadowDecoration.CustomizableEdges = customizableEdges26;
            txtTen.Size = new Size(351, 49);
            txtTen.TabIndex = 210;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Cambria", 10.8F);
            label2.ForeColor = Color.FromArgb(37, 57, 67);
            label2.Location = new Point(21, 144);
            label2.Name = "label2";
            label2.Size = new Size(127, 21);
            label2.TabIndex = 208;
            label2.Text = "Tên Trạng Thái";
            // 
            // txtMa
            // 
            txtMa.BackColor = Color.Transparent;
            txtMa.BorderRadius = 5;
            txtMa.CustomizableEdges = customizableEdges27;
            txtMa.DefaultText = "";
            txtMa.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtMa.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtMa.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtMa.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtMa.Enabled = false;
            txtMa.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtMa.Font = new Font("Segoe UI", 9F);
            txtMa.ForeColor = Color.FromArgb(37, 57, 67);
            txtMa.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtMa.Location = new Point(52, 55);
            txtMa.Margin = new Padding(3, 4, 3, 4);
            txtMa.Name = "txtMa";
            txtMa.PasswordChar = '\0';
            txtMa.PlaceholderText = "";
            txtMa.ReadOnly = true;
            txtMa.SelectedText = "";
            txtMa.ShadowDecoration.CustomizableEdges = customizableEdges28;
            txtMa.Size = new Size(351, 49);
            txtMa.TabIndex = 212;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Cambria", 10.8F);
            label1.ForeColor = Color.FromArgb(37, 57, 67);
            label1.Location = new Point(21, 30);
            label1.Name = "label1";
            label1.Size = new Size(122, 21);
            label1.TabIndex = 217;
            label1.Text = "Mã Trạng Thái";
            // 
            // guna2CustomGradientPanel1
            // 
            guna2CustomGradientPanel1.Controls.Add(label3);
            guna2CustomGradientPanel1.Controls.Add(panel1);
            guna2CustomGradientPanel1.Controls.Add(txtTen);
            guna2CustomGradientPanel1.Controls.Add(label1);
            guna2CustomGradientPanel1.Controls.Add(txtMa);
            guna2CustomGradientPanel1.Controls.Add(btnHuy);
            guna2CustomGradientPanel1.Controls.Add(label2);
            guna2CustomGradientPanel1.Controls.Add(btnThem);
            guna2CustomGradientPanel1.CustomizableEdges = customizableEdges29;
            guna2CustomGradientPanel1.Location = new Point(44, 137);
            guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            guna2CustomGradientPanel1.ShadowDecoration.CustomizableEdges = customizableEdges30;
            guna2CustomGradientPanel1.Size = new Size(423, 471);
            guna2CustomGradientPanel1.TabIndex = 218;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Cambria", 10.8F);
            label3.Location = new Point(33, 257);
            label3.Name = "label3";
            label3.Size = new Size(94, 21);
            label3.TabIndex = 219;
            label3.Text = "Trạng Thái";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(rdhoatdong);
            panel1.Controls.Add(rdtamdung);
            panel1.Location = new Point(33, 281);
            panel1.Name = "panel1";
            panel1.Size = new Size(370, 74);
            panel1.TabIndex = 218;
            // 
            // rdhoatdong
            // 
            rdhoatdong.AutoSize = true;
            rdhoatdong.Location = new Point(18, 28);
            rdhoatdong.Name = "rdhoatdong";
            rdhoatdong.Size = new Size(104, 24);
            rdhoatdong.TabIndex = 172;
            rdhoatdong.TabStop = true;
            rdhoatdong.Text = "Hoạt Động";
            rdhoatdong.UseVisualStyleBackColor = true;
            // 
            // rdtamdung
            // 
            rdtamdung.AutoSize = true;
            rdtamdung.Location = new Point(214, 28);
            rdtamdung.Name = "rdtamdung";
            rdtamdung.Size = new Size(100, 24);
            rdtamdung.TabIndex = 173;
            rdtamdung.TabStop = true;
            rdtamdung.Text = "Tạm Dừng";
            rdtamdung.UseVisualStyleBackColor = true;
            // 
            // frmSuaTrangThai
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(46, 72, 82);
            ClientSize = new Size(519, 652);
            Controls.Add(guna2CustomGradientPanel1);
            Controls.Add(lbThemSach);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmSuaTrangThai";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sửa_Trạng_Thái";
            TopMost = true;
            Load += frmThemTTTT_Load;
            guna2CustomGradientPanel1.ResumeLayout(false);
            guna2CustomGradientPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label lbThemSach;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
        private Guna.UI2.WinForms.Guna2Button btnThem;
        private Guna2TextBox txtTen;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2RadioButton rdoNgunfApDung;
        private Guna.UI2.WinForms.Guna2RadioButton rdoApDung;
        private Label label7;
        private Guna.UI2.WinForms.Guna2TextBox txtPhiPhat;
        private Guna.UI2.WinForms.Guna2TextBox txtPhiMuon;
        private Label label2;
        private Guna.UI2.WinForms.Guna2TextBox txtMa;
        private Label label5;
        private Label label1;
        private Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Label label3;
        private Panel panel1;
        private RadioButton rdhoatdong;
        private RadioButton rdtamdung;
    }
}