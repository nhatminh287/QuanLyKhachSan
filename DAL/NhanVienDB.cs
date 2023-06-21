using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class NhanVienDB : DataaccessDAL
    {
        public static List<NhanVienDTO> LaydsNhanvien()
        {
            List<NhanVienDTO> dsnv = new List<NhanVienDTO>();
            Moketnoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select * from NhanVien";
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int manv = reader.GetInt32(0);
                string tennv = reader.GetString(1);
                string bophan = reader.GetString(2);

                NhanVienDTO n = new NhanVienDTO();
                n.MaNV = manv;
                n.TenNV = tennv;
                n.BoPhan = bophan;
                dsnv.Add(n);
            }
            reader.Close();
            return dsnv;
        }
    }
}
