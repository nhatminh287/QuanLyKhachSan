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
                listView1.Items.Add(lvi);
            }
        }

    }
}
