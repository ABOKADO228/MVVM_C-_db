using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Database.Queries
{
    public static class PositionQueries
    {
        public static string GetAllPositions => "SELECT * FROM Positions";
        public static string GetPositionById => "SELECT * FROM Positions WHERE Id = @Id";

        public static string InsertPosition => @"
        INSERT INTO Positions (FullName, Salary, Responsibilities, Requirements) 
        VALUES (@FullName, @Salary, @Responsibilities, @Requirements);
        SELECT last_insert_rowid();";

        public static string UpdatePosition => @"
        UPDATE Positions 
        SET FullName = @FullName, 
            Salary = @Salary, 
            Responsibilities = @Responsibilities, 
            Requirements = @Requirements
        WHERE Id = @Id";

        public static string DeletePosition => "DELETE FROM Positions WHERE Id = @Id";
    }
}
