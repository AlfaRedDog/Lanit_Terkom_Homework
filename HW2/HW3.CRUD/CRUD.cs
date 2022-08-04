using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HW2.MenuOut;
using HW3.Records;

namespace HW3.CRUD
{
    public class CRUD : ICRUD
    {
        private const string _connString = "Server=localhost\\sqlexpress;Database=ShopDB;Trusted_Connection=True";

        public void CreateRecord(IRecord record, string nameOfTable)
        {
            string sqlQuery = $"INSERT INTO {nameOfTable} VALUES (";

            foreach (var prop in record.GetType().GetProperties())
            {
                if (prop.PropertyType != typeof(int))
                {
                    sqlQuery += $"'{prop.GetValue(record, null)}', ";
                }
                else
                {
                    sqlQuery += $"{prop.GetValue(record, null)}, ";
                }
            }
            sqlQuery = sqlQuery.Remove(sqlQuery.Length - 2) + ")";

            SqlConnection conn = new SqlConnection(_connString);
            ExecuteQuery(sqlQuery, conn);
        }

        public void DeleteRecord<T>(T value, string column, string nameOfTable)
        {
            string sqlQuery = "";
            if (value is string || value is Guid || value is DateTime)
            {
                sqlQuery = $"DELETE FROM {nameOfTable} WHERE {column}='{value}'";
            }
            if (value is Int32)
            {
                sqlQuery = $"DELETE FROM {nameOfTable} WHERE {column}={value}";
            }

            if (!string.IsNullOrEmpty(sqlQuery))
            {
                SqlConnection conn = new SqlConnection(_connString);
                ExecuteQuery(sqlQuery, conn);
            }
            else
            {
                MenuOutput.ColorWriteLine(ConsoleColor.Red, "incorrect value");
            }
        }

        public void ReadRecord<T>(T value, string column, string nameOfTable)
        {
            SqlConnection conn = new SqlConnection(_connString);
            conn.Open();

            string sqlQuery = "";
            if (value is string || value is Guid || value is DateTime)
            {
                sqlQuery = $"SELECT * FROM {nameOfTable} WHERE {column}='{value}'";
            }
            if (value is Int32)
            {
                sqlQuery = $"SELECT * FROM {nameOfTable} WHERE {column}={value}";
            }

            if (!string.IsNullOrEmpty(sqlQuery))
            {
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable schemaTable = reader.GetSchemaTable();

                        List<string> columns = new();
                        foreach (DataRow row in schemaTable.Rows)
                        {
                            foreach (DataColumn colum in schemaTable.Columns)
                            {
                                if (colum.ColumnName == "ColumnName")
                                {
                                    columns.Add(row[colum].ToString());
                                }
                            }
                        }

                        while (reader.Read())
                        {
                            foreach (string colum in columns)
                            {
                                Console.WriteLine(reader[colum]);
                            }
                        }
                    }
                }
            }
            else
            {
                MenuOutput.ColorWriteLine(ConsoleColor.Red, "incorrect value");
            }
            conn.Close();
        }

        public void UpdateRecord<T>(Guid id, string column, T value, string nameOfTable)
        {
            string sqlQuery = "";
            if (value is string || value is Guid || value is DateTime)
            {
                sqlQuery = $"UPDATE {nameOfTable} SET {column} = '{value}' WHERE Id = '{id}'";
            }
            if (value is Int32)
            {
                sqlQuery = $"UPDATE {nameOfTable} SET {column} = {value} WHERE Id = '{id}'";
            }

            if(!string.IsNullOrEmpty(sqlQuery))
            {
                SqlConnection conn = new SqlConnection(_connString);
                ExecuteQuery(sqlQuery, conn);
            }
            else
            {
                MenuOutput.ColorWriteLine(ConsoleColor.Red, "incorrect value");
            }
            
        }

        public void ClearTable(string nameOfTable)
        {
            SqlConnection conn = new SqlConnection(_connString);
            ExecuteQuery($"DELETE FROM {nameOfTable}", conn);
        }

        public void ExecuteQuery(string sqlQuery, SqlConnection conn)
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
            {
                cmd.ExecuteNonQuery();
            }
            conn.Close();
        }
    }
}
