using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
using APP_QuanLiDungCuAmNhac.Forms;
using APP_QuanLiDungCuAmNhac.My_Control;

namespace APP_QuanLiDungCuAmNhac.UserControls
{
    public partial class UC_KhoHang : UserControl
    {
        BLLKho KhoBLL = new BLLKho();

        public UC_KhoHang()
        {
            InitializeComponent();
    
        }

        private void UC_KhoHang_Load(object sender, EventArgs e)
        {
            DGVKho.Font = new Font("Century", 15);
            DGVKho.ColumnHeadersDefaultCellStyle.Font = new Font("Century", 17, FontStyle.Bold);
            LoadDGVKho();
            LoadCBBSP();
            LoadCBBNCC();
        }

        public void LoadDGVKho()
        {
            DGVKho.DataSource = KhoBLL.LoadKho();
        }

        public void LoadCBBSP()
        {
           
        }

        public void LoadCBBNCC()
        {
            var SPList = KhoBLL.LoadNCC();
            SPList.Insert(0, new NhaCungCap { MaNCC = -1, TenNCC = "Tat ca" });
            cbbNCC.DataSource = SPList;
            cbbNCC.DisplayMember = "TenNCC";
            cbbNCC.ValueMember = "MaNCC";
        }

        private void DGVKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo chỉ thực hiện khi click vào các ô hợp lệ
            {
                txtMaKho.Text = DGVKho.CurrentRow.Cells[0].Value.ToString();
                
                string MaNCC = DGVKho.CurrentRow.Cells[1].Value.ToString();      
                int selectedMaNCC;
                if (int.TryParse(MaNCC, out selectedMaNCC))
                {
                    cbbNCC.SelectedValue = selectedMaNCC;
                }

                string MaSP = DGVKho.CurrentRow.Cells[2].Value.ToString();
                int selectedMaSP;
                if (int.TryParse(MaSP, out selectedMaSP))
                {
                    cbbSP.SelectedValue = selectedMaSP;
                }
                txtSL.Text = DGVKho.CurrentRow.Cells[3].Value.ToString();

                string NgayNhap = DGVKho.CurrentRow.Cells[4].Value.ToString();
                DateTime selectedDate;
                if (DateTime.TryParse(NgayNhap, out selectedDate))
                {
                    DTNgayNhap.Value = selectedDate;
                }

                txtGiaNhap.Text = DGVKho.CurrentRow.Cells[5].Value.ToString();
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (DGVKho.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DGVKho.SelectedRows[0];
                int MaKho = int.Parse(selectedRow.Cells[0].Value.ToString());
                if (KhoBLL.IsMaKho(MaKho))
                {
                    MessageBox.Show("Mã khuyến mãi không tồn tại");
                    return;
                }
                KhoBLL.XoaKho(MaKho);
                MessageBox.Show("Xoa thanh cong");
                LoadDGVKho();
            }
        }
        private FormMain _mainForm;
        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemVaoKho frmThemVaoKho = new frmThemVaoKho();
            frmThemVaoKho.ShowDialog();
            //if (int.Parse(cbbNCC.SelectedValue.ToString()) == -1)
            //{
            //    MessageBox.Show("Vui lòng chọn nhà cung cấp");
            //    return;
            //}
            //if (int.Parse(cbbSP.SelectedValue.ToString()) == -1)
            //{
            //    MessageBox.Show("Vui lòng chọn sản phẩm");
            //    return;
            //}
            //if (string.IsNullOrEmpty(txtSL.Text))
            //{
            //    MessageBox.Show("Vui lòng nhập số lượng");
            //    return;
            //}
            //if (string.IsNullOrEmpty(txtGiaNhap.Text))
            //{
            //    MessageBox.Show("Vui lòng nhập giá");
            //    return;
            //}

            //KhoHang kh = new KhoHang();
            //kh.MaNCC = int.Parse(cbbNCC.SelectedValue.ToString());
            //kh.MaSP = int.Parse(cbbSP.SelectedValue.ToString());
            //kh.SoLuongNhap = int.Parse(txtSL.Text);
            //kh.NgayNhap = DTNgayNhap.Value.Date;
            //kh.GiaNhap = float.Parse(txtGiaNhap.Text);
            //KhoBLL.InsertKho(kh);
            //MessageBox.Show("Thêm thành công");
            //LoadDGVKho();  


        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtMaKho.Text))
            {
                MessageBox.Show("Vui lòng chọn dòng cần update");
                return;
            }    
            if (int.Parse(cbbNCC.SelectedValue.ToString()) == -1)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp");
                return;
            }
            if (int.Parse(cbbSP.SelectedValue.ToString()) == -1)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm");
                return;
            }
            if (string.IsNullOrEmpty(txtSL.Text))
            {
                MessageBox.Show("Vui lòng nhập số lượng");
                return;
            }
            if (string.IsNullOrEmpty(txtGiaNhap.Text))
            {
                MessageBox.Show("Vui lòng nhập giá");
                return;
            }

            KhoHang kh = new KhoHang();
            kh.MaKho = int.Parse(txtMaKho.Text);
            kh.MaNCC = int.Parse(cbbNCC.SelectedValue.ToString());
            kh.MaSP = int.Parse(cbbSP.SelectedValue.ToString());
            kh.SoLuongNhap = int.Parse(txtSL.Text);
            kh.NgayNhap = DTNgayNhap.Value.Date;
            kh.GiaNhap = float.Parse(txtGiaNhap.Text);
            KhoBLL.UpdateKho(kh);
            MessageBox.Show("Update thành công");
            LoadDGVKho();
        }
    }
}
