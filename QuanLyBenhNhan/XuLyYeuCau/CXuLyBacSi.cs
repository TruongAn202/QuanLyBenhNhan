using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBenhNhan
{
    class CXuLyBacSi
    {
        private Dictionary<string, CBacSi> dsBS;

        public CXuLyBacSi()
        {
            TruyCapDuLieu duLieu = TruyCapDuLieu.khoiTao();
            this.dsBS = duLieu.getDSBS();
        }
        public List<CBacSi> getDsBacSi()
        {
            return dsBS.Values.ToList();  
        }

        public void insertBS(CBacSi bs)
        {
            if (!dsBS.ContainsKey(bs.MaBS))
            {
                dsBS.Add(bs.MaBS, bs);
            }
        }

        public CBacSi searchBS(string mabs) // kt mã bs, trùng trả về đối tượng tương ứng, ko có trả về null
        {
            if (dsBS.ContainsKey(mabs))
                return dsBS[mabs];
            return null;
        }

        public void deleteBS(string mabs)
        {
            if (dsBS.ContainsKey(mabs))
                dsBS.Remove(mabs);
        }

        public void updateBS(CBacSi bs)
        {
            if (dsBS.ContainsKey(bs.MaBS))
                dsBS[bs.MaBS] = bs;
        }

        public bool ktTrungMa(string maBS)
        {
            return dsBS.ContainsKey(maBS);   
        }
        
    }
}
