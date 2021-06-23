using System;
using System.Collections.Generic;
using System.Text;
using Application.Interfaces;

namespace Infrastructure.Notifications
{
    public class EmailNotificationsStrategy : INotifications
    {
        public string To { get; set; }

        public void Notify(string message)
        {
            //TODO: Implementar código para enviar correo electrónico
            Console.WriteLine("Correo electrónico enviado exitosamente a: " + To);
        }
    }
}
