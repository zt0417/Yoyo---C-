namespace ASQL_Final_Yoyo
{
    partial class frmAdminPage
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
            this.lblReadFromQueue = new System.Windows.Forms.Label();
            this.btnBeginTransaction = new System.Windows.Forms.Button();
            this.txtboxDebug1 = new System.Windows.Forms.TextBox();
            this.txtboxDebug2 = new System.Windows.Forms.TextBox();
            this.txtboxDebug3 = new System.Windows.Forms.TextBox();
            this.txtboxDebug4 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lblReadFromQueue
            // 
            this.lblReadFromQueue.AutoSize = true;
            this.lblReadFromQueue.Location = new System.Drawing.Point(12, 9);
            this.lblReadFromQueue.Name = "lblReadFromQueue";
            this.lblReadFromQueue.Size = new System.Drawing.Size(361, 13);
            this.lblReadFromQueue.TabIndex = 0;
            this.lblReadFromQueue.Text = "Press the button to start reading from the message queue into the database";
            // 
            // btnBeginTransaction
            // 
            this.btnBeginTransaction.Location = new System.Drawing.Point(12, 25);
            this.btnBeginTransaction.Name = "btnBeginTransaction";
            this.btnBeginTransaction.Size = new System.Drawing.Size(105, 23);
            this.btnBeginTransaction.TabIndex = 1;
            this.btnBeginTransaction.Text = "Begin Transaction";
            this.btnBeginTransaction.UseVisualStyleBackColor = true;
            this.btnBeginTransaction.Click += new System.EventHandler(this.btnBeginTransaction_Click);
            // 
            // txtboxDebug1
            // 
            this.txtboxDebug1.Location = new System.Drawing.Point(15, 77);
            this.txtboxDebug1.Name = "txtboxDebug1";
            this.txtboxDebug1.Size = new System.Drawing.Size(351, 20);
            this.txtboxDebug1.TabIndex = 2;
            // 
            // txtboxDebug2
            // 
            this.txtboxDebug2.Location = new System.Drawing.Point(15, 121);
            this.txtboxDebug2.Name = "txtboxDebug2";
            this.txtboxDebug2.Size = new System.Drawing.Size(351, 20);
            this.txtboxDebug2.TabIndex = 3;
            // 
            // txtboxDebug3
            // 
            this.txtboxDebug3.Location = new System.Drawing.Point(15, 169);
            this.txtboxDebug3.Name = "txtboxDebug3";
            this.txtboxDebug3.Size = new System.Drawing.Size(351, 20);
            this.txtboxDebug3.TabIndex = 4;
            // 
            // txtboxDebug4
            // 
            this.txtboxDebug4.Location = new System.Drawing.Point(15, 209);
            this.txtboxDebug4.Name = "txtboxDebug4";
            this.txtboxDebug4.Size = new System.Drawing.Size(351, 20);
            this.txtboxDebug4.TabIndex = 5;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(151, 28);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 6;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // frmAdminPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 262);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtboxDebug4);
            this.Controls.Add(this.txtboxDebug3);
            this.Controls.Add(this.txtboxDebug2);
            this.Controls.Add(this.txtboxDebug1);
            this.Controls.Add(this.btnBeginTransaction);
            this.Controls.Add(this.lblReadFromQueue);
            this.Name = "frmAdminPage";
            this.Text = "AdminPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReadFromQueue;
        private System.Windows.Forms.Button btnBeginTransaction;
        private System.Windows.Forms.TextBox txtboxDebug1;
        private System.Windows.Forms.TextBox txtboxDebug2;
        private System.Windows.Forms.TextBox txtboxDebug3;
        private System.Windows.Forms.TextBox txtboxDebug4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}