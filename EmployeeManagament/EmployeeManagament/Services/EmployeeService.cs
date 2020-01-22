using EmployeeManagament.Exceptions;
using EmployeeManagament.Helpers;
using EmployeeManagament.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;

namespace EmployeeManagament.Services
{
    public class EmployeeService : IEmployeeService
    {
        readonly IEmployeeRepository EmployeeRepository = new EmployeeRepository();

        public IEnumerable<EmployeeDto> GetEmployees()
        {
            return EmployeeRepository.GetEmployees().ToEmloyeeDtoCollection();
        }

        public EmployeeDto GetEmployeesById(string id)
        {
            if (!int.TryParse(id, out _))
            {
                throw new WebFaultException<string>("Id shold have an integer format", HttpStatusCode.BadRequest);
            }

            return GetEmployees(id, (x) => EmployeeRepository.GetEmployeeById(x)).ToEmloyeeDto();
        }

        public EmployeeDto GetEmployeesBySpecialization(string specialization)
        {
            return GetEmployees(specialization, (x) => EmployeeRepository.GetEmployeeBySpecialization(x)).ToEmloyeeDto();
        }

        public void AddEmployee(EmployeeDto employeeDto)
        {
            if (employeeDto == null)
            {
                throw new WebFaultException<string>("Employee data shold be provided!", HttpStatusCode.BadRequest);
            }

            if (employeeDto.Specialization.Equals("Manager") && string.IsNullOrEmpty(employeeDto.TeamMembers))
            {
                throw new WebFaultException<string>("Team members data shold be provided for employee with Manager spetialization!", HttpStatusCode.BadRequest);
            }

            Employee employeeToCreate = new Employee()
            {
                Specialization = employeeDto.Specialization,
                Experience = Convert.ToDouble(employeeDto.Experience),
                Name = employeeDto.Name,
                Position = employeeDto.Position,
                Salary = Convert.ToInt32(employeeDto.Salary),
                TeamMembers = employeeDto.TeamMembers
            };

            EmployeeRepository.Create(employeeToCreate);

            WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Created;
            //WebOperationContext.Current.OutgoingResponse.StatusDescription = "Employee has been created";
        }

        public void UpdateEmployee(EmployeeDto employeeDto, string id)
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

            Employee employeeToCreate = new Employee()
            {
                Id = Convert.ToInt32(id),
                Specialization = employeeDto.Specialization,
                Experience = Convert.ToDouble(employeeDto.Experience),
                Name = employeeDto.Name,
                Position = employeeDto.Position,
                Salary = Convert.ToInt32(employeeDto.Salary),
                TeamMembers = employeeDto.TeamMembers
            };

            try
            {
                EmployeeRepository.UpdateById(employeeToCreate);
            }
            catch (UserNotFoundException)
            {
                throw new WebFaultException<string>("Employee with provided search criteria could not be found!", HttpStatusCode.NotFound);
            }
        }

        private Employee GetEmployees(string value, Func<string, Employee> getEmployeeFunc)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new WebFaultException<string>("Search criteria shold not be emplty!", HttpStatusCode.BadRequest);
            }

            var employees = getEmployeeFunc.Invoke(value);

            if (employees == null)
            {
                throw new WebFaultException<string>("Employee with provided search criteria could not be found!", HttpStatusCode.NotFound);
            }

            return employees;
        }
    }
}
