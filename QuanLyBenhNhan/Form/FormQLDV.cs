using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBenhNhan
{
    public partial class FormQLDV : Form
    {
        CXuLyDichVu xulyDV = new CXuLyDichVu();
        public FormQLDV()
        {
            InitializeComponent();
        }

        private void clear()
        {
            tbDonGia.Text = "";
            tbMaDV.Text = "";
            tbTenDV.Text = "";
            tbMaDV.Focus();
        }
        private void show()
        {
            BindingSource bs = new BindingSource(); // dối tượng kết nối dữ liệu
            bs.DataSource = xulyDV.getDsDichVu(); //cho dữ liệu của bs dc gán bằng dữ liệu của danh sách xulyBN
            dgvDSDV.DataSource = bs; // lấy dữ liệu đó gán vào dữ liệu datagirdview

            clear();
        }
        private string getMaDV()  
        {
            if (dgvDSDV.SelectedRows.Count == 0) return "";
            int index = dgvDSDV.SelectedRows[0].Index;
            return dgvDSDV.Rows[index].Cells[0].Value.ToString();
        }
               

        private void dgvDSDV_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string madv = getMaDV();
            if (madv == "") return;

            CDichVu dv = xulyDV.searchDV(madv);

            tbMaDV.Text = dv.MaDichVu;
            tbTenDV.Text = dv.TenDichVu;
            tbDonGia.Text = dv.Dongia.ToString();
        }

        private void dgvDSDV_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // Vẽ số thứ tự lên cột đầu tiên (index 0)
            using (SolidBrush brush = new SolidBrush(dgvDSDV.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, brush, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void FormQLDV_Load(object sender, EventArgs e)
        {    
            // insert stt
            dgvDSDV.RowPostPaint += dgvDSDV_RowPostPaint;
            dgvDSDV.RowHeadersVisible = true;
            dgvDSDV.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            
            //luu
            //string defaultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dataQLDV.dat");
            //if (File.Exists(defaultPath))
            //{
            //    xulyDV.docFile(defaultPath);
            //}
            dgvDSDV.DataSource = xulyDV.getDsDichVu();
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string madv = getMaDV();
            if (madv != "")
            {
                xulyDV.deleteDV(madv);
                show();
            }
            dgvDSDV.ClearSelection();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //string defaultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dataQLDV.dat");

            if (TruyCapDuLieu.luuFile("data.dat"))
            {
                MessageBox.Show("Dữ liệu đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thể lưu dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgvDSDV.ClearSelection();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string madv = getMaDV();
            if (madv == "") return;
            CDichVu dv = xulyDV.searchDV(madv);

            string newMaBS = tbMaDV.Text.Trim();

            if (!newMaBS.Equals(madv, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Không được sửa mã dịch vụ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                tbMaDV.Text = madv;
                return;
            }

            dv.TenDichVu = tbTenDV.Text;
            dv.MaDichVu = tbMaDV.Text;
            dv.Dongia = double.Parse(tbDonGia.Text);

            xulyDV.updateDV(dv);
            show();
            dgvDSDV.ClearSelection();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string madv = tbMaDV.Text.Trim();
            string tenDV = tbTenDV.Text.Trim();
            string donGiaStr = tbDonGia.Text.Trim();

            if (string.IsNullOrEmpty(madv))
            {
                MessageBox.Show("Vui lòng nhập mã dịch vụ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (xulyDV.ktTrungMa(madv))
            {
                MessageBox.Show("Mã dịch vụ đã tồn tại. Vui lòng chọn mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (!double.TryParse(donGiaStr, out double donGia))
            {
                MessageBox.Show("Đơn giá phải là số. Vui lòng viết lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbDonGia.Focus();
                return;
            }
            else
            {
                // Truyền giá trị đã kiểm tra và xác định trước đó
                xulyDV.insertDV(new CDichVu(madv, tenDV, donGia));
                show();
                dgvDSDV.ClearSelection();
            }
        }

        private void dgvDSDV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
