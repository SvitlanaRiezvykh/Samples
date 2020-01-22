using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace EmployeeManagament.Models
{
    [DataContract]
    public class EmployeeDto
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Specialization { get; set; }
        [DataMember]
        public string Position { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Salary { get; set; }
        [DataMember]
        public string Experience { get; set; }
        [DataMember]
        public string TeamMembers { get; set; }
    }
}