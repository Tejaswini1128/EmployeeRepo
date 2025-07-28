using MySql.Data.MySqlClient;
using MySqlEmployeeApp;

var connectionString = "server=localhost;user=root;password=root;database=EmployeeManagement";

using var connection = new MySqlConnection(connectionString);
connection.Open();

string query = @"
    SELECT e.EmployeeID, e.Name, d.DepartmentName, s.Amount AS Salary
    FROM Employees e
    JOIN Departments d ON e.DepartmentID = d.DepartmentID
    JOIN Salaries s ON e.EmployeeID = s.EmployeeID";

using var cmd = new MySqlCommand(query, connection);
using var reader = cmd.ExecuteReader();

var employees = new List<Employee>();

while (reader.Read())
{
    employees.Add(new Employee
    {
        EmployeeID = reader.GetInt32("EmployeeID"),
        Name = reader.GetString("Name"),
        DepartmentName = reader.GetString("DepartmentName"),
        Salary = reader.GetDecimal("Salary")
    });
}

foreach (var emp in employees)
{
    Console.WriteLine($"ID: {emp.EmployeeID}, Name: {emp.Name}, Dept: {emp.DepartmentName}, Salary: {emp.Salary}");
}
