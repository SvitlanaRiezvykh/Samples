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
        const string XmlPath = "App_data/Data.xml";
        readonly IEmployeeRepository EmployeeRepository;

        public EmployeeService()
        {
            EmployeeRepository = new EmployeeRepository(XmlPath);
        }

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            EmployeeRepository = employeeRepository;
        }

        public IEnumerable<EmployeeDto> GetEmployees()
        {
            return EmployeeRepository.GetEmployees().ToEmloyeeDtoCollection();
        }

        public EmployeeDto GetEmployeeById(string id)
        {
            if (!int.TryParse(id, out _))
            {
                throw new WebFaultException<string>("Id shold have an integer format", HttpStatusCode.BadRequest);
            }

            return GetEmployees(id, (x) => EmployeeRepository.GetEmployeeById(x)).ToEmloyeeDto();
        }

        public IEnumerable<EmployeeDto> GetEmployeesBySpecialization(string specialization)
        {
            return GetEmployees(specialization, (x) => EmployeeRepository.GetEmployeesBySpecialization(x)).ToEmloyeeDtoCollection();
        }

        public void AddEmployee(EmployeeDto employeeDto)
        {
            employeeDto.ValidateEmployeeData();
            Employee employeeToCreate = employeeDto.ToEmloyee();

            EmployeeRepository.Create(employeeToCreate);

            WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Created;
        }

        public void UpdateEmployee(EmployeeDto employeeDto, string id)
        {
            employeeDto.ValidateEmployeeData();
            Employee employeeToCreate = employeeDto.ToEmloyee(id);

            try
            {
                EmployeeRepository.UpdateById(employeeToCreate);
            }
            catch (UserNotFoundException)
            {
                throw new WebFaultException<string>("Employee with provided search criteria could not be found!", HttpStatusCode.NotFound);
            }
        }

        private T GetEmployees<T>(string value, Func<string, T> getEmployeeFunc)
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
