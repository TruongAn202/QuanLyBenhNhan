
namespace QuanLyBenhNhan
{
    partial class FormQLHD
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnEdit = new System.Windows.Forms.Panel();
            this.label = new System.Windows.Forms.Label();
            this.dgvDSPK = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbMaPK = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbTim = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbTenBN = new System.Windows.Forms.TextBox();
            this.btnXemHD = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.pnEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSPK)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnEdit
            // 
            this.pnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(181)))), ((int)(((byte)(252)))));
            this.pnEdit.Controls.Add(this.label);
            this.pnEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnEdit.Location = new System.Drawing.Point(0, 0);
            this.pnEdit.Name = "pnEdit";
            this.pnEdit.Size = new System.Drawing.Size(1402, 78);
            this.pnEdit.TabIndex = 102;
            // 
            // label
            // 
            this.label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Inter", 19.8F, System.Drawing.FontStyle.Bold);
            this.label.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label.Location = new System.Drawing.Point(563, 20);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(279, 40);
            this.label.TabIndex = 0;
            this.label.Text = "Quản lý hóa đơn";
            // 
            // dgvDSPK
            // 
            this.dgvDSPK.AllowUserToAddRows = false;
            this.dgvDSPK.AllowUserToDeleteRows = false;
            this.dgvDSPK.AllowUserToResizeColumns = false;
            this.dgvDSPK.AllowUserToResizeRows = false;
            this.dgvDSPK.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDSPK.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Inter", 10.2F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSPK.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSPK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSPK.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Inter", 10.2F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDSPK.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDSPK.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvDSPK.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(181)))), ((int)(((byte)(252)))));
            this.dgvDSPK.Location = new System.Drawing.Point(0, 636);
            this.dgvDSPK.MultiSelect = false;
            this.dgvDSPK.Name = "dgvDSPK";
            this.dgvDSPK.ReadOnly = true;
            this.dgvDSPK.RowHeadersVisible = false;
            this.dgvDSPK.RowHeadersWidth = 51;
            this.dgvDSPK.RowTemplate.Height = 24;
            this.dgvDSPK.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDSPK.Size = new System.Drawing.Size(1402, 347);
            this.dgvDSPK.TabIndex = 116;
            this.dgvDSPK.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQLHD_RowEnter);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Maphieukham";
            this.Column1.HeaderText = "Mã phiếu khám";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "BenhNhan";
            this.Column3.HeaderText = "Tên bệnh nhân";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "BacSi";
            this.Column4.HeaderText = "Tên bác sĩ";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "ThanhTien";
            this.Column5.HeaderText = "Thành tièn";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Ngaylapphieu";
            this.Column2.HeaderText = "Ngày khám";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(181)))), ((int)(((byte)(252)))));
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 604);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1402, 32);
            this.panel3.TabIndex = 153;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Font = new System.Drawing.Font("Inter Medium", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Transparent;
            this.label12.Image = global::QuanLyBenhNhan.Properties.Resources.icons8_list_25;
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 32);
            this.label12.TabIndex = 100;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Inter Medium", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(36, 0);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.label13.Size = new System.Drawing.Size(273, 35);
            this.label13.TabIndex = 0;
            this.label13.Text = "Danh sách phiếu khám";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.tbMaPK);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbTenBN);
            this.groupBox2.Controls.Add(this.btnXemHD);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(21, 94);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1198, 356);
            this.groupBox2.TabIndex = 154;
            this.groupBox2.TabStop = false;
            // 
            // tbMaPK
            // 
            this.tbMaPK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMaPK.Font = new System.Drawing.Font("Inter", 10.2F);
            this.tbMaPK.Location = new System.Drawing.Point(774, 176);
            this.tbMaPK.Multiline = true;
            this.tbMaPK.Name = "tbMaPK";
            this.tbMaPK.ReadOnly = true;
            this.tbMaPK.Size = new System.Drawing.Size(205, 28);
            this.tbMaPK.TabIndex = 160;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbTim);
            this.groupBox1.Controls.Add(this.btnTim);
            this.groupBox1.Font = new System.Drawing.Font("Inter", 12F);
            this.groupBox1.Location = new System.Drawing.Point(11, 240);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(431, 102);
            this.groupBox1.TabIndex = 159;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm";
            // 
            // tbTim
            // 
            this.tbTim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTim.Location = new System.Drawing.Point(229, 30);
            this.tbTim.Multiline = true;
            this.tbTim.Name = "tbTim";
            this.tbTim.Size = new System.Drawing.Size(178, 47);
            this.tbTim.TabIndex = 151;
            this.tbTim.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbTim_KeyDown);
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(181)))), ((int)(((byte)(252)))));
            this.btnTim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTim.FlatAppearance.BorderSize = 0;
            this.btnTim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTim.Font = new System.Drawing.Font("Inter Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.ForeColor = System.Drawing.Color.White;
            this.btnTim.Image = global::QuanLyBenhNhan.Properties.Resources.icons8_magnifying_glass_20;
            this.btnTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTim.Location = new System.Drawing.Point(21, 30);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(178, 47);
            this.btnTim.TabIndex = 150;
            this.btnTim.Text = "Tìm theo mã";
            this.btnTim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTim.UseVisualStyleBackColor = false;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Inter Medium", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(370, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(481, 40);
            this.label4.TabIndex = 143;
            this.label4.Text = "Danh sách phiếu khám đã lập";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(181)))), ((int)(((byte)(252)))));
            this.panel2.Controls.Add(this.label9);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1341, 32);
            this.panel2.TabIndex = 83;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Inter Medium", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(3);
            this.label9.Size = new System.Drawing.Size(264, 35);
            this.label9.TabIndex = 0;
            this.label9.Text = "Thông tin phiếu khám";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Inter", 10.2F);
            this.label6.Location = new System.Drawing.Point(610, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 20);
            this.label6.TabIndex = 119;
            this.label6.Text = "Mã phiếu khám";
            // 
            // tbTenBN
            // 
            this.tbTenBN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTenBN.Enabled = false;
            this.tbTenBN.Font = new System.Drawing.Font("Inter", 10.2F);
            this.tbTenBN.Location = new System.Drawing.Point(377, 176);
            this.tbTenBN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTenBN.Name = "tbTenBN";
            this.tbTenBN.ReadOnly = true;
            this.tbTenBN.Size = new System.Drawing.Size(192, 28);
            this.tbTenBN.TabIndex = 125;
            // 
            // btnXemHD
            // 
            this.btnXemHD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(146)))), ((int)(((byte)(70)))));
            this.btnXemHD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXemHD.FlatAppearance.BorderSize = 0;
            this.btnXemHD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemHD.Font = new System.Drawing.Font("Inter Medium", 12F, System.Drawing.FontStyle.Bold);
            this.btnXemHD.ForeColor = System.Drawing.Color.White;
            this.btnXemHD.Image = global::QuanLyBenhNhan.Properties.Resources.icons8_magnifying_glass_20;
            this.btnXemHD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXemHD.Location = new System.Drawing.Point(996, 298);
            this.btnXemHD.Margin = new System.Windows.Forms.Padding(0);
            this.btnXemHD.Name = "btnXemHD";
            this.btnXemHD.Size = new System.Drawing.Size(187, 44);
            this.btnXemHD.TabIndex = 140;
            this.btnXemHD.Text = "Xem hóa đơn";
            this.btnXemHD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXemHD.UseVisualStyleBackColor = false;
            this.btnXemHD.Click += new System.EventHandler(this.btnXemHD_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Inter", 10.2F);
            this.label7.Location = new System.Drawing.Point(215, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 20);
            this.label7.TabIndex = 122;
            this.label7.Text = "Tên bệnh nhân";
            // 
            // FormQLHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1402, 983);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dgvDSPK);
            this.Controls.Add(this.pnEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormQLHD";
            this.Text = "FormQLHD";
            this.Load += new System.EventHandler(this.FormQLHD_Load);
            this.pnEdit.ResumeLayout(false);
            this.pnEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSPK)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnEdit;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.DataGridView dgvDSPK;
        private System.Windows.Forms.Button btnXemHD;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbTim;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbTenBN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbMaPK;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}