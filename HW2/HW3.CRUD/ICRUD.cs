using HW3.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3.CRUD
{
    public interface ICRUD
    {
        public void CreateRecord(IRecord record, string nameOfTable);

        public void UpdateRecord<T>(Guid id, string column, T value, string nameOfTable);

        public void DeleteRecord<T>(T value, string column, string nameOfTable);

        public void ReadRecord<T>(T value, string column, string nameOfTable);
    }
}
