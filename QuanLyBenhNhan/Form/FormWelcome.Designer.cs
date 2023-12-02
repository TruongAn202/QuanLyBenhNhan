
namespace QuanLyBenhNhan
{
    partial class FormWelcome
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
            this.NameApp = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnResDown = new System.Windows.Forms.Button();
            this.btnMini = new System.Windows.Forms.Button();
            this.groupStart = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.groupStart.SuspendLayout();
            this.SuspendLayout();
            // 
            // NameApp
            // 
            this.NameApp.AutoSize = true;
            this.NameApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameApp.ForeColor = System.Drawing.Color.White;
            this.NameApp.Location = new System.Drawing.Point(63, 85);
            this.NameApp.Name = "NameApp";
            this.NameApp.Size = new System.Drawing.Size(545, 39);
            this.NameApp.TabIndex = 0;
            this.NameApp.Text = "Quản lý bệnh nhân tại phòng khám";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(147)))), ((int)(((byte)(177)))));
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(253, 205);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(141, 60);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(147)))), ((int)(((byte)(177)))));
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnResDown);
            this.panel1.Controls.Add(this.btnMini);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 57);
            this.panel1.TabIndex = 2;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::QuanLyBenhNhan.Properties.Resources.icons8_close_30__3_;
            this.btnClose.Location = new System.Drawing.Point(731, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(60, 50);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnResDown
            // 
            this.btnResDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResDown.FlatAppearance.BorderSize = 0;
            this.btnResDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResDown.Image = global::QuanLyBenhNhan.Properties.Resources.icons8_restore_down_30__1_;
            this.btnResDown.Location = new System.Drawing.Point(655, 0);
            this.btnResDown.Name = "btnResDown";
            this.btnResDown.Size = new System.Drawing.Size(60, 50);
            this.btnResDown.TabIndex = 0;
            this.btnResDown.UseVisualStyleBackColor = true;
            this.btnResDown.Click += new System.EventHandler(this.btnResDown_Click);
            // 
            // btnMini
            // 
            this.btnMini.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMini.FlatAppearance.BorderSize = 0;
            this.btnMini.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMini.Image = global::QuanLyBenhNhan.Properties.Resources.icons8_subtract_30__1_;
            this.btnMini.Location = new System.Drawing.Point(574, 0);
            this.btnMini.Name = "btnMini";
            this.btnMini.Size = new System.Drawing.Size(60, 50);
            this.btnMini.TabIndex = 0;
            this.btnMini.UseVisualStyleBackColor = true;
            this.btnMini.Click += new System.EventHandler(this.btnMini_Click);
            // 
            // groupStart
            // 
            this.groupStart.Controls.Add(this.btnStart);
            this.groupStart.Controls.Add(this.NameApp);
            this.groupStart.ForeColor = System.Drawing.Color.White;
            this.groupStart.Location = new System.Drawing.Point(68, 99);
            this.groupStart.Name = "groupStart";
            this.groupStart.Size = new System.Drawing.Size(667, 293);
            this.groupStart.TabIndex = 3;
            this.groupStart.TabStop = false;
            // 
            // FormWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(177)))), ((int)(((byte)(196)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupStart);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "FormWelcome";
            this.Text = "FormWelcome";
            this.Load += new System.EventHandler(this.FormWelcome_Load);
            this.panel1.ResumeLayout(false);
            this.groupStart.ResumeLayout(false);
            this.groupStart.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label NameApp;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnResDown;
        private System.Windows.Forms.Button btnMini;
        private System.Windows.Forms.GroupBox groupStart;
    }
}