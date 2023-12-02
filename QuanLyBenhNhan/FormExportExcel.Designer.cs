
namespace QuanLyBenhNhan
{
    partial class FormExportExcel
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
            this.panelExportExcel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelExportExcel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelExportExcel
            // 
            this.panelExportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(181)))), ((int)(((byte)(252)))));
            this.panelExportExcel.Controls.Add(this.label1);
            this.panelExportExcel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelExportExcel.Location = new System.Drawing.Point(0, 0);
            this.panelExportExcel.Name = "panelExportExcel";
            this.panelExportExcel.Size = new System.Drawing.Size(852, 78);
            this.panelExportExcel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(326, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Xuất file excel";
            // 
            // FormExportExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 550);
            this.Controls.Add(this.panelExportExcel);
            this.Name = "FormExportExcel";
            this.Text = "FormExportExcel";
            this.panelExportExcel.ResumeLayout(false);
            this.panelExportExcel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelExportExcel;
        private System.Windows.Forms.Label label1;
    }
}