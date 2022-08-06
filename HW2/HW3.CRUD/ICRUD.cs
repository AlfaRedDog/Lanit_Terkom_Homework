using HW3.Records;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HW3.CRUD
{
    public interface ICRUD
    {
        public void CreateRecord(IRecord record, string tableName, string sqlQuery = "");

        public void UpdateRecord<T>(Guid id, string column, T value, string tableName, string sqlQuery = "");

        public void DeleteRecord<T>(T value, string column, string tableName, string sqlQuery = "");

        public List<IRecord> ReadRecord<T>(T value, string column, string tableName, string sqlQuery = "");

        public void ClearTable(string tableName);

        public List<string> GetColumns(string tableName);

        public void ExecuteQuery(string sqlQuery, SqlConnection conn);

    }
}
