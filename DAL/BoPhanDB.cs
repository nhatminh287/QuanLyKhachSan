using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class BoPhanDB:DataaccessDAL
    {
        public static List<BoPhanDTO> LaydsBoPhan()
        {
            List<BoPhanDTO> dsbp = new List<BoPhanDTO>();
            Moketnoi();
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select * from BoPhan";
            command.Connection = conec;
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string id = reader.GetString(0);
                string tenbp = reader.GetString(1);

                BoPhanDTO n = new BoPhanDTO();
                n.ID = id;
                n.TenBoPhan = tenbp;
                dsbp.Add(n);
            }
            reader.Close();
            return dsbp;
        }
    }
}

