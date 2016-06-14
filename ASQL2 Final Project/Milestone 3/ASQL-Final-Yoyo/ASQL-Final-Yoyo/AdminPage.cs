using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


namespace ASQL_Final_Yoyo
{
    public partial class frmAdminPage : Form
    {
        DAL dal = new DAL();
        public frmAdminPage()
        {
            InitializeComponent();
        }

        private void btnBeginTransaction_Click(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txtboxDebug1.Text = dateTimePicker1.Value.ToString();
            txtboxDebug2.Text = dateTimePicker1.Text;
            txtboxDebug3.Text = dateTimePicker1.ToString();
        }

        OpenFileDialog ofd = new OpenFileDialog();

        /// <summary>
        /// This function is used to add schedule to database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddSchedule_Click(object sender, EventArgs e)
        {

            ofd.Filter = "GPD|*.xlsx";
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;
            string workbookPath="";

            //If the dialog open get the file path.
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                workbookPath = ofd.FileName;


                //Keep the data from execl 
                int counter = 1;
                List<String> title = new List<string>();
                List<String> Column = new List<string>();
                List<String> OneRecord = new List<string>();
                bool flag = false;

                string str;
                int rCnt = 0;
                int cCnt = 0;


                // Put value into execl from.
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(workbookPath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                range = xlWorkSheet.UsedRange;

                for (rCnt = 1; rCnt <= range.Rows.Count; rCnt++)
                {
                    for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                    {
                        str = Convert.ToString((range.Cells[rCnt, cCnt] as Excel.Range).Value2);

                        // 1
                        if (title.Count < 5)
                        {
                            title.Add(str);
                        }
                        else
                        {
                            Column.Add(str);
                        }
                    }
                }

                xlWorkBook.Close(true, null, null);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);

                //
                for (int i = 0; i < Column.Count; i++)
                {
                    if (counter < 5)
                    {
                        OneRecord.Add(Column[i]);
                    }
                    else
                    {
                        OneRecord.Add(Column[i]);
                        flag = true;
                    }

                    if (flag == true)
                    {
                        String sqlString = MakeSqlString(OneRecord);

                        //insert to database
                        dal.InsertIntoSchedule(sqlString);

                        OneRecord.Clear();
                        counter = 0;
                        flag = false;
                    }

                    counter++;
                }

                MessageBox.Show("Schedul File has load into DataBase.");
            }
        }



        /// <summary>
        /// The insert schelude string
        /// </summary>
        /// <param name="OneRecord">The information list</param>
        /// <returns>The sql string</returns>
        public String MakeSqlString(List<String> OneRecord)
        {
            String sql = "INSERT INTO ScheduleTable(StartTime, EndTime, TheDate, SKUID, WorkArea) VALUES('" + OneRecord[0].Replace("|",":") + "','"+ OneRecord[1].Replace("|", ":") + "','"+ OneRecord[2] + "','" + OneRecord[3] + "','"+ OneRecord[4] + "')";

            return sql;
        }




        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        /// <summary>
        /// Add new user into database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUser_Click(object sender, EventArgs e)
        {
            string UserName=this.txtboxDebug1.Text;
            string Password=this.txtboxDebug2.Text;
            int level;

            if (!this.Administrator.Checked && !this.General.Checked)
            {
                MessageBox.Show("Choose user tpye.");
            }
            else if (UserName == "")
            {
                MessageBox.Show("User name can not be blank.");
            }
            else if (Password=="")
            {
                MessageBox.Show("Password can not be blank.");
            }
            else
            {
                if (this.Administrator.Checked)
                {
                    level = 10;
                }
                else {
                    level = 5;
                }
                String sqlString = MakeSqlAddUserString(UserName, Password, level);

                dal.InsertNewUser(sqlString);

                MessageBox.Show("New user has save to DataBase.");
            }



        }


        /// <summary>
        /// The sql string
        /// </summary>
        /// <param name="UserName">New user name</param>
        /// <param name="Password">The password</param>
        /// <returns></returns>
        public String MakeSqlAddUserString(string UserName, string Password, int level)
        {
            String sql = "INSERT INTO UsersTable(Name, ThePassword, SecurityLevel) VALUES('" + UserName + "','" + Password + "','" + level + "')";

            return sql;
        }


    }
}
