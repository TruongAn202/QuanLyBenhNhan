using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBenhNhan
{
    [Serializable]
    internal class CPhieuKham{
        private List<CChiTietPhieuKham> dsCTPK;
        public List<CChiTietPhieuKham> DsCTPK { 
            get => dsCTPK.ToList(); 
            set => dsCTPK = value; } 
        private string maphieukham;
        private DateTime ngaylapphieu;
        private CBenhNhan benhNhan;
        private CBacSi bacSi;
        public string Maphieukham { get => maphieukham; set => maphieukham = value; }
        public DateTime Ngaylapphieu { get => ngaylapphieu; set => ngaylapphieu = value; }
        public CBenhNhan BenhNhan { get => benhNhan; set => benhNhan = value; }
        public CBacSi BacSi { get => bacSi; set => bacSi = value; }
        public CPhieuKham(string maphieukham, DateTime ngaylapphieu, CBenhNhan benhnhan, 
            CBacSi bacsi, List<CChiTietPhieuKham> dsCTPK)
        {
            Maphieukham = maphieukham;
            Ngaylapphieu = ngaylapphieu;
            BenhNhan = benhnhan;
            BacSi = bacsi;
            this.dsCTPK = dsCTPK;
        }
        public CPhieuKham()
        {
            Maphieukham = "";
            Ngaylapphieu = DateTime.Today;
            BenhNhan = null;
            BacSi = null;
            DsCTPK = new List<CChiTietPhieuKham>();
        }
        private CChiTietPhieuKham timCtpk(string maDV)
        {
            foreach (CChiTietPhieuKham cthd in dsCTPK)
            {
                if (cthd.DichVu.MaDichVu == maDV)
                    return cthd;
            }
            return null;
        }
        public void insert(CDichVu dv, int soLuong)
        {
            CChiTietPhieuKham existCtpk = timCtpk(dv.MaDichVu);
            if (existCtpk == null)
                dsCTPK.Add(new CChiTietPhieuKham(soLuong, dv));
            else
            {
                existCtpk.SoLuong += soLuong;
            }
        }             
        public double ThanhTien
        {
            get
            {
                double tong = 0;
                foreach (CChiTietPhieuKham ct in dsCTPK)
                    tong += ct.ThanhTien;
                return tong;
            }
        }
        public string TinhTrang
        {
            get
            {
                CXuLyHoaDon xuLyHoaDon = new CXuLyHoaDon();
                List<CHoaDon> danhSachHoaDon = xuLyHoaDon.SearchByMaPK(Maphieukham);

                if (danhSachHoaDon.Any(hoaDon => hoaDon.TinhTrang == "Thanh toán đủ"))
                {
                    return "Đã thanh toán đủ";
                }
                else
                {
                    return "Chưa thanh toán";
                }
            }
        }
        public override string ToString() 
        {
            return Maphieukham;
        }
        
    }
}
