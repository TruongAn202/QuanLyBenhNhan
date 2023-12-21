using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBenhNhan
{
    [Serializable]
    class CBenhNhan{
        private string maBN;
        private string tenBN;
        private string soDienThoai;
        private string diaChi;
        private string gioiTinh;
        private DateTime ngaySinh;
        private DateTime ngayKham;
        private string ghiChu; 
        public CBenhNhan(string maBN, string tenBN, string soDienThoai, string diaChi, 
            string gioiTinh, DateTime ngaySinh, DateTime ngayKham, string ghiChu)
        {
            MaBN = maBN;
            TenBN = tenBN;
            SoDienThoai = soDienThoai;
            DiaChi = diaChi;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            NgayKham = ngayKham;
            GhiChu = ghiChu;
        }
        public CBenhNhan() : this("", "", "", "", "", DateTime.Today, DateTime.Today, "")
        {

        }
        public string MaBN { get => maBN; set => maBN = value; }
        public string TenBN { get => tenBN; set => tenBN = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public DateTime NgayKham { get => ngayKham; set => ngayKham = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
        public override string ToString() 
        {
            return TenBN;
        }
    }
}
