using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace QuanLyKhachSanGUI
{
    public partial class MHDangKiVanChuyen : Form
    {
        private int ID;
        private string MaKH;
        private string TenKH;
        private string Phong;
        public MHDangKiVanChuyen(int ID,string MaKH,string TenKH,string Phong)
        {
            InitializeComponent();
            this.MaKH = MaKH;
            this.TenKH = TenKH;
            this.Phong = Phong;
            this.ID = ID;

            textBox1.Text = MaKH;
            textBox2.Text = TenKH;
            textBox3.Text = Phong;
        }
        private void PopulateManvComboBox1()
        {
            // Clear the existing items in the ComboBox
            comboBox1.Items.Clear();

            List<NhanVienDTO> dsnv = NhanVien.LayDanhSachNvVanChuyen();

            // Add the MaNV values to the ComboBox
            foreach (NhanVienDTO nhanVien in dsnv)
            {

                comboBox1.Items.Add("#" + nhanVien.MaNV + " " + NhanVien.TenNhanVien(nhanVien.MaNV));
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            PopulateManvComboBox1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || textBox5.Text == "" || (int)numericUpDown1.Value == 0)
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                VanChuyenHanhLyDTO VanChuyen = new VanChuyenHanhLyDTO();
                VanChuyen.MaKH = int.Parse(MaKH);
                VanChuyen.SoLuong = (int)numericUpDown1.Value;
                VanChuyen.GhiChu = textBox5.Text;
                VanChuyen.MaPhong = int.Parse(Phong);
                VanChuyen.NVVanChuyen = int.Parse(comboBox1.SelectedItem.ToString().Substring(1, comboBox1.SelectedItem.ToString().IndexOf(' ')));
                if( VanChuyenHanhLy.ThemVCHL(VanChuyen) && YeuCauDatPhong.CapNhatTinhTrang(ID) )
                {
                    MessageBox.Show("Đăng kí thành công!");
                    this.Close();
                }    
            }
        }
    }
}
