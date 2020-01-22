using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace EmployeeManagament.Models
{
    [DataContract]
    [Serializable()]
    public class EmployeeList
    {
        [DataMember]
        public IEnumerable<EmployeeDto> Employees { get; set; }
    }
}