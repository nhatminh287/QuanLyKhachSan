using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class Phong 
    {        
        public static List<PhongDTO> laydanhsachphong()
        {
            return PhongDB.LaydsPhong();
        }
        public static bool Themphong(PhongDTO p)

        {
            return PhongDB.Themphong(p);
        }
    }
}
