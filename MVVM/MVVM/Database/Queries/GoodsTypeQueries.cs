using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Database.Queries
{
    public static class GoodsTypeQueries
    {
        public static string GetAllGoodsTypes => "SELECT * FROM GoodsType";
        public static string GetGoodsTypeById => "SELECT * FROM GoodsType WHERE Id = @Id";

        public static string InsertGoodsType => @"
        INSERT INTO GoodsType (FullName, Description, Peculiarities) 
        VALUES (@FullName, @Description, @Peculiarities);
        SELECT last_insert_rowid();";

        public static string UpdateGoodsType => @"
        UPDATE GoodsType 
        SET FullName = @FullName, 
            Description = @Description, 
            Peculiarities = @Peculiarities
        WHERE Id = @Id";

        public static string DeleteGoodsType => "DELETE FROM GoodsType WHERE Id = @Id";
    }
}
