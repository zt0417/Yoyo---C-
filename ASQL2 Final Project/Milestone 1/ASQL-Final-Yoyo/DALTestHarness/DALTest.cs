/*
 * Authors:          Tong Zhang, Bridget Kerr & Ibrahim Naamani
 * Date of creation: March 16, 2016
 * File Name:        DALTest.cs
 * Description:      This class is the test harness for the DAL (Data Access Layer) class library. It tests al of the methods that 
 *                   the DAL library contains.
 *                   
 *                   The integerity for server connection will be tested. But it is important to note that for the majority
 *                   of the tests a valid connection is required before the function may be tested properly.
 * 
 * Last Modified:    March 16, 2016
*/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using DataAccessLayer;
using System.Collections.Generic;
namespace DALTestHarness
{
    [TestClass]
    public class DALTest
    {

        /*
         * Name: CreateDALTest
         * 
         * Description: The purpose of this test is to test the constructor of the DAL.
         *              
         *              This test is a bit different than any other test because it requires the user to ensure that
         *              a database was set up successfuly and is accessiable.
         *              
         * 
         * 
         * Expected Result: Success
         * Actual Result:   Success
         * 
         *              In the case that this test fails, one must ensure that the local database being used is called
         *              yoyo and is a Microsoft SQL Express server (./SQLEXPRESS) and that the credentials for the login
         *              have not been modified from what was set by the admins during setup.
        */
        [TestMethod]
        public void CreateDALTest()
        {
            DAL theData = new DAL();
            string dataVerified = theData.VerifyConnection();
            string status = theData.VerifyConnection();
            Assert.AreEqual(status, "Success");
            Assert.AreEqual(dataVerified, "Success");
        }

        /*
         * Name: InsertIntoDBTest
         * 
         * Description: The purpose of this test is to test the insert method that will be used to insert the generated
         *              data regarding the Yoyo into the database. For this test we're using exactly what the syntax 
         *              woud look like.
         * 
         * Expected Result: True
         * Actual Result:   True
         * 
        */
        [TestMethod]
        public void InsertIntoDBTest()
        {
            DAL theData = new DAL();
            theData.VerifyConnection();
            bool status = theData.InsertInto(@"'MyArea', '81b12bc3-a993-41a4-9ef9-fff24abccfc3', 'Line7', '14', '0','3/16/2016 3:04:14 PM', '0' ");
            Assert.AreEqual(status, true);
        }

        /*
         * Name: ReadFromDBTest
         * 
         * Description: The purpose of this test is to test the read method that will be used to read from the database
         *              so that the reports may be generated for the user. The data is read into a list of strings, coloumn
         *              by column with the retrieved data. If the List is returned with the first object being called "NULL"
         *              then the test has failed
         * 
         * Expected Result: True
         * Actual Result:   True
         * 
        */
        [TestMethod]
        public void ReadFromDBTest()
        {
            DAL theData = new DAL();
            theData.VerifyConnection();
            List<string>[] status = new List<string>[7];
            status = theData.retrieveInformation("SELECT * FROM YoyoTable", 7);
            Assert.AreNotEqual(status[0], "Null");
        }

    }
}
