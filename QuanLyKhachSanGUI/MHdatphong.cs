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

namespace QuanLyKhachSanGUI
{
    public partial class MHdatphong : Form
    {
        private string maPhongValue;
        public MHdatphong(string maPhong)
        {
            InitializeComponent();
            maPhongValue = maPhong;
            
        }
        private void PopulateManvComboBox1()
        {
            // Clear the existing items in the ComboBox
            comboBox1.Items.Clear();
            
            List<NhanVienDTO> dsnv = NhanVien.laydanhsachnv();        
            
            // Add the MaNV values to the ComboBox
            foreach (NhanVienDTO nhanVien in dsnv)
            {
                comboBox1.Items.Add(nhanVien.MaNV);
            }
        }
        private void PopulateMakhComboBox2()
        {
            // Clear the existing items in the ComboBox
            comboBox2.Items.Clear();
            
            List<KhachHangDTO> dskh = KhachHang.laydanhsachkhachhang();

            // Add the MaNV values to the ComboBox
            foreach (KhachHangDTO k in dskh)
            {
                comboBox2.Items.Add(k.MaKH);
            }
        }
        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            PopulateManvComboBox1();
        }
        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            PopulateMakhComboBox2();
        }
        private void MHdatphong_Load(object sender, EventArgs e)
        {
            // Use the maPhongValue in the YeuCauDatPhong form
            textBox4.Text = maPhongValue;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Retrieve the selected NhanVien object based on the selected MaNV
            string selectedMaNV = comboBox1.SelectedItem.ToString();
            
            List<NhanVienDTO> dsnv = NhanVien.laydanhsachnv();
            NhanVienDTO selectedNhanVien = dsnv.FirstOrDefault(nvi => nvi.MaNV == (Convert.ToInt32(selectedMaNV)));
            

            // Update the TextBox with the selected NhanVien's TenNV
            textBox2.Text = selectedNhanVien.TenNV;
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Retrieve the selected NhanVien object based on the selected MaNV
            string selectedMaKH = comboBox2.SelectedItem.ToString();
            
            List<KhachHangDTO> dskh = KhachHang.laydanhsachkhachhang();
            KhachHangDTO selectedKH = dskh.FirstOrDefault(k => k.MaKH == (Convert.ToInt32(selectedMaKH)));


            // Update the TextBox with the selected NhanVien's TenNV
            textBox1.Text = selectedKH.TenKH;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || textBox5.Text == "" || textBox3.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin đặt phòng!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                YeuCauDatPhongDTO y = new YeuCauDatPhongDTO();
                //DateTime selectedDate = dateTimePicker1.Value;
                //MessageBox.Show(selectedDate.ToString("yyyy-MM-dd"));

                y.NgayDen = dateTimePicker1.Text;

                y.SoDemLuTru = int.Parse(textBox5.Text);

                y.Phong = int.Parse(textBox4.Text);

                y.YeuCauDacBiet = textBox3.Text;
                y.MaKH = int.Parse(comboBox2.Text);
                y.NhanVienTiepNhan = int.Parse(comboBox1.Text);

                bool kq = YeuCauDatPhong.Themyeucaudatphong(y);
                if (kq)
                    MessageBox.Show("Thêm thành công!");
            }
        }
    }
}
