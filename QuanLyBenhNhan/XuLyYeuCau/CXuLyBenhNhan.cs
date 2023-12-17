using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBenhNhan
{
    class CXuLyBenhNhan
    {
        private Dictionary<string, CBenhNhan> dsBN;
        public CXuLyBenhNhan()
        {
            TruyCapDuLieu duLieu = TruyCapDuLieu.khoiTao();
            this.dsBN = duLieu.getDSBN();
        }
        public List<CBenhNhan> getDsBenhNhan()
        {
            return dsBN.Values.ToList();
        }

        public void insertBN(CBenhNhan bn)
        {
            if (!dsBN.ContainsKey(bn.MaBN))
            {
                dsBN.Add(bn.MaBN, bn);
            }
        }

        public CBenhNhan searchBN(string mabn)
        {
            if (dsBN.ContainsKey(mabn))
                return dsBN[mabn];
            return null;
        }

        public void deleteBN(string mabn)
        {
            if (dsBN.ContainsKey(mabn))
                dsBN.Remove(mabn);
        }

        public void updateBN(CBenhNhan bn)
        {
            if (dsBN.ContainsKey(bn.MaBN))
                dsBN[bn.MaBN] = bn;
        }

        public bool ktTrungMa(string maBN)
        {
            return dsBN.ContainsKey(maBN);   // Kiểm tra xem mã bệnh nhân đã tồn tại trong dsBN hay không                      
        }
        
    }
}
