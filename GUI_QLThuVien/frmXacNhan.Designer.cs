namespace GUI_QLThuVien
{
    partial class frmXacNhan
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            txtTitle = new Label();
            txtMa = new Guna.UI2.WinForms.Guna2TextBox();
            btnHuy = new Guna.UI2.WinForms.Guna2Button();
            btnSend = new Guna.UI2.WinForms.Guna2Button();
            label1 = new Label();
            txtRSPass = new Guna.UI2.WinForms.Guna2TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.BackColor = Color.FromArgb(37, 57, 67);
            txtTitle.Dock = DockStyle.Top;
            txtTitle.Font = new Font("Microsoft Sans Serif", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTitle.ForeColor = Color.White;
            txtTitle.Location = new Point(0, 0);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(545, 65);
            txtTitle.TabIndex = 59;
            txtTitle.Text = "XÁC NHẬN MÃ";
            txtTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtMa
            // 
            txtMa.BackColor = Color.Transparent;
            txtMa.BorderRadius = 5;
            txtMa.CustomizableEdges = customizableEdges1;
            txtMa.DefaultText = "";
            txtMa.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtMa.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtMa.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtMa.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtMa.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtMa.Font = new Font("Segoe UI", 9F);
            txtMa.ForeColor = Color.FromArgb(37, 57, 67);
            txtMa.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtMa.Location = new Point(98, 219);
            txtMa.Margin = new Padding(3, 4, 3, 4);
            txtMa.Name = "txtMa";
            txtMa.PasswordChar = '\0';
            txtMa.PlaceholderText = "";
            txtMa.SelectedText = "";
            txtMa.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtMa.Size = new Size(364, 49);
            txtMa.TabIndex = 164;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.Transparent;
            btnHuy.BorderRadius = 5;
            btnHuy.CustomizableEdges = customizableEdges3;
            btnHuy.DisabledState.BorderColor = Color.DarkGray;
            btnHuy.DisabledState.CustomBorderColor = Color.DarkGray;
            btnHuy.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnHuy.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnHuy.FillColor = Color.Firebrick;
            btnHuy.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(203, 512);
            btnHuy.Name = "btnHuy";
            btnHuy.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnHuy.Size = new Size(125, 56);
            btnHuy.TabIndex = 162;
            btnHuy.Text = "Hủy";
            btnHuy.Click += btnHuy_Click;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.Transparent;
            btnSend.BorderRadius = 5;
            btnSend.CustomizableEdges = customizableEdges5;
            btnSend.DisabledState.BorderColor = Color.DarkGray;
            btnSend.DisabledState.CustomBorderColor = Color.DarkGray;
            btnSend.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnSend.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnSend.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            btnSend.ForeColor = Color.White;
            btnSend.Location = new Point(203, 423);
            btnSend.Name = "btnSend";
            btnSend.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnSend.Size = new Size(125, 56);
            btnSend.TabIndex = 163;
            btnSend.Text = "Xác Nhận";
            btnSend.Click += btnSend_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.White;
            label1.Location = new Point(115, 195);
            label1.Name = "label1";
            label1.Size = new Size(33, 20);
            label1.TabIndex = 161;
            label1.Text = "Mã:";
            // 
            // txtRSPass
            // 
            txtRSPass.BackColor = Color.Transparent;
            txtRSPass.BorderRadius = 5;
            txtRSPass.CustomizableEdges = customizableEdges7;
            txtRSPass.DefaultText = "";
            txtRSPass.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtRSPass.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtRSPass.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtRSPass.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtRSPass.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtRSPass.Font = new Font("Segoe UI", 9F);
            txtRSPass.ForeColor = Color.FromArgb(37, 57, 67);
            txtRSPass.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtRSPass.Location = new Point(98, 316);
            txtRSPass.Margin = new Padding(3, 4, 3, 4);
            txtRSPass.Name = "txtRSPass";
            txtRSPass.PasswordChar = '*';
            txtRSPass.PlaceholderText = "";
            txtRSPass.SelectedText = "";
            txtRSPass.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtRSPass.Size = new Size(364, 49);
            txtRSPass.TabIndex = 166;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.White;
            label2.Location = new Point(115, 292);
            label2.Name = "label2";
            label2.Size = new Size(105, 20);
            label2.TabIndex = 165;
            label2.Text = "Mật Khẩu Mới:";
            // 
            // frmXacNhan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Âm_nhạc_Áp_phích;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(545, 653);
            Controls.Add(txtRSPass);
            Controls.Add(label2);
            Controls.Add(txtMa);
            Controls.Add(btnHuy);
            Controls.Add(btnSend);
            Controls.Add(label1);
            Controls.Add(txtTitle);
            DoubleBuffered = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmXacNhan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Xác_Nhận_Mã";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label txtTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtMa;
        private Guna.UI2.WinForms.Guna2Button btnHuy;
        private Guna.UI2.WinForms.Guna2Button btnSend;
        private Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtRSPass;
        private Label label2;
    }
}