namespace EmployeeManagament.Models
{
    public class Employee
    {
        public int? Id { get; set; }
        public string Specialization { get; set; }
        public string Position { get; set; }
        public string Name { get; set; }
        public int? Salary { get; set; }
        public double? Experience { get; set; }
        public string TeamMembers { get; set; }
    }
}