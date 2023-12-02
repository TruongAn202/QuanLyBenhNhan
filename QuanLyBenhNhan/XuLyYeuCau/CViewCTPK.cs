using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBenhNhan
{
    internal class CViewCTPK
    {
        private CChiTietPhieuKham ctpk;

        public CViewCTPK(CChiTietPhieuKham ctpk)
        {
            this.ctpk = ctpk;
        }

        public string MaDV => ctpk.DichVu.MaDichVu;
        public string TenDV => ctpk.DichVu.TenDichVu;
        public double DonGia => ctpk.DonGia;
        public int SoLuong => ctpk.SoLuong;
        public double ThanhTien => ctpk.ThanhTien;

        public static List<CViewCTPK> getViewList(List<CChiTietPhieuKham> dsCTPK)
        {
            List<CViewCTPK> viewList = new List<CViewCTPK>();
            foreach (CChiTietPhieuKham cthd in dsCTPK)
            {
                viewList.Add(new CViewCTPK(cthd));
            }
            return viewList;
        }


    }
}
