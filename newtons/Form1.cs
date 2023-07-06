using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Globalization;
using System.IO;
using System.Collections;
using Dapper;

namespace Exam_Gridview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

           
        }

        //private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    MessageBox.Show(dataGridView1.SelectedRows.ToString());
        //}

        private void button_qry_Click(object sender, EventArgs e)
        {
            Controller ctr = new Controller();

            var conn = ctr.sqlCon();
            var cmd = ctr.sqlCmd();
            conn.Open();
            //var da = ctr.sqlAdt("SELECT * FROM `tbl_history`");

            //DataTable dt = new DataTable();

            //da.Fill(dt);

            //dataGridView1.DataSource = dt;
            //conn.Close();

            var sql = "SELECT * FROM `tbl_history`";

            // Dapper 
            var history = conn.Query<Cal>(sql).ToList();

            

            MessageBox.Show($"{ history[1].Expression} ---- {history[1].Operand_1}");

            foreach (var data in history)
            {
                Console.WriteLine(data.Expression + "====" + data.Operand_1);
            }



        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0) {
                MessageBox.Show(dataGridView1.SelectedRows[0].Index.ToString());
                
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                MessageBox.Show(row.Cells[e.ColumnIndex].Value.ToString());

            }
        }

        private void button_upload_Click(object sender, EventArgs e)
        {
            //Controller ctr = new Controller();

            //var fileContent = ctr.readFile("SELECT_FILE");

            //Console.Write(fileContent);


            string json = @"[
                  {
	                'Name': 'Bad Boys',
	                'ReleaseDate': '1995-4-7T00:00:00',
	                'Genres': [
	                  'Action',
	                  'Comedy'
	                ]
                  },
                  {
                  'Name': 'Baby Boys',
                  'ReleaseDate': '1995-5-7T00:00:00',
                  'Genres': [
                    'Comedy',
	                'funny'
                  ]
                }
                ]";

          
            ArrayList  arrayM = JsonConvert.DeserializeObject<ArrayList>(json);
            

            foreach(var data in arrayM)
            {
                Movie m = JsonConvert.DeserializeObject<Movie>(data.ToString());
                MessageBox.Show(m.Genres[1]);
            }
      
           
        }
    }
}
