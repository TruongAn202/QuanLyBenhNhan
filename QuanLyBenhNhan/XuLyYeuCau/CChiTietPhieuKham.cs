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
        public int SoLuong { get; set; }
        public double DonGia { get; set; }

        public CDichVu DichVu { get; set; }

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
    }
}
