namespace Application.Employees.Commands.UpdateEmployee
{
    public interface IUpdateEmployeeCommand
    {
        void Execute(UpdateEmployeeModel model);
    }
}