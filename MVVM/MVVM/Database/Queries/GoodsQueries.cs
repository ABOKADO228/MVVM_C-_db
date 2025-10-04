using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Database.Queries
{
    public static class GoodsQueries
    {
        public static string GetAllGoods => @"
        SELECT g.*, gt.FullName as GoodsTypeName
        FROM Goods g
        LEFT JOIN GoodsType gt ON g.TypeId = gt.Id";

        public static string GetGoodsById => @"
        SELECT g.*, gt.FullName as GoodsTypeName
        FROM Goods g
        LEFT JOIN GoodsType gt ON g.TypeId = gt.Id
        WHERE g.Id = @Id";

        public static string InsertGoods => @"
        INSERT INTO Goods (TypeId, Manufacturer, Name, StorageConditions, Package, ExpirationDate) 
        VALUES (@TypeId, @Manufacturer, @Name, @StorageConditions, @Package, @ExpirationDate);
        SELECT last_insert_rowid();";

        public static string UpdateGoods => @"
        UPDATE Goods 
        SET TypeId = @TypeId, 
            Manufacturer = @Manufacturer, 
            Name = @Name, 
            StorageConditions = @StorageConditions, 
            Package = @Package, 
            ExpirationDate = @ExpirationDate
        WHERE Id = @Id";

        public static string DeleteGoods => "DELETE FROM Goods WHERE Id = @Id";
    }
}
