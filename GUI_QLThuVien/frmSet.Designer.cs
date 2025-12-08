namespace GUI_QLThuVien
{
    partial class frmSet
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
            btnDoiMK = new Guna.UI2.WinForms.Guna2Button();
            txtSDT = new Guna.UI2.WinForms.Guna2TextBox();
            label3 = new Label();
            txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            label5 = new Label();
            txtTen = new Guna.UI2.WinForms.Guna2TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnDoiMK
            // 
            btnDoiMK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDoiMK.BorderRadius = 10;
            btnDoiMK.CustomizableEdges = customizableEdges1;
            btnDoiMK.DisabledState.BorderColor = Color.DarkGray;
            btnDoiMK.DisabledState.CustomBorderColor = Color.DarkGray;
            btnDoiMK.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnDoiMK.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnDoiMK.FillColor = Color.FromArgb(0, 192, 0);
            btnDoiMK.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDoiMK.ForeColor = Color.White;
            btnDoiMK.Location = new Point(1036, 729);
            btnDoiMK.Name = "btnDoiMK";
            btnDoiMK.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnDoiMK.Size = new Size(165, 56);
            btnDoiMK.TabIndex = 183;
            btnDoiMK.Text = "Đổi Mật Khẩu";
            btnDoiMK.Click += btnDoiMK_Click_1;
            // 
            // txtSDT
            // 
            txtSDT.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSDT.BorderRadius = 5;
            txtSDT.CustomizableEdges = customizableEdges3;
            txtSDT.DefaultText = "";
            txtSDT.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSDT.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSDT.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSDT.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSDT.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSDT.Font = new Font("Segoe UI", 9F);
            txtSDT.ForeColor = Color.FromArgb(37, 57, 67);
            txtSDT.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSDT.Location = new Point(443, 466);
            txtSDT.Margin = new Padding(3, 4, 3, 4);
            txtSDT.Name = "txtSDT";
            txtSDT.PasswordChar = '\0';
            txtSDT.PlaceholderText = "";
            txtSDT.SelectedText = "";
            txtSDT.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtSDT.Size = new Size(431, 49);
            txtSDT.TabIndex = 129;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(37, 57, 67);
            label3.Location = new Point(328, 482);
            label3.Name = "label3";
            label3.Size = new Size(102, 20);
            label3.TabIndex = 128;
            label3.Text = "Số Điện Thoại";
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.BorderRadius = 5;
            txtEmail.CustomizableEdges = customizableEdges5;
            txtEmail.DefaultText = "";
            txtEmail.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtEmail.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtEmail.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtEmail.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtEmail.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtEmail.Font = new Font("Segoe UI", 9F);
            txtEmail.ForeColor = Color.FromArgb(37, 57, 67);
            txtEmail.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtEmail.Location = new Point(443, 367);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.PasswordChar = '\0';
            txtEmail.PlaceholderText = "";
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtEmail.Size = new Size(431, 49);
            txtEmail.TabIndex = 127;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.ForeColor = Color.FromArgb(37, 57, 67);
            label5.Location = new Point(374, 383);
            label5.Name = "label5";
            label5.Size = new Size(46, 20);
            label5.TabIndex = 126;
            label5.Text = "Email";
            // 
            // txtTen
            // 
            txtTen.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTen.BorderRadius = 5;
            txtTen.CustomizableEdges = customizableEdges7;
            txtTen.DefaultText = "";
            txtTen.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtTen.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtTen.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtTen.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtTen.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTen.Font = new Font("Segoe UI", 9F);
            txtTen.ForeColor = Color.FromArgb(37, 57, 67);
            txtTen.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTen.Location = new Point(443, 268);
            txtTen.Margin = new Padding(3, 4, 3, 4);
            txtTen.Name = "txtTen";
            txtTen.PasswordChar = '\0';
            txtTen.PlaceholderText = "";
            txtTen.SelectedText = "";
            txtTen.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtTen.Size = new Size(431, 49);
            txtTen.TabIndex = 130;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(37, 57, 67);
            label1.Location = new Point(388, 284);
            label1.Name = "label1";
            label1.Size = new Size(32, 20);
            label1.TabIndex = 129;
            label1.Text = "Tên";
            // 
            // frmSet
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1265, 819);
            Controls.Add(label5);
            Controls.Add(txtEmail);
            Controls.Add(btnDoiMK);
            Controls.Add(txtTen);
            Controls.Add(label3);
            Controls.Add(txtSDT);
            Controls.Add(label1);
            Name = "frmSet";
            Text = "Thông_Tin_Tài_Khoản";
            TopMost = true;
            Load += frmSet_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Label label5;
        private Guna.UI2.WinForms.Guna2TextBox txtSDT;
        private Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtTen;
        private Label label1;
        private Guna.UI2.WinForms.Guna2Button btnDoiMK;
    }
}