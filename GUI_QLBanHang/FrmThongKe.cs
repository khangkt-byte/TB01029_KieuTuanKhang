using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLBanHang;

namespace GUI_QLBanHang
{
    public partial class FrmThongKe : Form
    {
        BUS_Hang busHang = new BUS_QLBanHang.BUS_Hang();
        BUS_Log busLog = new BUS_QLBanHang.BUS_Log();
        public FrmThongKe()
        {
            InitializeComponent();
            tpsanpham.Focus();
        }

        private void FrmThongKe_Load(object sender, EventArgs e)
        {
            LoadGridview_ThongKeHang();
        }

        private void TcThongKe_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tpsanpham)
            {
                LoadGridview_ThongKeHang();
            }
            else if (e.TabPage == tptonkho)
            {
                LoadGridview_ThongKeTonKho();
            }
            else if (e.TabPage == tpLogSanPham)
            {
                LoadGridview_LogSanPham();
            }
        }

        private void LoadGridview_ThongKeHang()
        {
            dgvsp.AutoResizeColumns();
            dgvsp.DataSource = busHang.ThongKeHang();
            dgvsp.Columns[0].HeaderText = "Mã nhân viên";
            dgvsp.Columns[1].HeaderText = "Tên nhân viên";
            dgvsp.Columns[2].HeaderText = "Số Lượng Sản Phẩm Nhập";
        }
        private void LoadGridview_ThongKeTonKho()
        {
            dgvtonkho.AutoResizeColumns();
            dgvtonkho.DataSource = busHang.ThongKeTonKho();
            dgvtonkho.Columns[0].HeaderText = "Mã Sản Phẩm";
            dgvtonkho.Columns[1].HeaderText = "Tên Sản Phẩm";
            dgvtonkho.Columns[2].HeaderText = "Số Lượng Tồn";
        }

        private void LoadGridview_LogSanPham()
        {
            dgvLogSanPham.DataSource = busLog.GetLogSanPham();
            dgvLogSanPham.Columns[0].HeaderText = "ID";
            dgvLogSanPham.Columns[0].FillWeight = 50;
            dgvLogSanPham.Columns[1].HeaderText = "Sản phẩm";
            dgvLogSanPham.Columns[2].HeaderText = "Nhân viên";
            dgvLogSanPham.Columns[3].HeaderText = "Hành động";
            dgvLogSanPham.Columns[4].HeaderText = "Giá trị cũ";
            dgvLogSanPham.Columns[4].FillWeight = 150;
            dgvLogSanPham.Columns[5].HeaderText = "Giá trị mới";
            dgvLogSanPham.Columns[5].FillWeight = 150;
            dgvLogSanPham.Columns[6].HeaderText = "Thời gian";
        }
    }
}

