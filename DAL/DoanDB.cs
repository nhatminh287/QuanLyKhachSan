using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class DoanDB : DataaccessDAL
    {
        public static List<DoanDTO> LaydsDoan()
        {
            List<DoanDTO> dsd = new List<DoanDTO>();
            Moketnoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select * from Doan";
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int ma = reader.GetInt32(0);
                string td = reader.GetString(1);
                int ndk = reader.GetInt32(2);
                int sn = reader.GetInt32(3);

                DoanDTO n = new DoanDTO();
                n.MaDoan = ma;
                n.TenDoan = td;
                n.NguoiDangKy = ndk;
                n.SoNguoi = sn;
                dsd.Add(n);
            }
            reader.Close();
            Dongketnoi();
            return dsd;
        }
        public static bool Themdoan(DoanDTO d)
        {

            DataaccessDAL.Moketnoi();

            SqlCommand command = new SqlCommand();

            command.CommandType = System.Data.CommandType.Text;

            command.CommandText = "insert into Doan(TenDoan, NguoiDangKy, SoNguoi)  Values(@ten, @ndk, @songuoi)";

            command.Connection = DataaccessDAL.conec;


            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = d.TenDoan;

            command.Parameters.Add("@ndk", SqlDbType.Int).Value = d.NguoiDangKy;

            command.Parameters.Add("@songuoi", SqlDbType.Int).Value = d.SoNguoi;            

            int kq = command.ExecuteNonQuery();
            DataaccessDAL.Dongketnoi();
            return kq > 0;
        }
        public static bool Capnhatdoan(DoanDTO d)
        {

            DataaccessDAL.Moketnoi();

            SqlCommand command = new SqlCommand();

            command.CommandType = System.Data.CommandType.Text;

            command.CommandText = "update Doan set TenDoan = @ten, NguoiDangKy = @ndk, SoNguoi = @songuoi  where MaDoan = @madoan";

            command.Connection = DataaccessDAL.conec;
            command.Parameters.Add("@madoan", SqlDbType.Int).Value = d.MaDoan;

            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = d.TenDoan;

            command.Parameters.Add("@ndk", SqlDbType.Int).Value = d.NguoiDangKy;

            command.Parameters.Add("@songuoi", SqlDbType.Int).Value = d.SoNguoi;

            int kq = command.ExecuteNonQuery();
            DataaccessDAL.Dongketnoi();
            return kq > 0;
        }
    }
}

