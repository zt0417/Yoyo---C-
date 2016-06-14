/*
 * Authors:          Tong Zhang, Bridget Kerr & Ibrahim Naamani
 * Date of creation: March 16, 2016
 * File Name:        DAL.cs
 * Description:      This class acts as a Data Access Layer between the application and the database.
 *                   The user is able to set a connectionString upon constructing the class. They are then able to verify the connection
 *                   and execute queries to the database.
 * 
 * Last Modified:    March 16, 2016
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ASQL_Final_Yoyo
{
    public class DAL
    {
        private SqlConnection conn;
        private SqlCommand sqlCmd;
        private string connectionString;
        private ConnectionStringSettings mySettings;

        /*
         * Function:    DAL
         * 
         * Description:	The constructor for the DAL class.
         *              
         *              Uses a default connection string to the yoyo table within a SQL Server database.
         * 
         * Parameters:	void
         * 
         * Returns:		void
        */
        public DAL()
        {
            mySettings = ConfigurationManager.ConnectionStrings["YoYoConn"];
            connectionString = mySettings.ConnectionString;
        }



        /*
         * Function:    VerifyConnection
         * 
         * Description:	This function is used to determine whether the connection is valid or not.
         *              
         * Parameters:	void
         * 
         * Returns:		string - verifiedStatus
         *              "Success" represents that the connection is verified
         *              an exception will be returned if the connection is not verified.
        */
        public string VerifyConnection()
        {
            string verifiedStatus = "";

            try
            {
                conn = new SqlConnection(connectionString);
                verifiedStatus = "Success";
            }
            catch (Exception e)
            {
                verifiedStatus = e.ToString();
                ForceDisconnect();
            }

            return verifiedStatus;
        }

        /*
         * Function:    AttemptLogin
         * 
         * Description: This function takes a users name and password and verifies that they have access 
         *              to the system.
         * 
         * Parameters:  string - userName
         *              The userName being passed into the procedure
         *              string - password
         *              The password being passed into the procedure
         * 
         * Returns:     int - returnValue
         *              The security level of the user represented by a number
        */
        public int AttemptLogin(string userName, string password)
        {
            int returnValue = 0;

            sqlCmd = new SqlCommand("userName", conn);

            sqlCmd.CommandType = CommandType.StoredProcedure;

            //Setting up the parameters
            sqlCmd.Parameters.Add("@userName", SqlDbType.NVarChar).Value = userName;
            sqlCmd.Parameters.Add("@pword", SqlDbType.NVarChar).Value = password;

            //Setting up the return value
            SqlParameter retval = sqlCmd.Parameters.Add("@result", SqlDbType.Int);
            retval.Direction = ParameterDirection.ReturnValue;

            //Opening the connection
            conn.Open();
            sqlCmd.ExecuteNonQuery();
            conn.Close();

            returnValue = (Int32)sqlCmd.Parameters["@result"].Value;

            return returnValue;
        }

        /*
         * Function:     RetrieveCount
         * 
         * Description:  This method takes an SQL count statement, and retrieves the count for it. 
         *               It would be used in conjunction for calculating Excel data.
         * 
         * Parameters:   string - theQuery
         *               This is the SQL statement to be executed
         * 
         * Returns:      Int32 - returnValue
         *               The value of the query, 0 if no results     
        */

        public int RetrieveCount(string theQuery)
        {
            Int32 returnValue = 0;

            sqlCmd = new SqlCommand(theQuery, conn);

            try
            {
                conn.Open();
                returnValue = (Int32) sqlCmd.ExecuteScalar();
                conn.Close();
            }
            catch (Exception e)
            {
                returnValue = 0;
                ForceDisconnect();
            }

            return returnValue;
        }

        /*
         * Function:    InsertInto
         * 
         * Description:	This function is used to insert into the database specifically for
         *              any of the Yoyos that are being made. The query string gets passed in
         *              with the content that is being parsed from the message queue
         *              
         * Parameters:	string - theInformation
         *              This is the parsed data that is being inserted
         * 
         * Returns:		bool - returnValue
         *              True means inserted properly
         *              False means the insert failed.
        */
        public bool InsertInto(string theInformation)
        {
            bool returnValue = false;
            string theQuery = "INSERT INTO YoYoTable "
                            + "(WorkArea, YoYoID, LineNumber, StateID, RejectID, DateTimeOfCompletion, SKUID) "
                            + "VALUES(" 
                            + theInformation
                            + ")";

            sqlCmd = new SqlCommand(theQuery, conn);

            try
            {
                conn.Open();
                sqlCmd.ExecuteNonQuery();
                conn.Close();
                returnValue = true;
            }
            catch (Exception e)
            {
                returnValue = false;
                ForceDisconnect();
            }
            return returnValue;
        }

        /*
         * Function:    retrieveInformation
         * 
         * Description:	This function is used to read from the database specifically for
         *              the yoyos when generating the reports for the user
         *              
         * Parameters:	string - theQuery
         *              the querey to read from the specified table
         *              int - numberOfCol
         *              The number of columns being read in.
         * 
         * Returns:		List<string>[] - retrievedDBInfo
         *              If everything is successful, the array will contain the elements from the database
         *              If the function fails, then everything is cleared from the list and NULL Is inserted into the [0] index.
        */
        public List<string>[] retrieveInformation(string theQuery, int numberOfCol)
        {
            List<string>[] retrievedDBInfo = new List<string>[numberOfCol];

            for (int i = 0; i < numberOfCol; i++)
            {
                retrievedDBInfo[i] = new List<string>();
            }

            try
            {
                sqlCmd = new SqlCommand(theQuery, conn);

                conn.Open();

                SqlDataReader sqlReader = sqlCmd.ExecuteReader();

                while (sqlReader.Read())
                {
                    for (int j = 0; j < numberOfCol; ++j)
                    {
                        retrievedDBInfo[j].Add(sqlReader[j] + "");
                    }
                }

                sqlReader.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                for (int i = 0; i < numberOfCol; i++)
                {
                    retrievedDBInfo[i].Clear();
                }
                retrievedDBInfo[0].Add("Null");
                ForceDisconnect();
            }

            return retrievedDBInfo;
        }


        /*
         * Function:    ForceDisconnect
         * 
         * Description:	This function forces the database to disconnect. It's used as a fail safe if at any point
         *              the database needs to be disconnected. It checks for an open conncetion, if the connection is open
         *              then it gets closed.
         * 
         * Parameters:	void
         * 
         * Returns:		returnValue - int
         *              1 represents that the connection was force closed
         *              0 represents that no connection was found to be closed
        */
        public int ForceDisconnect()
        {
            int returnValue = 0;
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
                returnValue = 1;
            }
            return returnValue;
        }

        public DataTable RetrieveTable(string parameters, string whichTable)
        {
            SqlDataReader rdr;


            string[] filters = parameters.Split('-');
            string theFiltersCombined = "";
            string theQuery = "";
            

            DataTable theTable = new DataTable();


            for (int i = 0; i < filters.Length; i++)
            {
                theFiltersCombined = theFiltersCombined + " " + filters[i] + " ";
            }

            if (whichTable == "FirstTimeYield")
            {
                theQuery = "EXEC FirstYield";

                theTable.Columns.Add("Station");
                theTable.Columns.Add("YoyoNumber");
                theTable.Columns.Add("Reject");
                theTable.Columns.Add("Rework");
            }
            else if (whichTable == "FinalYield")
            {
                theQuery = "EXEC FinalYield";

                theTable.Columns.Add("Values");
            }
            else if (whichTable == "Praeto")
            {
                theQuery = "EXEC Praeto";

                theTable.Columns.Add("Description");
                theTable.Columns.Add("Count", typeof(int));
            }

            sqlCmd = new SqlCommand(theQuery, conn);

            conn.Open();

            rdr = sqlCmd.ExecuteReader();

            if (whichTable == "FirstTimeYield")
            {
                while (rdr.Read())
                {
                    DataRow dr = theTable.NewRow();
                    dr[0] = rdr[0];
                    dr[1] = rdr[1];
                    dr[2] = rdr[2];
                    dr[3] = rdr[3];
                    theTable.Rows.Add(dr);
                }
            }
            else if (whichTable == "FinalYield")
            {
                while (rdr.Read())
                {
                    DataRow dr = theTable.NewRow();
                    dr[0] = rdr[0];
                    theTable.Rows.Add(dr);
                }
            }
            else if (whichTable == "Praeto")
            {
                while (rdr.Read())
                {
                    DataRow dr = theTable.NewRow();
                    dr[0] = rdr[0];
                    dr[1] = rdr[1];
                    theTable.Rows.Add(dr);
                }
            }

            rdr.Close();
            conn.Close();

            return theTable;
        }

        public DataTable populateSpecificTable(string whichTable)
        {
            DataTable db = new DataTable();
            db.Columns.Add("Column1");
            string theQuery = "";
            
            SqlDataReader rdr;

            if (whichTable == "Colours")
            {
                theQuery = "Exec GetColours";
            }
            else if (whichTable == "Products")
            {
                theQuery = "Exec GetProducts";
            }
            
            sqlCmd = new SqlCommand(theQuery, conn);

            conn.Open();

            rdr = sqlCmd.ExecuteReader();
            while (rdr.Read())
            {
                DataRow dr = db.NewRow();
                dr[0] = rdr[0];
                db.Rows.Add(dr);
            }

            rdr.Close();
            conn.Close();

            return db;
        }
    }
}