using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DALKhuyenMai
    {
        QL_DCANDataContext qldc = new QL_DCANDataContext();

        public DALKhuyenMai()
        {

        }
        public List<KhuyenMai> LoadKM()
        {
            return qldc.KhuyenMais.Select(km => km).ToList<KhuyenMai>();
        }

        public List<SanPham> LoadSP()
        {
            return qldc.SanPhams.Select(km => km).ToList<SanPham>();
        }

        public void InsertKM(KhuyenMai km)
        {
            var KM = new KhuyenMai
            {
                TenKM = km.TenKM,
                GiamGia = km.GiamGia,
                NgayBD = km.NgayBD,
                NgayKT = km.NgayKT,
                MaSP = km.MaSP
            };
            qldc.KhuyenMais.InsertOnSubmit(KM);
            qldc.SubmitChanges();
        }

        public bool IsTenKM(string TenKM)
        {
            var kt = qldc.KhuyenMais.Where(l => l.TenKM == TenKM).Count();
            if (kt == 0)
                return true;
            else
                return false;
        }

        public bool IsMaKM(int MaKM)
        {
            var kt = qldc.KhuyenMais.Where(l => l.MaKM == MaKM).Count();
            if (kt == 0)
                return true;
            else
                return false;
        }

        public List<KhuyenMai> LoadKMTheoMa(int MaKM)
        {
            return qldc.KhuyenMais.Where(l => l.MaKM == MaKM).ToList<KhuyenMai>();
        }

        public List<KhuyenMai> LoadKMTheoTen(string TenKM)
        {
            string seachItem = TenKM.ToLower();
            return qldc.KhuyenMais.Where(l => l.TenKM.Contains(seachItem)).ToList<KhuyenMai>();
        }

        public void XoaKM(int MaKM)
        {
            var KM = qldc.KhuyenMais.SingleOrDefault(l => l.MaKM == MaKM);
            if (KM != null)
            {
                qldc.KhuyenMais.DeleteOnSubmit(KM);
                qldc.SubmitChanges();
            }
            else
            {
                throw new Exception("Loại không tồn tại.");
            }
        }

        public bool IsTHOnSP(int MaTH)
        {
            var TH = qldc.SanPhams.Where(t => t.MaTH == MaTH).FirstOrDefault();
            if (TH != null)
                return true;
            else
                return false;
        }

        public void UpdateKM(KhuyenMai km)
        {
            var KM = qldc.KhuyenMais.FirstOrDefault(l => l.MaKM == km.MaKM);
            if (KM != null)
            {
                KM.TenKM = km.TenKM;
                KM.GiamGia = km.GiamGia;
                KM.NgayBD = km.NgayBD;
                KM.NgayKT = km.NgayKT;
                KM.MaSP = km.MaSP;
                qldc.SubmitChanges();
            }
            else
                throw new Exception("Loại không tồn tại.");
        }
    }
}
