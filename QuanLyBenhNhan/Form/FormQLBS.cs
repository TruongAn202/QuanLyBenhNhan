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
            string tenbs = tbTenBS.Text.Trim();
            string sdt = tbSDT.Text.Trim();
            string diachi = tbDiaChi.Text.Trim();
            string gioitinh = cbGioiTinh.Text;

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
            else if (string.IsNullOrEmpty(tenbs) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(diachi) || string.IsNullOrEmpty(gioitinh))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bác sĩ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                xulyBS.insertBS(new CBacSi(mabs, tenbs, sdt, diachi, gioitinh, dtNgaySInh.Value, dtNgayVaoLam.Value));
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

        private void btnTim_Click(object sender, EventArgs e)
        {
            string mabs = tbTim.Text.Trim();

            if (string.IsNullOrEmpty(mabs))
            {
                MessageBox.Show("Vui lòng nhập mã bác sĩ vào ô tìm kiếm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbTim.Focus();
                return;
            }

            int columnIndexMaBN = 0; //thay 0 bang cot thuc te
            //xoa hightlight trc do
            foreach (DataGridViewRow row in dgvDSBS.Rows)
            {
                dgvDSBS.ClearSelection();
                row.DefaultCellStyle.BackColor = dgvDSBS.DefaultCellStyle.BackColor;
                row.DefaultCellStyle.ForeColor = dgvDSBS.DefaultCellStyle.ForeColor;
            }
            CBacSi bs = xulyBS.searchBS(mabs);

            if (bs != null)
            {
                DataGridViewRow foundRow = dgvDSBS.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells[columnIndexMaBN].Value.ToString() == mabs)
                    .FirstOrDefault();

                if (foundRow != null)
                {
                    //hightlight
                    foundRow.DefaultCellStyle.BackColor = Color.Yellow;
                    foundRow.DefaultCellStyle.ForeColor = Color.Black;

                    // Tùy chọn: Scroll đến dòng được tìm thấy
                    dgvDSBS.FirstDisplayedScrollingRowIndex = foundRow.Index;
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy bác sĩ có mã: " + mabs + ". Vui lòng kiểm tra lại và nhập mã theo định dạng đúng (viết hoa và viết thường).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbTim.Focus();
            }
            tbTim.Clear();
        }

        private void tbTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {  
                e.SuppressKeyPress = true; // Ngăn chặn tiếp tục xử lý sự kiện KeyPress    
                string mabs = tbTim.Text.Trim();
                if (string.IsNullOrEmpty(mabs))
                { 
                    MessageBox.Show("Vui lòng nhập mã bệnh nhân.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbTim.SelectAll();
                    tbTim.Focus();
                    return;
                }
                int columnIndexMaBN = 0; // Thay thế 0 bằng chỉ mục cột thực tế của cột chứa mã bệnh nhân trong DataGridView của bạn

                foreach (DataGridViewRow row in dgvDSBS.Rows)
                {
                    row.DefaultCellStyle.BackColor = dgvDSBS.DefaultCellStyle.BackColor;
                    row.DefaultCellStyle.ForeColor = dgvDSBS.DefaultCellStyle.ForeColor;
                }
                CBacSi bs = xulyBS.searchBS(mabs);

                if (bs != null)
                {
                    // Tìm dòng chứa dữ liệu của bệnh nhân được tìm thấy
                    DataGridViewRow foundRow = dgvDSBS.Rows
                        .Cast<DataGridViewRow>()
                        .Where(r => r.Cells[columnIndexMaBN].Value.ToString() == mabs)
                        .FirstOrDefault();
                    if (foundRow != null)
                    {
                        dgvDSBS.ClearSelection();
                        foundRow.DefaultCellStyle.BackColor = Color.Yellow;
                        foundRow.DefaultCellStyle.ForeColor = Color.Black;
                  
                        dgvDSBS.FirstDisplayedScrollingRowIndex = foundRow.Index;
                    }
                }
                else
                { 
                    MessageBox.Show("Không tìm thấy bệnh nhân có mã: " + mabs + ". Vui lòng kiểm tra lại và nhập mã theo định dạng đúng (viết hoa và viết thường).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    tbTim.Focus();
                }
                tbTim.Clear();
            }
            
        }

        private void tbTim_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
