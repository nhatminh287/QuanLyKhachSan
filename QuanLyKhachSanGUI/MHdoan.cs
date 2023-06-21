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
    public partial class MHdoan : Form
    {
        public MHdoan()
        {
            InitializeComponent();
            ShowListView();

        }
        private void ShowListView()
        {
            List<DoanDTO> dsDoanGUI = Doan.laydanhsachDoan();
            listView1.Items.Clear();
            foreach (DoanDTO p in dsDoanGUI)
            {
                ListViewItem lvi = new ListViewItem(p.MaDoan + "");
                lvi.SubItems.Add(p.TenDoan + "");
                lvi.SubItems.Add(p.NguoiDangKy + "");
                lvi.SubItems.Add(p.SoNguoi + "");

                listView1.Items.Add(lvi);
            }
        }
        private void PopulateMakhComboBox1()
        {
            // Clear the existing items in the ComboBox
            comboBox1.Items.Clear();

            List<KhachHangDTO> dskh = KhachHang.laydanhsachkhachhang();

            // Add the MaNV values to the ComboBox
            foreach (KhachHangDTO k in dskh)
            {
                comboBox1.Items.Add(k.MaKH);
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedRow = listView1.SelectedItems[0];
                // Access the selected row's data and perform the desired actions
                string madoan = selectedRow.SubItems[0].Text;
                string tendoan = selectedRow.SubItems[1].Text;
                string ndk = selectedRow.SubItems[2].Text;
                string songuoi = selectedRow.SubItems[3].Text;
            

                textBox1.Text = madoan;
                textBox2.Text = tendoan;
                comboBox1.Text = ndk;
                
                textBox4.Text = songuoi;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || textBox2.Text == "" || textBox1.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin trước khi thêm đoàn!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DoanDTO p = new DoanDTO();

                p.TenDoan = textBox2.Text;
                p.NguoiDangKy = int.Parse(comboBox1.Text);
                p.SoNguoi = int.Parse(textBox4.Text);

                bool kq = Doan.Themdoan(p);
                if (kq)
                    MessageBox.Show("Thêm thành công!");
                ShowListView();

            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Retrieve the selected NhanVien object based on the selected MaNV
            string selectedMaKH = comboBox1.SelectedItem.ToString();

            List<KhachHangDTO> dskh = KhachHang.laydanhsachkhachhang();
            KhachHangDTO selectedKH = dskh.FirstOrDefault(k => k.MaKH == (Convert.ToInt32(selectedMaKH)));


            // Update the TextBox with the selected NhanVien's TenNV
            textBox3.Text = selectedKH.TenKH;
        }
        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            PopulateMakhComboBox1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || textBox2.Text == "" || textBox1.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin trước khi cập nhật!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DoanDTO p = new DoanDTO();
                p.MaDoan = int.Parse(textBox1.Text);
                p.TenDoan = textBox2.Text;
                p.NguoiDangKy = int.Parse(comboBox1.Text);
                p.SoNguoi = int.Parse(textBox4.Text);

                bool kq = Doan.Capnhatdoan(p);
                if (kq)
                    MessageBox.Show("Cập nhật thành công!");
                ShowListView();

            }
        }
    }
}
