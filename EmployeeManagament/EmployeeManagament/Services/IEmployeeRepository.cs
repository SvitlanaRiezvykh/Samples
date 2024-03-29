﻿using EmployeeManagament.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagament.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeById(string id);
        IEnumerable<Employee> GetEmployeesBySpecialization(string specialization);
        void Create(Employee employeeToCreate);
        void UpdateById(Employee employeeToUpdate);
    }
}