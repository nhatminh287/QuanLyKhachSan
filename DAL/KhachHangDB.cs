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
    public class KhachHangDB : DataaccessDAL
    {
        public static bool Themkhachhang(KhachHangDTO kh)
        {

            DataaccessDAL.Moketnoi();

            SqlCommand command = new SqlCommand();

            command.CommandType = System.Data.CommandType.Text;
            if (kh.MaDoan == 0)
            {
                command.CommandText = "insert into KhachHang(TenKH, DiaChi, SoDienThoai, SoFax, Email, MaDoan) Values(@ten, @dc, @sdt, @sofax, @email, null)";
            }    
            else
            {
                command.CommandText = "insert into KhachHang(TenKH, DiaChi, SoDienThoai, SoFax, Email, MaDoan) Values(@ten, @dc, @sdt, @sofax, @email, @madoan)";
            }            

            command.Connection = DataaccessDAL.conec;


            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = kh.TenKH;

            command.Parameters.Add("@dc", SqlDbType.NVarChar).Value = kh.DiaChi;

            command.Parameters.Add("@sdt", SqlDbType.VarChar).Value = kh.SoDienThoai;

            command.Parameters.Add("@email", SqlDbType.VarChar).Value = kh.Email;

            command.Parameters.Add("@madoan", SqlDbType.Int).Value = kh.MaDoan;            

            int kq = command.ExecuteNonQuery();
            DataaccessDAL.Dongketnoi();

            return kq > 0;
        }
        public static List<KhachHangDTO> LaydsKhachHang()
        {
            List<KhachHangDTO> dsKhachHang = new List<KhachHangDTO>();
            Moketnoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select * from KhachHang";
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                int maKhachHang = reader.GetInt32(0);
                string tenkh = reader.GetString(1);
                string diachi = reader.GetString(2);
                string sodienthoai = reader.GetString(3);
                string sofax = reader.GetString(4);
                string email = reader.GetString(5);
                int madoan;
                if (!reader.IsDBNull(6))
                {
                    madoan = reader.GetInt32(6);                   
                }
                else
                {
                    // madoan = 0 khi Khach hang la khach le
                    madoan = 0;
                }

                KhachHangDTO k = new KhachHangDTO();
                k.MaKH = maKhachHang;
                k.TenKH = tenkh;
                k.DiaChi = diachi;
                k.SoDienThoai = sodienthoai;
                k.SoFax = sofax;
                k.Email = email;
                k.MaDoan = madoan;
                dsKhachHang.Add(k);
            }
            reader.Close();
            return dsKhachHang;
        }
        public static string TenKhachHang(int MaNV)
        {
            Moketnoi();

            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select TenKH from KhachHang where MaKH = @id";
            command.Parameters.AddWithValue("@id", MaNV);
            command.Connection = conec;

            SqlDataReader reader = command.ExecuteReader();

            string tenKhachHang = string.Empty;
            if (reader.Read())
            {
                tenKhachHang = reader.GetString(0);
            }

            reader.Close();
            Dongketnoi();

            return tenKhachHang;

        }
        public static bool Capnhatkhachhang(KhachHangDTO d)
        {

            DataaccessDAL.Moketnoi();

            SqlCommand command = new SqlCommand();

            command.CommandType = System.Data.CommandType.Text;
            if (d.MaDoan == 0)
                command.CommandText = "update KhachHang set TenKH = @ten, DiaChi = @dc, SoDienThoai = @sdt, SoFax = @fax, Email = @email, MaDoan = null where MaKH = @makh";
            else
                command.CommandText = "update KhachHang set TenKH = @ten, DiaChi = @dc, SoDienThoai = @sdt, SoFax = @fax, Email = @email, MaDoan = @madoan  where MaKH = @makh";

            command.Connection = DataaccessDAL.conec;
            command.Parameters.Add("@makh", SqlDbType.Int).Value = d.MaKH;

            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = d.TenKH;

            command.Parameters.Add("@dc", SqlDbType.NVarChar).Value = d.DiaChi;

            command.Parameters.Add("@sdt", SqlDbType.VarChar).Value = d.SoDienThoai;
            command.Parameters.Add("@fax", SqlDbType.VarChar).Value = d.SoFax;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = d.Email;
            command.Parameters.Add("@madoan", SqlDbType.Int).Value = d.MaDoan;

            int kq = command.ExecuteNonQuery();
            DataaccessDAL.Dongketnoi();
            return kq > 0;
        }
    }
}
