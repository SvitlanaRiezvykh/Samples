using EmployeeManagament.Models;
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
        EmployeeDto GetEmployeesById(string id);

        [OperationContract]
        [WebGet(UriTemplate = "/employees/specialization/{specialization}", ResponseFormat = WebMessageFormat.Json)]
        EmployeeDto GetEmployeesBySpecialization(string specialization);

        [OperationContract]
        [WebInvoke(UriTemplate = "/add",
                    Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Bare)]
        void AddEmployee(EmployeeDto employeeDto);

        [OperationContract]
        [WebInvoke(UriTemplate = "/update/id/{id}",
                    Method = "PUT",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json)]
        void UpdateEmployee(EmployeeDto employeeDto, string id);
    }

    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
