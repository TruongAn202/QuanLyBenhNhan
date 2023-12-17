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
            var existingHDs = xulyHD.SearchByMaPK(maPK);
            if (double.TryParse(tbDaTra.Text, out double daTra1) && double.TryParse(tbTongTien.Text, out double tongTien) && daTra1 > tongTien)
            {
                MessageBox.Show("Số tiền cần thanh toán không được lớn hơn tổng tiền dịch vụ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
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
            else if (existingHDs != null && existingHDs.Any(hd => hd.TinhTrang == "Paid"))
            {
                MessageBox.Show("Bệnh nhân này đã thanh toán đủ. Không thể thêm hóa đơn mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                pk = new CPhieuKham();
                pk.Maphieukham = maPK;
                pk.Maphieukham = txtMaPK.Text;

                hd = new CHoaDon(mahd, dtNgayLapPhieu.Value, pk, tenBN, tbTongTien.Text, daTra);
                xulyHD.insertHD(hd);
                TruyCapDuLieu.luuFile("data.dat");

                dgvDSHD.ClearSelection();

                dgvDSHD.DataSource = dgvDSHD.DataSource = xulyHD.SearchByMaPK(txtMaPK.Text);
            }
        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
