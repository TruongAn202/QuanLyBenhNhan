
namespace QuanLyBenhNhan
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnCloseMain = new System.Windows.Forms.Button();
            this.btnQLHD = new System.Windows.Forms.Button();
            this.btnQLPK = new System.Windows.Forms.Button();
            this.btnQLBS = new System.Windows.Forms.Button();
            this.btnQLDV = new System.Windows.Forms.Button();
            this.btnQLBN = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.labTime = new System.Windows.Forms.Label();
            this.labDay = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            this.panelChildForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(96)))), ((int)(((byte)(167)))));
            this.panelMenu.Controls.Add(this.btnCloseMain);
            this.panelMenu.Controls.Add(this.btnQLHD);
            this.panelMenu.Controls.Add(this.btnQLPK);
            this.panelMenu.Controls.Add(this.btnQLBS);
            this.panelMenu.Controls.Add(this.btnQLDV);
            this.panelMenu.Controls.Add(this.btnQLBN);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(295, 983);
            this.panelMenu.TabIndex = 0;
            // 
            // btnCloseMain
            // 
            this.btnCloseMain.FlatAppearance.BorderSize = 0;
            this.btnCloseMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseMain.Font = new System.Drawing.Font("Inter Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseMain.ForeColor = System.Drawing.Color.White;
            this.btnCloseMain.Image = global::QuanLyBenhNhan.Properties.Resources.icons8_exit_25;
            this.btnCloseMain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCloseMain.Location = new System.Drawing.Point(5, 475);
            this.btnCloseMain.Name = "btnCloseMain";
            this.btnCloseMain.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnCloseMain.Size = new System.Drawing.Size(130, 50);
            this.btnCloseMain.TabIndex = 6;
            this.btnCloseMain.Text = "Thoát";
            this.btnCloseMain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCloseMain.UseVisualStyleBackColor = true;
            this.btnCloseMain.Click += new System.EventHandler(this.btnCloseMain_Click_1);
            // 
            // btnQLHD
            // 
            this.btnQLHD.FlatAppearance.BorderSize = 0;
            this.btnQLHD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLHD.Font = new System.Drawing.Font("Inter Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLHD.ForeColor = System.Drawing.Color.White;
            this.btnQLHD.Image = global::QuanLyBenhNhan.Properties.Resources.icons8_bill_20;
            this.btnQLHD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLHD.Location = new System.Drawing.Point(5, 419);
            this.btnQLHD.Name = "btnQLHD";
            this.btnQLHD.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnQLHD.Size = new System.Drawing.Size(236, 50);
            this.btnQLHD.TabIndex = 5;
            this.btnQLHD.Text = "Quản lý hóa đơn";
            this.btnQLHD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQLHD.UseVisualStyleBackColor = true;
            this.btnQLHD.Click += new System.EventHandler(this.btnQLHD_Click);
            // 
            // btnQLPK
            // 
            this.btnQLPK.FlatAppearance.BorderSize = 0;
            this.btnQLPK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLPK.Font = new System.Drawing.Font("Inter Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLPK.ForeColor = System.Drawing.Color.White;
            this.btnQLPK.Image = global::QuanLyBenhNhan.Properties.Resources.icons8_report_20;
            this.btnQLPK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLPK.Location = new System.Drawing.Point(5, 363);
            this.btnQLPK.Name = "btnQLPK";
            this.btnQLPK.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnQLPK.Size = new System.Drawing.Size(267, 50);
            this.btnQLPK.TabIndex = 4;
            this.btnQLPK.Text = "Quản lý phiếu khám";
            this.btnQLPK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQLPK.UseVisualStyleBackColor = true;
            this.btnQLPK.Click += new System.EventHandler(this.btnQLPK_Click);
            // 
            // btnQLBS
            // 
            this.btnQLBS.FlatAppearance.BorderSize = 0;
            this.btnQLBS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLBS.Font = new System.Drawing.Font("Inter Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLBS.ForeColor = System.Drawing.Color.White;
            this.btnQLBS.Image = global::QuanLyBenhNhan.Properties.Resources.icons8_medical_doctor_20;
            this.btnQLBS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLBS.Location = new System.Drawing.Point(5, 307);
            this.btnQLBS.Name = "btnQLBS";
            this.btnQLBS.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnQLBS.Size = new System.Drawing.Size(214, 50);
            this.btnQLBS.TabIndex = 3;
            this.btnQLBS.Text = "Quản lý bác sĩ";
            this.btnQLBS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQLBS.UseVisualStyleBackColor = true;
            this.btnQLBS.Click += new System.EventHandler(this.btnQLBS_Click);
            // 
            // btnQLDV
            // 
            this.btnQLDV.FlatAppearance.BorderSize = 0;
            this.btnQLDV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLDV.Font = new System.Drawing.Font("Inter Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLDV.ForeColor = System.Drawing.Color.White;
            this.btnQLDV.Image = global::QuanLyBenhNhan.Properties.Resources.icons8_list_20;
            this.btnQLDV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLDV.Location = new System.Drawing.Point(11, 246);
            this.btnQLDV.Name = "btnQLDV";
            this.btnQLDV.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnQLDV.Size = new System.Drawing.Size(222, 50);
            this.btnQLDV.TabIndex = 2;
            this.btnQLDV.Text = "Quản lý dịch vụ";
            this.btnQLDV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQLDV.UseVisualStyleBackColor = true;
            this.btnQLDV.Click += new System.EventHandler(this.btnQLDV_Click);
            // 
            // btnQLBN
            // 
            this.btnQLBN.FlatAppearance.BorderSize = 0;
            this.btnQLBN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQLBN.Font = new System.Drawing.Font("Inter Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLBN.ForeColor = System.Drawing.Color.White;
            this.btnQLBN.Image = global::QuanLyBenhNhan.Properties.Resources.icons8_pulse_25;
            this.btnQLBN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLBN.Location = new System.Drawing.Point(5, 190);
            this.btnQLBN.Name = "btnQLBN";
            this.btnQLBN.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnQLBN.Size = new System.Drawing.Size(260, 50);
            this.btnQLBN.TabIndex = 1;
            this.btnQLBN.Text = "Quản lý bệnh nhân";
            this.btnQLBN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQLBN.UseVisualStyleBackColor = true;
            this.btnQLBN.Click += new System.EventHandler(this.btnQLBN_Click);
            this.btnQLBN.MouseEnter += new System.EventHandler(this.btnInsertCha_MouseEnter);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(96)))), ((int)(((byte)(167)))));
            this.panelLogo.Controls.Add(this.btnHome);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(295, 184);
            this.panelLogo.TabIndex = 0;
            // 
            // btnHome
            // 
            this.btnHome.Image = global::QuanLyBenhNhan.Properties.Resources._30;
            this.btnHome.Location = new System.Drawing.Point(12, 12);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(166, 138);
            this.btnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnHome.TabIndex = 0;
            this.btnHome.TabStop = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panelChildForm
            // 
            this.panelChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(181)))), ((int)(((byte)(252)))));
            this.panelChildForm.Controls.Add(this.labTime);
            this.panelChildForm.Controls.Add(this.labDay);
            this.panelChildForm.Controls.Add(this.pictureBox1);
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(295, 0);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(1402, 983);
            this.panelChildForm.TabIndex = 2;
            // 
            // labTime
            // 
            this.labTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labTime.AutoSize = true;
            this.labTime.Font = new System.Drawing.Font("Inter", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labTime.ForeColor = System.Drawing.Color.White;
            this.labTime.Location = new System.Drawing.Point(531, 601);
            this.labTime.Name = "labTime";
            this.labTime.Size = new System.Drawing.Size(170, 72);
            this.labTime.TabIndex = 2;
            this.labTime.Text = "Time";
            // 
            // labDay
            // 
            this.labDay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labDay.AutoSize = true;
            this.labDay.Font = new System.Drawing.Font("Inter Italic", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labDay.ForeColor = System.Drawing.Color.White;
            this.labDay.Location = new System.Drawing.Point(501, 673);
            this.labDay.Name = "labDay";
            this.labDay.Size = new System.Drawing.Size(57, 29);
            this.labDay.TabIndex = 1;
            this.labDay.Text = "Day";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::QuanLyBenhNhan.Properties.Resources.An__5_;
            this.pictureBox1.Location = new System.Drawing.Point(475, 214);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(480, 480);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1697, 983);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.panelMenu);
            this.MinimumSize = new System.Drawing.Size(998, 553);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý bệnh nhân";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            this.panelChildForm.ResumeLayout(false);
            this.panelChildForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnQLHD;
        private System.Windows.Forms.Button btnQLPK;
        private System.Windows.Forms.Button btnQLDV;
        private System.Windows.Forms.Button btnQLBN;
        private System.Windows.Forms.PictureBox btnHome;
        private System.Windows.Forms.Label labDay;
        private System.Windows.Forms.Label labTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnQLBS;
        private System.Windows.Forms.Button btnCloseMain;
    }
}

