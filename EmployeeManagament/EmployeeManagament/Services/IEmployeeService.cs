﻿using EmployeeManagament.Models;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace EmployeeManagament.Services
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/employees", ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<EmployeeDto> GetEmployees();

        [OperationContract]
        [WebGet(UriTemplate = "/employees/id/{id}", ResponseFormat = WebMessageFormat.Json)]
        EmployeeDto GetEmployeeById(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/employees/specialization/{specialization}", ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<EmployeeDto> GetEmployeesBySpecialization(string specialization);

        [OperationContract]
        [WebInvoke(UriTemplate = "/add",
                    Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Bare)]
        void AddEmployee(EmployeeDto employeeDto);

        [OperationContract]
        [WebInvoke(UriTemplate = "/update/id/{id}",
                    Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json)]
        void UpdateEmployee(EmployeeDto employeeDto, string id);
    }
}
