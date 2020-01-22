using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using EmployeeManagament.Exceptions;
using EmployeeManagament.Helpers;
using EmployeeManagament.Models;

namespace EmployeeManagament.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private const string XmlPath = "App_data/Data.xml";
        public XDocument Xmldoc { get; private set; }

        public IEnumerable<Employee> GetEmployees()
        {
            Xmldoc = XDocument.Load(XmlPath);
            var employees = LoadEmployees();

            return employees;
        }

        public Employee GetEmployeeById(string idAsString)
        {
            var id = Convert.ToInt32(idAsString);

            return GetEmployees().FirstOrDefault(x => x.Id == id);
        }

        public Employee GetEmployeeBySpecialization(string specialization)
        {
            return GetEmployees().FirstOrDefault(x => x.Specialization == specialization);
        }

        public void Create(Employee employeeToCreate)
        {
            var lastEmployee = GetEmployees()?.Last();

            employeeToCreate.Id = lastEmployee.Id + 1;

            var contentBuilder = new XElementBuilder();

            var content = contentBuilder.AddNodeIfNotEmpty("Id", employeeToCreate.Id.ToString())
                                        .AddNodeIfNotEmpty("Specialization", employeeToCreate.Specialization)
                                        .AddNodeIfNotEmpty("Position", employeeToCreate.Position)
                                        .AddNodeIfNotEmpty("Name", employeeToCreate.Name)
                                        .AddNodeIfNotEmpty("Salary", employeeToCreate.Salary.ToString())
                                        .AddNodeIfNotEmpty("Experience", employeeToCreate.Experience.ToString())
                                        .AddNodeIfNotEmpty("TeamMembers", employeeToCreate.TeamMembers).Build();

            EmployeeDescendants.Last()
                               .AddAfterSelf(new XElement("Employee", content.ToArray()));

            Xmldoc.Save(XmlPath);
        }

        public void UpdateById(Employee employeeToUpdate)
        {
            Xmldoc = XDocument.Load(XmlPath);
            XElement employee = EmployeeDescendants.FirstOrDefault(p => p.Element("Id").Value.Equals(employeeToUpdate.Id.ToString()));

            if (employee == null) throw new UserNotFoundException();

            employee.SetValueIfNotEmpty("Specialization", employeeToUpdate.Specialization);
            employee.SetValueIfNotEmpty("Position", employeeToUpdate.Position);
            employee.SetValueIfNotEmpty("Name", employeeToUpdate.Name);
            employee.SetValueIfNotEmpty("Salary", employeeToUpdate.Salary.ToString());
            employee.SetValueIfNotEmpty("Experience", employeeToUpdate.Experience.ToString());
            employee.SetValueIfNotEmpty("TeamMembers", employeeToUpdate.TeamMembers);

            Xmldoc.Save(XmlPath);
        }

        private IEnumerable<XElement> EmployeeDescendants => Xmldoc.Element("EmployeeList").Descendants("Employee");

        private IOrderedEnumerable<Employee> LoadEmployees()
        {
            return EmployeeDescendants.Select(p => new Employee
            {
                Id = Convert.ToInt32(p.Element("Id").Value),
                Specialization = p.Element("Specialization")?.Value,
                Position = p.Element("Position")?.Value,
                Name = p.Element("Name")?.Value,
                Salary = Convert.ToInt32(p.Element("Salary")?.Value),
                Experience = Convert.ToDouble(p.Element("Experience")?.Value),
                TeamMembers = p.Element("TeamMembers")?.Value
            }).OrderBy(p => p.Id);
        }
    }
}