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
    public partial class FormXemHD : Form
    {
        private CXuLyHoaDon xulyHD = new CXuLyHoaDon();
        private CHoaDon hd;
        private CPhieuKham pk;
        public FormXemHD(string maPK)
        {
            InitializeComponent();
        }

        public TextBox tbTongThu
        {
            get { return tbTongTien; }
            set { tbTongTien = value; }
        }
        public TextBox tbMaPK
        {
            get { return txtMaPK; }
            set { txtMaPK = value; }
        }
        public TextBox tbTenBN
        {
            get { return txtTenBN; }
            set { txtTenBN = value; }
        }

        private void FormXemHD_Load(object sender, EventArgs e)
        {
            dgvDSHD.DataSource = xulyHD.SearchByMaPK(txtMaPK.Text);
            string absolutePath = "iconMini.png"; // để hỉnh ở ngoài, click vào hình chọn: copy to Output -> copu if newer, thêm ảnh: click phải dự án -> add -> Existring items
            Image image = Image.FromFile(absolutePath);

            // image -> icon
            Icon icon = Icon.FromHandle(((Bitmap)image).GetHicon());

            // Đặt Icon cho Form
            this.Icon = icon;
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
            dgvDSHD.ClearSelection();
        }
        private void btnLapHD_Click_1(object sender, EventArgs e)
        {
            string mahd = tbMaHD.Text.Trim();
            string maPK = txtMaPK.Text;
            string tenBN = txtTenBN.Text.Trim();
            string daTraStr = tbDaTra.Text.Trim();
            double traThem;
            string traThemStr = tbTraThem.Text.Trim();
            var existingHDs = xulyHD.SearchByMaPK(maPK);


            if (string.IsNullOrEmpty(mahd))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbMaHD.Focus();
                return;
            }
            else if (xulyHD.ktTrungMa(mahd))
            {
                MessageBox.Show("Mã hóa đơn đã tồn tại. Vui lòng chọn mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (!double.TryParse(daTraStr, out double daTra))
            {
                MessageBox.Show("Số tiền đã thanh toán phải là số. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbDaTra.Focus();
                return;
            }
            else if (existingHDs != null && existingHDs.Any(hd => hd.TinhTrang == "Thanh toán đủ"))
            {
                MessageBox.Show("Bệnh nhân này đã thanh toán đủ. Không thể thêm hóa đơn mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (!double.TryParse(traThemStr, out traThem))
            {
                MessageBox.Show("Số tiền thanh toán thêm phải là số. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbTraThem.Focus();
                return;
            }
            else if (traThem < 0)
            {
                MessageBox.Show("Số tiền thanh toán thêm không được là số âm. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbTraThem.Focus();
                return;
            }
            else
            {
                if (existingHDs == null || !existingHDs.Any())
                {
                    daTra += traThem;
                    if (daTra > Convert.ToDouble(tbTongTien.Text))
                    {
                        MessageBox.Show("Số tiền trả thêm cộng với số tiền đã thanh toán đã vượt mức tổng tiền.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    pk = new CPhieuKham();
                    pk.Maphieukham = maPK;
                    pk.Maphieukham = txtMaPK.Text;

                    hd = new CHoaDon(mahd, dtNgayLapPhieu.Value, pk, tenBN, tbTongTien.Text, daTra);
                    xulyHD.insertHD(hd);

                    TruyCapDuLieu.luuFile("data.dat");

                    dgvDSHD.ClearSelection();
                    dgvDSHD.DataSource = dgvDSHD.DataSource = xulyHD.SearchByMaPK(txtMaPK.Text);
                }
                else
                {
                    DataGridViewRow selectedRow = dgvDSHD.SelectedRows[0];
                    if (selectedRow.DefaultCellStyle.BackColor == Color.Yellow)
                    {
                        daTra += traThem;
                        if (daTra > Convert.ToDouble(tbTongTien.Text))
                        {
                            MessageBox.Show("Số tiền trả thêm cộng với số tiền đã thanh toán đã vượt mức tổng tiền.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        pk = new CPhieuKham();
                        pk.Maphieukham = maPK;
                        pk.Maphieukham = txtMaPK.Text;

                        hd = new CHoaDon(mahd, dtNgayLapPhieu.Value, pk, tenBN, tbTongTien.Text, daTra);
                        xulyHD.insertHD(hd);

                        TruyCapDuLieu.luuFile("data.dat");

                        dgvDSHD.ClearSelection();
                        dgvDSHD.DataSource = dgvDSHD.DataSource = xulyHD.SearchByMaPK(txtMaPK.Text);
                    }
                    else
                    {
                        MessageBox.Show("Hãy nhấp chuột trái vào dòng đã được đánh dấu màu vàng sau khi bạn đã nhấn nút \"Tìm mới nhất\" để thực hiện thanh toán.", "Cảnh báo nguy hiểm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                }

            }
        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
        private string getMaHD()
        {
            if (dgvDSHD.SelectedRows.Count == 0) return "";
            int index = dgvDSHD.SelectedRows[0].Index;
            return dgvDSHD.Rows[index].Cells[0].Value.ToString();
        }

        private void dgvDSHD_RowEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            string mahd = getMaHD();
            if (mahd == "") return;

            CHoaDon hd = xulyHD.searchHD(mahd);

            tbTongThu.Text = hd.TongTien;
            tbDaTra.Text = hd.DaTra.ToString();
            tbTraThem.Clear();
        }

        private void btnHDMN_Click(object sender, EventArgs e)
        {
            dgvDSHD.ClearSelection();
            if (dgvDSHD.Rows.Count > 0)
            {
                //  dòng cuối 
                int lastRowIndex = dgvDSHD.Rows.Count - 1;
                dgvDSHD.Rows[lastRowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                // cuộn tới dòng đó
                dgvDSHD.FirstDisplayedScrollingRowIndex = lastRowIndex;

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
            foreach (DataGridViewRow row in dgvDSHD.Rows)
            {
                dgvDSHD.ClearSelection();
                row.DefaultCellStyle.BackColor = dgvDSHD.DefaultCellStyle.BackColor;
                row.DefaultCellStyle.ForeColor = dgvDSHD.DefaultCellStyle.ForeColor;
            }
            CHoaDon hd = xulyHD.searchHD(mahd);

            if (hd != null)
            {
                DataGridViewRow foundRow = dgvDSHD.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells[columnIndexMaBN].Value.ToString() == mahd)
                    .FirstOrDefault();

                if (foundRow != null)
                {
                    //hightlight
                    foundRow.DefaultCellStyle.BackColor = Color.Yellow;
                    foundRow.DefaultCellStyle.ForeColor = Color.Black;

                    // Tùy chọn: Scroll đến dòng được tìm thấy
                    dgvDSHD.FirstDisplayedScrollingRowIndex = foundRow.Index;
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy hóa đơn có mã: " + mahd + ". Vui lòng kiểm tra lại và nhập mã theo định dạng đúng (viết hoa và viết thường).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Vui lòng nhập mã hóa đơn vào ô tìm kiếm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbTim.SelectAll();
                    tbTim.Focus();
                    return;
                }
                int columnIndexMaBN = 0; // Thay thế 0 bằng chỉ mục cột thực tế của cột chứa mã bệnh nhân trong DataGridView của bạn

                foreach (DataGridViewRow row in dgvDSHD.Rows)
                {
                    row.DefaultCellStyle.BackColor = dgvDSHD.DefaultCellStyle.BackColor;
                    row.DefaultCellStyle.ForeColor = dgvDSHD.DefaultCellStyle.ForeColor;
                }
                CHoaDon hd = xulyHD.searchHD(mahd);

                if (hd != null)
                {
                    // Tìm dòng chứa dữ liệu của bệnh nhân được tìm thấy
                    DataGridViewRow foundRow = dgvDSHD.Rows
                        .Cast<DataGridViewRow>()
                        .Where(r => r.Cells[columnIndexMaBN].Value.ToString() == mahd)
                        .FirstOrDefault();
                    if (foundRow != null)
                    {
                        dgvDSHD.ClearSelection();
                        foundRow.DefaultCellStyle.BackColor = Color.Yellow;
                        foundRow.DefaultCellStyle.ForeColor = Color.Black;

                        dgvDSHD.FirstDisplayedScrollingRowIndex = foundRow.Index;
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
