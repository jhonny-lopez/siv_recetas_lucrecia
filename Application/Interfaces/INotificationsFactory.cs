using Domain.Contacts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    //Patrón Factory
    public interface INotificationsFactory
    {
        INotifications Build(Contact contact);
    }
}
