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

        public static List<string> tables = GetTables();

        public void CreateRecord(IRecord record, string tableName, string sqlQuery = "")
        {
            try
            {
                if (sqlQuery == "")
                {
                    sqlQuery = $"INSERT INTO {tableName} VALUES (";

                    foreach (var prop in record.GetType().GetProperties())
                    {
                        sqlQuery += $"'{prop.GetValue(record)}', ";
                    }
                    sqlQuery = sqlQuery.Remove(sqlQuery.Length - 2) + ")";
                }

                SqlConnection conn = new SqlConnection(_connString);
                ExecuteQuery(sqlQuery, conn);
            }
            catch(Exception ex)
            {
                MenuOutput.PrintInfoException("CreateRecord exception", ex);
            }
        }

        public void DeleteRecord<T>(T value, string column, string tableName, string sqlQuery = "")
        {
            try
            {
                if (sqlQuery == "")
                {
                    sqlQuery = $"DELETE FROM {tableName} WHERE {column}='{value}'";
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
            catch(Exception ex)
            {
                MenuOutput.PrintInfoException("DeleteRecord exception", ex);
            }
        }

        public List<IRecord> ReadRecord<T>(T value, string column, string tableName, string sqlQuery = "")
        {
            SqlConnection conn = new SqlConnection(_connString);
            try
            {
                conn.Open();
                if (sqlQuery == "")
                {
                    sqlQuery = $"SELECT * FROM {tableName} WHERE {column}='{value}'";
                }

                if (!ReferenceEquals(sqlQuery, null))
                {
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<IRecord> result = new();

                            while (reader.Read())
                            {
                                List<string> row = new();
                                for(int i = 0; i < reader.FieldCount; i++)
                                {
                                    row.Add(reader.GetValue(i).ToString());
                                }
                                result.Add(ParseListToIRecord(tableName, row));
                            }
                            return result;
                        }
                    }
                }
                else
                {
                    MenuOutput.ColorWriteLine(ConsoleColor.Red, "incorrect value");
                    return null;
                }
            }
            catch(Exception ex)
            {
                MenuOutput.PrintInfoException("ReadRecord exception", ex);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public void UpdateRecord<T>(Guid id, string column, T value, string tableName, string sqlQuery = "")
        {
            try
            {
                if(sqlQuery == "")
                    sqlQuery = $"UPDATE {tableName} SET {column} = '{value}' WHERE Id = '{id}'"; // проверять value на null
                
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
            catch(Exception ex)
            {
                MenuOutput.PrintInfoException("UpdateRecord exception", ex);
            }
            
        }

        public void ClearTable(string tableName)
        {
            SqlConnection conn = new SqlConnection(_connString);
            ExecuteQuery($"DELETE FROM {tableName}", conn);
        }

        public List<IRecord> AnyQueryCrud(string sqlQuery, string tableName)
        {
            if (sqlQuery.Contains("DELETE"))
            {
                DeleteRecord<int>(0, "", tableName, sqlQuery);
                return null;
            }

            if (sqlQuery.Contains("INSERT"))
            {
                CreateRecord(new Item(), tableName, sqlQuery);
                return null;
            }

            if (sqlQuery.Contains("UPDATE"))
            {
                UpdateRecord<int>(Guid.Empty, "", 0, tableName, sqlQuery);
                return null;
            }

            if (sqlQuery.Contains("SELECT"))
            {
                return ReadRecord<int>(0, "", tableName, sqlQuery);
            }
            return null;
        }

        public static List<string> GetTables()
        {
            using (SqlConnection connection = new SqlConnection(_connString))
            {
                connection.Open();
                DataTable schema = connection.GetSchema("Tables");
                List<string> TableNames = new List<string>();

                foreach (DataRow row in schema.Rows)
                {
                    TableNames.Add(row[2].ToString());
                }
                connection.Close();
                return TableNames;
            }
        }

        public IRecord ParseListToIRecord(string tableName, List<string> values)
        {
            IRecord record;
            switch (tableName)
            {
                case "Items": record = new Item(values); return record;
                case "Customers": record = new Customer(values); return record;
                case "Orders": record = new Order(values); return record;
                case "Providers": record = new Provider(values); return record;
                default: throw new ArgumentException("Name of table is wrong");
            }
        }

        public void ExecuteQuery(string sqlQuery, SqlConnection conn)
        {
            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            catch(Exception ex)
            {
                MenuOutput.PrintInfoException("ExecuteQuery exception", ex);
            }
        }

        public List<string> GetColumns(string tableName)
        {
            string sqlQuery = $"SELECT * FROM {tableName} WHERE 1=0";

            SqlConnection conn = new SqlConnection(_connString);
            conn.Open();

            List<string> columns = new();
            using (SqlCommand cmd = new SqlCommand(sqlQuery, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable schemaTable = reader.GetSchemaTable();

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
                }
            }

            conn.Close();
            return columns;
        }
    }
}
