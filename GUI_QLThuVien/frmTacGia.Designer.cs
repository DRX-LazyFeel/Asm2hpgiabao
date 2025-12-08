namespace GUI_QLThuVien
{
    partial class frmTacGia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTacGia));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            btnLamMoi = new Guna.UI2.WinForms.Guna2Button();
            txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            btxoa = new Guna.UI2.WinForms.Guna2Button();
            btthemm = new Guna.UI2.WinForms.Guna2Button();
            panel1 = new Panel();
            dgvTacGia = new Guna.UI2.WinForms.Guna2DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTacGia).BeginInit();
            SuspendLayout();
            // 
            // btnLamMoi
            // 
            btnLamMoi.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLamMoi.BorderRadius = 10;
            btnLamMoi.CustomizableEdges = customizableEdges1;
            btnLamMoi.DisabledState.BorderColor = Color.DarkGray;
            btnLamMoi.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLamMoi.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLamMoi.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLamMoi.FillColor = Color.FromArgb(255, 128, 0);
            btnLamMoi.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(1122, 3);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnLamMoi.Size = new Size(125, 56);
            btnLamMoi.TabIndex = 100;
            btnLamMoi.Text = "Làm Mới";
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.BorderRadius = 5;
            txtTimKiem.CustomizableEdges = customizableEdges3;
            txtTimKiem.DefaultText = "";
            txtTimKiem.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtTimKiem.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtTimKiem.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtTimKiem.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtTimKiem.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTimKiem.Font = new Font("Segoe UI", 9F);
            txtTimKiem.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTimKiem.IconLeftSize = new Size(40, 40);
            txtTimKiem.IconRight = (Image)resources.GetObject("txtTimKiem.IconRight");
            txtTimKiem.Location = new Point(12, 9);
            txtTimKiem.Margin = new Padding(3, 4, 3, 4);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PasswordChar = '\0';
            txtTimKiem.PlaceholderText = "Tìm Kiếm";
            txtTimKiem.SelectedText = "";
            txtTimKiem.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtTimKiem.Size = new Size(362, 50);
            txtTimKiem.TabIndex = 71;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // btxoa
            // 
            btxoa.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btxoa.BorderRadius = 10;
            btxoa.CustomizableEdges = customizableEdges5;
            btxoa.DisabledState.BorderColor = Color.DarkGray;
            btxoa.DisabledState.CustomBorderColor = Color.DarkGray;
            btxoa.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btxoa.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btxoa.FillColor = Color.FromArgb(192, 0, 0);
            btxoa.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btxoa.ForeColor = Color.White;
            btxoa.Location = new Point(965, 3);
            btxoa.Name = "btxoa";
            btxoa.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btxoa.Size = new Size(125, 56);
            btxoa.TabIndex = 102;
            btxoa.Text = "Xóa";
            btxoa.Click += btxoa_Click;
            // 
            // btthemm
            // 
            btthemm.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btthemm.BorderRadius = 10;
            btthemm.CustomizableEdges = customizableEdges7;
            btthemm.DisabledState.BorderColor = Color.DarkGray;
            btthemm.DisabledState.CustomBorderColor = Color.DarkGray;
            btthemm.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btthemm.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btthemm.FillColor = Color.FromArgb(0, 192, 0);
            btthemm.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btthemm.ForeColor = Color.White;
            btthemm.Location = new Point(814, 3);
            btthemm.Name = "btthemm";
            btthemm.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btthemm.Size = new Size(125, 56);
            btthemm.TabIndex = 101;
            btthemm.Text = "Thêm";
            btthemm.Click += btthemm_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtTimKiem);
            panel1.Controls.Add(btnLamMoi);
            panel1.Controls.Add(btxoa);
            panel1.Controls.Add(btthemm);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1259, 70);
            panel1.TabIndex = 103;
            // 
            // dgvTacGia
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvTacGia.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvTacGia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvTacGia.ColumnHeadersHeight = 50;
            dgvTacGia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvTacGia.DefaultCellStyle = dataGridViewCellStyle3;
            dgvTacGia.Dock = DockStyle.Fill;
            dgvTacGia.GridColor = Color.FromArgb(231, 229, 255);
            dgvTacGia.Location = new Point(0, 70);
            dgvTacGia.Name = "dgvTacGia";
            dgvTacGia.RowHeadersVisible = false;
            dgvTacGia.RowHeadersWidth = 51;
            dgvTacGia.Size = new Size(1259, 814);
            dgvTacGia.TabIndex = 170;
            dgvTacGia.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvTacGia.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvTacGia.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvTacGia.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvTacGia.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvTacGia.ThemeStyle.BackColor = Color.White;
            dgvTacGia.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvTacGia.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvTacGia.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTacGia.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvTacGia.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvTacGia.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvTacGia.ThemeStyle.HeaderStyle.Height = 50;
            dgvTacGia.ThemeStyle.ReadOnly = false;
            dgvTacGia.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvTacGia.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTacGia.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvTacGia.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvTacGia.ThemeStyle.RowsStyle.Height = 29;
            dgvTacGia.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvTacGia.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvTacGia.CellDoubleClick += dgvTacGia_CellDoubleClick_1;
            // 
            // frmTacGia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1259, 884);
            Controls.Add(dgvTacGia);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmTacGia";
            Text = "Tác_Giả";
            TopMost = true;
            WindowState = FormWindowState.Maximized;
            Load += frmTacGia_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTacGia).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnLamMoi;
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2Button btxoa;
        private Guna.UI2.WinForms.Guna2Button btthemm;
        private Panel panel1;
        private Guna.UI2.WinForms.Guna2DataGridView dgvTacGia;
    }
}