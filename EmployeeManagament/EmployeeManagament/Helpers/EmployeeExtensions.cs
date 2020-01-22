using EmployeeManagament.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagament.Helpers
{
    public static class EmployeeExtensions
    {
        public static EmployeeDto ToEmloyeeDto(this Employee employee)
        {
            return new EmployeeDto()
            {
                Experience = employee.Experience?.ToString(),
                Id = employee.Id?.ToString(),
                Name = employee.Name,
                Position = employee.Position,
                Salary = employee.Id?.ToString(),
                Specialization = employee.Specialization,
                TeamMembers = employee.TeamMembers?.ToString()
            };
        }

        public static IEnumerable<EmployeeDto> ToEmloyeeDtoCollection(this IEnumerable<Employee> employeeCollection)
        {
            return employeeCollection.Select(x => x.ToEmloyeeDto());
        }
    }
}
