using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using test1019.Models;

namespace test1019.Repository
{
    class ClassR
    {
        public string ConnectionString
        {
            get
            {
                return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mm930\source\repos\nkust1019\test1019\test1019\data\Database1.mdf;Integrated Security=True";
            }
        }
        public void Insert(Class1 item)
        {
            var newItem = item;
            var connection = new SqlConnection(ConnectionString);
            connection.Open();

            var command = new SqlCommand("", connection);
            command.CommandText = string.Format(@"
            INSERT INTO OpenData(服務分類, 資料集名稱, 主要欄位說明)
            VALUES              (N'{0}', N'{1}', N'{2}')
            ", newItem.服務分類, newItem.資料集名稱, newItem.主要欄位說明);

            command.ExecuteNonQuery();

            connection.Close();
        }
    }
}
