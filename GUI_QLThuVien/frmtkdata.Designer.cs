namespace GUI_QLThuVien
{
    partial class frmtkdata
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel1 = new Panel();
            label1 = new Label();
            cbNV = new Guna.UI2.WinForms.Guna2ComboBox();
            btTK = new Guna.UI2.WinForms.Guna2Button();
            dgvdt = new Guna.UI2.WinForms.Guna2DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvdt).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(cbNV);
            panel1.Location = new Point(12, 55);
            panel1.Name = "panel1";
            panel1.Size = new Size(476, 142);
            panel1.TabIndex = 110;
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
            cbNV.CustomizableEdges = customizableEdges1;
            cbNV.DrawMode = DrawMode.OwnerDrawFixed;
            cbNV.DropDownStyle = ComboBoxStyle.DropDownList;
            cbNV.FocusedColor = Color.FromArgb(94, 148, 255);
            cbNV.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cbNV.Font = new Font("Segoe UI", 10F);
            cbNV.ForeColor = Color.FromArgb(68, 88, 112);
            cbNV.ItemHeight = 30;
            cbNV.Location = new Point(62, 46);
            cbNV.Name = "cbNV";
            cbNV.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cbNV.Size = new Size(336, 36);
            cbNV.TabIndex = 100;
            // 
            // btTK
            // 
            btTK.BorderRadius = 5;
            btTK.CustomizableEdges = customizableEdges3;
            btTK.DisabledState.BorderColor = Color.DarkGray;
            btTK.DisabledState.CustomBorderColor = Color.DarkGray;
            btTK.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btTK.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btTK.Font = new Font("Segoe UI", 9F);
            btTK.ForeColor = Color.White;
            btTK.Location = new Point(151, 235);
            btTK.Name = "btTK";
            btTK.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btTK.Size = new Size(158, 56);
            btTK.TabIndex = 109;
            btTK.Text = "Thống Kê";
            btTK.Click += btTK_Click;
            // 
            // dgvdt
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            dgvdt.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvdt.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvdt.ColumnHeadersHeight = 4;
            dgvdt.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvdt.DefaultCellStyle = dataGridViewCellStyle3;
            dgvdt.GridColor = Color.FromArgb(231, 229, 255);
            dgvdt.Location = new Point(494, 12);
            dgvdt.Name = "dgvdt";
            dgvdt.RowHeadersVisible = false;
            dgvdt.RowHeadersWidth = 51;
            dgvdt.Size = new Size(848, 664);
            dgvdt.TabIndex = 111;
            dgvdt.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            dgvdt.ThemeStyle.AlternatingRowsStyle.Font = null;
            dgvdt.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            dgvdt.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            dgvdt.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            dgvdt.ThemeStyle.BackColor = Color.White;
            dgvdt.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            dgvdt.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            dgvdt.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvdt.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            dgvdt.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            dgvdt.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dgvdt.ThemeStyle.HeaderStyle.Height = 4;
            dgvdt.ThemeStyle.ReadOnly = false;
            dgvdt.ThemeStyle.RowsStyle.BackColor = Color.White;
            dgvdt.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvdt.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            dgvdt.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            dgvdt.ThemeStyle.RowsStyle.Height = 29;
            dgvdt.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dgvdt.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dgvdt.Visible = false;
            dgvdt.CellContentClick += dgvdt_CellContentClick;
            // 
            // frmtkdata
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1364, 688);
            Controls.Add(dgvdt);
            Controls.Add(panel1);
            Controls.Add(btTK);
            Name = "frmtkdata";
            Text = "frmtkdata";
            TopMost = true;
            Load += frmtkdata_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvdt).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Guna.UI2.WinForms.Guna2ComboBox cbNV;
        private Guna.UI2.WinForms.Guna2Button btTK;
        private Guna.UI2.WinForms.Guna2DataGridView dgvdt;
    }
}