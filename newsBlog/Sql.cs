using News;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace News
{
    public static class sql
    {
        public static DataTable Exec(string srg)
        {
            string constring = @"Data Source=TEYMUROV\SQLEXPRESS; 
                                    Initial Catalog=Ders; Integrated Security=True";
            SqlConnection sqlcon = new SqlConnection(constring);
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(srg, sqlcon);
            SqlDataAdapter sda = new SqlDataAdapter(sqlcom);
            DataTable dt = new DataTable();
            int v = sda.Fill(dt);
            sqlcon.Close();
            return dt;
        }
    }

}
