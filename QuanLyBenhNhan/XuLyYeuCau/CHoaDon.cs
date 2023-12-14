using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBenhNhan
{
    [Serializable]
    class CHoaDon{
        private string mahoadon;
        private DateTime ngaylaphoadon;
        private string tenBN;
        private string tongTien;
        private double daTra;
        private CPhieuKham phieuKham;      
        public string Mahoadon { get => mahoadon; set => mahoadon = value; }
        public DateTime Ngaylaphoadon { get => ngaylaphoadon; set => ngaylaphoadon = value; }
        public string TenBN { get => tenBN; set => tenBN = value; }
        public string TongTien { get => tongTien; set => tongTien = value; }
        public CPhieuKham PhieuKham { get => phieuKham; set => phieuKham = value; }
        public double DaTra { get => daTra; set => daTra = value; }
        public double ConLai
        {
            get
            {              
                if (double.TryParse(TongTien, out double tongTienDouble))
                {             
                    return tongTienDouble - DaTra;
                }
                else
                {    
                    throw new InvalidOperationException("Không thể chuyển đổi giá trị TongTien thành kiểu double.");
                }
            }
        }
        public CHoaDon(string mahoadon, DateTime ngaylaphoadon, CPhieuKham pk, 
            string tenbn, string tongtien, double datra)
        {
            Mahoadon = mahoadon;
            Ngaylaphoadon = ngaylaphoadon;
           
            TenBN = tenbn;
            PhieuKham = pk;
            TongTien = tongtien;
            DaTra = datra;
        }
        public CHoaDon() 
        {
            Mahoadon = null;
            ngaylaphoadon = DateTime.Today;
            TenBN = null;
            PhieuKham = null;
            TongTien = null;
            DaTra = 0;
            
           
        }
        public string TinhTrang
        {
            get
            {
                if (double.TryParse(TongTien, out double tongTienDouble))
                {
                    if (tongTienDouble == DaTra)
                    {
                        return "Paid";
                    }
                    else
                    {
                        return "Còn nợ";
                    }
                }
                else
                {
                    throw new InvalidOperationException("Không thể chuyển đổi giá trị TongTien thành kiểu double.");
                }
            }
        }
    }
}
