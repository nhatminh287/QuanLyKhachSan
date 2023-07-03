using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class YeuCauDatPhongDTO
    {
        public int ID { get; set; }
        public string NgayDen { get; set; }
        public int SoDemLuTru { get; set; }
        public int Phong { get; set; }
        public string YeuCauDacBiet { get; set; }
        public int MaKH { get; set; }
        public int NhanVienTiepNhan { get; set; }
        public int TinhTrang { get; set; }
    }
}
