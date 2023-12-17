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
        private CXuLyPhieuKham xulyPK = new CXuLyPhieuKham();
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
        private string getTenBN()
        {
            if (dgvDSBN.SelectedRows.Count > 0)
            {
                // Lấy đối tượng dữ liệu liên kết với dòng được chọn
                CBenhNhan bennhan = dgvDSBN.SelectedRows[0].DataBoundItem as CBenhNhan;

                // Kiểm tra null để tránh lỗi
                if (bennhan != null)
                {
                    // Truy cập thuộc tính TenBS
                    return bennhan.TenBN;
                }
            }

            return "";
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
            dgvDSBN.DataSource = xulyBN.getDsBenhNhan();  
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string mabn = tbMaBN.Text.Trim();
            string tenbn = tbTenBN.Text.Trim();
            string sdt = tbSDT.Text.Trim();
            string diachi = tbDiaChi.Text.Trim();
            string gioitinh = cbGioiTinh.Text;

            if (string.IsNullOrEmpty(mabn))
            {
                MessageBox.Show("Vui lòng nhập mã bệnh nhân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbMaBN.Focus();
                return;
            }
            else if (xulyBN.ktTrungMa(mabn))
            {
                MessageBox.Show("Mã bệnh nhân đã tồn tại. Vui lòng chọn mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(tenbn) || string.IsNullOrEmpty(sdt) || string.IsNullOrEmpty(diachi) || string.IsNullOrEmpty(gioitinh))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bệnh nhân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                xulyBN.insertBN(new CBenhNhan(mabn, tenbn, sdt, diachi, gioitinh, dtNgaySInh.Value, dtNgayKham.Value, tbGhiChu.Text));

                clear();
                show();
            }
            dgvDSBN.ClearSelection();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string tenbn = getTenBN();
            string mabn = getMaBN();
            if (tenbn != "")
            {
                bool benhnhandatontai = false;

                // Kiểm tra xem bác sĩ có tồn tại trong các phiếu khám không
                foreach (CPhieuKham pk in xulyPK.getDsPhieuKham())
                {
                    if (pk.BenhNhan != null && pk.BenhNhan.TenBN == tenbn)
                    {
                        benhnhandatontai = true;
                        break;
                    }
                }
                if (benhnhandatontai)
                {
                    MessageBox.Show("Không thể xóa bệnh nhân đã tồn tại trong ít nhất một phiếu khám.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    xulyBN.deleteBN(mabn);
                    show();
                }
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
        private void btnTim_Click(object sender, EventArgs e)
        {
            string mabn = tbTim.Text.Trim();

            if (string.IsNullOrEmpty(mabn))
            {  
                MessageBox.Show("Vui lòng nhập mã bệnh nhân vào ô tìm kiếm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);                
                tbTim.Focus();   
                return;
            }
            
            int columnIndexMaBN = 0; //thay 0 bang cot thuc te
            //xoa hightlight trc do
            foreach (DataGridViewRow row in dgvDSBN.Rows)
            {
                dgvDSBN.ClearSelection();
                row.DefaultCellStyle.BackColor = dgvDSBN.DefaultCellStyle.BackColor;
                row.DefaultCellStyle.ForeColor = dgvDSBN.DefaultCellStyle.ForeColor;
            }
            CBenhNhan bn = xulyBN.searchBN(mabn);

            if (bn != null)
            {            
                DataGridViewRow foundRow = dgvDSBN.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells[columnIndexMaBN].Value.ToString() == mabn)
                    .FirstOrDefault();

                if (foundRow != null)
                {
                    //hightlight
                    foundRow.DefaultCellStyle.BackColor = Color.Yellow;
                    foundRow.DefaultCellStyle.ForeColor = Color.Black;

                    // Tùy chọn: Scroll đến dòng được tìm thấy
                    dgvDSBN.FirstDisplayedScrollingRowIndex = foundRow.Index;
                }
            }
            else
            {   
                MessageBox.Show("Không tìm thấy bệnh nhân có mã: " + mabn + ". Vui lòng kiểm tra lại và nhập mã theo định dạng đúng (viết hoa và viết thường).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbTim.Focus();
            }
            tbTim.Clear();
        }

        private void tbTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {  
                e.SuppressKeyPress = true; // Ngăn chặn tiếp tục xử lý sự kiện KeyPress
                string mabn = tbTim.Text.Trim();
                if (string.IsNullOrEmpty(mabn))
                {                   
                    MessageBox.Show("Vui lòng nhập mã bệnh nhân vào ô tìm kiếm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                    tbTim.SelectAll();
                    tbTim.Focus();
                    return;
                }
                int columnIndexMaBN = 0; // Thay thế 0 bằng chỉ mục cột thực tế của cột chứa mã bệnh nhân trong DataGridView của bạn             
                foreach (DataGridViewRow row in dgvDSBN.Rows)
                {
                    row.DefaultCellStyle.BackColor = dgvDSBN.DefaultCellStyle.BackColor;
                    row.DefaultCellStyle.ForeColor = dgvDSBN.DefaultCellStyle.ForeColor;
                }
                CBenhNhan bn = xulyBN.searchBN(mabn);
                if (bn != null)
                {
                    // Tìm dòng chứa dữ liệu của bệnh nhân được tìm thấy
                    DataGridViewRow foundRow = dgvDSBN.Rows
                        .Cast<DataGridViewRow>()
                        .Where(r => r.Cells[columnIndexMaBN].Value.ToString() == mabn)
                        .FirstOrDefault();

                    if (foundRow != null)
                    {
                        dgvDSBN.ClearSelection();
                        foundRow.DefaultCellStyle.BackColor = Color.Yellow;
                        foundRow.DefaultCellStyle.ForeColor = Color.Black;

                        // Tùy chọn: Scroll đến dòng được tìm thấy
                        dgvDSBN.FirstDisplayedScrollingRowIndex = foundRow.Index;
                    }
                }
                else
                {                  
                    MessageBox.Show("Không tìm thấy bệnh nhân có mã: " + mabn + ". Vui lòng kiểm tra lại và nhập mã theo định dạng đúng (viết hoa và viết thường).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);                   
                    tbTim.Focus();
                }
                tbTim.Clear();
            }
        }      
    }
}
