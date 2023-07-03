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
    public partial class MHxemyeucaudatphong : Form
    {
        public MHxemyeucaudatphong()
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            List<YeuCauDatPhongDTO> dsyeucaudatphong = YeuCauDatPhong.laydsyeucaudatphong();
            listView1.Items.Clear();
            foreach (YeuCauDatPhongDTO p in dsyeucaudatphong)
            {
                ListViewItem lvi = new ListViewItem(p.ID + "");
                lvi.SubItems.Add(p.NgayDen + "");
                lvi.SubItems.Add(p.SoDemLuTru + "");
                lvi.SubItems.Add(p.Phong + "");
                lvi.SubItems.Add(p.YeuCauDacBiet + "");
                lvi.SubItems.Add(p.MaKH + "");
                lvi.SubItems.Add(p.NhanVienTiepNhan + "");
                if(p.TinhTrang == 1)
                {
                    lvi.SubItems.Add("Đã hoàn tất");
                }
                else
                {
                    lvi.SubItems.Add("Chưa hoàn tất");
                }
                listView1.Items.Add(lvi);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count ==1 && listView1.SelectedItems[0].SubItems[7].Text == "Chưa hoàn tất")
            {
                ListViewItem selectedRow = listView1.SelectedItems[0];
                YeuCauDatPhongDTO ycdp = new YeuCauDatPhongDTO();
                ycdp.ID = int.Parse(selectedRow.SubItems[0].Text);
                ycdp.NgayDen = selectedRow.SubItems[1].Text;
                ycdp.SoDemLuTru = int.Parse(selectedRow.SubItems[2].Text);
                ycdp.Phong = int.Parse(selectedRow.SubItems[3].Text);
                ycdp.YeuCauDacBiet = selectedRow.SubItems[4].Text;
                ycdp.MaKH = int.Parse(selectedRow.SubItems[5].Text);
                ycdp.NhanVienTiepNhan = int.Parse(selectedRow.SubItems[6].Text);
                MHTiepNhanYeuCau form = new MHTiepNhanYeuCau(ycdp);
                Hide();
                form.ShowDialog();
                Show();
                LoadData();
            }    
            else if(listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Hãy chọn một yêu cầu đặt phòng!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Yêu cầu này đã hoàn tất. Hãy chọn yêu cầu khác!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
