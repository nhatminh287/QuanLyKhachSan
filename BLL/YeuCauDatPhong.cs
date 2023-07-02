using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class YeuCauDatPhong
    {
        public static bool Themyeucaudatphong(YeuCauDatPhongDTO yc)

        {
            return YeuCauDatPhongDB.Themyeucaudatphong(yc);
        }

        public static List<YeuCauDatPhongDTO> laydsyeucaudatphong()
        {
            return YeuCauDatPhongDB.LaydsYeuCauDatPhong();
        }
        public static bool CapNhatTinhTrang(int ID)
        {
            return YeuCauDatPhongDB.CapNhatTinhTrang(ID);
        }
    }
}
