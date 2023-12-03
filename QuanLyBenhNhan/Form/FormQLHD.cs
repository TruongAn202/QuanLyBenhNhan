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
        private CXuLyHoaDon xulyHD;
        private CXuLyPhieuKham xulyPK = new CXuLyPhieuKham();
        private CHoaDon hd;

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
            xulyHD = new CXuLyHoaDon();
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
            else
            {
                

                hd = new CHoaDon(tbMaHD.Text, dtNgayLapPhieu.Value, cbMaPK.Text, tbTenBN.Text, tbTongTien.Text) ;
                xulyHD.insertHD(hd);

                //dgvQLHD.DataSource = xulyHD.getDSHoaDon();
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
            if (dgvQLHD.SelectedRows.Count == 0) return "";
            int index = dgvQLHD.SelectedRows[0].Index;
            return dgvQLHD.Rows[index].Cells[0].Value.ToString();
        }
        private void dgvQLHD_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string mahd = getMaHD();
            if (mahd == "") return;
            CHoaDon hd = xulyHD.searchHD(mahd); // không duoc sua mã

            tbMaHD.Text = hd.Mahoadon;
            cbMaPK.Text = hd.MaPK;
            dtNgayLapPhieu.Value = hd.Ngaylaphoadon;
            tbTongTien.Text = hd.TongTien;
            tbTenBN.Text = hd.TenBN;
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
