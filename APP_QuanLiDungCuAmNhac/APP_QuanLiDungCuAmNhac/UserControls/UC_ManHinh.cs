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
    public partial class UC_ManHinh : UserControl
    {
        BLLManHinh ManHinhBLL = new BLLManHinh();
        public UC_ManHinh()
        {
            InitializeComponent();
        }

        private void UC_ManHinh_Load(object sender, EventArgs e)
        {
            LoadMH();
        }

        public void LoadMH()
        {
            DGVMH.DataSource = ManHinhBLL.LoadMH(); 
        }
    }
}
