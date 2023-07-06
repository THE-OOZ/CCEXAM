using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Data;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Exam_Gridview
{
    public class Movie
    {
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public List<string> Genres { get; set; }
    }

    public class Cal
    {
        public string Expression { get; set; }
        public string Operand_1 { get; set; }

    }

    class Controller
    {
        

        public string fileContent;

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

        public MySqlDataReader sqlQuery(string cs)
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

        public MySqlDataAdapter sqlAdt(string cs)
        {
            Controller ctr = new Controller();
            var conn = ctr.sqlCon();
            MySqlDataAdapter da = new MySqlDataAdapter(cs, conn);
            return da;

        }

        public string readFile(string src)
        {
            string fileName;
            string filePath;
            //string fileContent;

            if (src == "LOCAL_FILE")
            {
                fileName = "Lab-Result.txt";                                   // --- debug path --- //
                filePath = Path.Combine(Application.StartupPath, fileName);
                fileContent = File.ReadAllText(filePath);
            }
            else if (src == "SELECT_FILE")
            {
                Stream st;
                OpenFileDialog opf = new OpenFileDialog();

                if (opf.ShowDialog() == DialogResult.OK)
                {

                    if ((st = opf.OpenFile()) != null)
                    {
                        filePath = opf.FileName;
                        fileContent = File.ReadAllText(filePath);
                    }
                }
            }

            return fileContent;
        }

    }
}
