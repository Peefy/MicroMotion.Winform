using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SQLite;

namespace MicroMotion.Sqlite
{
    public abstract class BaseSqliteObject
    {
        public int ID { get; set; }

        public virtual string CreateTableToString()
        {
            return "";
        }

        public virtual string ValuesTableToString()
        {
            return "";
        }

    }
}
