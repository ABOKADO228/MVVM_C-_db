using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Database.Queries
{
    public static class CustomerQueries
    {
        public static string GetAllCustomers => @"
        SELECT c.*, 
               g1.Name as Goods1Name, 
               g2.Name as Goods2Name,
               g3.Name as Goods3Name 
        FROM Customers c
        LEFT JOIN Goods g1 ON c.NeedGoods1 = g1.Id
        LEFT JOIN Goods g2 ON c.NeedGoods2 = g2.Id
        LEFT JOIN Goods g3 ON c.NeedGoods3 = g3.Id";

        public static string GetCustomerById => @"
        SELECT c.*, 
               g1.Name as Goods1Name, 
               g2.Name as Goods2Name,
               g3.Name as Goods3Name 
        FROM Customers c
        LEFT JOIN Goods g1 ON c.NeedGoods1 = g1.Id
        LEFT JOIN Goods g2 ON c.NeedGoods2 = g2.Id
        LEFT JOIN Goods g3 ON c.NeedGoods3 = g3.Id
        WHERE c.Id = @Id";

        public static string InsertCustomer => @"
        INSERT INTO Customers (FullName, Address, Phone, NeedGoods1, NeedGoods2, NeedGoods3) 
        VALUES (@FullName, @Address, @Phone, @NeedGoods1, @NeedGoods2, @NeedGoods3);
        SELECT last_insert_rowid();";

        public static string UpdateCustomer => @"
        UPDATE Customers 
        SET FullName = @FullName, 
            Address = @Address, 
            Phone = @Phone, 
            NeedGoods1 = @NeedGoods1, 
            NeedGoods2 = @NeedGoods2, 
            NeedGoods3 = @NeedGoods3 
        WHERE Id = @Id";

        public static string DeleteCustomer => "DELETE FROM Customers WHERE Id = @Id";
    }
}
