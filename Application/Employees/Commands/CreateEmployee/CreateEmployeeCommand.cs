using Application.Interfaces;
using Domain.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : ICreateEmployeeCommand
    {
        private readonly IDatabaseService _databaseService;

        public CreateEmployeeCommand(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public void Execute(CreateEmployeeModel model)
        {
            var employee = new Employee
            {
                EmailAddress = model.EmailAddress,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            _databaseService.Employees.Add(employee);

            _databaseService.Save();
        }
    }
}
