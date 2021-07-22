using Domain.Employees;
using System.Collections.Generic;

namespace Application.Employees.Queries.GetEmployeesList
{
    public interface IGetEmployeesListQuery
    {
        ICollection<Employee> Execute();
    }
}