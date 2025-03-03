using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QLBanHang;
using DTO_QLBanHang;

namespace GUI_QLBanHang
{
    public partial class frmHang : Form
    {
        BUS_Hang busHang = new BUS_QLBanHang.BUS_Hang();
        string stremail = FrmMain.mail;//nhận email tư FrmMain
        string checkUrlImage;//kiểm tra hinh khi câp nhật
        string fileName;  // ten file
        string newFileName;
        string fileSavePath;//url store image  
        string fileAddress;// url load images
        readonly string saveDirectory = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));

        public frmHang()
        {
            InitializeComponent();
        }
        public frmHang(string email)
        {
            // stremail = email;
        }
        private void FrmHang_Load(object sender, EventArgs e)
        {
            ResetValues();
            LoadGridview_Hang();

        }
        private void BtnThem_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnBoqua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnMo.Enabled = true;
            txtTenhang.Enabled = true;
            txtSoluong.Enabled = true;
            txtDongianhap.Enabled = true;
            txtDongiaban.Enabled = true;
            txtGhichu.Enabled = true;
            txtMahang.Text = null;
            txtTenhang.Text = null;
            txtSoluong.Text = null;
            txtDongianhap.Text = null;
            txtDongiaban.Text = null;
            txtHinh.Text = null;
            pbHinh.Image = null;
            txtGhichu.Text = null;
            txtTenhang.Focus();
        }
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            int maHang = int.Parse(txtMahang.Text);
            if (MessageBox.Show("Bạn có chắc muốn xóa dữ liệu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //do something if YES
                if (busHang.DeleteHang(maHang, stremail))
                {
                    MessageBox.Show("Xóa dữ liệu thành công");
                    File.Delete(saveDirectory + checkUrlImage);
                    ResetValues();
                    LoadGridview_Hang(); // refresh datagridview
                }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
            else
            {
                //do something if NO
                ResetValues();
            }
        }
        private void BtnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnBoqua_Click(object sender, EventArgs e)
        {
            ResetValues();
        }
        private void LoadGridview_Hang()
        {
            dgvhang.DataSource = busHang.getHang();
            dgvhang.Columns[0].HeaderText = "Mã Sản Phẩm";
            dgvhang.Columns[1].HeaderText = "Tên Sản Phẩm";
            dgvhang.Columns[2].HeaderText = "Số Lượng";
            dgvhang.Columns[3].HeaderText = "Đơn Giá Nhập";
            dgvhang.Columns[4].HeaderText = "Đơn Giá Bán";
            dgvhang.Columns[5].HeaderText = "Hình Ảnh";
            dgvhang.Columns[7].Visible = false;

        }
        private void ResetValues()
        {
            txtMahang.Text = null;
            txtTenhang.Text = null;
            txtSoluong.Text = null;
            txtDongianhap.Text = null;
            txtDongiaban.Text = null;
            txtHinh.Text = null;
            pbHinh.Image = null;
            txtGhichu.Text = null;

            txtTenhang.Enabled = false;
            txtSoluong.Enabled = false;
            txtDongianhap.Enabled = false;
            txtDongiaban.Enabled = false;
            txtHinh.Enabled = false;
            txtGhichu.Enabled = false;
            btnMo.Enabled = false;
            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnDong.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            int intSoLuong;
            bool isInt = int.TryParse(txtSoluong.Text.Trim().ToString(), out intSoLuong);//ep kiểu để kiểm tra là số hay chữ
            float floatDonGiaNhap;
            bool isFloatNhap = float.TryParse(txtDongianhap.Text.Trim().ToString(), out floatDonGiaNhap);
            float floatDonGiaBan;
            bool isFloatBan = float.TryParse(txtDongiaban.Text.Trim().ToString(), out floatDonGiaBan);
            if (txtTenhang.Text.Trim().Length == 0)// kiem tra phai nhap data
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenhang.Focus();
                return;
            }
            else if (!isInt || int.Parse(txtSoluong.Text) < 0)// kiem tra so nguyen > 0
            {
                MessageBox.Show("Bạn phải nhập số lượng sản phẩm >= 0, số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoluong.Focus();
                return;
            }
            else if (!isFloatNhap || float.Parse(txtDongianhap.Text) <= 0)// kiem tra so > 0
            {
                MessageBox.Show("Bạn phải nhập đơn giá nhập > 0, số thực", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDongianhap.Focus();
                return;
            }
            else if (!isFloatBan || float.Parse(txtDongiaban.Text) <= 0)// kiem tra so > 0
            {
                MessageBox.Show("Bạn phải nhập đơn giá bán > 0, số thực", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDongiaban.Focus();
                return;
            }
            else if (float.Parse(txtDongiaban.Text) < float.Parse(txtDongianhap.Text))// kiem tra don gia ban lon hon don gia nhap
            {
                MessageBox.Show("Bạn phải nhập đơn giá bán lớn hơn hoặc bằng đơn giá nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDongiaban.Focus();
                return;
            }
            else if (txtHinh.Text.Trim().Length == 0)// kiem tra phai nhap hinh
            {
                MessageBox.Show("Bạn phải upload hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnMo.Focus();
                return;
            }
            else
            {
                DTO_Hang h = new DTO_Hang(txtTenhang.Text, int.Parse(txtSoluong.Text), float.Parse(txtDongianhap.Text),
                    float.Parse(txtDongiaban.Text), "\\Images\\" + newFileName, txtGhichu.Text, stremail);
                if (busHang.InsertHang(h))
                {
                    MessageBox.Show("Thêm sản phẩm thành công");
                    File.Copy(fileAddress, fileSavePath, true);// copy file hinh vao ung dung
                    ResetValues();
                    LoadGridview_Hang(); // refresh datagridview
                }
                else
                {
                    MessageBox.Show("Thêm sản phẩm không thành công");
                }

            }
        }
        private void BtnMo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                fileAddress = dlgOpen.FileName;
                pbHinh.Image = Image.FromFile(fileAddress);
                fileName = Path.GetFileName(dlgOpen.FileName);
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(fileAddress);
                string currentTime = String.Format("{0:yyyy-MM-dd_HH-mm-ss}", DateTime.Now);
                string extension = Path.GetExtension(fileAddress);
                newFileName = $"{fileNameWithoutExt}_{currentTime}{extension}";
                fileSavePath = saveDirectory + "\\Images\\" + newFileName;// combine with file name*/
                txtHinh.Text = "\\Images\\" + newFileName;
            }

            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            //openFileDialog.FilterIndex = 2;
            //openFileDialog.Title = "Chọn ảnh minh hoạ cho sản phẩm";
            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    var imagePath = openFileDialog.FileName;
            //    pbHinh.ImageLocation = imagePath;
            //    txtHinh.Text = imagePath;
            //}
        }
        private void Dgvhang_Click(object sender, EventArgs e)
        {
            if (dgvhang.Rows.Count > 1)
            {
                btnMo.Enabled = true;
                btnLuu.Enabled = false;
                txtTenhang.Enabled = true;
                txtSoluong.Enabled = true;
                txtDongianhap.Enabled = true;
                txtDongiaban.Enabled = true;
                txtGhichu.Enabled = true;
                txtTenhang.Focus();
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtMahang.Text = dgvhang.CurrentRow.Cells["MaHang"].Value.ToString();
                txtTenhang.Text = dgvhang.CurrentRow.Cells["TenHang"].Value.ToString();
                txtSoluong.Text = dgvhang.CurrentRow.Cells["SoLuong"].Value.ToString();
                txtDongianhap.Text = dgvhang.CurrentRow.Cells["DonGiaNhap"].Value.ToString();
                txtDongiaban.Text = dgvhang.CurrentRow.Cells["DonGiaBan"].Value.ToString();
                txtHinh.Text = dgvhang.CurrentRow.Cells["HinhAnh"].Value.ToString();
                checkUrlImage = txtHinh.Text;//giữ đường dẫn file hình
                //pbHinh.Image = Image.FromFile(saveDirectory + dgvhang.CurrentRow.Cells["HinhAnh"].Value.ToString());
                using (Image temp = Image.FromFile(saveDirectory + dgvhang.CurrentRow.Cells["HinhAnh"].Value.ToString()))
                {
                    pbHinh.Image = new Bitmap(temp);
                }
                //pbHinh.ImageLocation = dgvhang.CurrentRow.Cells["HinhAnh"].Value.ToString();
                txtGhichu.Text = dgvhang.CurrentRow.Cells["GhiChu"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Bảng không tồn tại dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BtnSua_Click(object sender, EventArgs e)
        {
            int intSoLuong;
            bool isInt = int.TryParse(txtSoluong.Text.Trim().ToString(), out intSoLuong);
            float floatDonGiaNhap;
            bool isFloatNhap = float.TryParse(txtDongianhap.Text.Trim().ToString(), out floatDonGiaNhap);
            float floatDonGiaBan;
            bool isFloatBan = float.TryParse(txtDongiaban.Text.Trim().ToString(), out floatDonGiaBan);
            if (txtTenhang.Text.Trim().Length == 0)// kiem tra phai nhap data
            {
                MessageBox.Show("Bạn phải nhập tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTenhang.Focus();
                return;
            }
            else if (!isInt || int.Parse(txtSoluong.Text) < 0)// kiem tra so nguyen > 0
            {
                MessageBox.Show("Bạn phải nhập số lượng sản phẩm >= 0, số nguyên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSoluong.Focus();
                return;
            }
            else if (!isFloatNhap || float.Parse(txtDongianhap.Text) <= 0)// kiem tra so > 0
            {
                MessageBox.Show("Bạn phải nhập đơn giá nhập > 0, số thực", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDongianhap.Focus();
                return;
            }
            else if (!isFloatBan || float.Parse(txtDongiaban.Text) <= 0)// kiem tra so > 0
            {
                MessageBox.Show("Bạn phải nhập đơn giá bán > 0, số thực", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDongiaban.Focus();
                return;
            }
            else if (float.Parse(txtDongiaban.Text) < float.Parse(txtDongianhap.Text))// kiem tra don gia ban lon hon don gia nhap
            {
                MessageBox.Show("Bạn phải nhập đơn giá bán lớn hơn hoặc bằng đơn giá nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDongiaban.Focus();
                return;
            }
            else if (txtHinh.Text.Trim().Length == 0)// kiem tra phai nhap hinh
            {
                MessageBox.Show("Bạn phải upload hình", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnMo.Focus();
                return;
            }
            else
            {
                DTO_Hang h = new DTO_Hang(int.Parse(txtMahang.Text), txtTenhang.Text, int.Parse(txtSoluong.Text),
                    float.Parse(txtDongianhap.Text),
                    float.Parse(txtDongiaban.Text), txtHinh.Text, txtGhichu.Text, stremail);
                if (MessageBox.Show("Bạn có chắc muốn chỉnh sửa?", "Xác nhận", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busHang.UpdateHang(h))
                    {
                        if (txtHinh.Text != checkUrlImage)//nêu có thay doi hình
                        {
                            File.Copy(fileAddress, fileSavePath, true);// copy file hinh vao ung dung
                            File.Delete(saveDirectory + checkUrlImage);
                        }
                        MessageBox.Show("Sửa thành công");
                        ResetValues();
                        LoadGridview_Hang(); // refresh datagridview
                    }
                    else
                    {
                        MessageBox.Show("Sửa không thành công");
                    }
                }
                else
                {
                    ResetValues();
                }
            }
        }
        private void BtnTimkiem_Click(object sender, EventArgs e)
        {
            string tenHang = txttimKiem.Text;
            DataTable ds = busHang.SearchHang(tenHang);
            if (ds.Rows.Count > 0)
            {
                dgvhang.DataSource = ds;
                dgvhang.Columns[0].HeaderText = "Mã Sản Phẩm";
                dgvhang.Columns[1].HeaderText = "Tên Sản Phẩm";
                dgvhang.Columns[2].HeaderText = "Số Lượng";
                dgvhang.Columns[3].HeaderText = "Đơn Giá Nhập";
                dgvhang.Columns[4].HeaderText = "Đơn Giá Bán";
            }
            else
            {
                MessageBox.Show("Không tìm thấy sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txttimKiem.Text = "Nhập tên sản phẩm";
            txttimKiem.BackColor = Color.LightGray;
            ResetValues();
        }
        private void TxttimKiem_Click(object sender, EventArgs e)
        {
            txttimKiem.Text = null;
            txttimKiem.BackColor = Color.White;
        }
        private void BtnDanhsach_Click(object sender, EventArgs e)
        {
            LoadGridview_Hang();
        }
    }
}
