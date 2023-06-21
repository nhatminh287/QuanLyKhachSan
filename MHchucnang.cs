using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSanGUI
{
    public partial class MHchucnang : Form
    {
        public MHchucnang()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MHdanhsachphong form = new MHdanhsachphong();
            Hide();
            form.ShowDialog();           
            Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MHthongtinkhachhang form = new MHthongtinkhachhang();
            Hide();
            form.ShowDialog();
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MHxemyeucaudatphong form = new MHxemyeucaudatphong();
            Hide();
            form.ShowDialog();
            Show();
        }
    }
}
