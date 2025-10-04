using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Database.Queries
{
    public static class WarehouseQueries
    {
        public static string GetAllWarehouseRecords => @"
        SELECT w.*, 
               g.Name as GoodsName,
               s.FullName as SupplierName,
               c.FullName as CustomerName,
               e.FullName as EmployeeName
        FROM Warehouse w
        LEFT JOIN Goods g ON w.GoodsId = g.Id
        LEFT JOIN Suppliers s ON w.SuppliersId = s.Id
        LEFT JOIN Customers c ON w.CustomerId = c.Id
        LEFT JOIN Employee e ON w.EmployeeId = e.Id";

        public static string GetWarehouseRecordById => @"
        SELECT w.*, 
               g.Name as GoodsName,
               s.FullName as SupplierName,
               c.FullName as CustomerName,
               e.FullName as EmployeeName
        FROM Warehouse w
        LEFT JOIN Goods g ON w.GoodsId = g.Id
        LEFT JOIN Suppliers s ON w.SuppliersId = s.Id
        LEFT JOIN Customers c ON w.CustomerId = c.Id
        LEFT JOIN Employee e ON w.EmployeeId = e.Id
        WHERE w.rowid = @Id"; 

        public static string InsertWarehouseRecord => @"
        INSERT INTO Warehouse (ReceiptDate, OrderDate, DispatchDate, GoodsId, CustomerId, SuppliersId, DeliveryMethod, Volume, Price, EmployeeId) 
        VALUES (@ReceiptDate, @OrderDate, @DispatchDate, @GoodsId, @CustomerId, @SuppliersId, @DeliveryMethod, @Volume, @Price, @EmployeeId);
        SELECT last_insert_rowid();";

        public static string UpdateWarehouseRecord => @"
        UPDATE Warehouse 
        SET ReceiptDate = @ReceiptDate, 
            OrderDate = @OrderDate, 
            DispatchDate = @DispatchDate, 
            GoodsId = @GoodsId, 
            CustomerId = @CustomerId, 
            SuppliersId = @SuppliersId, 
            DeliveryMethod = @DeliveryMethod, 
            Volume = @Volume, 
            Price = @Price, 
            EmployeeId = @EmployeeId
        WHERE rowid = @Id";

        public static string DeleteWarehouseRecord => "DELETE FROM Warehouse WHERE rowid = @Id";
    }
}
