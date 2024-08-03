using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DALHoaDon
    {
        QL_DCANDataContext qldcan = new QL_DCANDataContext();
        public int SaveHoaDon(HoaDon hoaDon)
        {

            qldcan.HoaDons.InsertOnSubmit(hoaDon);
            qldcan.SubmitChanges();
            return hoaDon.MaHD; // Trả về MaHD của hóa đơn vừa được lưu
           
        }

        public bool SaveChiTietHoaDon(ChiTietHoaDon chiTietHoaDon)
        {
            try
            {
                qldcan.ChiTietHoaDons.InsertOnSubmit(chiTietHoaDon);
                qldcan.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return false;
            }
        }

        public List<DoanhThuTheoNgay> GetDoanhThuTheoThang(int month, int year)
        {
            var query = qldcan.HoaDons
            .Where(hd => hd.NgayDat.HasValue && hd.NgayDat.Value.Month == month && hd.NgayDat.Value.Year == year)
            .GroupBy(hd => hd.NgayDat.Value.Day)
            .Select(g => new DoanhThuTheoNgay
            {
                Ngay = g.Key,
                DoanhThu = g.Sum(hd => hd.TongTien ?? 0)
            })
            .ToList();

            return query;
        }

        public class DoanhThuTheoNgay
        {
            public int Ngay { get; set; }
            public decimal DoanhThu { get; set; }
        }
    }
}
