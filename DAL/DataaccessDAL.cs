using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataaccessDAL
    {
        public static SqlConnection conec = null;
        public static string strconec = @"Data Source=LAPTOP-9UBO3DBS;Initial Catalog=QuanLyKhachSan;User ID=sa;Password=thi2522002";
        public static void Moketnoi()
        {
            if (conec==null)
            {
                conec = new SqlConnection(strconec);
            }
            if (conec.State==ConnectionState.Closed)
            {
                conec.Open();
            }
        }
        public static void Dongketnoi()
        {
            if (conec!=null && conec.State==ConnectionState.Open)
            {
                conec.Close();
            }
        }
    }
}
