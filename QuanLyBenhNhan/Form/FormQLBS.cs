using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace QuanLyBenhNhan
{
    public partial class FormQLBS : Form
    {
        private CXuLyBacSi xulyBS = new CXuLyBacSi();
        

        public FormQLBS()
        {
            InitializeComponent();
        }

        private void clear()
        {
            tbMaBS.Text = "";
            tbTenBS.Text = "";
            tbSDT.Text = "";
            tbDiaChi.Text = "";
            cbGioiTinh.Text = "";
            dtNgayVaoLam.Value = DateTime.Today;
            dtNgaySInh.Value = DateTime.Today;
            tbMaBS.Focus();
        }

        private void show()
        {
            BindingSource BS = new BindingSource(); // dối tượng kết nối dữ liệu
            BS.DataSource = xulyBS.getDsBacSi(); //cho dữ liệu của bs dc gán bằng dữ liệu của danh sách xulyBN
            dgvDSBS.DataSource = BS; // lấy dữ liệu đó gán vào dữ liệu datagirdview

            clear();
        }

        private string getMaBS() //lấy mã bác sĩ của dòng đang chọn 
        {
            if (dgvDSBS.SelectedRows.Count == 0) return "";
            int index = dgvDSBS.SelectedRows[0].Index;
            return dgvDSBS.Rows[index].Cells[0].Value.ToString();
        }

        

        

        

        private void dgvDSBS_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string mabs = getMaBS();
            if (mabs == "") return;
            CBacSi doctor = xulyBS.searchBS(mabs);

            tbMaBS.Text = doctor.MaBS;
            tbTenBS.Text = doctor.TenBS;
            tbSDT.Text = doctor.SoDienThoai;
            tbDiaChi.Text = doctor.DiaChi;
            cbGioiTinh.Text = doctor.GioiTinh;
            dtNgayVaoLam.Value = doctor.NgayVaoLam;
            dtNgaySInh.Value = doctor.NgaySinh;
        }

        private void dgvDSBS_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            // Vẽ số thứ tự lên cột đầu tiên (index 0)
            using (SolidBrush brush = new SolidBrush(dgvDSBS.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(), e.InheritedRowStyle.Font, brush, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
            }
        }

        private void FormQLBS_Load(object sender, EventArgs e)
        {
            dgvDSBS.RowPostPaint += dgvDSBS_RowPostPaint;
            dgvDSBS.RowHeadersVisible = true;
            dgvDSBS.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            //string defaultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dataQLBS.dat");
            //    if (File.Exists(defaultPath))
            //    {
            //        xulyBS.docFile(defaultPath);
            //    }
            dgvDSBS.DataSource = xulyBS.getDsBacSi(); // load data lên dgv ngay
            
        }

        

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            //string defaultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dataQLBS.dat");

            if (TruyCapDuLieu.luuFile("data.dat"))
            {
                MessageBox.Show("Dữ liệu đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thể lưu dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dgvDSBS.ClearSelection();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string mabs = getMaBS();
            if (mabs == "") return;
            CBacSi bs = xulyBS.searchBS(mabs);

            string newMaBS = tbMaBS.Text.Trim();

            if (!newMaBS.Equals(mabs, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Không được sửa mã bác sĩ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                tbMaBS.Text = mabs;
                return;
            }
            bs.TenBS = tbTenBS.Text;
            bs.SoDienThoai = tbSDT.Text;
            bs.DiaChi = tbDiaChi.Text;
            bs.GioiTinh = cbGioiTinh.Text;
            bs.NgayVaoLam = dtNgayVaoLam.Value;
            bs.NgaySinh = dtNgaySInh.Value;

            xulyBS.updateBS(bs);
            show();
            dgvDSBS.ClearSelection();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string mabs = tbMaBS.Text.Trim();
            if (string.IsNullOrEmpty(mabs))
            {
                MessageBox.Show("Vui lòng nhập mã bác sĩ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (xulyBS.ktTrungMa(mabs))
            {
                MessageBox.Show("Mã bác sĩ đã tồn tại. Vui lòng chọn mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                xulyBS.insertBS(new CBacSi(tbMaBS.Text, tbTenBS.Text, tbSDT.Text, tbDiaChi.Text, cbGioiTinh.Text, dtNgaySInh.Value, dtNgayVaoLam.Value));
                show();
            }
            dgvDSBS.ClearSelection();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string mabs = getMaBS();
            if (mabs != "")
            {
                xulyBS.deleteBS(mabs);
                show();
            }
            dgvDSBS.ClearSelection();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void dgvDSBS_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
