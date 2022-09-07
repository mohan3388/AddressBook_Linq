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
    }
}
