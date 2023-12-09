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
    public partial class FormQLPK : Form
    {
        List<CChiTietPhieuKham> dsCTPK;
        private CXuLyPhieuKham xyLyPK = new CXuLyPhieuKham();
        private CXuLyDichVu xuLyDV = new CXuLyDichVu();
        CChiTietPhieuKham ctpk = new CChiTietPhieuKham();
        List<CChiTietPhieuKham> dsTamThoi = new List<CChiTietPhieuKham>();
        CDichVu dv = new CDichVu();
        private CPhieuKham pk;
        public FormQLPK()
        {
            InitializeComponent();
            showDV();
            showDSPK();
            
        }
        private void showDV() // du lieu dich vu
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = xuLyDV.getDsDichVu();
            cbMaDV.DataSource = bs;

        }
        private void showDSPK() // du lieu phieu kham
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = xyLyPK.getDsPhieuKham();
            dgvQLPK.DataSource = bs;
        }
        private string getMaPK()
        {
            if (dgvQLPK.SelectedRows.Count == 0) return "";
            int index = dgvQLPK.SelectedRows[0].Index;
            return dgvQLPK.Rows[index].Cells[0].Value.ToString();
        }
        private void FormQLPK_Load(object sender, EventArgs e)
        {
            cbBS.DataSource = xyLyPK.getDsBacSi();           
            cbBN.DataSource = xyLyPK.getDsBenhNhan();          
        }     
        private void clear()
        {
            tbMaPK.Clear();
            cbBN.SelectedIndex = 0;
            cbBS.SelectedIndex = 0;
            tbSoLuong.Clear();

            dtNgayLapPhieu.Value = DateTime.Today;

            cbMaDV.SelectedIndex = 0;

            dgvChiTietPK.DataSource = null;
        }
        private void showChiTietPK(List<CChiTietPhieuKham> dsCTPK) // danh muc dich vu
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = CViewCTPK.getViewList(dsCTPK); //lay danh sach view
            dgvChiTietPK.DataSource = bs;
        }              
        private void btnXemPK_Click_1(object sender, EventArgs e)
        {
            string mapk = getMaPK();
            if (string.IsNullOrEmpty(mapk))
            {
                MessageBox.Show("Hãy chọn một phiếu khám để thực hiện hành động.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CPhieuKham pk = xyLyPK.searchPK(mapk);

            tbMaPK.Text = pk.Maphieukham;
            cbBN.Text = pk.BenhNhan.TenBN;
            cbBS.Text = pk.BacSi.TenBS;
            dtNgayLapPhieu.Value = pk.Ngaylapphieu;

            //ListCtpk = pk.ChiTietPhieuKham;

            showChiTietPK(pk.DsCTPK);
        }
        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (TruyCapDuLieu.luuFile("data.dat"))
            {
                MessageBox.Show("Dữ liệu đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thể lưu dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            string mapk = getMaPK();
            if (mapk != "")
            {
                xyLyPK.deletePK(mapk);
                showDSPK();
                clear();

            }
        }        
        private void btnChonDV_Click_1(object sender, EventArgs e)
        {
            CDichVu dv = cbMaDV.SelectedItem as CDichVu;

            if (string.IsNullOrEmpty(tbSoLuong.Text))
            {
                MessageBox.Show("Hãy nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbSoLuong.Focus();
                return;
            }

            if (!int.TryParse(tbSoLuong.Text, out int soluong) || soluong <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ, hãy nhập số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbSoLuong.Focus();
                return;
            }

            // Kiểm tra xem mã dịch vụ 
            CChiTietPhieuKham existingItem = dsTamThoi.FirstOrDefault(item => item.DichVu.MaDichVu == dv.MaDichVu);

            if (existingItem != null)
            {
                // cập nhật số lượng
                existingItem.SoLuong += soluong;
            }
            else
            {   
                dsTamThoi.Add(new CChiTietPhieuKham(soluong, dv));
            }
            showChiTietPK(dsTamThoi);
        }

        private void cbMaDV_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CDichVu dv = cbMaDV.SelectedItem as CDichVu;
            tbTenDV.Text = dv.TenDichVu;
            tbDonGia.Text = dv.Dongia + "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string mapk = getMaPK();
            if (mapk == "") return;
            CPhieuKham pk = xyLyPK.searchPK(mapk);

            string newMaPK = tbMaPK.Text.Trim();

            if (!newMaPK.Equals(mapk, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Không được sửa mã phiếu khám.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                tbMaPK.Text = mapk;
                return;
            }

            pk.BacSi.TenBS = cbBS.Text;
            pk.BenhNhan.TenBN = cbBN.Text;
            pk.Ngaylapphieu = dtNgayLapPhieu.Value;

            xyLyPK.updatePK(pk);
            showDSPK();

            // Tim va chon dong vua sua
            int rowIndex = -1;
            foreach (DataGridViewRow row in dgvQLPK.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(newMaPK, StringComparison.OrdinalIgnoreCase))
                {
                    rowIndex = row.Index;
                    break;
                }
            }

            if (rowIndex != -1)
            {
                dgvQLPK.CurrentCell = dgvQLPK.Rows[rowIndex].Cells[0];
                dgvQLPK.Rows[rowIndex].Selected = true; // Chọn dòng
            }
        }

        private void dgvQLPK_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string mapk = getMaPK();
            if (mapk == "") return;
            CPhieuKham pk = xyLyPK.searchPK(mapk); // không duoc sua mã

            tbMaPK.Text = pk.Maphieukham;
            dtNgayLapPhieu.Value = pk.Ngaylapphieu;
            cbBN.Text = pk.BenhNhan.TenBN;
            cbBS.Text = pk.BacSi.TenBS;
           
        }

        private void btnLapPK_Click(object sender, EventArgs e)
        {
            pk = null;
            clear();
            foreach (DataGridViewRow row in dgvQLPK.Rows)
            {
                row.DefaultCellStyle.BackColor = dgvQLPK.DefaultCellStyle.BackColor;
                row.DefaultCellStyle.ForeColor = dgvQLPK.DefaultCellStyle.ForeColor;
                dgvQLPK.ClearSelection();
            }

            // Xóa nội dung trong TextBox "tbTim"
            tbTimPk.Clear();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string mapk = tbMaPK.Text.Trim();
            if (string.IsNullOrEmpty(mapk))
            {
                MessageBox.Show("Vui lòng nhập mã phiếu khám.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbMaPK.Focus();
                return;
            }
            else if (xyLyPK.ktTrungMa(mapk))
            {
                MessageBox.Show("Mã phiếu khám đã tồn tại. Vui lòng chọn mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                // Kiểm tra xem có dịch vụ nào được chọn không
                if (dsTamThoi.Count == 0)
                {
                    MessageBox.Show("Hãy chọn dịch vụ trước khi lập phiếu khám", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                CBacSi bs = new CBacSi();
                CBenhNhan bn = new CBenhNhan();
                bs.TenBS = cbBS.Text;
                bs.MaBS = cbBS.SelectedValue.ToString();
                bn.TenBN = cbBN.Text;
                bn.MaBN = cbBN.SelectedValue.ToString();
                dsCTPK = new List<CChiTietPhieuKham>();
                pk = new CPhieuKham(tbMaPK.Text, dtNgayLapPhieu.Value, bn, bs, dsCTPK);
                xyLyPK.insertPK(pk);

                foreach (CChiTietPhieuKham ctpk in dsTamThoi)
                {
                    pk.insert(ctpk.DichVu, ctpk.SoLuong);
                }
                dsTamThoi.Clear();

                showDSPK();

                // Highlight dòng mới thêm vào
                int rowIndex = dgvQLPK.Rows.Count - 1;
                dgvQLPK.CurrentCell = dgvQLPK.Rows[rowIndex].Cells[0];
                clear();
            }
        }

        private void btnTimPK_Click(object sender, EventArgs e)
        {
            string mapk = tbTimPk.Text.Trim();

            if (string.IsNullOrEmpty(mapk))
            {
                MessageBox.Show("Vui lòng nhập mã phiếu khám vào ô tìm kiếm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbTimPk.Focus();
                return;
            }

            int columnIndexMaBN = 0; //thay 0 bang cot thuc te
            //xoa hightlight trc do
            foreach (DataGridViewRow row in dgvQLPK.Rows)
            {
                dgvQLPK.ClearSelection();
                row.DefaultCellStyle.BackColor = dgvQLPK.DefaultCellStyle.BackColor;
                row.DefaultCellStyle.ForeColor = dgvQLPK.DefaultCellStyle.ForeColor;
            }
            CPhieuKham pk = xyLyPK.searchPK(mapk);

            if (pk != null)
            {
                DataGridViewRow foundRow = dgvQLPK.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells[columnIndexMaBN].Value.ToString() == mapk)
                    .FirstOrDefault();

                if (foundRow != null)
                {
                    //hightlight
                    foundRow.DefaultCellStyle.BackColor = Color.Yellow;
                    foundRow.DefaultCellStyle.ForeColor = Color.Black;

                    // Tùy chọn: Scroll đến dòng được tìm thấy
                    dgvQLPK.FirstDisplayedScrollingRowIndex = foundRow.Index;
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy phiếu khám có mã: " + mapk + ". Vui lòng kiểm tra lại và nhập mã theo định dạng đúng (viết hoa và viết thường).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbTimPk.Focus();
            }
            tbTimPk.Clear();
        }

        private void tbTimPk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn chặn tiếp tục xử lý sự kiện KeyPress    
                string mapk = tbTimPk.Text.Trim();
                if (string.IsNullOrEmpty(mapk))
                {
                    MessageBox.Show("Vui lòng nhập mã phiếu khám vào ô tìm kiếm.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbTimPk.SelectAll();
                    tbTimPk.Focus();
                    return;
                }
                int columnIndexMaBN = 0; // Thay thế 0 bằng chỉ mục cột thực tế của cột chứa mã bệnh nhân trong DataGridView của bạn

                foreach (DataGridViewRow row in dgvQLPK.Rows)
                {
                    row.DefaultCellStyle.BackColor = dgvQLPK.DefaultCellStyle.BackColor;
                    row.DefaultCellStyle.ForeColor = dgvQLPK.DefaultCellStyle.ForeColor;
                }
                CPhieuKham pk = xyLyPK.searchPK(mapk);

                if (pk != null)
                {
                    // Tìm dòng chứa dữ liệu của bệnh nhân được tìm thấy
                    DataGridViewRow foundRow = dgvQLPK.Rows
                        .Cast<DataGridViewRow>()
                        .Where(r => r.Cells[columnIndexMaBN].Value.ToString() == mapk)
                        .FirstOrDefault();
                    if (foundRow != null)
                    {
                        dgvQLPK.ClearSelection();
                        foundRow.DefaultCellStyle.BackColor = Color.Yellow;
                        foundRow.DefaultCellStyle.ForeColor = Color.Black;

                        dgvQLPK.FirstDisplayedScrollingRowIndex = foundRow.Index;
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy phiếu khám có mã: " + mapk + ". Vui lòng kiểm tra lại và nhập mã theo định dạng đúng (viết hoa và viết thường).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbTimPk.Focus();
                }
                tbTimPk.Clear();
            }
        }
    }
}
