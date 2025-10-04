using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Database.Queries
{
    public static class EmployeeQueries
    {
        public static string GetAllEmployees => @"
        SELECT e.*, p.FullName as PositionName
        FROM Employee e
        LEFT JOIN Positions p ON e.PositionId = p.Id";

        public static string GetEmployeeById => @"
        SELECT e.*, p.FullName as PositionName
        FROM Employee e
        LEFT JOIN Positions p ON e.PositionId = p.Id
        WHERE e.Id = @Id";

        public static string InsertEmployee => @"
        INSERT INTO Employee (FullName, Age, Gender, Address, Phone, Pass, PositionId) 
        VALUES (@FullName, @Age, @Gender, @Address, @Phone, @Pass, @PositionId);
        SELECT last_insert_rowid();";

        public static string UpdateEmployee => @"
        UPDATE Employee 
        SET FullName = @FullName, 
            Age = @Age, 
            Gender = @Gender, 
            Address = @Address, 
            Phone = @Phone, 
            Pass = @Pass, 
            PositionId = @PositionId
        WHERE Id = @Id";

        public static string DeleteEmployee => "DELETE FROM Employee WHERE Id = @Id";
    }
}

