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
    public partial class FormQLBN : Form
    {
        private CXuLyBenhNhan xulyBN = new CXuLyBenhNhan();
        public FormQLBN()
        {
            InitializeComponent();
        }

        private void clear()
        {
            tbMaBN.Text = "";
            tbTenBN.Text = "";
            tbSDT.Text = "";
            tbDiaChi.Text = "";
            cbGioiTinh.Text = "";
            dtNgayKham.Value = DateTime.Today;
            dtNgaySInh.Value = DateTime.Today;
            tbGhiChu.Text = "";
            tbMaBN.Focus();
        }
        private void show()
        {
            BindingSource bs = new BindingSource(); // dối tượng kết nối dữ liệu
            bs.DataSource = xulyBN.getDsBenhNhan(); //cho dữ liệu của bs dc gán bằng dữ liệu của danh sách xulyBN
            dgvDSBN.DataSource = bs; // lấy dữ liệu đó gán vào dữ liệu datagirdview

            
        }
        private string getMaBN() //lấy mã bệnh nhân của dòng đang chọn 
        {
            if (dgvDSBN.SelectedRows.Count == 0) return "";
            int index = dgvDSBN.SelectedRows[0].Index;
            return dgvDSBN.Rows[index].Cells[0].Value.ToString();
        }

        private void dgvDSBN_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // Vẽ số thứ tự lên cột đầu tiên (index 0)
            using (SolidBrush brush = new SolidBrush(dgvDSBN.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, brush, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void dgvDSBN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void FormQLBN_Load(object sender, EventArgs e)
        {
            
            dgvDSBN.RowPostPaint += dgvDSBN_RowPostPaint;
            dgvDSBN.RowHeadersVisible = true; // STT
            dgvDSBN.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders; // dieu chinh cot trai de chua all noi dung
            //dgvDSBN.EnableHeadersVisualStyles = false;
            //dgvDSBN.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; 
            //dgvDSBN.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(140, 181, 252);
            //dgvDSBN.DefaultCellStyle.Font = new Font("Inter", 9, FontStyle.Regular);
            // Đổi font chữ cho thanh tiêu đề
            //dgvDSBN.ColumnHeadersDefaultCellStyle.Font = new Font("Inter", 9, FontStyle.Regular);
            //string defaultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dataQLBN.dat");
            //if (File.Exists(defaultPath))
            //{
            //    xulyBN.docFile(defaultPath);
            //}
            dgvDSBN.DataSource = xulyBN.getDsBenhNhan();
            
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string mabn = tbMaBN.Text.Trim();
            if (string.IsNullOrEmpty(mabn))
            {
                MessageBox.Show("Vui lòng nhập mã bệnh nhân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (xulyBN.ktTrungMa(mabn))
            {
                MessageBox.Show("Mã bệnh nhân đã tồn tại. Vui lòng chọn mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            else {
                xulyBN.insertBN(new CBenhNhan(tbMaBN.Text, tbTenBN.Text, tbSDT.Text, tbDiaChi.Text, cbGioiTinh.Text/*rbNam.Checked*/, dtNgaySInh.Value, dtNgayKham.Value, tbGhiChu.Text));

                clear();
                show();
            }
            dgvDSBN.ClearSelection();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string mabn = getMaBN();
            if (mabn != "")
            {
                xulyBN.deleteBN(mabn);

                clear();
                show();
            }
            dgvDSBN.ClearSelection();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string mabn = getMaBN();
            if (mabn == "") return;
            CBenhNhan bn = xulyBN.searchBN(mabn);

            string newMaBN = tbMaBN.Text.Trim(); // Trim(): loai bo khoang trang

            // Kiểm tra xem mã bệnh nhân đã thay đổi hay không
            if (!newMaBN.Equals(mabn, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Không được sửa mã bệnh nhân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                tbMaBN.Text = mabn;              
                return;
            }

            bn.TenBN = tbTenBN.Text;
            bn.SoDienThoai = tbSDT.Text;
            bn.DiaChi = tbDiaChi.Text;
            bn.GioiTinh = cbGioiTinh.Text;
            bn.NgayKham = dtNgayKham.Value;
            bn.NgaySinh = dtNgaySInh.Value;
            bn.GhiChu = tbGhiChu.Text;

            xulyBN.updateBN(bn);

            clear();
            show();
            dgvDSBN.ClearSelection();
        }

        private void dgvDSBN_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string mabn = getMaBN();
            if (mabn == "") return;
            CBenhNhan bn = xulyBN.searchBN(mabn); // không duoc sua mã
               
            tbMaBN.Text = bn.MaBN;
            tbTenBN.Text = bn.TenBN;
            tbSDT.Text = bn.SoDienThoai;
            tbDiaChi.Text = bn.DiaChi;
            cbGioiTinh.Text = bn.GioiTinh;
            dtNgayKham.Value = bn.NgayKham;
            dtNgaySInh.Value = bn.NgaySinh;
            tbGhiChu.Text = bn.GhiChu;
        }       

        private void btnSave_Click(object sender, EventArgs e)
        {
            //string defaultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dataQLBN.dat");

            if (TruyCapDuLieu.luuFile("data.dat"))
            {
                MessageBox.Show("Dữ liệu đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thể lưu dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgvDSBN.ClearSelection();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgvDSBN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
