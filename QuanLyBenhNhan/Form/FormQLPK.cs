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
        private void dgvChiTietPK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }                  
        private void btnXemPK_Click_1(object sender, EventArgs e)
        {
            string mapk = getMaPK();
            if (mapk == "") return;
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
                return; 
            }

           
            if (!int.TryParse(tbSoLuong.Text, out int soluong) || soluong <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
            dsTamThoi.Add(new CChiTietPhieuKham(soluong, dv));
            //pk.insert(dv, soluong);
            showChiTietPK(dsTamThoi);
            //showChiTietPK(pk.DsCTPK);
        }

        private void cbBN_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void tbTenDV_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbMaDV_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CDichVu dv = cbMaDV.SelectedItem as CDichVu;
            tbTenDV.Text = dv.TenDichVu;
            tbDonGia.Text = dv.Dongia + "";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string mapk = getMaPK(); ;
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
            dgvQLPK.ClearSelection();
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
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string mapk = tbMaPK.Text.Trim();
            if (string.IsNullOrEmpty(mapk))
            {
                MessageBox.Show("Vui lòng nhập mã phiếu khám.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (xyLyPK.ktTrungMa(mapk))
            {
                MessageBox.Show("Mã phiếu khám đã tồn tại. Vui lòng chọn mã khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            else
            {
                CBacSi bs = new CBacSi();
                CBenhNhan bn = new CBenhNhan();
                bs.TenBS = cbBS.Text;
                bs.MaBS = cbBS.SelectedValue.ToString();
                bn.TenBN = cbBN.Text;
                bn.MaBN = cbBN.SelectedValue.ToString();
                dsCTPK = new List<CChiTietPhieuKham>();
                
                pk = new CPhieuKham(tbMaPK.Text, dtNgayLapPhieu.Value, bn, bs, dsCTPK);
                xyLyPK.insertPK(pk);

                if (dsTamThoi.Count > 0)
                {
                    
                    foreach (CChiTietPhieuKham ctpk in dsTamThoi)
                    {
                        pk.insert(ctpk.DichVu, ctpk.SoLuong);
                    }

                    
                    dsTamThoi.Clear();
                }
                

                showDSPK();

            }
        }
    }
}
