using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SQLite;

using MicroMotion.Sqlite;

namespace MicroMotion.Utils
{
    public class SqliteUtil : IDisposable
    {
        private static SqliteUtil instance;

        public static SqliteUtil Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SqliteUtil();
                }
                return instance;
            }
        }

        public List<DeviceUserSqliteObject> Datas { get; set; }

        public bool IsExistData
        {
            get { return Datas.Count > 0; }
        }

        public string TableName = "DeviceUserTable";
        public string DatabaseName = "MySQLiteData";
        SQLiteConnection conn;

        public SqliteUtil()
        {
            Datas = new List<DeviceUserSqliteObject>();

            conn = null;
            string dbPath = "Data Source =" + Environment.CurrentDirectory + 
                "/" + DatabaseName + ".db";

            conn = new SQLiteConnection(dbPath);//创建数据库实例，指定文件位置  
            conn.Open();//打开数据库，若文件不存在会自动创建  
            var data = new DeviceUserSqliteObject();
            string sql = string.Format("CREATE TABLE IF NOT EXISTS {0}({1});",
                TableName,data.CreateTableToString());//建表语句  
            SQLiteCommand cmdCreateTable = new SQLiteCommand(sql, conn);
            cmdCreateTable.ExecuteNonQuery();//如果表不存在，创建数据表  
        }

        public void InsertData(DeviceUserSqliteObject data)  
        {
            SQLiteCommand cmdInsert = new SQLiteCommand(conn);
            cmdInsert.CommandText = string.Format("INSERT INTO {0} VALUES({1})",
                TableName,data.ValuesTableToString());
            cmdInsert.ExecuteNonQuery();
        }

        public void FindDataFromTime(DateTime startTime,DateTime endTime)
        {
            Datas.Clear();
            List<DeviceUserSqliteObject> datas = new List<DeviceUserSqliteObject>();
            SQLiteCommand cmdInsert = new SQLiteCommand(conn);
            cmdInsert.CommandText = string.Format("SELECT * FROM {0} ",TableName);
            cmdInsert.ExecuteNonQuery();
            SQLiteDataReader dataReader = cmdInsert.ExecuteReader();
            while (dataReader.Read())
            {
                var timeFindStr = dataReader["StartTime"].ToString();
                DateTime time;
                if (DateTime.TryParseExact(timeFindStr, "yyyy/MM/dd HH:mm:ss",
                    System.Globalization.CultureInfo.CurrentCulture,
                    System.Globalization.DateTimeStyles.NoCurrentDateDefault, out time) == false)
                    continue;
                if (time >= startTime && time <= endTime)
                {
                    datas.Add(new DeviceUserSqliteObject() 
                    {
                        UserName = dataReader["UserName"].ToString(),
                        MaterialName = dataReader["MaterialName"].ToString(),
                        TypeName = dataReader["TypeName"].ToString(),
                        QualityFlow = dataReader["QualityFlow"].ToString(),
                        Density = dataReader["Density"].ToString(),
                        Temperature = dataReader["Temperature"].ToString(),
                        TotalAmount = dataReader["TotalAmount"].ToString(),
                        Goal = dataReader["Goal"].ToString(),
                        Real = dataReader["Real"].ToString(),
                        Date = dataReader["Date"].ToString(),
                        StartTime = dataReader["StartTime"].ToString(),
                        EndTime = dataReader["EndTime"].ToString(),
                    });
                }
            }
            Datas = datas;
        }

        public void FindDataFromTypeName(string typeName)
        {
            Datas.Clear();
            List<DeviceUserSqliteObject> datas = new List<DeviceUserSqliteObject>();
            SQLiteCommand cmdInsert = new SQLiteCommand(conn);
            cmdInsert.CommandText = string.Format("SELECT * FROM {0} ", TableName);
            cmdInsert.ExecuteNonQuery();
            SQLiteDataReader dataReader = cmdInsert.ExecuteReader();
            while (dataReader.Read())
            {
                var typeNameFindStr = dataReader["TypeName"].ToString();
                if (typeNameFindStr == typeName)
                {
                    datas.Add(new DeviceUserSqliteObject()
                    {
                        UserName = dataReader["UserName"].ToString(),
                        MaterialName = dataReader["MaterialName"].ToString(),
                        TypeName = dataReader["TypeName"].ToString(),
                        QualityFlow = dataReader["QualityFlow"].ToString(),
                        Density = dataReader["Density"].ToString(),
                        Temperature = dataReader["Temperature"].ToString(),
                        TotalAmount = dataReader["TotalAmount"].ToString(),
                        Goal = dataReader["Goal"].ToString(),
                        Real = dataReader["Real"].ToString(),
                        Date = dataReader["Date"].ToString(),
                        StartTime = dataReader["StartTime"].ToString(),
                        EndTime = dataReader["EndTime"].ToString(),
                    });
                }
            }
            Datas = datas;
        }

        public void FindDataFromMaterialName(string materialName)
        {
            Datas.Clear();
            List<DeviceUserSqliteObject> datas = new List<DeviceUserSqliteObject>();
            SQLiteCommand cmdInsert = new SQLiteCommand(conn);
            cmdInsert.CommandText = string.Format("SELECT * FROM {0} ", TableName);
            cmdInsert.ExecuteNonQuery();
            SQLiteDataReader dataReader = cmdInsert.ExecuteReader();
            while (dataReader.Read())
            {
                var materialFindStr = dataReader["MaterialName"].ToString();
                if (materialFindStr == materialName)
                {
                    datas.Add(new DeviceUserSqliteObject()
                    {
                        UserName = dataReader["UserName"].ToString(),
                        MaterialName = dataReader["MaterialName"].ToString(),
                        TypeName = dataReader["TypeName"].ToString(),
                        QualityFlow = dataReader["QualityFlow"].ToString(),
                        Density = dataReader["Density"].ToString(),
                        Temperature = dataReader["Temperature"].ToString(),
                        TotalAmount = dataReader["TotalAmount"].ToString(),
                        Goal = dataReader["Goal"].ToString(),
                        Real = dataReader["Real"].ToString(),
                        Date = dataReader["Date"].ToString(),
                        StartTime = dataReader["StartTime"].ToString(),
                        EndTime = dataReader["EndTime"].ToString(),
                    });
                }
            }
            Datas = datas;
        }

        public void FindDataFromUserName(string userName)
        {
            Datas.Clear();
            List<DeviceUserSqliteObject> datas = new List<DeviceUserSqliteObject>();
            SQLiteCommand cmdInsert = new SQLiteCommand(conn);
            cmdInsert.CommandText = string.Format("SELECT * FROM {0} ", TableName);
            cmdInsert.ExecuteNonQuery();
            SQLiteDataReader dataReader = cmdInsert.ExecuteReader();
            while (dataReader.Read())
            {
                var userFindStr = dataReader["UserName"].ToString();
                if (userFindStr == userName)
                {
                    datas.Add(new DeviceUserSqliteObject()
                    {
                        UserName = dataReader["UserName"].ToString(),
                        MaterialName = dataReader["MaterialName"].ToString(),
                        TypeName = dataReader["TypeName"].ToString(),
                        QualityFlow = dataReader["QualityFlow"].ToString(),
                        Density = dataReader["Density"].ToString(),
                        Temperature = dataReader["Temperature"].ToString(),
                        TotalAmount = dataReader["TotalAmount"].ToString(),
                        Goal = dataReader["Goal"].ToString(),
                        Real = dataReader["Real"].ToString(),
                        Date = dataReader["Date"].ToString(),
                        StartTime = dataReader["StartTime"].ToString(),
                        EndTime = dataReader["EndTime"].ToString(),
                    });
                }
            }
            Datas = datas;
        }

        public void Dispose()
        {
            if (conn != null)
                conn.Close();
        }
    }
}
