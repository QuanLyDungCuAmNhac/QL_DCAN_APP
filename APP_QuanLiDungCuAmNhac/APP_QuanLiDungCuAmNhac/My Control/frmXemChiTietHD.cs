using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_QuanLiDungCuAmNhac.My_Control
{
    public partial class frmXemChiTietHD : Form
    {
        public DataGridView DataGridViewCTHD
        {
            get { return datagridviewCTHD; }
        }
        public frmXemChiTietHD()
        {
            InitializeComponent();
            datagridviewCTHD.AutoGenerateColumns = false;

            // Tạo cột mã chi tiết
            DataGridViewTextBoxColumn maChiTietColumn = new DataGridViewTextBoxColumn();
            maChiTietColumn.Name = "MaHD";
            maChiTietColumn.HeaderText = "Mã Chi Tiết";
            maChiTietColumn.DataPropertyName = "MaHD"; // Thuộc tính trong đối tượng chi tiết hóa đơn
            datagridviewCTHD.Columns.Add(maChiTietColumn);

            DataGridViewTextBoxColumn maSPColumn = new DataGridViewTextBoxColumn();
            maChiTietColumn.Name = "MaSP";
            maChiTietColumn.HeaderText = "Mã SP";
            maChiTietColumn.DataPropertyName = "MaSP"; // Thuộc tính trong đối tượng chi tiết hóa đơn
            datagridviewCTHD.Columns.Add(maSPColumn);

            // Tạo cột số lượng
            DataGridViewTextBoxColumn soLuongColumn = new DataGridViewTextBoxColumn();
            soLuongColumn.Name = "SoLuong";
            soLuongColumn.HeaderText = "Số Lượng";
            soLuongColumn.DataPropertyName = "SoLuong"; // Thuộc tính trong đối tượng chi tiết hóa đơn
            datagridviewCTHD.Columns.Add(soLuongColumn);

            DataGridViewTextBoxColumn donGiaColumn = new DataGridViewTextBoxColumn();
            donGiaColumn.Name = "DonGia";
            donGiaColumn.HeaderText = "Đơn Giá";
            donGiaColumn.DataPropertyName = "DonGia"; // Thuộc tính trong đối tượng chi tiết hóa đơn
            datagridviewCTHD.Columns.Add(donGiaColumn);

        }
    }
}
