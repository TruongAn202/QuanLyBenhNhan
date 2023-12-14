using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBenhNhan
{
    [Serializable]
    class CChiTietPhieuKham
    {
        public CDichVu DichVu { get; set; }
        public string TenDV => DichVu.TenDichVu;
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        

        public double ThanhTien => SoLuong * DonGia;

        public CChiTietPhieuKham(int soluong, CDichVu dichvu)
        {
            SoLuong = soluong;
            DichVu = dichvu;
            DonGia = dichvu.Dongia;
        }

        public CChiTietPhieuKham()
        {
            SoLuong = 0;
            DonGia = 0;
            DichVu = null;
        }
        

        public static List<CChiTietPhieuKham> getViewList(List<CChiTietPhieuKham> dsCTPK)
        {
            return dsCTPK;
        }
        

    }
}
