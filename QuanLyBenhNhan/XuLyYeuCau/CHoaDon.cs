using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBenhNhan
{
    [Serializable]
    class CHoaDon
    {
        private string mahoadon;
        private DateTime ngaylaphoadon;
        private string tenBN;
        //private string maPK;
        private string tongTien;
        private CPhieuKham phieuKham;
       // private CBenhNhan benhNhan;

        public string Mahoadon { get => mahoadon; set => mahoadon = value; }
        public DateTime Ngaylaphoadon { get => ngaylaphoadon; set => ngaylaphoadon = value; }
        public string TenBN { get => tenBN; set => tenBN = value; }
        //public string MaPK { get => maPK; set => maPK = value; }
        public string TongTien { get => tongTien; set => tongTien = value; }

        public CPhieuKham PhieuKham { get => phieuKham; set => phieuKham = value; }
        // internal CBenhNhan BenhNhan { get => benhNhan; set => benhNhan = value; }

        public CHoaDon(string mahoadon, DateTime ngaylaphoadon, CPhieuKham pk, string tenbn, string tongtien)
        {
            Mahoadon = mahoadon;
            Ngaylaphoadon = ngaylaphoadon;
            TenBN = tenbn;
            PhieuKham = pk;
            TongTien = tongtien;
            
        }

        public CHoaDon() 
        {
            Mahoadon = null;
            ngaylaphoadon = DateTime.Today;
            TenBN = null;
            PhieuKham = null;
            TongTien = null;
            
           
        }
       
    }
}
