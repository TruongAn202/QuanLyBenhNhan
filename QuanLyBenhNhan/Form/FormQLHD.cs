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
                pk = new CPhieuKham(); 
                pk.Maphieukham = cbMaPK.Text; 
                pk.Maphieukham = cbMaPK.SelectedValue.ToString();

                hd = new CHoaDon(tbMaHD.Text, dtNgayLapPhieu.Value, pk, tbTenBN.Text, tbTongTien.Text);
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

            

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgvQLHD_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string mahd = getMaHD();
            if (mahd != "")
            {
                xulyHD.deleteDV(mahd);
                showDSHD();
                

            }
        }
    }
}
