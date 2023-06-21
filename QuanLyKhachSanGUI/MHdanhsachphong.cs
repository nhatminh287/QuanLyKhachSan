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
    public partial class MHdanhsachphong : Form
    {
        public MHdanhsachphong()
        {
            InitializeComponent();                        

        }
        public void MHdanhsachphong_Load(object sender, EventArgs e)
        {
            List<PhongDTO> dsphongGUI = Phong.laydanhsachphong();
            listView1.Items.Clear();
            foreach (PhongDTO p in dsphongGUI)
            {
                ListViewItem lvi = new ListViewItem(p.MaPhong + "");
                lvi.SubItems.Add(p.GiaPhong + "");
                lvi.SubItems.Add(p.SoNguoiO + "");
                lvi.SubItems.Add(p.LoaiPhong + "");
                lvi.SubItems.Add(p.TinhTrang + "");
                listView1.Items.Add(lvi);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedRow = listView1.SelectedItems[0];
                // Access the selected row's data and perform the desired actions
                string maPhong = selectedRow.SubItems[0].Text;
                string giaPhong = selectedRow.SubItems[1].Text;
                string soNguoiO = selectedRow.SubItems[2].Text;
                string loaiPhong = selectedRow.SubItems[3].Text;
                string tinhTrang = selectedRow.SubItems[4].Text;

                textBox1.Text = maPhong;
                textBox2.Text = giaPhong;
                textBox3.Text = soNguoiO;
                textBox4.Text = loaiPhong;
                textBox5.Text = tinhTrang;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Hãy chọn phòng trước khi đặt phòng!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                string maPhong = textBox1.Text;

                MHdatphong yeuCauDatPhongForm = new MHdatphong(maPhong);
                Hide();
                yeuCauDatPhongForm.ShowDialog(); // Show the YeuCauDatPhong form as a modal dialog
                Show();
            }
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Hãy nhập thông tin trước khi thêm phòng phòng!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                PhongDTO p = new PhongDTO();

                p.GiaPhong = int.Parse(textBox2.Text);
                p.SoNguoiO = int.Parse(textBox3.Text);
                p.LoaiPhong = int.Parse(textBox4.Text);
                p.TinhTrang = int.Parse(textBox5.Text);

                bool kq = Phong.Themphong(p);
                if (kq)
                    MessageBox.Show("Thêm thành công!");
                MHdanhsachphong_Load(this, EventArgs.Empty);
            }
        }
    }
    
}
