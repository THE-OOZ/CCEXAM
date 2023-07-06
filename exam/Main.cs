using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text.Json;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace Exam_B
{
    public partial class Main : Form

    {
        public List<ResultHeader> itemList;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        public Main()
        {

            DateTime date = DateTime.ParseExact("17/04/1961 00:00:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("th-TH"));

            string dateTime = date.ToString("yyyy-MM-dd HH:mm:ss");

            Console.Write(dateTime);

            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            MouseDown += new MouseEventHandler(move_window);

          
          }

        private void move_window(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

  

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string qryStr = $"SELECT `lab_id` FROM `tbl_lab_request`; ";


            Controller ctr = new Controller();
            //ctr.ConnSql("OPEN");

            //MySqlCommand cmd = ctr.conn.CreateCommand();
            //MySqlDataAdapter sda = new MySqlDataAdapter(qryStr, ctr.conn);

            //DataTable dt = new DataTable();
            //sda.Fill(dt);

            itemList = ctr.getItemList();

            comboBoxID.DataSource = itemList;
            comboBoxID.DisplayMember = "LabNumber";
         
          //  ctr.ConnSql("CLOSE");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void comboBoxID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SELECT_RESULT = $"SELECT `result_name`, `result_value`,`result_unit`,`result_ref_range` ,`result_flag` " +
                                $"FROM `tbl_lab_result` WHERE `result_lab_id`='{comboBoxID.Text}'; ";

           // string SELECT_PATIENT = $"SELECT `lab_ref_hn` FROM `tbl_lab_request` WHERE `lab_id`='{comboBoxID.Text}';";

            Controller ctr = new Controller();
           ctr.ConnSql("OPEN");



            MySqlDataAdapter sda = new MySqlDataAdapter(SELECT_RESULT, ctr.conn);
           
            DataTable dt = new DataTable();

            List<ResultList> DataList = new List<ResultList>();
            List<ResultHeader> RH = new List<ResultHeader>();

            var itemsList = itemList;

            labelHn.Text = itemsList[comboBoxID.SelectedIndex].HN;
            labelName.Text = itemsList[comboBoxID.SelectedIndex].FirstName;
            labelBc.Text = itemsList[comboBoxID.SelectedIndex].ResultList[0].BarcodeNumber;
            labelDiag.Text = itemsList[comboBoxID.SelectedIndex].RequestRemark;
            labelUnit.Text = itemsList[comboBoxID.SelectedIndex].RequestUnit;
            labelRT.Text = itemsList[comboBoxID.SelectedIndex].ResultList[0].ReportResultDateTime;


            listView1.View = View.Details;
            listView1.Clear();
            listView1.Columns.Clear();
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            
            listView1.Columns.Add("NAME", 120 , HorizontalAlignment.Center);
            listView1.Columns.Add("Value", 60);
            listView1.Columns.Add("Unit", 80);
            listView1.Columns.Add("Normal", 100);
            listView1.Columns.Add("Flag", 60);
            var i = 0;
            foreach (var item in itemsList[comboBoxID.SelectedIndex].ResultList)
            {
                var lvi = new ListViewItem(item.TestName);
                
                lvi.SubItems.Add(item.ResultValue);
                lvi.SubItems.Add(item.ResultUnit);
                lvi.SubItems.Add(item.ReferenceRange);

                lvi.SubItems.Add(item.ResultFlag);
                listView1.Items.Add(lvi);
                if (item.ResultFlag.ToString() == "H")
                {
                    listView1.Items[i].BackColor = Color.Salmon;
                }
                else
                {
                    listView1.Items[i].BackColor = Color.Aquamarine;
                }
                i = i + 1;
            }
           

            sda.Fill(dt);
            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAppr_Click(object sender, EventArgs e)
        {
            

            string fileName = "Lab-Result.txt";                                    
            //MessageBox.Show(Application.ExecutablePath.ToString());
            //MessageBox.Show(Application.StartupPath.ToString());


            string filePath = Path.Combine(Application.StartupPath, fileName);     //===========   TXT PATH FILE  ==========//
            string fileContent = File.ReadAllText(filePath);

            //Console.WriteLine("File Contents: " + fileContent);

      


            Controller ctr = new Controller();

            DateTime date = DateTime.ParseExact("17/04/1961 00:00:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("th-TH"));

            string dateTime = date.ToString("yyyy-MM-dd HH:mm:ss");

            Console.WriteLine(dateTime);




            // ctr.InsertResult(items);
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
