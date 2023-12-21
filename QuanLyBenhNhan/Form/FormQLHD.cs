using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBenhNhan
{
    public partial class FormQLHD : Form
    {
        private CXuLyHoaDon xulyHD = new CXuLyHoaDon();
        private CXuLyPhieuKham xulyPK = new CXuLyPhieuKham();
        public FormQLHD()
        {
            InitializeComponent();  
        }
        private void FormQLHD_Load(object sender, EventArgs e)
        {
            showDSPK();
            
        }
        private void showDSPK()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = xulyHD.getDSPhieuKham();
            dgvDSPK.DataSource = bs;
        }
        private void showDSHD()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = xulyHD.getDSHoaDon();
            dgvDSPK.DataSource = bs;
        }
        private string getMaPK()
        {
            if (dgvDSPK.SelectedRows.Count == 0) return "";
            int index = dgvDSPK.SelectedRows[0].Index;
            // Kiểm tra xem ô có giá trị null không
            object cellValue = dgvDSPK.Rows[index].Cells[0].Value;

            if (cellValue != null)
            {
                return cellValue.ToString();
            }
            else
            {
                MessageBox.Show("Lỗi cell: Giá trị của ô là null");
                return "";
            }
        } 
        
        private void btnTim_Click(object sender, EventArgs e)
        {
            string mapk = tbTim.Text.Trim();

            if (string.IsNullOrEmpty(mapk))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn vào ô tìm kiếm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbTim.Focus();
                return;
            }
            int columnIndexMaBN = 0; //thay 0 bang cot thuc te
            //xoa hightlight trc do
            foreach (DataGridViewRow row in dgvDSPK.Rows)
            {
                dgvDSPK.ClearSelection();
                row.DefaultCellStyle.BackColor = dgvDSPK.DefaultCellStyle.BackColor;
                row.DefaultCellStyle.ForeColor = dgvDSPK.DefaultCellStyle.ForeColor;
            }
            CPhieuKham pk = xulyPK.searchPK(mapk);

            if (pk != null)
            {
                DataGridViewRow foundRow = dgvDSPK.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells[columnIndexMaBN].Value.ToString() == mapk)
                    .FirstOrDefault();

                if (foundRow != null)
                {
                    //hightlight
                    foundRow.DefaultCellStyle.BackColor = Color.Yellow;
                    foundRow.DefaultCellStyle.ForeColor = Color.Black;

                    // Tùy chọn: Scroll đến dòng được tìm thấy
                    dgvDSPK.FirstDisplayedScrollingRowIndex = foundRow.Index;
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy hóa đơn có mã: " +mapk + ". Vui lòng kiểm tra lại và nhập mã theo định dạng đúng (viết hoa và viết thường).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbTim.Focus();
            }
            tbTim.Clear();
        }
        private void tbTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn chặn tiếp tục xử lý sự kiện KeyPress    
                string mapk = tbTim.Text.Trim();
                if (string.IsNullOrEmpty(mapk))
                {
                    MessageBox.Show("Vui lòng nhập mã hóa đơn vào ô tìm kiếm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbTim.SelectAll();
                    tbTim.Focus();
                    return;
                }
                int columnIndexMaBN = 0; // Thay thế 0 bằng chỉ mục cột thực tế của cột chứa mã bệnh nhân trong DataGridView của bạn

                foreach (DataGridViewRow row in dgvDSPK.Rows)
                {
                    row.DefaultCellStyle.BackColor = dgvDSPK.DefaultCellStyle.BackColor;
                    row.DefaultCellStyle.ForeColor = dgvDSPK.DefaultCellStyle.ForeColor;
                }
                CPhieuKham pk = xulyPK.searchPK(mapk);

                if (pk != null)
                {
                    // Tìm dòng chứa dữ liệu của bệnh nhân được tìm thấy
                    DataGridViewRow foundRow = dgvDSPK.Rows
                        .Cast<DataGridViewRow>()
                        .Where(r => r.Cells[columnIndexMaBN].Value.ToString() == mapk)
                        .FirstOrDefault();
                    if (foundRow != null)
                    {
                        dgvDSPK.ClearSelection();
                        foundRow.DefaultCellStyle.BackColor = Color.Yellow;
                        foundRow.DefaultCellStyle.ForeColor = Color.Black;

                        dgvDSPK.FirstDisplayedScrollingRowIndex = foundRow.Index;
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn có mã: " + mapk + ". Vui lòng kiểm tra lại và nhập mã theo định dạng đúng (viết hoa và viết thường).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbTim.Focus();
                }
                tbTim.Clear();
            }
        }
        private void btnXemHD_Click(object sender, EventArgs e)
        {
            if (dgvDSPK.SelectedRows.Count > 0)
            {
                // Lấy đối tượng dữ liệu của dòng được chọn
                CPhieuKham selectedPhieuKham = dgvDSPK.SelectedRows[0].DataBoundItem as CPhieuKham; 
                if (selectedPhieuKham != null && !string.IsNullOrEmpty(selectedPhieuKham.Maphieukham))
                {
                    FormXemHD formXemHD = new FormXemHD(selectedPhieuKham.Maphieukham);
                    // Đặt giá trị "MaPK" cho TextBox trên FormXemHD
                    formXemHD.tbMaPK.Text = selectedPhieuKham.Maphieukham;

                    formXemHD.tbTenBN.Text = selectedPhieuKham.BenhNhan.TenBN;

                    formXemHD.tbTongThu.Text = selectedPhieuKham.ThanhTien.ToString();

                    // Hiển thị FormXemHD
                    formXemHD.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Dòng được chọn không chứa thông tin hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xem hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvDSPK_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string mapk = getMaPK();
            if (mapk == "") return;
            CPhieuKham pk = xulyPK.searchPK(mapk); // không duoc sua mã
        }

        private void cbLocTinhTrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvDSPK.DataSource = xulyPK.SearchByTinhTrang(cbLocTinhTrang.Text);
            if (cbLocTinhTrang.Text == "Tất cả")
            {
                showDSPK();
            }
        }
    }
}
