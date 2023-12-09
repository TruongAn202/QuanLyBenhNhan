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
        private CHoaDon hd;
        private CPhieuKham pk;
        public FormQLHD()
        {
            InitializeComponent();
            showPK();
            
        }

        //private void showHD(List<CHoaDon> dsHD) // danh muc dich vu
        //{
        //    BindingSource bs = new BindingSource();
        //    bs.DataSource = CViewHD.getViewList(dsHD); //lay danh sach view
        //    dgvQLHD.DataSource = bs;
        //}
        private void FormQLHD_Load(object sender, EventArgs e)
        {
            
            showDSHD();
        }
        private void showPK()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = xulyPK.getDsPhieuKham();
            cbMaPK.DataSource = bs;

        }
        private void cbMaPK_SelectedIndexChanged(object sender, EventArgs e)
        {
            CPhieuKham pk = cbMaPK.SelectedItem as CPhieuKham;
            
            tbTenBN.Text = pk.BenhNhan.TenBN;
            tbTongTien.Text = pk.ThanhTien.ToString();
        }

        private void showDSHD()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = xulyHD.getDSHoaDon();
            dgvQLHD.DataSource = bs;
        }
        private void btnLapHD_Click(object sender, EventArgs e)
        {
            string mahd = tbMaHD.Text.Trim();
            string maPK = cbMaPK.Text;
            string tenBN = tbTenBN.Text.Trim();
            string daTraStr = tbDaTra.Text.Trim();

            if (string.IsNullOrEmpty(mahd))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (xulyHD.ktTrungMa(mahd))
            {
                MessageBox.Show("Mã hóa đơn đã tồn tại. Vui lòng chọn mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(maPK))
            {
                MessageBox.Show("Vui lòng chọn mã phiếu khám.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (!double.TryParse(daTraStr, out double daTra))
            {
                MessageBox.Show("Số tiền đã thanh toán phải là số. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbDaTra.Focus();
                return;
            }
            else
            {
                pk = new CPhieuKham();
                pk.Maphieukham = maPK;
                pk.Maphieukham = cbMaPK.SelectedValue.ToString();

                hd = new CHoaDon(mahd, dtNgayLapPhieu.Value, pk, tenBN, tbTongTien.Text, daTra);
                xulyHD.insertHD(hd);

                showDSHD();
            }
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
            dgvQLHD.ClearSelection();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private string getMaHD()
        {
            //if (dgvQLHD.SelectedRows.Count == 0) return "";
            //int index = dgvQLHD.SelectedRows[0].Index;
            //return dgvQLHD.Rows[index].Cells[0].Value.ToString();
            if (dgvQLHD.SelectedRows.Count == 0) return "";
            int index = dgvQLHD.SelectedRows[0].Index;

            // Kiểm tra xem ô có giá trị null không
            object cellValue = dgvQLHD.Rows[index].Cells[0].Value;

            if (cellValue != null)
            {
                return cellValue.ToString();
            }
            else
            {
                MessageBox.Show("Lỗi cell: Giá trị của ô là null");
                // Xử lý trường hợp giá trị là null
                return "";
            }
        }
        private void dgvQLHD_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string mahd = getMaHD();
            if (mahd == "") return;
            CHoaDon hd = xulyHD.searchHD(mahd); // không duoc sua mã

            tbMaHD.Text = hd.Mahoadon;
            cbMaPK.Text = hd.PhieuKham.Maphieukham;
            dtNgayLapPhieu.Value = hd.Ngaylaphoadon;
            tbTongTien.Text = hd.TongTien;
            tbTenBN.Text = hd.TenBN;
            tbDaTra.Text = hd.DaTra.ToString();
            tbConLai.Text = hd.ConLai.ToString();
            

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgvQLHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void tbDaTra_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbConLai_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            string mahd = getMaHD();
            if (mahd != "")
            {
                xulyHD.deleteDV(mahd);
                showDSHD();


            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string mahd = tbTim.Text.Trim();

            if (string.IsNullOrEmpty(mahd))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn vào ô tìm kiếm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbTim.Focus();
                return;
            }

            int columnIndexMaBN = 0; //thay 0 bang cot thuc te
            //xoa hightlight trc do
            foreach (DataGridViewRow row in dgvQLHD.Rows)
            {
                dgvQLHD.ClearSelection();
                row.DefaultCellStyle.BackColor = dgvQLHD.DefaultCellStyle.BackColor;
                row.DefaultCellStyle.ForeColor = dgvQLHD.DefaultCellStyle.ForeColor;
            }
            CHoaDon hd = xulyHD.searchHD(mahd);

            if (hd != null)
            {
                DataGridViewRow foundRow = dgvQLHD.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells[columnIndexMaBN].Value.ToString() == mahd)
                    .FirstOrDefault();

                if (foundRow != null)
                {
                    //hightlight
                    foundRow.DefaultCellStyle.BackColor = Color.Yellow;
                    foundRow.DefaultCellStyle.ForeColor = Color.Black;

                    // Tùy chọn: Scroll đến dòng được tìm thấy
                    dgvQLHD.FirstDisplayedScrollingRowIndex = foundRow.Index;
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy dịch vụ có mã: " + mahd + ". Vui lòng kiểm tra lại và nhập mã theo định dạng đúng (viết hoa và viết thường).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbTim.Focus();
            }
            tbTim.Clear();
        }

        private void tbTim_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn chặn tiếp tục xử lý sự kiện KeyPress    
                string mahd = tbTim.Text.Trim();
                if (string.IsNullOrEmpty(mahd))
                {
                    MessageBox.Show("Vui lòng nhập mã hóa đơn.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbTim.SelectAll();
                    tbTim.Focus();
                    return;
                }
                int columnIndexMaBN = 0; // Thay thế 0 bằng chỉ mục cột thực tế của cột chứa mã bệnh nhân trong DataGridView của bạn

                foreach (DataGridViewRow row in dgvQLHD.Rows)
                {
                    row.DefaultCellStyle.BackColor = dgvQLHD.DefaultCellStyle.BackColor;
                    row.DefaultCellStyle.ForeColor = dgvQLHD.DefaultCellStyle.ForeColor;
                }
                CHoaDon hd = xulyHD.searchHD(mahd);

                if (hd != null)
                {
                    // Tìm dòng chứa dữ liệu của bệnh nhân được tìm thấy
                    DataGridViewRow foundRow = dgvQLHD.Rows
                        .Cast<DataGridViewRow>()
                        .Where(r => r.Cells[columnIndexMaBN].Value.ToString() == mahd)
                        .FirstOrDefault();
                    if (foundRow != null)
                    {
                        dgvQLHD.ClearSelection();
                        foundRow.DefaultCellStyle.BackColor = Color.Yellow;
                        foundRow.DefaultCellStyle.ForeColor = Color.Black;

                        dgvQLHD.FirstDisplayedScrollingRowIndex = foundRow.Index;
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn có mã: " + mahd + ". Vui lòng kiểm tra lại và nhập mã theo định dạng đúng (viết hoa và viết thường).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbTim.Focus();
                }
                tbTim.Clear();
            }
        }
    }
}
