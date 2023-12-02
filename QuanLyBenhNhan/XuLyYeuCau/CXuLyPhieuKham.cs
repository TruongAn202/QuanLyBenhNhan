using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBenhNhan
{
   
    class CXuLyPhieuKham
    {
        private Dictionary<string, CPhieuKham> dsPK; // real
        private Dictionary<string, CBenhNhan> dsBN;
        private Dictionary<string, CBacSi> dsBS;
        private Dictionary<string, CDichVu> dsDV;

        public CXuLyPhieuKham()
        {
            dsPK = new Dictionary<string, CPhieuKham>();
            TruyCapDuLieu duLieu = TruyCapDuLieu.khoiTao();
            this.dsPK = duLieu.getDSPK();
            this.dsBN = duLieu.getDSBN();
            this.dsBS = duLieu.getDSBS();
            this.dsDV = duLieu.getDSDV();
        }

        public List<CPhieuKham> getDsPhieuKham() // reAL
        {
            return dsPK.Values.ToList();
        }

        public List<CBacSi> getDsBacSi()
        {
            return dsBS.Values.ToList();
        }
        public List<CBenhNhan> getDsBenhNhan()
        {
            return dsBN.Values.ToList();
        }

        public List<CDichVu> getDSDichVu()
        {
            return dsDV.Values.ToList();
        }
        public void insertPK(CPhieuKham pk)
        {
            if (!dsPK.ContainsKey(pk.Maphieukham))
            {
                dsPK.Add(pk.Maphieukham, pk);
            }
        }

        public CPhieuKham searchPK(string mapk)
        {
            if (dsPK.ContainsKey(mapk))
                return dsPK[mapk];
            return null;
        }

        public void deletePK(string mapk)
        {
            if (dsPK.ContainsKey(mapk))
                dsPK.Remove(mapk);
        }

        public void updatePK(CPhieuKham pk)
        {
            if (dsPK.ContainsKey(pk.Maphieukham))
                dsPK[pk.Maphieukham] = pk;
        }

        public bool ktTrungMa(string maPK)
        {
            return dsPK.ContainsKey(maPK);
        }
    }
}
