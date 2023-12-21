using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBenhNhan
{
    [Serializable]
    class CDichVu
    {
        private string maDichVu;
        private string tenDichVu;
        private double dongia;
        public CDichVu(string maDichVu, string tenDichVu, double dongia)
        {
            MaDichVu = maDichVu;
            TenDichVu = tenDichVu;
            Dongia = dongia;
        }
        public CDichVu()
        {
            MaDichVu = null;
            TenDichVu = null;
            Dongia = 0;
        }
        public string MaDichVu { get => maDichVu; set => maDichVu = value; }
        public string TenDichVu { get => tenDichVu; set => tenDichVu = value; }
        public double Dongia { get => dongia; set => dongia = value; }
        public override string ToString() 
        {
            return MaDichVu;

        }
    }
}
