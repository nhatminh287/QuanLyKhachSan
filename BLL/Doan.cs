using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class Doan
    {      
        public static List<DoanDTO> laydanhsachDoan()
        {
            return DoanDB.LaydsDoan();
        }
        public static bool Themdoan(DoanDTO d)

        {
            return DoanDB.Themdoan(d);
        }
        public static bool Capnhatdoan(DoanDTO d)

        {
            return DoanDB.Capnhatdoan(d);
        }
    }
}
