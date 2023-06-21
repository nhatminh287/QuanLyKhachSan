using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class PhongDB : DataaccessDAL
    {
        public static List<PhongDTO> LaydsPhong()
        {
            List<PhongDTO> dsphong = new List<PhongDTO>();
            Moketnoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select * from Phong";
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int maphong = reader.GetInt32(0);
                int giaphong = reader.GetInt32(1);
                int songuoio = reader.GetInt32(2);
                int loaiphong = reader.GetInt32(3);
                int tinhtrang = reader.GetInt32(4);
                PhongDTO p = new PhongDTO();
                p.MaPhong = maphong;
                p.GiaPhong = giaphong;
                p.SoNguoiO = songuoio;
                p.LoaiPhong = loaiphong;
                p.TinhTrang = tinhtrang;
                dsphong.Add(p);
            }
            reader.Close();
            Dongketnoi();
            return dsphong;
        }
        public static bool Themphong(PhongDTO p)
        {

            DataaccessDAL.Moketnoi();

            SqlCommand command = new SqlCommand();

            command.CommandType = System.Data.CommandType.Text;

            command.CommandText = "insert into Phong(GiaPhong, SoNguoiO, LoaiPhong, TinhTrang)  Values(@gia, @songuoi, @loaiphong, @tt)";

            command.Connection = DataaccessDAL.conec;


            command.Parameters.Add("@gia", SqlDbType.Int).Value = p.GiaPhong;

            command.Parameters.Add("@songuoi", SqlDbType.Int).Value = p.SoNguoiO;

            command.Parameters.Add("@loaiphong", SqlDbType.Int).Value = p.LoaiPhong;

            command.Parameters.Add("@tt", SqlDbType.Int).Value = p.TinhTrang;

            

            int kq = command.ExecuteNonQuery();
            Dongketnoi();
            return kq > 0;
        }
    }
}
