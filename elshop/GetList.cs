using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace elshop
{
    static class GetData
    {
        static SqlConnection con;
        static SqlDataAdapter da;
        static SqlCommand cmd;
        static DataSet ds;
        public static DataSet GetDataList(String query, String table)
        {
            con = new SqlConnection(@"Data Source=LAPTOP-R7H40FQK\BIZARRO;Initial Catalog=ElectroShop;Integrated Security=True");
            da = new SqlDataAdapter(query, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, table);
            con.Close();
            return ds;
        }
    }
}
