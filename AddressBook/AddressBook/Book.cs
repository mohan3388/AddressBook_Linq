using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class Book
    {
        DataTable dataTable;
        public void CreateTableUsingLinq()
        {
            dataTable = new DataTable("AddressBook");
            DataColumn dtCol;

            dtCol = new DataColumn();
            dtCol.DataType = typeof(Int32);
            dtCol.ColumnName = "Id";
            dataTable.Columns.Add(dtCol);

            dtCol = new DataColumn();
            dtCol.DataType = typeof(String);
            dtCol.ColumnName = "FirstName";
            dataTable.Columns.Add(dtCol);

            dtCol = new DataColumn();
            dtCol.DataType = typeof(String);
            dtCol.ColumnName = "LastName";
            dataTable.Columns.Add(dtCol);

            dtCol = new DataColumn();
            dtCol.DataType = typeof(String);
            dtCol.ColumnName = "Address";
            dataTable.Columns.Add(dtCol);

            dtCol = new DataColumn();
            dtCol.DataType = typeof(String);
            dtCol.ColumnName = "City";
            dataTable.Columns.Add(dtCol);

            dtCol = new DataColumn();
            dtCol.DataType = typeof(String);
            dtCol.ColumnName = "State";
            dataTable.Columns.Add(dtCol);

            dtCol = new DataColumn();
            dtCol.DataType = typeof(String);
            dtCol.ColumnName = "Email";
            dataTable.Columns.Add(dtCol);

            dtCol = new DataColumn();
            dtCol.DataType = typeof(Int64);
            dtCol.ColumnName = "PhoneNumber";
            dataTable.Columns.Add(dtCol);

            dtCol = new DataColumn();
            dtCol.DataType = typeof(Int64);
            dtCol.ColumnName = "Zip";
            dataTable.Columns.Add(dtCol);

        }
        public void InsertionInDataTable(Contact contact)
        {
            DataRow dtRow = dataTable.NewRow();
            dtRow["Id"] = contact.Id;
            dtRow["FirstName"] = contact.FirstName;
            dtRow["LastName"] = contact.LastName;
            dtRow["Address"] = contact.Address;
            dtRow["City"] = contact.City;
            dtRow["State"] = contact.State;
            dtRow["Zip"] = contact.zip;
            dtRow["PhoneNumber"] = contact.PhoneNumber;
            dtRow["Email"] = contact.Email;
            dataTable.Rows.Add(dtRow);

        }
        public void Display()
        {
            foreach (DataRow dtRows in dataTable.Rows)
            {
                Console.WriteLine(" Id: {0} \n First Name: {1} \n Last Name: {2} \n Address: {3} \n City: {4} \n State: {5} \n Zip: {6} \n Phone Number: {7} \n Email: {8} \n", dtRows["ID"], dtRows["FirstName"], dtRows["LastName"], dtRows["Address"], dtRows["City"], dtRows["State"], dtRows["Zip"], dtRows["PhoneNumber"], dtRows["Email"]);
            }
        }
        public int AddDataInDatatable()
        {
            CreateTableUsingLinq();
            Contact contact1 = new Contact();
            Contact contact2 = new Contact();
            contact1.Id = 1;
            contact1.FirstName = "Mohan";
            contact1.LastName = "Sahu";
            contact1.PhoneNumber = 7898524871;
            contact1.Email = "mohan54@gmail.com";
            contact1.Address = "katulboard";
            contact1.City = "Bhilai";
            contact1.State = "CG";
            contact1.zip = 490020;
            InsertionInDataTable(contact1);

            contact2.Id = 2;
            contact2.FirstName = "Kshma";
            contact2.LastName = "Gupta";
            contact2.PhoneNumber = 9178986254;
            contact2.Email = "kshma@gmail.com";
            contact2.Address = "chowhan town";
            contact2.City = "Bhilai";
            contact2.State = "CG";
            contact2.zip = 621001;
            InsertionInDataTable(contact2);

            return dataTable.Rows.Count;
        }
        public int EditInDataTable(string FirstName, string ColumnName)
        {
            AddDataInDatatable();
            var EditList = (from ContactList in dataTable.AsEnumerable() where ContactList.Field<string>("FirstName") == FirstName select ContactList).FirstOrDefault();
            if (EditList != null)
            {
                EditList[ColumnName] = "Sahu";
                Display();
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int DeleteRowInDataTable(string FirstName)
        {
            AddDataInDatatable();
            var modifiedList = (from ContactList in dataTable.AsEnumerable() where ContactList.Field<string>("FirstName") == FirstName select ContactList).FirstOrDefault();
            if (modifiedList != null)
            {
                modifiedList.Delete();
                Console.WriteLine("After Deletion");
                Display();
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public string RetrieveBasedOnCityorState(string City, string State)
        {
            AddDataInDatatable();
            string nameList = "";
            var modifiedList = (from ContactList in dataTable.AsEnumerable() where (ContactList.Field<string>("State") == State || ContactList.Field<string>("City") == City) select ContactList);
            foreach (var dtRows in modifiedList)
            {
                nameList += dtRows["FirstName"] + " ";
                Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4} \t {5} \t {6} \t {7} \t {8}\n", dtRows["ID"], dtRows["FirstName"], dtRows["LastName"], dtRows["Address"], dtRows["City"], dtRows["State"], dtRows["Zip"], dtRows["PhoneNumber"], dtRows["Email"]);
            }
            return nameList;
        }
        public string RetrieveCountBasedOnCityorState()
        {
            AddDataInDatatable();
            string result = "";
            var modifiedList = (from ContactList in dataTable.AsEnumerable().GroupBy(r => new { Col1 = r["City"], Col2 = r["State"] }) select ContactList);
            Console.WriteLine("Äfter count");
            foreach (var j in modifiedList)
            {
                result += j.Count() + " ";
                Console.WriteLine("Count: " + j.Key);
                foreach (var dtRows in j)
                {
                    Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4} \t {5} \t {6} \t {7} \t {8}\n", dtRows["ID"], dtRows["FirstName"], dtRows["LastName"], dtRows["Address"], dtRows["City"], dtRows["State"], dtRows["Zip"], dtRows["PhoneNumber"], dtRows["Email"]);
                }
            }
            return result;
        }
        public string SortBasedOnNameInDataTable(string City)
        {
            AddDataInDatatable();
            string result = "";
            var modifiedList = (from ContactList in dataTable.AsEnumerable() orderby ContactList.Field<string>("FirstName") where ContactList.Field<string>("City") == City select ContactList);
            Console.WriteLine("After sorting");
            foreach (var dtRows in modifiedList)
            {
                result += dtRows["FirstName"] + " ";
                Console.WriteLine("{0} \t {1} \t {2} \t {3} \t {4} \t {5} \t {6} \t {7} \t {8}\n", dtRows["ID"], dtRows["FirstName"], dtRows["LastName"], dtRows["Address"], dtRows["City"], dtRows["State"], dtRows["Zip"], dtRows["PhoneNumber"], dtRows["Email"]);

            }
            return result;
        }
    }
}
