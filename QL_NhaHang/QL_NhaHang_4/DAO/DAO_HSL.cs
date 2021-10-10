﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_HSL
    {
        public DataTable loadHeSoLuong()
        {
            SqlConnection conn = new SqlConnection(SQLDatabase.ConnectionString);
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from HeSoLuong", conn);
                da.Fill(dt);
                return dt;
            }
            catch
            { }
            finally { conn.Close(); }
            return dt;
        }
    }
}
