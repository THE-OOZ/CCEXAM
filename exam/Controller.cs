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

namespace Exam_B
{

    class Controller
    {
      
        public string cs;
        public string fileContent;
        public MySqlConnection conn;
        public List<ResultHeader> RHL = new List<ResultHeader>();

        public void ConnSql(string status)
        {
            cs = @"server=localhost;userid=root;password=;database=lab_exam";
            conn = new MySqlConnection(cs);

            if (status == "CLOSE")
            {
                conn.Close();
            }
            else if (status == "OPEN")
            {
                conn.Open();
            }

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
            else if(src == "SELECT_FILE")
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

        public  List<ResultHeader>  getItemList()
        {   
            ArrayList items = JsonSerializer.Deserialize<ArrayList>(readFile("SELECT_FILE"));
            ResultHeader RH;
            foreach (var data in items)
            { 
                 RH = JsonSerializer.Deserialize<ResultHeader>(data.ToString());
                 RHL.Add(RH);
            }
            return RHL;
        }

        
        //public ResultHeader getRH(string content)
        //{
        //    ResultHeader items = JsonSerializer.Deserialize<ResultHeader>(content);
        //    return items;
        //}
        //public void PrintField(string table_name)
        //{
        //    List<string> ListFeild = new List<string>();
        //  //  string qryStr = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{table_name}'";
        //    ConnSql("OPEN");
        //    MySqlCommand cmd = conn.CreateCommand();
        //    MySqlDataAdapter sda = new MySqlDataAdapter(qryStr, conn);

        //    DataTable dt = new DataTable();
        //    sda.Fill(dt);
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        ListFeild.Add(dt.Rows[i][0].ToString());
        //    }
        //    Console.WriteLine("===========================");
        //    Console.WriteLine(string.Join(", ", ListFeild));
        //}

        //public void insertSql()
        //{
        //    ConnSql("OPEN");
        //    MySqlCommand cmd = conn.CreateCommand();
        //    cmd.CommandText = $"INSERT INTO tbl_units(unit_id,unit_name) VALUES(@unitId, @unitName)";
        //    cmd.Parameters.AddWithValue("@unitId", "U004");
        //    cmd.Parameters.AddWithValue("@unitName", "LAB-3");
        //    try
        //    {
        //        cmd.ExecuteNonQuery();
        //        ConnSql("CLOSE");
        //    }
        //    catch {
        //        ConnSql("CLOSE");
        //    }

        //}
        //public string  ConvertDt(string dt)
        //{
        //    DateTime date = DateTime.ParseExact(dt, "dd/MM/yyyy HH:mm:ss", CultureInfo.GetCultureInfo("th-TH"));

        //    string dateTime = date.ToString("yyyy-MM-dd HH:mm:ss");

        //    return dateTime;
        //}

        public void InsertResult(ResultHeader rh)
        {
            

            List<string> ListCmd= new List<string>();

            var rl = rh.ResultList;


            


            string ToPatient = $" INSERT INTO `tbl_patient_details`(`HN`, `prefix_name`, `first_name`, `last_name`, `date_of_birth`, `sex`, `weight`, `height`) " +
                               $" VALUES ('{rh.HN}','{rh.PrefixName}','{rh.FirstName}','{rh.LastName}','{rh.DateOfBirth}','{rh.Sex}','{rh.Weight}','{rh.Height}')";

            string ToUnit = $"INSERT INTO `tbl_units`(`unit_code_name`, `unit_detail`) VALUES ('{rh.RequestUnit}','')";

            string ToStaff = $"INSERT INTO `tbl_lab_staff`(`staff_id`, `staff_name`, `staff_last_name`, `staff_permission`, `staff_unit`, `staff_password`, `staff_passcode`) " +
                             $"VALUES ('00001','SARAN','K','VERIFY','ER','666666','666666')";


            //Console.WriteLine(ToUnit);
            // Console.WriteLine("----");
            



            string ToLabReq = $"INSERT INTO `tbl_lab_request`(`lab_id`, `lab_req_name`, `lab_verify_status`, `lab_ref_hn`, `lab_req_unit`, `approve_datetime`, `approve_staff_id`, `lab_result_list_id`)" +
                              $" VALUES ('{rh.LabNumber}','{rh.RequestRemark}','PENDING','{rh.HN}','{rh.RequestUnit}','','','{rl[0].BarcodeNumber}')";

           // Console.WriteLine(ToLabReq);
           

            foreach (var i in rl)
            {
                int Index;
                Index = rl.IndexOf(i);

                string ToLabResult = $"INSERT INTO `tbl_lab_result`(`result_list_id`,`result_lab_id`, `result_code`, `result_name`, `result_status`, `result_type`, `result_value`, `result_unit`, `result_flag`, `result_ref_range`, `result_datetime`, `result_test_code`, `result_test_name`, `cri_flag`, `cri_remark`, `dilution_flag`, `inform_cri_by`, `inform_cri_datetime`, `inform_cri_to`, `repeat_flag`, `report_by`, `result_remark`, `specimen_code`, `specimen_name`, `test_remark`) " +
                                     $"VALUES ('{rl[Index].BarcodeNumber}-{Index+1}','{rh.LabNumber}','{rl[Index].ResultCode}','{rl[Index].ResultName}','{rl[Index].ResultStatus}'," +
                                              $"'{rl[Index].ResultType}','{ float.Parse(rl[Index].ResultValue, CultureInfo.InvariantCulture.NumberFormat)}','{rl[Index].ResultUnit}','{rl[Index].ResultFlag}'," +
                                              $"'{rl[Index].ReferenceRange}','{rl[Index].ReportResultDateTime}','{rl[Index].TestCode}','{rl[Index].TestName}','{rl[Index].CriticalFlag}'," +
                                              $"'{rl[Index].CriticalRemark}','{rl[Index].ResultDilutionFlag}','{rl[Index].InformCriticalBy}','{rl[Index].InformCriticalDateTime}'," +
                                              $"'{rl[Index].InformCriticalTo}','{rl[Index].ResultRepeatFlag}','{rl[Index].ReportResultBy}','{rl[Index].ResultRemark}','{rl[Index].SpecimenCode}','{rl[Index].SpecimenName}','{rl[Index].TestRemark}')  \n;";


                // Console.Write(ToLabResult);

                //ConnSql("OPEN");
                //MySqlCommand cmd = conn.CreateCommand();
                //MySqlCommand cmd1 = new MySqlCommand(ToLabResult, conn);
                //cmd1.ExecuteNonQuery();
                //try
                //{ cmd1.ExecuteNonQuery();
                //    Console.Write("SUCCESS!!");
                //    ConnSql("CLOSE"); }
                //catch
                //{  ConnSql("CLOSE");}

            }
          


           // MySqlCommand cmd2 = new MySqlCommand(ToLabReq, conn);

            

           // Console.WriteLine(ToPatient);
            Console.WriteLine(ToLabReq);

            //foreach (var item in typeof(ResultList).GetProperties())
            //{

            //    Console.WriteLine($" {item.Name}");
            //}




        }

    }


}
