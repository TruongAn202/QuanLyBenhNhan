﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBenhNhan
{
    
    class CXuLyHoaDon
    {
        private Dictionary<string, CHoaDon> dsHD;
        private Dictionary<string, CPhieuKham> dsPK = new Dictionary<string, CPhieuKham>();
        public CXuLyHoaDon()
        {
            dsHD = new Dictionary<string, CHoaDon>();
            TruyCapDuLieu duLieu = TruyCapDuLieu.khoiTao();
            this.dsHD = duLieu.getDSHD();
            this.dsPK = duLieu.getDSPK();
        }
        public List<CHoaDon> getDSHoaDon()
        {
            return dsHD.Values.ToList();
        }
        public List<CPhieuKham> getDSPhieuKham()
        {
            return dsPK.Values.ToList();
        }
        public void insertHD(CHoaDon hd)
        {
            if (!dsHD.ContainsKey(hd.Mahoadon))
            {
                dsHD.Add(hd.Mahoadon, hd);
            }
        }
        public CHoaDon searchHD(string mahd)
        {
            if (dsHD.ContainsKey(mahd))
                return dsHD[mahd];
            return null;
        }
        public void deleteHD(string mahd)
        {
            if (dsHD.ContainsKey(mahd))
                dsHD.Remove(mahd);
        }
        public void updateHD(CHoaDon hd)
        {
            if (dsHD.ContainsKey(hd.Mahoadon))
                dsHD[hd.Mahoadon] = hd;
        }
        public bool ktTrungMa(string maHD)
        {
            return dsHD.ContainsKey(maHD);
        }
        public List<CHoaDon> SearchByMaPK(string code)
        {
            List<CHoaDon> listSearch = new List<CHoaDon>();
            foreach (var kvp in dsHD)
            {
                if (kvp.Value.PhieuKham.Maphieukham.Contains(code))
                {
                    listSearch.Add(kvp.Value);
                }
            }
            return listSearch;
        }
    }
}
