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
    public class YeuCauDatPhongDB : DataaccessDAL
    {
        public static bool Themyeucaudatphong(YeuCauDatPhongDTO yc)
        {

            DataaccessDAL.Moketnoi();

            SqlCommand command = new SqlCommand();

            command.CommandType = System.Data.CommandType.Text;

            command.CommandText = "insert into YeuCauDatPhong(NgayDen, SoDemLuuTru, Phong, YeuCauDacBiet, MaKH, NhanvienTiepNhan) Values(@ngay, @sodem, @phong, @ycdb, @makh, @nv)";

            command.Connection = DataaccessDAL.conec;


            command.Parameters.Add("@ngay", SqlDbType.Date).Value = yc.NgayDen;

            command.Parameters.Add("@sodem", SqlDbType.Int).Value = yc.SoDemLuTru;

            command.Parameters.Add("@phong", SqlDbType.Int).Value = yc.Phong;

            command.Parameters.Add("@ycdb", SqlDbType.NVarChar).Value = yc.YeuCauDacBiet;

            command.Parameters.Add("@makh", SqlDbType.Int).Value = yc.MaKH;

            command.Parameters.Add("@nv", SqlDbType.Int).Value = yc.NhanVienTiepNhan;

            int kq = command.ExecuteNonQuery();

            return kq > 0;
        }

        public static List<YeuCauDatPhongDTO> LaydsYeuCauDatPhong()
        {
            List<YeuCauDatPhongDTO> dsYeuCauDatPhong = new List<YeuCauDatPhongDTO>();
            Moketnoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select * from YeuCauDatPhong where TinhTrang = 0";
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int id= reader.GetInt32(0);
                DateTime nd = reader.GetDateTime(1);
                int sd = reader.GetInt32(2);
                int p = reader.GetInt32(3);
                string y = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);

                int makh = reader.GetInt32(5);
                int nv = reader.GetInt32(6);
                YeuCauDatPhongDTO yc = new YeuCauDatPhongDTO();
                yc.ID = id;
                yc.NgayDen = nd.ToString();
                yc.SoDemLuTru = sd;
                yc.Phong = p;
                yc.YeuCauDacBiet = y;
                yc.MaKH = makh;
                yc.NhanVienTiepNhan = nv;
                dsYeuCauDatPhong.Add(yc);
            }
            reader.Close();
            Dongketnoi();
            return dsYeuCauDatPhong;
        }
        public static bool CapNhatTinhTrang(int ID)
        {
            Moketnoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "UPDATE YeuCauDatPhong SET TinhTrang = 1 WHERE ID = @id";
            command.Connection = conec;
            command.Parameters.Add("@id", SqlDbType.Int).Value = ID;

            int kq = command.ExecuteNonQuery();

            Dongketnoi();

            return kq > 0;
        }
    }
}

