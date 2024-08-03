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

namespace APP_QuanLiDungCuAmNhac.UserControls
{

    public partial class UC_ThemVaoKho : UserControl
    {
        BLLSanPham SanPhamBLL = new BLLSanPham();
        public UC_ThemVaoKho()
        {
            InitializeComponent();
            this.Load += UC_ThemVaoKho_Load;
           
        }

        private void UC_ThemVaoKho_Load(object sender, EventArgs e)
        {
            loadSP();
        }
        public void loadSP()
        {
            DGVSanPham.DataSource = SanPhamBLL.LoadSP();
        }

    }
}
