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
        private CChiTietPhieuKham ctpk = new CChiTietPhieuKham();
        List<CChiTietPhieuKham> dsCTPK = new List<CChiTietPhieuKham>();
        private CXuLyPhieuKham xulyPK = new CXuLyPhieuKham();
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
        private string getTenDV()
        {
            if (dgvDSDV.SelectedRows.Count > 0)
            {
                // Lấy đối tượng dữ liệu liên kết với dòng được chọn
                CDichVu dichvu = dgvDSDV.SelectedRows[0].DataBoundItem as CDichVu;

                // Kiểm tra null để tránh lỗi
                if (dichvu != null)
                {
                    // Truy cập thuộc tính TenBS
                    return dichvu.TenDichVu;
                }
            }

            return "";
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
           
            dgvDSDV.DataSource = xulyDV.getDsDichVu();
            
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string tendv = getTenDV();
            string madv = getMaDV();
            if (tendv != "")
            {
                bool dichvudatontai = false;

                // Kiểm tra xem dịch vụ có tồn tại trong ít nhất một phiếu khám không
                foreach (CPhieuKham pk in xulyPK.getDsPhieuKham())
                {
                    foreach (CChiTietPhieuKham ctpk in pk.DsCTPK)
                    {
                        if (ctpk.DichVu != null && ctpk.DichVu.TenDichVu == tendv)
                        {
                            dichvudatontai = true;
                            break;
                        }
                    }

                    if (dichvudatontai)
                    {
                        break; // Nếu đã tìm thấy trong một phiếu khám thì thoát khỏi vòng lặp ngoại cùng
                    }
                }

                if (dichvudatontai)
                {
                    MessageBox.Show("Không thể xóa dịch vụ đã tồn tại trong ít nhất một phiếu khám.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    xulyDV.deleteDV(madv);
                    show();
                }
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
            string donGiaStr = tbDonGia.Text.Trim();
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
            if (!double.TryParse(donGiaStr, out double donGia))
            {
                MessageBox.Show("Đơn giá phải là số. Vui lòng viết lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbDonGia.Focus();
                return;
            }
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
                tbMaDV.Focus();
                return;
            }
            else if (xulyDV.ktTrungMa(madv))
            {
                MessageBox.Show("Mã dịch vụ đã tồn tại. Vui lòng chọn mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(tenDV))
            {
                MessageBox.Show("Vui lòng nhập tên dịch vụ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbTenDV.Focus();
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
        private void btnTim_Click(object sender, EventArgs e)
        {
            string madv = tbTim.Text.Trim();

            if (string.IsNullOrEmpty(madv))
            {
                MessageBox.Show("Vui lòng nhập mã dịch vụ vào ô tìm kiếm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbTim.Focus();
                return;
            }

            int columnIndexMaBN = 0; //thay 0 bang cot thuc te
            //xoa hightlight trc do
            foreach (DataGridViewRow row in dgvDSDV.Rows)
            {
                dgvDSDV.ClearSelection();
                row.DefaultCellStyle.BackColor = dgvDSDV.DefaultCellStyle.BackColor;
                row.DefaultCellStyle.ForeColor = dgvDSDV.DefaultCellStyle.ForeColor;
            }
            CDichVu dv = xulyDV.searchDV(madv);

            if (dv != null)
            {
                DataGridViewRow foundRow = dgvDSDV.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells[columnIndexMaBN].Value.ToString() == madv)
                    .FirstOrDefault();

                if (foundRow != null)
                {
                    //hightlight
                    foundRow.DefaultCellStyle.BackColor = Color.Yellow;
                    foundRow.DefaultCellStyle.ForeColor = Color.Black;

                    // cuộn đến dòng được tìm thấy
                    dgvDSDV.FirstDisplayedScrollingRowIndex = foundRow.Index;
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy dịch vụ có mã: " + madv + ". Vui lòng kiểm tra lại và nhập mã theo định dạng đúng (viết hoa và viết thường).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbTim.Focus();
            }
            tbTim.Clear();
        }

        private void tbTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn chặn tiếp tục xử lý sự kiện KeyPress    
                string madv = tbTim.Text.Trim();
                if (string.IsNullOrEmpty(madv))
                {
                    MessageBox.Show("Vui lòng nhập mã dịch vụ vào ô tìm kiếm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbTim.SelectAll();
                    tbTim.Focus();
                    return;
                }
                int columnIndexMaBN = 0; // Thay thế 0 bằng chỉ mục cột thực tế của cột chứa mã bệnh nhân trong DataGridView của bạn

                foreach (DataGridViewRow row in dgvDSDV.Rows)
                {
                    row.DefaultCellStyle.BackColor = dgvDSDV.DefaultCellStyle.BackColor;
                    row.DefaultCellStyle.ForeColor = dgvDSDV.DefaultCellStyle.ForeColor;
                }
                CDichVu dv = xulyDV.searchDV(madv);

                if (dv != null)
                {
                    // Tìm dòng chứa dữ liệu của bệnh nhân được tìm thấy
                    DataGridViewRow foundRow = dgvDSDV.Rows
                        .Cast<DataGridViewRow>()
                        .Where(r => r.Cells[columnIndexMaBN].Value.ToString() == madv)
                        .FirstOrDefault();
                    if (foundRow != null)
                    {
                        dgvDSDV.ClearSelection();
                        foundRow.DefaultCellStyle.BackColor = Color.Yellow;
                        foundRow.DefaultCellStyle.ForeColor = Color.Black;

                        dgvDSDV.FirstDisplayedScrollingRowIndex = foundRow.Index;
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dịch vụ có mã: " + madv + ". Vui lòng kiểm tra lại và nhập mã theo định dạng đúng (viết hoa và viết thường).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbTim.Focus();
                }
                tbTim.Clear();
            }
        }      
    }
}
