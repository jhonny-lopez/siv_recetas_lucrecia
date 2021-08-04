using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}
