using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;


namespace BLL
{
    public class VanChuyenHanhLy
    {
        public static List<VanChuyenHanhLyDTO> LayDSVanChuyenHanhLy()
        {
            return VanChuyenHanhLyDB.LayDSVanChuyenHanhLy();
        }
        public static bool CapNhatVanChuyen(int SoLuong,string GhiChu,int ID)
        {
            return VanChuyenHanhLyDB.CapNhatVanChuyen(SoLuong, GhiChu, ID);
        }
        public static bool ThemVCHL(VanChuyenHanhLyDTO VanChuyen)
        {
            return VanChuyenHanhLyDB.ThemVCHL(VanChuyen);
        }
    }
}
