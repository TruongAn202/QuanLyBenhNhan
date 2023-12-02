using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBenhNhan
{
    [Serializable]
    class TruyCapDuLieu
    {

        private static TruyCapDuLieu instance = null;
        private Dictionary<string, CBacSi> dsBS;
        private Dictionary<string, CBenhNhan> dsBN;
        private Dictionary<string, CDichVu> dsDV;
        private Dictionary<string, CPhieuKham> dsPK;
        private Dictionary<string, CHoaDon> dsHD;

        private TruyCapDuLieu()
        {
            dsBS = new Dictionary<string, CBacSi>();
            dsBN = new Dictionary<string, CBenhNhan>();
            dsDV = new Dictionary<string, CDichVu>();
            dsPK = new Dictionary<string, CPhieuKham>();
            dsHD = new Dictionary<string, CHoaDon>();
        }

        public static TruyCapDuLieu khoiTao()
        {
            if (instance == null)
            {
                instance = new TruyCapDuLieu();
            }
            return instance;
        }

        public Dictionary<string, CBacSi> getDSBS()
        {
            return dsBS;
        }
        public Dictionary<string, CBenhNhan> getDSBN()
        {
            return dsBN;
        }
        public Dictionary<string, CDichVu> getDSDV()
        {
            return dsDV;
        }
        public Dictionary<string, CPhieuKham> getDSPK()
        {
            return dsPK;
        }
        public Dictionary<string, CHoaDon> getDSHD()
        {
            return dsHD;
        }



        public static bool luuFile(string filename)
        {
            try
            {
                FileStream fs = new FileStream(filename, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, instance);
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool docFile(string filename)
        {
            try
            {
                FileStream fs = new FileStream(filename, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                instance = (TruyCapDuLieu)bf.Deserialize(fs);
                fs.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
