using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class KhachHang
    {        
        public static List<KhachHangDTO> laydanhsachkhachhang()
        {
            return KhachHangDB.LaydsKhachHang();
        }
        public static bool Themkhachhang(KhachHangDTO kh)

        {
            return KhachHangDB.Themkhachhang(kh);
        }
        public static string TenKhachHang(int MaKH)
        {
            return KhachHangDB.TenKhachHang(MaKH);
        }
    }
}
