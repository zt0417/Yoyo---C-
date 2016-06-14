namespace ASQL_Final_Yoyo
{
    partial class frmUserPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblDiagram = new System.Windows.Forms.Label();
            this.radioFirstTimeYield = new System.Windows.Forms.RadioButton();
            this.radioFinalYield = new System.Windows.Forms.RadioButton();
            this.radioPareto = new System.Windows.Forms.RadioButton();
            this.datagridTable = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.comboProducts = new System.Windows.Forms.ComboBox();
            this.comboColours = new System.Windows.Forms.ComboBox();
            this.lblFilters = new System.Windows.Forms.Label();
            this.lblColours = new System.Windows.Forms.Label();
            this.lblProducts = new System.Windows.Forms.Label();
            this.lblDefects = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEnddate = new System.Windows.Forms.Label();
            this.comboDefects = new System.Windows.Forms.ComboBox();
            this.dateTimeStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.chkboxApplyFilters = new System.Windows.Forms.CheckBox();
            this.lblSeparator = new System.Windows.Forms.Label();
            this.chartResults = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chckboxDateFilter = new System.Windows.Forms.CheckBox();
            this.lblFeedBack = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.datagridTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartResults)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDiagram
            // 
            this.lblDiagram.AutoSize = true;
            this.lblDiagram.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiagram.Location = new System.Drawing.Point(9, 9);
            this.lblDiagram.Name = "lblDiagram";
            this.lblDiagram.Size = new System.Drawing.Size(109, 25);
            this.lblDiagram.TabIndex = 3;
            this.lblDiagram.Text = "Diagrams:";
            // 
            // radioFirstTimeYield
            // 
            this.radioFirstTimeYield.AutoSize = true;
            this.radioFirstTimeYield.Checked = true;
            this.radioFirstTimeYield.Location = new System.Drawing.Point(12, 45);
            this.radioFirstTimeYield.Name = "radioFirstTimeYield";
            this.radioFirstTimeYield.Size = new System.Drawing.Size(96, 17);
            this.radioFirstTimeYield.TabIndex = 4;
            this.radioFirstTimeYield.TabStop = true;
            this.radioFirstTimeYield.Text = "First Time Yield";
            this.radioFirstTimeYield.UseVisualStyleBackColor = true;
            // 
            // radioFinalYield
            // 
            this.radioFinalYield.AutoSize = true;
            this.radioFinalYield.Location = new System.Drawing.Point(12, 68);
            this.radioFinalYield.Name = "radioFinalYield";
            this.radioFinalYield.Size = new System.Drawing.Size(73, 17);
            this.radioFinalYield.TabIndex = 5;
            this.radioFinalYield.Text = "Final Yield";
            this.radioFinalYield.UseVisualStyleBackColor = true;
            // 
            // radioPareto
            // 
            this.radioPareto.AutoSize = true;
            this.radioPareto.Location = new System.Drawing.Point(12, 91);
            this.radioPareto.Name = "radioPareto";
            this.radioPareto.Size = new System.Drawing.Size(56, 17);
            this.radioPareto.TabIndex = 6;
            this.radioPareto.Text = "Pareto";
            this.radioPareto.UseVisualStyleBackColor = true;
            // 
            // datagridTable
            // 
            this.datagridTable.AllowUserToAddRows = false;
            this.datagridTable.AllowUserToDeleteRows = false;
            this.datagridTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.datagridTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.datagridTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridTable.Location = new System.Drawing.Point(12, 227);
            this.datagridTable.Name = "datagridTable";
            this.datagridTable.ReadOnly = true;
            this.datagridTable.Size = new System.Drawing.Size(314, 292);
            this.datagridTable.TabIndex = 7;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(10, 178);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(653, 23);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // comboProducts
            // 
            this.comboProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboProducts.FormattingEnabled = true;
            this.comboProducts.Location = new System.Drawing.Point(226, 44);
            this.comboProducts.Name = "comboProducts";
            this.comboProducts.Size = new System.Drawing.Size(121, 21);
            this.comboProducts.Sorted = true;
            this.comboProducts.TabIndex = 9;
            // 
            // comboColours
            // 
            this.comboColours.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboColours.FormattingEnabled = true;
            this.comboColours.Location = new System.Drawing.Point(226, 75);
            this.comboColours.Name = "comboColours";
            this.comboColours.Size = new System.Drawing.Size(121, 21);
            this.comboColours.Sorted = true;
            this.comboColours.TabIndex = 10;
            // 
            // lblFilters
            // 
            this.lblFilters.AutoSize = true;
            this.lblFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilters.Location = new System.Drawing.Point(159, 9);
            this.lblFilters.Name = "lblFilters";
            this.lblFilters.Size = new System.Drawing.Size(77, 25);
            this.lblFilters.TabIndex = 11;
            this.lblFilters.Text = "Filters:";
            // 
            // lblColours
            // 
            this.lblColours.AutoSize = true;
            this.lblColours.Location = new System.Drawing.Point(161, 78);
            this.lblColours.Name = "lblColours";
            this.lblColours.Size = new System.Drawing.Size(45, 13);
            this.lblColours.TabIndex = 12;
            this.lblColours.Text = "Colours:";
            // 
            // lblProducts
            // 
            this.lblProducts.AutoSize = true;
            this.lblProducts.Location = new System.Drawing.Point(161, 48);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(49, 13);
            this.lblProducts.TabIndex = 13;
            this.lblProducts.Text = "Products";
            // 
            // lblDefects
            // 
            this.lblDefects.AutoSize = true;
            this.lblDefects.Location = new System.Drawing.Point(161, 109);
            this.lblDefects.Name = "lblDefects";
            this.lblDefects.Size = new System.Drawing.Size(47, 13);
            this.lblDefects.TabIndex = 14;
            this.lblDefects.Text = "Defects:";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(402, 45);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(58, 13);
            this.lblStartDate.TabIndex = 15;
            this.lblStartDate.Text = "Start Date:";
            // 
            // lblEnddate
            // 
            this.lblEnddate.AutoSize = true;
            this.lblEnddate.Location = new System.Drawing.Point(402, 108);
            this.lblEnddate.Name = "lblEnddate";
            this.lblEnddate.Size = new System.Drawing.Size(55, 13);
            this.lblEnddate.TabIndex = 16;
            this.lblEnddate.Text = "End Date:";
            // 
            // comboDefects
            // 
            this.comboDefects.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDefects.FormattingEnabled = true;
            this.comboDefects.Location = new System.Drawing.Point(226, 106);
            this.comboDefects.Name = "comboDefects";
            this.comboDefects.Size = new System.Drawing.Size(121, 21);
            this.comboDefects.Sorted = true;
            this.comboDefects.TabIndex = 17;
            // 
            // dateTimeStart
            // 
            this.dateTimeStart.Location = new System.Drawing.Point(463, 41);
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.Size = new System.Drawing.Size(200, 20);
            this.dateTimeStart.TabIndex = 18;
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.Location = new System.Drawing.Point(463, 104);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(200, 20);
            this.dateTimeEnd.TabIndex = 19;
            // 
            // chkboxApplyFilters
            // 
            this.chkboxApplyFilters.AutoSize = true;
            this.chkboxApplyFilters.Location = new System.Drawing.Point(164, 144);
            this.chkboxApplyFilters.Name = "chkboxApplyFilters";
            this.chkboxApplyFilters.Size = new System.Drawing.Size(82, 17);
            this.chkboxApplyFilters.TabIndex = 20;
            this.chkboxApplyFilters.Text = "Apply Filters";
            this.chkboxApplyFilters.UseVisualStyleBackColor = true;
            // 
            // lblSeparator
            // 
            this.lblSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSeparator.Location = new System.Drawing.Point(374, 9);
            this.lblSeparator.Name = "lblSeparator";
            this.lblSeparator.Size = new System.Drawing.Size(1, 152);
            this.lblSeparator.TabIndex = 21;
            // 
            // chartResults
            // 
            chartArea2.Name = "ChartArea1";
            this.chartResults.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartResults.Legends.Add(legend2);
            this.chartResults.Location = new System.Drawing.Point(351, 227);
            this.chartResults.Name = "chartResults";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartResults.Series.Add(series2);
            this.chartResults.Size = new System.Drawing.Size(312, 292);
            this.chartResults.TabIndex = 22;
            this.chartResults.Text = "Display Results";
            // 
            // chckboxDateFilter
            // 
            this.chckboxDateFilter.AutoSize = true;
            this.chckboxDateFilter.Location = new System.Drawing.Point(405, 144);
            this.chckboxDateFilter.Name = "chckboxDateFilter";
            this.chckboxDateFilter.Size = new System.Drawing.Size(103, 17);
            this.chckboxDateFilter.TabIndex = 23;
            this.chckboxDateFilter.Text = "Apply Date Filter";
            this.chckboxDateFilter.UseVisualStyleBackColor = true;
            // 
            // lblFeedBack
            // 
            this.lblFeedBack.AutoSize = true;
            this.lblFeedBack.ForeColor = System.Drawing.Color.Red;
            this.lblFeedBack.Location = new System.Drawing.Point(322, 204);
            this.lblFeedBack.Name = "lblFeedBack";
            this.lblFeedBack.Size = new System.Drawing.Size(0, 13);
            this.lblFeedBack.TabIndex = 24;
            // 
            // frmUserPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 540);
            this.Controls.Add(this.lblFeedBack);
            this.Controls.Add(this.chckboxDateFilter);
            this.Controls.Add(this.chartResults);
            this.Controls.Add(this.lblSeparator);
            this.Controls.Add(this.chkboxApplyFilters);
            this.Controls.Add(this.dateTimeEnd);
            this.Controls.Add(this.dateTimeStart);
            this.Controls.Add(this.comboDefects);
            this.Controls.Add(this.lblEnddate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.lblDefects);
            this.Controls.Add(this.lblProducts);
            this.Controls.Add(this.lblColours);
            this.Controls.Add(this.lblFilters);
            this.Controls.Add(this.comboColours);
            this.Controls.Add(this.comboProducts);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.datagridTable);
            this.Controls.Add(this.radioPareto);
            this.Controls.Add(this.radioFinalYield);
            this.Controls.Add(this.radioFirstTimeYield);
            this.Controls.Add(this.lblDiagram);
            this.Name = "frmUserPage";
            this.Text = "UserPage";
            ((System.ComponentModel.ISupportInitialize)(this.datagridTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDiagram;
        private System.Windows.Forms.RadioButton radioFirstTimeYield;
        private System.Windows.Forms.RadioButton radioFinalYield;
        private System.Windows.Forms.RadioButton radioPareto;
        private System.Windows.Forms.DataGridView datagridTable;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox comboProducts;
        private System.Windows.Forms.ComboBox comboColours;
        private System.Windows.Forms.Label lblFilters;
        private System.Windows.Forms.Label lblColours;
        private System.Windows.Forms.Label lblProducts;
        private System.Windows.Forms.Label lblDefects;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEnddate;
        private System.Windows.Forms.ComboBox comboDefects;
        private System.Windows.Forms.DateTimePicker dateTimeStart;
        private System.Windows.Forms.DateTimePicker dateTimeEnd;
        private System.Windows.Forms.CheckBox chkboxApplyFilters;
        private System.Windows.Forms.Label lblSeparator;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartResults;
        private System.Windows.Forms.CheckBox chckboxDateFilter;
        private System.Windows.Forms.Label lblFeedBack;



    }
}