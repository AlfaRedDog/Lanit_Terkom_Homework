using HW3.Records;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HW3.CRUD
{
    public interface ICRUD
    {
        void CreateRecord(IRecord record, string tableName, string sqlQuery = "");

        void UpdateRecord<T>(Guid id, string column, T value, string tableName, string sqlQuery = "");

        void DeleteRecord<T>(T value, string column, string tableName, string sqlQuery = "");

        List<IRecord> ReadRecord<T>(T value, string column, string tableName, string sqlQuery = "");

        void ClearTable(string tableName);

        List<string> GetColumns(string tableName);

        void ExecuteQuery(string sqlQuery, SqlConnection conn);

    }
}
