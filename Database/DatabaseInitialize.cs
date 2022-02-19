using BaiThi.Entities;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiThi.Database
{
    class DatabaseInitialize
    {
        private static SQLiteConnection conn = new SQLiteConnection("lab3.db");

        public static bool CreateTables()
        {
            var sql = "CREATE TABLE IF NOT EXISTS contacts " +
            "(PhoneNumber NVARCHAR(100) PRIMARY KEY," +
            "Name NVARCHAR(255) NOT NULL)";
            using (var statement = conn.Prepare(sql))
            {
                statement.Step();
            }
            return true;
        }

        public bool InsertData(Contact obj)
        {
            var sql = $"INSERT INTO contacts (Name, PhoneNumber) VALUES ('{obj.Name}', '{obj.PhoneNumber}')";
            using (var statement = conn.Prepare(sql))
            {
                statement.Step();
            }
            return true;
        }

            public List<Contact> ListData()
            {
                var contacts = new List<Contact>();
                var sql = "SELECT * FROM contacts";
                using (var statement = conn.Prepare(sql))
                {
                    while (statement.Step() == SQLiteResult.ROW)
                    {
                        var name = (string)statement["Name"];
                        var phone = (string)statement["PhoneNumber"];
                        var obj = new Contact(name, phone);
                       contacts.Add(obj);
                    
                    }
                }
                return contacts;
        }

    }
}
