namespace Application.Employees.Commands.CreateEmployee
{
    public interface ICreateEmployeeCommand
    {
        void Execute(CreateEmployeeModel model);
    }
}