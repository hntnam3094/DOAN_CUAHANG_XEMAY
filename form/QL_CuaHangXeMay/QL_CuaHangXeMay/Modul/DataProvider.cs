using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QL_CuaHangXeMay.Modul
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }


        public string strcn = @"Data Source=" + Connection.sever + ";Initial Catalog=" + Connection.databasename + ";User ID=" + Connection.sa + "; Password=" + Connection.pass + "";

        //public string strcn = "Data Source=.\\sqlexpress ;Initial Catalog=QL_CuaHangXe;User ID=sa; Password=123";
        public DataTable ExecuteQury(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection cn = new SqlConnection(strcn))
            {

                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                cn.Close();
            }
            return dt;
        }



        public int ExecuteNonQuery(string query)
        {
            int dt = 0;
            using (SqlConnection cn = new SqlConnection(strcn))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                dt = cmd.ExecuteNonQuery();
                cn.Close();
            }
            return dt;
        }

        public object ExecuteScalar(string query)
        {
            object dt = 0;
            using (SqlConnection cn = new SqlConnection(strcn))
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand(query, cn);
                dt = cmd.ExecuteScalar();
                cn.Close();
            }
            return dt;
        }



    }


}
