using System;
using System.Collections.Generic;
using System.Text;

using MicroMotion.Sqlite;

namespace MicroMotion.Sqlite
{
    public class DeviceUserSqliteObject : BaseSqliteObject
    {
        public string UserName { get; set; }

        public string MaterialName { get; set; }
        public string TypeName { get; set; }
        
        public string QualityFlow { get; set; }
        public string Density { get; set; }
        public string Temperature { get; set; }
        public string TotalAmount { get; set; }

        public string Goal { get; set; }
        public string Real { get; set; }

        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

       
        public override string CreateTableToString()
        {
            return "ID" + " integer, " +

                "UserName" + " varchar(30), " +

                "MaterialName" + " varchar(30), " +
                "TypeName" + " varchar(20), " +

                "QualityFlow" + " varchar(20), " +
                "Density" + " varchar(20), " +
                "Temperature" + " varchar(20), " +
                "TotalAmount" + " varchar(20), " +

                "Goal" + " varchar(20), " +
                "Real" + " varchar(20), " +

                "Date" + " varchar(20), " +
                "StartTime" + " varchar(20), " +
                "EndTime" + " varchar(20)";
        }

        public override string ValuesTableToString()
        {
            return ID.ToString() + ", " +

                "'" + UserName + "', " +

                "'" + MaterialName + "', " +
                "'" + TypeName + "', " +

                "'" + QualityFlow + "', " +
                "'" + Density + "', " +
                "'" + Temperature + "', " +
                "'" + TotalAmount + "', " +

                "'" + Goal + "', " +
                "'" + Real + "', " +

                "'" + Date + "', " +
                "'" + StartTime + "', " +
                "'" + EndTime + "'";
        }

    }
}
