using System;

namespace EmployeeManagament.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("User haven't been found by provided criteria")
        {

        }
    }
}
