using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ASQL_Final_Yoyo
{
    public partial class frmUserPage : Form
    {
        public DAL dataAccess = new DAL();
        private string success;

        public frmUserPage()
        {
            InitializeComponent();
            success = dataAccess.VerifyConnection();
            
            DataTable coloursTable = dataAccess.populateSpecificTable("Colours");
            DataTable productsTable = dataAccess.populateSpecificTable("Products");

            for (int i = 0; i < coloursTable.Rows.Count; i ++)
            {
                comboColours.Items.Insert(i, coloursTable.Rows[i].ItemArray[0]);
            }

            for (int i = 0; i < productsTable.Rows.Count; i++)
            {
                comboProducts.Items.Insert(i, productsTable.Rows[i].ItemArray[0]);
            }

            comboDefects.Items.Insert(0, "Rejected");
            comboDefects.Items.Insert(0, "Reworked");

            comboColours.SelectedIndex = 0;
            comboProducts.SelectedIndex = 0;
            comboDefects.SelectedIndex = 0;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (success != "Success")
            {
                lblFeedBack.Text = "Unable to connect to server";
            }
            else
            {

                if (radioFirstTimeYield.Checked)
                {
                    retrieveFirstTimeYield();
                }
                else if (radioFinalYield.Checked)
                {
                    retrieveFinalYield();
                }
                else if (radioPareto.Checked)
                {
                    retrievePraetoTable();
                }
            }
        }

        private void retrieveFirstTimeYield()
        {
            chartResults.DataSource = null;
            chartResults.Series.Clear();
            chartResults.Series.Add("Series");
            chartResults.Series[0].ChartType = SeriesChartType.Pie;

            DataTable tbl = dataAccess.RetrieveTable("", "FirstTimeYield");

            datagridTable.DataSource = tbl;

            string[] x = new String[tbl.Rows.Count];
            int[] y = new int[tbl.Rows.Count];


            for (int i = 0; i < tbl.Rows.Count; i++)
            {

                x[i] = tbl.Rows[i][1].ToString();
                y[i] = Convert.ToInt32(tbl.Rows[i][1]);
            }

            chartResults.Series[0].Points.DataBindXY(x, y);
            chartResults.Legends[0].Enabled = true;

        }

        private void retrieveFinalYield()
        {
            chartResults.DataSource = null;
            chartResults.Series.Clear();
            chartResults.Series.Add("Series");
            chartResults.Series[0].ChartType = SeriesChartType.Pie;

            DataTable tbl = dataAccess.RetrieveTable("", "FinalYield");

            datagridTable.DataSource = tbl;

            string[] x = new String[tbl.Rows.Count];
            double[] y = new double[tbl.Rows.Count];

            x[0] = "Rejects";
            x[1] = "Final Yield";
            y[0] = Convert.ToDouble( tbl.Rows[1][0] )/( Convert.ToDouble(tbl.Rows[0][0]  ) + Convert.ToDouble( tbl.Rows[1][0] )) * 100;
            y[1] = 100 - y[0];

            chartResults.Series[0].Points.DataBindXY(x, y);
            chartResults.Legends[0].Enabled = true;
        }

        private void retrievePraetoTable()
        {
            
            chartResults.DataSource = null;
            chartResults.Series.Clear();
            chartResults.Series.Add("Series");
            chartResults.Series[0].ChartType = SeriesChartType.Column;
            chartResults.Series.Add("Series2");
            chartResults.Series[1].ChartType = SeriesChartType.Line;

            chartResults.Series[1].YAxisType = AxisType.Secondary;
            
            chartResults.ChartAreas[0].AxisY2.Maximum = 100;
            //chartResults.Series[1].Label = "#PERCENT{P0}";
           


            DataTable tbl = dataAccess.RetrieveTable("", "Praeto");

            datagridTable.DataSource = tbl;

            int theValue = 0;

            int runningTotal = 0;

            double tempValue = 0;

            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                theValue += Convert.ToInt32(tbl.Rows[i][1]);
            chartResults.Series["Series"].Points.AddY(tbl.Rows[i][1]);


            }

            for(int j = 0; j < tbl.Rows.Count; j++)
            {
             tempValue += (Convert.ToDouble(tbl.Rows[j][1])/ theValue * 100);
            chartResults.Series["Series2"].Points.AddY(Math.Round(tempValue, 2));
            }
            chartResults.ChartAreas[0].AxisY.Maximum = theValue;
            chartResults.ChartAreas[0].AxisY2.LabelStyle.Format = "{#'%'}";

            
            chartResults.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chartResults.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;

            

        }

    }
}
