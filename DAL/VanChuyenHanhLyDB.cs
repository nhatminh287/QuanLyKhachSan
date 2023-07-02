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
    public class VanChuyenHanhLyDB:DataaccessDAL
    {
        public static List<VanChuyenHanhLyDTO> LayDSVanChuyenHanhLy()
        {
            List<VanChuyenHanhLyDTO> DSVanChuyenHanhLy = new List<VanChuyenHanhLyDTO>();
            Moketnoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select * from VanChuyenHanhLy";
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int ID = reader.GetInt32(0);
                int SoLuong = reader.GetInt32(1);
                string GhiChu = reader.GetString(2);
                int MaKH = reader.GetInt32(3);
                int MaPhong = reader.GetInt32(4);
                int NVVanChuyen = reader.GetInt32(5);


                VanChuyenHanhLyDTO VanChuyen = new VanChuyenHanhLyDTO();
                VanChuyen.ID= ID;
                VanChuyen.SoLuong= SoLuong;
                VanChuyen.GhiChu= GhiChu;
                VanChuyen.MaKH= MaKH;
                VanChuyen.MaPhong= MaPhong;
                VanChuyen.NVVanChuyen = NVVanChuyen;
                DSVanChuyenHanhLy.Add(VanChuyen);
            }
            reader.Close();
            Dongketnoi();
            return DSVanChuyenHanhLy;
        }

        public static bool CapNhatVanChuyen(int SoLuong, string GhiChu, int ID)
        {
            Moketnoi();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "UPDATE VanChuyenHanhLy SET SoLuong = @SoLuong, GhiChu = @GhiChu WHERE ID = @ID";
            command.Connection = conec;

            command.Parameters.Add("@SoLuong", SqlDbType.Int).Value = SoLuong;
            command.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value = GhiChu;
            command.Parameters.Add("@ID", SqlDbType.Int).Value = ID;

            int kq = command.ExecuteNonQuery();
            Dongketnoi();
            return kq > 0;
        }
        public static bool ThemVCHL(VanChuyenHanhLyDTO VanChuyen)
        {
            Moketnoi();

            SqlCommand command = new SqlCommand();

            command.CommandType = System.Data.CommandType.Text;

            command.CommandText = "insert into VanChuyenHanhLy(SoLuong, GhiChu, MaKH, MaPhong, NVVanChuyen) Values(@SoLuong, @GhiChu, @MaKH, @MaPhong, @NVVanChuyen)";

            command.Connection = conec;


            command.Parameters.Add("@SoLuong", SqlDbType.Int).Value = VanChuyen.SoLuong;

            command.Parameters.Add("@GhiChu", SqlDbType.NVarChar).Value =VanChuyen.GhiChu;

            command.Parameters.Add("@MaKH", SqlDbType.Int).Value = VanChuyen.MaKH;

            command.Parameters.Add("@MaPhong", SqlDbType.Int).Value = VanChuyen.MaPhong;

            command.Parameters.Add("@NVVanChuyen", SqlDbType.Int).Value = VanChuyen.NVVanChuyen;

            int kq = command.ExecuteNonQuery();
            Dongketnoi();
            return kq > 0;
        }
    }
}
