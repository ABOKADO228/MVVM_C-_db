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
            SELECT e.*, p.Name as PositionName 
            FROM Employees e 
            LEFT JOIN Positions p ON e.PositionId = p.Id";

        public static string GetEmployeeById => @"
            SELECT e.*, p.Name as PositionName 
            FROM Employees e 
            LEFT JOIN Positions p ON e.PositionId = p.Id 
            WHERE e.Id = @Id";

        public static string InsertEmployee => @"
            INSERT INTO Employees (FullName, Age, Gender, Address, Phone, PassportData, PositionId) 
            VALUES (@FullName, @Age, @Gender, @Address, @Phone, @PassportData, @PositionId);
            SELECT last_insert_rowid();";

        public static string UpdateEmployee => @"
            UPDATE Employees 
            SET FullName = @FullName, Age = @Age, Gender = @Gender, 
                Address = @Address, Phone = @Phone, PassportData = @PassportData, 
                PositionId = @PositionId 
            WHERE Id = @Id";

        public static string DeleteEmployee => "DELETE FROM Employees WHERE Id = @Id";
    }
}
