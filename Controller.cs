using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace calculator_1
{
    class Controller
    {
        public string cs;
        public MySqlConnection conn;
        public MySqlConnection sqlCon()
        {
            cs = @"server=localhost;userid=root;password=;database=calculator";
            conn = new MySqlConnection(cs);
            return conn;
   
        }

        public MySqlCommand sqlCmd()
        {
            MySqlCommand cmd = new MySqlCommand();
            return cmd;
        }

        public void sqlNonQuery(string cs)
        {
            Controller ctr = new Controller();
            var cmd = ctr.sqlCmd();
            var conn = ctr.sqlCon();

            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandText = cs;
          //  Console.WriteLine("CMD  : " + cmd.CommandText.ToString());
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public MySqlDataReader sqlQuery( string cs)
        {
            Controller ctr = new Controller();
            var cmd = ctr.sqlCmd();
            var conn = ctr.sqlCon();

            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandText = cs;

            var data = cmd.ExecuteReader();
           // conn.Close();
            return data;
        }

        public MySqlDataAdapter sqlAdt( string cs)
        {
            Controller ctr = new Controller();
            var conn = ctr.sqlCon();
            MySqlDataAdapter da = new MySqlDataAdapter(cs,conn);
            return da;
    
        }

    }
}
