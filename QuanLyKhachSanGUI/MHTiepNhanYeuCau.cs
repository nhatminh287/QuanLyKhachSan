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
using DTO;

namespace QuanLyKhachSanGUI
{
    public partial class MHTiepNhanYeuCau : Form
    {
        private YeuCauDatPhongDTO ycdp;
        public MHTiepNhanYeuCau(YeuCauDatPhongDTO ycdp)
        {

            InitializeComponent();
            this.ycdp = ycdp;
            textBox1.Text = ycdp.ID.ToString();
            textBox2.Text = ycdp.MaKH.ToString();
            textBox3.Text = ycdp.Phong.ToString();
            textBox4.Text = ycdp.SoDemLuTru.ToString();
            textBox5.Text = ycdp.NgayDen.ToString();
            textBox6.Text = BLL.KhachHang.TenKhachHang(ycdp.MaKH);
            textBox7.Text = ycdp.NhanVienTiepNhan.ToString();
            textBox8.Text = BLL.NhanVien.TenNhanVien(ycdp.NhanVienTiepNhan);
            textBox9.Text = ycdp.YeuCauDacBiet.ToString();
            if(BLL.Phong.TinhTrangVeSinh(ycdp.Phong) ==1)
            {
                textBox10.Text = "Đã dọn dẹp";
                button2.Enabled = false;
                button1.Enabled = true;

            }
            else
            {
                textBox10.Text = "Chưa dọn dẹp";
                button2.Enabled = true;
                button1.Enabled = false;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ID = ycdp.ID;
            string MaKH = ycdp.MaKH.ToString();
            string TenKH = BLL.KhachHang.TenKhachHang(ycdp.MaKH);
            string Phong = textBox3.Text = ycdp.Phong.ToString();
            MHDangKiVanChuyen form = new MHDangKiVanChuyen(ID,MaKH,TenKH,Phong);
            Hide();
            form.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(BLL.Phong.DonVeSinhPhong(ycdp.Phong))
            {
                MessageBox.Show("Đã liên hệ nhân viên vệ sinh!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (BLL.Phong.TinhTrangVeSinh(ycdp.Phong) == 1)
                {
                    textBox10.Text = "Đã dọn dẹp";
                    button2.Enabled = false;
                    button1.Enabled = true;

                }
                else
                {
                    textBox10.Text = "Chưa dọn dẹp";
                    button2.Enabled = true;
                    button1.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Có lỗi!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
            
        }
    }
}
