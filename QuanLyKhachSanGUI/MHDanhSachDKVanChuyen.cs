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

namespace QuanLyKhachSanGUI
{
    public partial class MHDanhSachDKVanChuyen : Form
    {
        public MHDanhSachDKVanChuyen()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            List<VanChuyenHanhLyDTO> DSVanChuyenHanhLy = VanChuyenHanhLy.LayDSVanChuyenHanhLy();
            listView1.Items.Clear();
            foreach (VanChuyenHanhLyDTO VanChuyen in DSVanChuyenHanhLy)
            {
                ListViewItem lvi = new ListViewItem(VanChuyen.ID + "");
                lvi.SubItems.Add(KhachHang.TenKhachHang(VanChuyen.MaKH) + "");
                lvi.SubItems.Add(VanChuyen.MaPhong + "");
                lvi.SubItems.Add(VanChuyen.SoLuong + "");
                lvi.SubItems.Add(NhanVien.TenNhanVien(VanChuyen.NVVanChuyen));
                lvi.SubItems.Add(VanChuyen.GhiChu + "");
                lvi.SubItems.Add(VanChuyen.MaKH + "");
                lvi.SubItems.Add(VanChuyen.NVVanChuyen + "");
                listView1.Items.Add(lvi);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedRow = listView1.SelectedItems[0];
                if ((int)numericUpDown1.Value == int.Parse(selectedRow.SubItems[3].Text) &&
                    textBox7.Text == selectedRow.SubItems[5].Text)
                {
                    MessageBox.Show("Không có gì thay đổi!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (numericUpDown1.Value == 0 || textBox7.Text == "")
                {
                    MessageBox.Show("Hãy điền đầy đủ thông tin!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (VanChuyenHanhLy.CapNhatVanChuyen((int)numericUpDown1.Value, textBox7.Text, int.Parse(selectedRow.SubItems[0].Text)))
                {
                    MessageBox.Show("Cập nhật thành công!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    numericUpDown1.Value = 0;
                }
            } 
            else
            {
                MessageBox.Show("Bạn chưa chọn yêu cầu vận chuyển hành lý nào!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedRow = listView1.SelectedItems[0];
                // Access the selected row's data and perform the desired actions
                string ID = selectedRow.SubItems[0].Text;
                string TenKH = selectedRow.SubItems[1].Text;
                string MaPhong = selectedRow.SubItems[2].Text;
                int SoLuong = int.Parse(selectedRow.SubItems[3].Text);
                string TenNV = selectedRow.SubItems[4].Text;
                string GhiChu = selectedRow.SubItems[5].Text;
                string MaKH = selectedRow.SubItems[6].Text;
                string MaNV = selectedRow.SubItems[7].Text;

                textBox1.Text = ID;
                textBox2.Text = TenKH;
                textBox3.Text = MaPhong;
                textBox4.Text = TenNV;
                textBox5.Text = MaKH;
                textBox6.Text = MaNV;
                textBox7.Text = GhiChu;
                numericUpDown1.Value = SoLuong;
                
            }
        }
    }
}
