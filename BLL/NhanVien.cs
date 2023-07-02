using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class NhanVien
    {        
        public static List<NhanVienDTO> laydanhsachnv()
        {
            return NhanVienDB.LaydsNhanvien();
        }
        public static List<NhanVienDTO> LayDanhSachNvVanChuyen()
        {
            return NhanVienDB.LayDanhSachNvVanChuyen();
        }
        public static string TenNhanVien(int MaNV)
        {
            return NhanVienDB.TenNhanVien(MaNV);
        }
    }
}
