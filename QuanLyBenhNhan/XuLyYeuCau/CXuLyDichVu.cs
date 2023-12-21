using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBenhNhan
{
    class CXuLyDichVu
    {
        private Dictionary<string, CDichVu> dsDV;
        public CXuLyDichVu()
        {
            TruyCapDuLieu duLieu = TruyCapDuLieu.khoiTao();
            this.dsDV = duLieu.getDSDV();
        }
        public List<CDichVu> getDsDichVu()
        {
            return dsDV.Values.ToList();
        }

        public void insertDV(CDichVu dv)
        {
            if (!dsDV.ContainsKey(dv.MaDichVu))
            {
                dsDV.Add(dv.MaDichVu, dv);
            }
        }

        public CDichVu searchDV(string madv)
        {
            if (dsDV.ContainsKey(madv))
                return dsDV[madv];
            return null;
        }

        public void deleteDV(string madv)
        {
            if (dsDV.ContainsKey(madv))
                dsDV.Remove(madv);
        }

        public void updateDV(CDichVu dv)
        {
            if (dsDV.ContainsKey(dv.MaDichVu))
                dsDV[dv.MaDichVu] = dv;
        }

        public bool ktTrungMa(string maDV)
        {
            return dsDV.ContainsKey(maDV);
        }
    }
}
