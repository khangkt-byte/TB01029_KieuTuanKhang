﻿using BUS_QLBanHang;
using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QLBanHang
{
    public partial class FrmMain : Form
    {
        public static int session = 0;//kiem tra tình trạng login
        public static int profile = 0;// 
        public static string mail;// truyên email từ frmMain cho các form khác thong qua bien static
        Thread th;//using System.Threading;
        FrmDangNhap dn;
        BUS_NhanVien busNhanVien = new BUS_NhanVien();
        public static Boolean isPasswordDefault = false;
        Form currentFormChild;
        public FrmMain()
        {
            InitializeComponent();
            //if (Properties.Settings.Default.Remember)
            //{
            //    dn = new FrmDangNhap();
            //    mail = Properties.Settings.Default.Email;
            //    session = Properties.Settings.Default.Session;
            //    dn.vaitro = Properties.Settings.Default.Role;
            //}
        }
        public void FrmMain_Load(object sender, EventArgs e)
        {
            Resetvalue();
            if (profile == 1)// nếu vừa câp nhật mật khẩu thì 
                             //phải login lại, mục 'thong tin nhan vien' ẩn
            {
                thongtinnvToolStripMenuItem.Text = null;
                profile = 0; //ẩn mục 'thong tin nhan vien'
            }
            if (busNhanVien.NhanVienKhongHoatDong(mail))
            {
                MessageBox.Show("Tài khoản của bạn không hoạt động!");
                LoOutToolStripMenuItem1_Click(sender, e);
                return;
            }
        }

        //show form KhachHang
        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Nếu chưa mở
            //if (!CheckExistForm("FrmKhach"))
            //{
            //    FrmKhach kh = new FrmKhach();
            //    kh.MdiParent = this;
            //    kh.Show();
            //}
            //else//hiển thị focus
            //    ActiveChildForm("FrmKhach");

            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            FrmKhach kh = new FrmKhach();
            currentFormChild = kh;
            kh.TopLevel = false;
            this.Controls.Add(kh);
            kh.StartPosition = FormStartPosition.Manual;
            kh.Location = new Point(
                (this.ClientSize.Width - kh.Width) / 2,
                (this.ClientSize.Height - kh.Height) / 2
            );
            kh.BringToFront();
            kh.Show();
        }

        //show form sản phẩm
        private void SảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!CheckExistForm("frmHang"))
            {
                th = new Thread(OpenNewForm);//chay lại form đang nhap
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
                ActiveChildForm("frmHang");
        }

        //show form nhanvien
        private void NhanVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (!CheckExistForm("frmNhanVien"))
            //{
            //    frmNhanVien nv = new frmNhanVien();
            //    nv.MdiParent = this;
            //    nv.Show();
            //}
            //else
            //    ActiveChildForm("frmNhanVien");

            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            frmNhanVien nv = new frmNhanVien();
            currentFormChild = nv;
            nv.TopLevel = false;
            this.Controls.Add(nv);
            nv.StartPosition = FormStartPosition.Manual;
            nv.Location = new Point(
                (this.ClientSize.Width - nv.Width) / 2,
                (this.ClientSize.Height - nv.Height) / 2
            );
            nv.BringToFront();
            nv.Show();
        }

        //show form đăng nhập
        public void ĐăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //if (!CheckExistForm("FrmDangNhap"))
            //{
            //    dn = new FrmDangNhap();
            //    dn.MdiParent = this;
            //    dn.Show();
            //    dn.FormClosed += new FormClosedEventHandler(FrmDangNhap_FormClosed);
            //}
            //else
            //{
            //    ActiveChildForm("FrmDangNhap");
            //}

            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            dn = new FrmDangNhap();
            currentFormChild = dn;
            dn.TopLevel = false;
            this.Controls.Add(dn);
            dn.StartPosition = FormStartPosition.Manual;
            dn.Location = new Point(
                (this.ClientSize.Width - dn.Width) / 2,
                (this.ClientSize.Height - dn.Height) / 2
            );
            dn.BringToFront();
            dn.Show();
            dn.FormClosed += new FormClosedEventHandler(FrmDangNhap_FormClosed);
        }

        //show form thông tin nv
        private void ProfileNvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmThongTinNV profilenv = new FrmThongTinNV(FrmMain.mail);// khơi tạo FrmThongTinNV với email nv

            //if (!CheckExistForm("frmThongTinNV"))
            //{
            //profilenv.MdiParent = this;
            //profilenv.Show();
            //    profilenv.FormClosed += new FormClosedEventHandler(FrmThongTinNV_FormClosed);
            //}
            //else
            //    ActiveChildForm("frmThongTinNV");

            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = profilenv;
            profilenv.TopLevel = false;
            this.Controls.Add(profilenv);
            profilenv.StartPosition = FormStartPosition.Manual;
            profilenv.Location = new Point(
                (this.ClientSize.Width - profilenv.Width) / 2,
                (this.ClientSize.Height - profilenv.Height) / 2
            );
            profilenv.BringToFront();
            profilenv.Show();
            profilenv.FormClosed += new FormClosedEventHandler(FrmThongTinNV_FormClosed);
        }

        //form thống kê sản phâm theo nhân viên nhập và thống kê số lượng sp tồn kho
        private void ThongKeSPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (!CheckExistForm("FrmThongKe"))
            //{
            //    FrmThongKe tk = new FrmThongKe();
            //    tk.MdiParent = this;
            //    tk.Show();
            //}
            //else
            //    ActiveChildForm("FrmThongKe");

            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            FrmThongKe tk = new FrmThongKe();
            currentFormChild = tk;
            tk.TopLevel = false;
            this.Controls.Add(tk);
            tk.StartPosition = FormStartPosition.Manual;
            tk.Location = new Point(
                (this.ClientSize.Width - tk.Width) / 2,
                (this.ClientSize.Height - tk.Height) / 2
            );
            tk.BringToFront();
            tk.Show();
        }

        //show file hương dẫn phan mem
        private void HuongDanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "Tai lieu huong dan su dung phan mem.pdf");
                System.Diagnostics.Process.Start(path);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("The file is not found in the specified location");
            }
        }

        //CheckExistForm để kiểm tra xem 1 Form với tên nào đó đã hiển thị trong Form Cha (frmMain) chưa? => Trả về True (đã hiển thị) hoặc False (nếu chưa hiển thị).
        private bool CheckExistForm(string name)
        {
            bool check = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }

        //ActiveChildForm dùng để “Kích hoạt”  – hiển thị lên trên cùng các trong số các Form Con nếu nó đã hiện mà không phải tạo thể hiện mới.
        private void ActiveChildForm(string name)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    frm.Activate();
                    break;
                }
            }
        }

        private void CheckPassword(object sender, EventArgs e, string email)
        {
            if (busNhanVien.NhanVienDangNhap(email, "23315424196402035621"))
            {
                FrmMain.isPasswordDefault = true;
                MessageBox.Show("Bạn đang sử dụng mật khẩu mặc định, vui lòng đổi mật khẩu mới để tiếp tục sử dụng!");
                ProfileNvToolStripMenuItem_Click(sender, e);
            }
            else
            {
                FrmMain.isPasswordDefault = false;
            }
        }

        //chuc nang nhan vien bình thường ko hiên thị quan lý nhan vien và thống kê
        private void VaiTroNV()
        {
            NhanVienToolStripMenuItem.Visible = false;
            thongkeToolStripMenuItem.Visible = false;
        }

        //Thiệt lap phan quyên khi load frmMain
        private void Resetvalue()
        {
            if (session == 1)
            {

                thongtinnvToolStripMenuItem.Text = "Chào " + FrmMain.mail;
                NhanVienToolStripMenuItem.Visible = true;
                NhanVienToolStripMenuItem.Enabled = true;
                danhMụcToolStripMenuItem.Visible = true;
                danhMụcToolStripMenuItem.Enabled = true;
                LoOutToolStripMenuItem1.Enabled = true;
                thongkeToolStripMenuItem.Visible = true;
                thongkeToolStripMenuItem.Enabled = true;
                ThongKeSPToolStripMenuItem.Visible = true;
                ThongKeSPToolStripMenuItem.Enabled = true;
                ProfileNvToolStripMenuItem.Visible = true;
                đăngNhậpToolStripMenuItem.Enabled = false;
                if (int.Parse(dn.vaitro) == 0)//nêu la vai tro nhan vien
                {
                    VaiTroNV(); //chuc nang nhan vien bình thường
                }
                if (isPasswordDefault)
                {
                    NhanVienToolStripMenuItem.Enabled = false;
                    danhMụcToolStripMenuItem.Enabled = false;
                    ThongKeSPToolStripMenuItem.Enabled = false;
                    thongkeToolStripMenuItem.Enabled = false;
                }
            }
            else
            {
                NhanVienToolStripMenuItem.Visible = false;
                danhMụcToolStripMenuItem.Visible = false;
                LoOutToolStripMenuItem1.Enabled = false;
                ProfileNvToolStripMenuItem.Visible = false;
                ThongKeSPToolStripMenuItem.Visible = false;
                thongkeToolStripMenuItem.Visible = false;
                đăngNhậpToolStripMenuItem.Enabled = true;
                mail = null;
                isPasswordDefault = false;
            }
        }

        void FrmDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            //when child form is closed, this code is executed        
            this.Refresh();
            FrmMain_Load(sender, e);// load form main again
            CheckPassword(sender, e, mail);
        }


        void FrmThongTinNV_FormClosed(object sender, FormClosedEventArgs e)
        {
            //when child form is closed, this code is executed
            this.Refresh();

            FrmMain_Load(sender, e);// load form main again
        }
        private void LoOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            thongtinnvToolStripMenuItem.Text = null;
            session = 0;
            Resetvalue();
            //Properties.Settings.Default.Remember = false;
            //Properties.Settings.Default.Save();
        }
        private void OpenNewForm()
        {
            Application.Run(new frmHang());
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hướngDẫnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
