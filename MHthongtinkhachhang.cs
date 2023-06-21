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
    public partial class MHthongtinkhachhang : Form
    {
        public MHthongtinkhachhang()
        {
            InitializeComponent();
            ShowListView();
        }
        private void ShowListView()
        {
            List<KhachHangDTO> dsKhachHangGUI = KhachHang.laydanhsachkhachhang();
            listView1.Items.Clear();
            foreach (KhachHangDTO p in dsKhachHangGUI)
            {
                ListViewItem lvi = new ListViewItem(p.MaKH + "");
                lvi.SubItems.Add(p.TenKH + "");
                lvi.SubItems.Add(p.DiaChi + "");
                lvi.SubItems.Add(p.SoDienThoai + "");
                lvi.SubItems.Add(p.SoFax + "");
                lvi.SubItems.Add(p.Email + "");
                lvi.SubItems.Add(p.MaDoan + "");
                listView1.Items.Add(lvi);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedRow = listView1.SelectedItems[0];
                // Access the selected row's data and perform the desired actions
                string maKH = selectedRow.SubItems[0].Text;
                string tenKH = selectedRow.SubItems[1].Text;
                string diachi= selectedRow.SubItems[2].Text;
                string sodt = selectedRow.SubItems[3].Text;
                string sofax = selectedRow.SubItems[4].Text;
                string email = selectedRow.SubItems[5].Text;
                string madoan = selectedRow.SubItems[6].Text;

                textBox1.Text = maKH;
                textBox2.Text = tenKH;
                textBox3.Text = diachi;
                textBox4.Text = sodt;
                textBox5.Text = sofax;
                textBox6.Text = email;
                comboBox1.Text = madoan;
            }
        }
        private void PopulateMadoanComboBox1()
        {
            // Clear the existing items in the ComboBox
            comboBox1.Items.Clear();
            comboBox1.Items.Add(0);
            
            List<DoanDTO> dsd = Doan.laydanhsachDoan();

            // Add the MaNV values to the ComboBox
            foreach (DoanDTO d in dsd)
            {
                comboBox1.Items.Add(d.MaDoan);
            }
        }
        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            PopulateMadoanComboBox1();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MHdoan form = new MHdoan();
            Hide();
            form.ShowDialog();
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || textBox2.Text == ""|| textBox3.Text == ""|| textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin trước khi thêm khách hàng!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                KhachHangDTO p = new KhachHangDTO();

                p.TenKH = textBox2.Text;
                p.DiaChi = textBox3.Text;
                p.SoDienThoai = textBox4.Text;
                p.SoFax = textBox5.Text;
                p.Email = textBox6.Text;
                p.MaDoan = int.Parse(comboBox1.Text);

                bool kq = KhachHang.Themkhachhang(p);
                if (kq)
                    MessageBox.Show("Thêm thành công!");
                ShowListView();

            }
        }
    }
}
