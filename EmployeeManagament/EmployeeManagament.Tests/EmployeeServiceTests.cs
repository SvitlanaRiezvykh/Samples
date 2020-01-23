using EmployeeManagament.Helpers;
using EmployeeManagament.Models;
using EmployeeManagament.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace EmployeeManagament.Tests
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        [Test]
        public void GetEmployeesTest()
        {
            var mockRepo = new Mock<IEmployeeRepository>();
            var employeeId = 1;
            var employee = GetFakeEmployee(employeeId);

            mockRepo.Setup(repo => repo.GetEmployeeById(It.Is<string>(s => s.Equals(employeeId.ToString())))).Returns(employee);
            var service = new EmployeeService(mockRepo.Object);

            var getEmployeeResult = service.GetEmployeeById(employeeId.ToString());

            Assert.AreEqual(employee.ToEmloyeeDto(), getEmployeeResult);
        }

        [Test]
        public void GetEmployeeByIdTest()
        {
            var mockRepo = new Mock<IEmployeeRepository>();
            var employees = new List<Employee>() { GetFakeEmployee() };

            mockRepo.Setup(repo => repo.GetEmployees()).Returns(employees);
            var service = new EmployeeService(mockRepo.Object);

            var getEmployeeResult = service.GetEmployees();

            CollectionAssert.AreEqual(employees.ToEmloyeeDtoCollection(), getEmployeeResult);
        }


        [Test]
        public void GetEmployeeBySpecializationTest()
        {
            var mockRepo = new Mock<IEmployeeRepository>();
            string specialization = "QA";
            var employees = new List<Employee>() { GetFakeEmployee(specialization: specialization) };

            mockRepo.Setup(repo => repo.GetEmployeesBySpecialization(It.Is<string>(s => s.Equals(specialization)))).Returns(employees);
            var service = new EmployeeService(mockRepo.Object);


            var getEmployeeResult = service.GetEmployeesBySpecialization(specialization);

            CollectionAssert.AreEqual(employees.ToEmloyeeDtoCollection(), getEmployeeResult);
        }

        private static Employee GetFakeEmployee(int employeeId = 1, string specialization = "QA")
        {
            return new Employee()
            {
                Name = "Tomas",
                Specialization = specialization,
                Salary = 900,
                Id = employeeId,
                Position = "Senior"
            };
        }
    }
}
