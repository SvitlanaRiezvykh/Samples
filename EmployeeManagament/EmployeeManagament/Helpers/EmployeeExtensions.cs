using EmployeeManagament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;

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

        public static Employee ToEmloyee(this EmployeeDto employeeDto, string id = null)
        {
            var employee = new Employee()
            {
                Specialization = employeeDto.Specialization,
                Experience = Convert.ToDouble(employeeDto.Experience),
                Name = employeeDto.Name,
                Position = employeeDto.Position,
                Salary = Convert.ToInt32(employeeDto.Salary),
                TeamMembers = employeeDto.TeamMembers
            };

            if (id != null)
            {
                employee.Id = Convert.ToInt32(id);
            }
            return employee;
        }

        public static void ValidateEmployeeData(this EmployeeDto employeeDto)
        {
            if (employeeDto == null)
            {
                throw new WebFaultException<string>("Employee data shold be provided!", HttpStatusCode.BadRequest);
            }

            if (employeeDto.Specialization != null && employeeDto.Specialization.Equals("Manager")
                && string.IsNullOrEmpty(employeeDto.TeamMembers))
            {
                throw new WebFaultException<string>("Team members data shold be provided for employee with Manager spetialization!", HttpStatusCode.BadRequest);
            }
        }
    }
}
