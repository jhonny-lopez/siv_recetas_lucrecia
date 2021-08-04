using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand : IUpdateEmployeeCommand
    {
        private readonly IDatabaseService _databaseService;

        public UpdateEmployeeCommand(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public void Execute(UpdateEmployeeModel model)
        {
            var employee = _databaseService.Employees.Find(model.Id);

            if (employee == null)
            {
                throw new Exception("El empleado no existe");
            }

            employee.EmailAddress = model.EmailAddress;
            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;

            _databaseService.Save();
        }
    }
}
