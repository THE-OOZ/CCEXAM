using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Exam_B
{
    public partial class Login : Form
    {

      
        public Login()
        {
            InitializeComponent();
             
        }

        //internal static string Sha256(string text)
        //{
        //    if (String.IsNullOrEmpty(text))
        //        return String.Empty;

        //    using (var sha = new System.Security.Cryptography.SHA256Managed())
        //    {
        //        byte[] textData = System.Text.Encoding.UTF8.GetBytes(text);
        //        byte[] hash = sha.ComputeHash(textData);
        //        return BitConverter.ToString(hash).Replace("-", String.Empty);
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {

            string cs;
            MySqlConnection conn;
            cs = @"server=localhost;userid=root;password=;database=lab_exam";
            conn = new MySqlConnection(cs);
         
            try
            {

                string qryStr = $"SELECT * FROM tbl_lab_staff " +
                                $"WHERE staff_id = '{tbUserName.Text}' " +
                                $"AND staff_password = '{tbPwd.Text}' ";

                MySqlDataAdapter sda = new MySqlDataAdapter(qryStr, conn);

                DataTable dt = new DataTable();
                sda.Fill(dt);

                
                
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Success!");
                    Main Mainfrom = new Main();
                    Mainfrom.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login Invalid !!","Error", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    tbPwd.Text = "";
                    tbUserName.Text = "";
                }

                conn.Close();
            }
            catch (Exception )
            {
                MessageBox.Show("Can not open connection ! ");
            }



            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbPwd_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
