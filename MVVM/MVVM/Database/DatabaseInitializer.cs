using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Database
{
    public class DatabaseInitializer
    {
        private readonly SQLiteHelper _dbHelper;

        public DatabaseInitializer(SQLiteHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public void InitializeDatabase()
        {
            CreateTables();
            InsertSampleData();
        }

        private void CreateTables()
        {
            var tables = new[]
            {
                @"CREATE TABLE IF NOT EXISTS Positions (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Salary DECIMAL NOT NULL CHECK(Salary>0),
                    Responsibilities TEXT,
                    Requirements TEXT
                )",
                @"CREATE TABLE IF NOT EXISTS Employees (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    FullName TEXT NOT NULL,
                    Age INTEGER NOT NULL,
                    Gender TEXT NOT NULL,
                    Address TEXT NOT NULL,
                    Phone TEXT NOT NULL,
                    PassportData TEXT NOT NULL,
                    PositionId INTEGER NOT NULL,
                    FOREIGN KEY (PositionId) REFERENCES Positions(Id)
                )",
                @"CREATE TABLE IF NOT EXISTS Goods(
                     Id INTEGER PRIMARY KEY AUTOINCREMENT,
                     TypeId INTEGER NOT NULL,
                     Manufacturer TEXT NOT NULL,
                     FullName TEXT NOT NULL,
                     StorageConditions TEXT,
                     Package TEXT,
                     ExpirationDate TEXT CHECK(date(ExpirationDate) IS NOT NULL),
                     FOREIGN KEY (Id) REFERENCES GoodsTypes(Id)
                     
                )", 
                @"CREATE TABLE IF NOT EXISTS GoodsTypes (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    FullName TEXT NOT NULL,
                    Description TEXT,
                    Peculiarities TEXT
                )",
                @"CREATE TABLE IF NOT EXISTS Suppliers (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    FullName TEXT NOT NULL,
                    Address TEXT NOT NULL,
                    Phone TEXT NOT NULL,
                    GoodsId1 INTEGER,
                    GoodsId2 INTEGER,
                    GoodsId3 INTEGER,
                    FOREIGN KEY (GoodsId1) REFERENCES Goods(Id),
                    FOREIGN KEY (GoodsId2) REFERENCES Goods(Id),
                    FOREIGN KEY (GoodsId3) REFERENCES Goods(Id)
                )",
                @"CREATE TABLE IF NOT EXISTS Customers (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    FullName TEXT NOT NULL,
                    Address TEXT NOT NULL,
                    Phone TEXT NOT NULL,
                    NeedGoods1 INTEGER, 
                    NeedGoods2 INTEGER, 
                    NeedGoods3 INTEGER,
                    FOREIGN KEY (NeedGoods1) REFERENCES Goods(Id),
                    FOREIGN KEY (NeedGoods2) REFERENCES Goods(Id),
                    FOREIGN KEY (NeedGoods3) REFERENCES Goods(Id)
                )",
                @"CREATE TABLE IF NOT EXISTS Warehouse (
                    ReceiptDate TEXT CHECK(date(ReceiptDate) IS NOT NULL),
                    OrderDate TEXT CHECK(date(OrderDate) IS NOT NULL),
                    DispatchDate TEXT CHECK(date(DispatchDate) IS NOT NULL),
                    GoodsId INTEGER NOT NULL,
                    CustomerId INTEGER NOT NULL,
                    SuppliersId INTEGER NOT NULL,
                    DeliveryMethod TEXT NOT NULL,
                    Volume INTEGER NOT NULL CHECK(Volume>0),
                    Price DECIMAL NOT NULL CHECK(Price>0),
                    EmployeeId INTEGER NOT NULL,
                    FOREIGN KEY (GoodsId) REFERENCES Goods(Id),
                    FOREIGN KEY (CustomerId) REFERENCES Customers(Id),
                    FOREIGN KEY (SuppliersId) REFERENCES Suppliers(Id),
                    FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)
                )"
            };

            foreach (var tableSql in tables)
            {
                _dbHelper.ExecuteNonQuery(tableSql);
            }
        }

        private void InsertSampleData()
        {
            var count = _dbHelper.ExecuteScalar("SELECT COUNT(*) FROM Positions");
            if (count is long longCount && longCount == 0)
            {
                // Вставляем тестовые данные
                //_dbHelper.ExecuteNonQuery(
                //    @"INSERT INTO Positions (Name, Salary, Responsibilities, Requirements) 
                //      VALUES ('Менеджер по продажам', 50000, 'Общение с клиентами', 'Опыт работы 1 год')");

                //_dbHelper.ExecuteNonQuery(
                //    @"INSERT INTO Positions (Name, Salary, Responsibilities, Requirements) 
                //      VALUES ('Технический специалист', 60000, 'Ремонт компьютеров', 'Техническое образование')");
            }
        }
    }
}

