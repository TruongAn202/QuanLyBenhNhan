using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBenhNhan
{
    [Serializable]
    class CBacSi
    {
        private string maBS;
        private string tenBS;
        private DateTime ngaySinh;
        private string diaChi;
        private string gioiTinh;
        private DateTime ngayVaoLam;
        private string soDienThoai;

        //luu y chỗ này, nếu ko làm đồng bộ thì dữ liệu sẽ null =>bên các nút ko lấy dc dữ liệu
        public string MaBS { get => maBS; set => maBS = value; }
        public string TenBS { get => tenBS; set => tenBS = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public DateTime NgayVaoLam { get => ngayVaoLam; set => ngayVaoLam = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }

        public CBacSi(string mabs, string tenbs, string sodienthoai, string diachi, string gioitinh, DateTime ngaysinh, DateTime ngayvaolam)
        {
            MaBS = mabs;
            TenBS = tenbs;
            NgaySinh = ngaysinh;
            DiaChi = diachi;
            GioiTinh = gioitinh;
            NgayVaoLam = ngayvaolam;
            SoDienThoai = sodienthoai;
        }

        public CBacSi() : this("", "", "", "", "", DateTime.Today, DateTime.Today)
        {

        }
        public override string ToString() //hienthi chi madv len cb
        {
            return TenBS;
        }
    }
}
