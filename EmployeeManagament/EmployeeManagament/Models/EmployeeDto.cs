using System;
using System.Collections.Generic;
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

        public override bool Equals(object obj)
        {
            return obj is EmployeeDto dto &&
                   Id == dto.Id &&
                   Specialization == dto.Specialization &&
                   Position == dto.Position &&
                   Name == dto.Name &&
                   Salary == dto.Salary &&
                   Experience == dto.Experience &&
                   TeamMembers == dto.TeamMembers;
        }

        public override int GetHashCode()
        {
            var hashCode = -21474461;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Specialization);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Position);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Salary);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Experience);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TeamMembers);
            return hashCode;
        }
    }
}