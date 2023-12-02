
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnEdit = new System.Windows.Forms.Panel();
            this.label = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbMaPK = new System.Windows.Forms.ComboBox();
            this.dtNgayLapPhieu = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMaHD = new System.Windows.Forms.TextBox();
            this.dgvQLHD = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbTenBN = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLapHD = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTongTien = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pnEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLHD)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.label.Location = new System.Drawing.Point(587, 25);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(279, 40);
            this.label.TabIndex = 0;
            this.label.Text = "Quản lý hóa đơn";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(181)))), ((int)(((byte)(252)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Inter Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::QuanLyBenhNhan.Properties.Resources.icons8_save_19;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(834, 352);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(145, 39);
            this.btnSave.TabIndex = 132;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbMaPK
            // 
            this.cbMaPK.Font = new System.Drawing.Font("Inter", 10.2F);
            this.cbMaPK.FormattingEnabled = true;
            this.cbMaPK.Location = new System.Drawing.Point(739, 173);
            this.cbMaPK.Name = "cbMaPK";
            this.cbMaPK.Size = new System.Drawing.Size(192, 28);
            this.cbMaPK.TabIndex = 131;
            this.cbMaPK.SelectedIndexChanged += new System.EventHandler(this.cbMaPK_SelectedIndexChanged);
            // 
            // dtNgayLapPhieu
            // 
            this.dtNgayLapPhieu.Font = new System.Drawing.Font("Inter", 10.2F);
            this.dtNgayLapPhieu.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayLapPhieu.Location = new System.Drawing.Point(365, 216);
            this.dtNgayLapPhieu.Name = "dtNgayLapPhieu";
            this.dtNgayLapPhieu.Size = new System.Drawing.Size(141, 28);
            this.dtNgayLapPhieu.TabIndex = 129;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Inter", 10.2F);
            this.label3.Location = new System.Drawing.Point(244, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 121;
            this.label3.Text = "Ngày lập";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Inter", 10.2F);
            this.label6.Location = new System.Drawing.Point(577, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 20);
            this.label6.TabIndex = 119;
            this.label6.Text = "Mã phiếu khám";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Inter", 10.2F);
            this.label1.Location = new System.Drawing.Point(244, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 118;
            this.label1.Text = "Mã hóa đơn";
            // 
            // tbMaHD
            // 
            this.tbMaHD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbMaHD.Font = new System.Drawing.Font("Inter", 10.2F);
            this.tbMaHD.Location = new System.Drawing.Point(365, 176);
            this.tbMaHD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbMaHD.Name = "tbMaHD";
            this.tbMaHD.Size = new System.Drawing.Size(141, 28);
            this.tbMaHD.TabIndex = 126;
            // 
            // dgvQLHD
            // 
            this.dgvQLHD.AllowUserToAddRows = false;
            this.dgvQLHD.AllowUserToDeleteRows = false;
            this.dgvQLHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQLHD.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Inter", 10.2F);
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQLHD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dgvQLHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQLHD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Inter", 10.2F);
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQLHD.DefaultCellStyle = dataGridViewCellStyle22;
            this.dgvQLHD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvQLHD.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(181)))), ((int)(((byte)(252)))));
            this.dgvQLHD.Location = new System.Drawing.Point(0, 689);
            this.dgvQLHD.Name = "dgvQLHD";
            this.dgvQLHD.ReadOnly = true;
            this.dgvQLHD.RowHeadersVisible = false;
            this.dgvQLHD.RowHeadersWidth = 51;
            this.dgvQLHD.RowTemplate.Height = 24;
            this.dgvQLHD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQLHD.Size = new System.Drawing.Size(1402, 294);
            this.dgvQLHD.TabIndex = 116;
            this.dgvQLHD.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQLHD_RowEnter);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Mahoadon";
            this.Column1.HeaderText = "Mã hóa đơn";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Ngaylaphoadon";
            this.Column2.HeaderText = "Ngày lập";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "TenBN";
            this.Column3.HeaderText = "Tên bệnh nhân";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "MaPK";
            this.Column4.HeaderText = "Mã phiếu khám";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "TongTien";
            this.Column5.HeaderText = "Tổng Tiền dịch vụ";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // tbTenBN
            // 
            this.tbTenBN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTenBN.Font = new System.Drawing.Font("Inter", 10.2F);
            this.tbTenBN.Location = new System.Drawing.Point(739, 220);
            this.tbTenBN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbTenBN.Name = "tbTenBN";
            this.tbTenBN.Size = new System.Drawing.Size(192, 28);
            this.tbTenBN.TabIndex = 125;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Inter", 10.2F);
            this.label7.Location = new System.Drawing.Point(577, 222);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 20);
            this.label7.TabIndex = 122;
            this.label7.Text = "Tên bệnh nhân";
            // 
            // btnLapHD
            // 
            this.btnLapHD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(146)))), ((int)(((byte)(70)))));
            this.btnLapHD.FlatAppearance.BorderSize = 0;
            this.btnLapHD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLapHD.Font = new System.Drawing.Font("Inter Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLapHD.ForeColor = System.Drawing.Color.White;
            this.btnLapHD.Image = global::QuanLyBenhNhan.Properties.Resources.icons8_add_20;
            this.btnLapHD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLapHD.Location = new System.Drawing.Point(1018, 352);
            this.btnLapHD.Margin = new System.Windows.Forms.Padding(0);
            this.btnLapHD.Name = "btnLapHD";
            this.btnLapHD.Size = new System.Drawing.Size(145, 39);
            this.btnLapHD.TabIndex = 140;
            this.btnLapHD.Text = "Lập hóa đơn";
            this.btnLapHD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLapHD.UseVisualStyleBackColor = false;
            this.btnLapHD.Click += new System.EventHandler(this.btnLapHD_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Inter", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(418, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 34);
            this.label2.TabIndex = 141;
            this.label2.Text = "Tổng thu";
            // 
            // tbTongTien
            // 
            this.tbTongTien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbTongTien.Font = new System.Drawing.Font("Inter", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTongTien.Location = new System.Drawing.Point(560, 290);
            this.tbTongTien.Name = "tbTongTien";
            this.tbTongTien.ReadOnly = true;
            this.tbTongTien.Size = new System.Drawing.Size(192, 40);
            this.tbTongTien.TabIndex = 142;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(181)))), ((int)(((byte)(252)))));
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 657);
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
            this.label13.Size = new System.Drawing.Size(234, 35);
            this.label13.TabIndex = 0;
            this.label13.Text = "Danh sách hóa đơn";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbTongTien);
            this.groupBox2.Controls.Add(this.tbMaHD);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbTenBN);
            this.groupBox2.Controls.Add(this.btnLapHD);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cbMaPK);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dtNgayLapPhieu);
            this.groupBox2.Location = new System.Drawing.Point(21, 95);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1198, 410);
            this.groupBox2.TabIndex = 154;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
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
            this.label9.Size = new System.Drawing.Size(225, 35);
            this.label9.TabIndex = 0;
            this.label9.Text = "Thông tin hóa đơn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Inter Medium", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(370, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(500, 41);
            this.label4.TabIndex = 143;
            this.label4.Text = "Hóa đơn khám và điều trị răng";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyBenhNhan.Properties.Resources._20;
            this.pictureBox1.Location = new System.Drawing.Point(30, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 144;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label5.Font = new System.Drawing.Font("Inter Medium Italic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 384);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(307, 23);
            this.label5.TabIndex = 145;
            this.label5.Text = "(*)Là tổng tiền của tất cả dịch vụ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Inter Italic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(402, 301);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 29);
            this.label8.TabIndex = 146;
            this.label8.Text = "*";
            // 
            // FormQLHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1402, 983);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dgvQLHD);
            this.Controls.Add(this.pnEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormQLHD";
            this.Text = "FormQLHD";
            this.Load += new System.EventHandler(this.FormQLHD_Load);
            this.pnEdit.ResumeLayout(false);
            this.pnEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLHD)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnEdit;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbMaPK;
        private System.Windows.Forms.DateTimePicker dtNgayLapPhieu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMaHD;
        private System.Windows.Forms.DataGridView dgvQLHD;
        private System.Windows.Forms.TextBox tbTenBN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLapHD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
    }
}