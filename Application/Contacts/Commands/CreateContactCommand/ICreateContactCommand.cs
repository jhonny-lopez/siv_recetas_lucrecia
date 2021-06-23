namespace Application.Contacts.Commands.CreateContactCommand
{
    public interface ICreateContactCommand
    {
        void Execute(ContactModel model);
    }
}