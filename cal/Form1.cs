using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace calculator_1
{
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        string opr;
        double operand1, operand2, result;


        public Form1()
        {
            InitializeComponent();

            MouseDown += new MouseEventHandler(move_window);


            //listView1.GridLines = false;
            //listView1.View = View.Details;
            //listView1.Columns.Add("HISTORY", 300);
            


           
          
        }
        Color hdrColor = SystemColors.Control;
     

        private void move_window(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public void setNum(int number)
        {
            
            if(label_main.Text.Count() < 9)
            {
                
           

                if (label_main.Text == "0")
                {
                    label_main.ResetText();
                    label_main.Text = label_main.Text + number;
                
                }
                else
                {
                    label_main.Text = label_main.Text + number;
                
                }

            }
            else
            {
                MessageBox.Show("Maximum Input !! (9 Digit)");
            }
        }
        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            setNum(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            setNum(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            setNum(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            setNum(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            setNum(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            setNum(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            setNum(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            setNum(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            setNum(9);
        }

        private void button_zero_Click(object sender, EventArgs e)
        {
            setNum(0);
        }

        private void button_point_Click(object sender, EventArgs e)
        {
            if (label_main.Text.Contains("."))
            {
                label_main.Text = label_main.Text;
            }
            else
            {
                label_main.Text = label_main.Text + ".";
            }
        }

        //================================================================================================
        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            button1.Image = Properties.Resources.Rectangle;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.Image = Properties.Resources.Rectangle_shd;
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            button2.Image = Properties.Resources.Rectangle;
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            button2.Image = Properties.Resources.Rectangle_shd;
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            button3.Image = Properties.Resources.Rectangle;
        }
        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            button3.Image = Properties.Resources.Rectangle_shd;
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            button4.Image = Properties.Resources.Rectangle_shd;
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            button4.Image = Properties.Resources.Rectangle;
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            button5.Image = Properties.Resources.Rectangle_shd;
        }

        private void button5_MouseUp(object sender, MouseEventArgs e)
        {
            button5.Image = Properties.Resources.Rectangle;
        }

        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            button6.Image = Properties.Resources.Rectangle_shd;
        }

        private void button6_MouseUp(object sender, MouseEventArgs e)
        {
            button6.Image = Properties.Resources.Rectangle;
        }

        private void button7_MouseDown(object sender, MouseEventArgs e)
        {
            button7.Image = Properties.Resources.Rectangle_shd;
        }

        private void button7_MouseUp(object sender, MouseEventArgs e)
        {
            button7.Image = Properties.Resources.Rectangle;
        }

        private void button8_MouseDown(object sender, MouseEventArgs e)
        {
            button8.Image = Properties.Resources.Rectangle_shd;
        }

        private void button8_MouseUp(object sender, MouseEventArgs e)
        {
            button8.Image = Properties.Resources.Rectangle;
        }


        private void button9_MouseDown(object sender, MouseEventArgs e)
        {
            button9.Image = Properties.Resources.Rectangle_shd;
        }

        private void button9_MouseUp(object sender, MouseEventArgs e)
        {
            button9.Image = Properties.Resources.Rectangle;
        }

        private void button_zero_MouseDown(object sender, MouseEventArgs e)
        {
            button_zero.Image = Properties.Resources.Rectangle_shd;
        }

        private void button_zero_MouseUp(object sender, MouseEventArgs e)
        {
            button_zero.Image = Properties.Resources.Rectangle;
        }



        //=========================== Oparand ================================//

        private void button_minus_Click(object sender, EventArgs e)
        {
            operand1 = Convert.ToDouble(label_main.Text);
            opr = "-";
            label_main.ResetText();
        }

        private void button_mul_Click(object sender, EventArgs e)
        {
            operand1 = Convert.ToDouble(label_main.Text);
            opr = "*";
            label_main.ResetText();
        }

        private void button_divide_Click(object sender, EventArgs e)
        {
            operand1 = Convert.ToDouble(label_main.Text);
            opr = "/";
            label_main.ResetText();
        }

   

        private void button_plus_Click(object sender, EventArgs e)
        {
            operand1 = Convert.ToDouble(label_main.Text);
            opr = "+";
            label_main.ResetText();

        }


        //================ equal / Insert ======================//
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var itemSelect = listView1.SelectedItems[0].SubItems[1].Text;

                operand1 = Convert.ToDouble(itemSelect);
                
                label_main.Text = itemSelect;

                 //  MessageBox.Show($"{itemSelect} , {operand1} ,{opr}, {operand2}");
            }
        }

        private void button_eq_Click(object sender, EventArgs e)
        {
            operand2 = Convert.ToDouble(label_main.Text);
            switch (opr)
            {
                case "+":
                    result = operand1 + operand2;
                    label_main.Text = Convert.ToString(result);
                    break;

                case "-":
                    result = operand1 - operand2;
                    label_main.Text = Convert.ToString(result);
                    break;

                case "*":
                    result = operand1 * operand2;
                    label_main.Text = Convert.ToString(result);
                    break;

                case "/":
                    if (operand2 == 0)
                    {
                        label_main.Text = "0";
                        MessageBox.Show("Can't Devide By Zero (Infinity)","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        break;
                    }
                    else
                    {
                        result = operand1 / operand2;
                        label_main.Text = Convert.ToString(result);
                        break;
                    }
            }

           

            Controller ctr = new Controller();
            var cmd = ctr.sqlCmd();
            var conn = ctr.sqlCon();

            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO `tbl_history`( `expression`, `operand_1`, `operand_2`, `result`) VALUES (@exp,@op1,@op2,@res)";
            cmd.Parameters.AddWithValue("@exp", $"{operand1}{opr}{operand2}={result}");
            cmd.Parameters.AddWithValue("@op1", operand1);
            cmd.Parameters.AddWithValue("@op2", operand2);
            cmd.Parameters.AddWithValue("@res", result);

            Console.Write(cmd.Parameters.ToString());
            Console.Write("CMD  : " + cmd.CommandText.ToString());
            cmd.ExecuteNonQuery();
            
            conn.Close();

            // ctr.sqlNonQuery("INSERT INTO `tbl_history`( `expression`, `operand_1`, `operand_2`, `result`) VALUES ('1+1=2','1','1','2')");
            // ctr.sqlNonQuery("INSERT INTO `tbl_history`( `expression`, `operand_1`, `operand_2`, `result`) VALUES ('11+11=22','11','11','22')");

            //DataSet ds = new DataSet();
            //var data = ctr.sqlQuery("SELECT * FROM `tbl_history` ");
            //data.Read();

            //  MessageBox.Show(data.GetString(data.GetOrdinal("expression")));

            var da = ctr.sqlAdt("SELECT * FROM `tbl_history` ");

            DataTable dt = new DataTable();

            da.Fill(dt);

            listView1.View = View.Details;
            listView1.Clear();
            listView1.Columns.Clear();
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("HISTORY", 100);
            listView1.Columns.Add("RESULT", 100);

            for (var i=0; i< dt.Rows.Count;i++)
            {
                var lvi = new ListViewItem(dt.Rows[i]["expression"].ToString());
                lvi.SubItems.Add(dt.Rows[i]["result"].ToString());
                listView1.Items.Add(lvi);
            }

        
           


        }

       
    }
}
