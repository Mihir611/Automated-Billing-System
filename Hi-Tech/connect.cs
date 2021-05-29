using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Hi_Tech
{
    class connect
    {
        public SqlCommand cmd = new SqlCommand();
        public SqlConnection cnn = new SqlConnection();
        public connect()
        {
            cnn.ConnectionString = @"Data Source=MIHIR-PC;Initial Catalog=HI_TECH;Integrated Security=True";
            cnn.Open();
            cmd.Connection = cnn;
        }
    }
}