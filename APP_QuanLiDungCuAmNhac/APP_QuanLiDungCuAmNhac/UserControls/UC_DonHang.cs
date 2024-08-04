using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using APP_QuanLiDungCuAmNhac.My_Control;
namespace APP_QuanLiDungCuAmNhac.UserControls
{
    public partial class UC_DonHang : UserControl
    {
        BLLHoaDon bllhd = new BLLHoaDon();
        public UC_DonHang()
        {
            InitializeComponent();
        }

        private void datagridviewHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UC_DonHang_Load(object sender, EventArgs e)
        {
            datagridviewHoaDon.ColumnHeadersDefaultCellStyle.Font = new Font("Seogoe UI", 12, FontStyle.Bold);
            datagridviewHoaDon.AutoGenerateColumns = false;
            // datagridviewHoaDon.ReadOnly = true; // Đặt toàn bộ DataGridView chỉ đọc
            datagridviewHoaDon.Columns["TinhTrang"].ReadOnly = false;
            DataGridViewButtonColumn viewDetailButtonColumn = new DataGridViewButtonColumn();
            viewDetailButtonColumn.Name = "ViewDetailButton";
            viewDetailButtonColumn.HeaderText = "";
            viewDetailButtonColumn.Text = "Xem Chi Tiết";
            viewDetailButtonColumn.UseColumnTextForButtonValue = true;
            viewDetailButtonColumn.Width = 100; // Đặt chiều rộng cho nút xem chi tiết, ví dụ 100 pixel
            datagridviewHoaDon.Columns.Add(viewDetailButtonColumn);

            datagridviewHoaDon.DataSource = bllhd.LoadHD();
            txtMaHD.KeyDown += new KeyEventHandler(txt_KeyDown);
            txtMaKH.KeyDown += new KeyEventHandler(txt_KeyDown);
            datagridviewHoaDon.CellValueChanged += datagridviewHoaDon_CellValueChanged;
        }
        private void datagridviewHoaDon_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == datagridviewHoaDon.Columns["TinhTrang"].Index)
            {
                int maHD = (int)datagridviewHoaDon.Rows[e.RowIndex].Cells["MaHD"].Value;
                string tinhTrangMoi = datagridviewHoaDon.Rows[e.RowIndex].Cells["TinhTrang"].Value.ToString();

                // Cập nhật tình trạng mới vào database
                bllhd.UpdateTinhTrang(maHD, tinhTrangMoi);
            }
        }
        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FilterDataGridView();
            }
        }

        // Hàm lọc dữ liệu DataGridView
        private void FilterDataGridView()
        {
            int? maHD = string.IsNullOrEmpty(txtMaHD.Text.Trim()) ? (int?)null : int.Parse(txtMaHD.Text.Trim());
            int? maKH = string.IsNullOrEmpty(txtMaKH.Text.Trim()) ? (int?)null : int.Parse(txtMaKH.Text.Trim());

            // Gọi phương thức lọc từ DAL
            var filteredData = bllhd.FilterHD(maHD, maKH);

            datagridviewHoaDon.DataSource = filteredData;
        }

        private void datagridviewHoaDon_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void datagridviewHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == datagridviewHoaDon.Columns["ViewDetailButton"].Index && e.RowIndex >= 0)
            {
                // Lấy mã hóa đơn của hàng được chọn
                int maHD = (int)datagridviewHoaDon.Rows[e.RowIndex].Cells["MaHD"].Value;
                var invoiceDetails = bllhd.GetInvoiceDetails(maHD);

                // Tạo form mới để hiển thị chi tiết hóa đơn
                frmXemChiTietHD frm = new frmXemChiTietHD();
                frm.DataGridViewCTHD.DataSource = invoiceDetails;

                frm.Size = new Size(600, 400);
                frm.ShowDialog();
            }
        }
    }
}
