using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class BLLKhuyenMai
    {
        DALKhuyenMai KhuyenMaiDAL = new DALKhuyenMai();

        public BLLKhuyenMai()
        {
        }

        public List<KhuyenMai> LoadKM()
        {
            return KhuyenMaiDAL.LoadKM();
        }

        public bool IsTenKM(string TenKM)
        {
            return KhuyenMaiDAL.IsTenKM(TenKM);
        }

        public List<KhuyenMai> LoadKMTheoMa(int MaKM)
        {
            return KhuyenMaiDAL.LoadKMTheoMa(MaKM);
        }

        public List<KhuyenMai> LoadKMTheoTen(string TenKM)
        {
            return KhuyenMaiDAL.LoadKMTheoTen(TenKM);
        }

        public List<SanPham> LoadSP()
        {
            return KhuyenMaiDAL.LoadSP();
        }

        public bool IsMaKH(int MaKM)
        {
            return KhuyenMaiDAL.IsMaKM(MaKM);
        }
        public void XoaKM(int MaKM)
        {
            KhuyenMaiDAL.XoaKM(MaKM);
        }

        public bool IsTHOnSP(int MaTH)
        {
            return KhuyenMaiDAL.IsTHOnSP(MaTH);
        }

        public void UpdateKM(KhuyenMai km)
        {
            KhuyenMaiDAL.UpdateKM(km);
        }

        public void InsertKM(KhuyenMai km)
        {
            KhuyenMaiDAL.InsertKM(km);
        }
    }
}
