using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Database.Queries
{
    public static class SupplierQueries
    {
        public static string GetAllSuppliers => @"
        SELECT s.*, 
               g1.Name as Goods1Name, 
               g2.Name as Goods2Name,
               g3.Name as Goods3Name 
        FROM Suppliers s
        LEFT JOIN Goods g1 ON s.GoodsId1 = g1.Id
        LEFT JOIN Goods g2 ON s.GoodsId2 = g2.Id
        LEFT JOIN Goods g3 ON s.GoodsId3 = g3.Id";

        public static string GetSupplierById => @"
        SELECT s.*, 
               g1.Name as Goods1Name, 
               g2.Name as Goods2Name,
               g3.Name as Goods3Name 
        FROM Suppliers s
        LEFT JOIN Goods g1 ON s.GoodsId1 = g1.Id
        LEFT JOIN Goods g2 ON s.GoodsId2 = g2.Id
        LEFT JOIN Goods g3 ON s.GoodsId3 = g3.Id
        WHERE s.Id = @Id";

        public static string InsertSupplier => @"
        INSERT INTO Suppliers (FullName, Address, Phone, GoodsId1, GoodsId2, GoodsId3) 
        VALUES (@FullName, @Address, @Phone, @GoodsId1, @GoodsId2, @GoodsId3);
        SELECT last_insert_rowid();";

        public static string UpdateSupplier => @"
        UPDATE Suppliers 
        SET FullName = @FullName, 
            Address = @Address, 
            Phone = @Phone, 
            GoodsId1 = @GoodsId1, 
            GoodsId2 = @GoodsId2, 
            GoodsId3 = @GoodsId3
        WHERE Id = @Id";

        public static string DeleteSupplier => "DELETE FROM Suppliers WHERE Id = @Id";
    }
}
