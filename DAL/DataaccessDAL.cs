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
        public static string strconec = @"Data Source=DESKTOP-RR82V1P\MSSQLSERVER01;Initial Catalog=QuanLyKhachSan;User ID=sa;Password=1234";
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
