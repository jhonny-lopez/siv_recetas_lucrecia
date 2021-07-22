using Application.Interfaces;
using Domain.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Employees.Queries.GetEmployeesList
{
    public class GetEmployeesListQuery : IGetEmployeesListQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetEmployeesListQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public ICollection<Employee> Execute()
        {
            var employees = _databaseService.Employees
                .OrderBy(it => it.FirstName)
                .ToList();

            return employees;
        }
    }
}
