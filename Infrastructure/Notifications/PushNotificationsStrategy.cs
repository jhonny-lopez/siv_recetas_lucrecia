using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Notifications
{
    public class PushNotificationsStrategy : INotifications
    {
        public string To { get; set; }

        public void Notify(string message)
        {
            //TODO: Implementar código para enviar Notificación PUSH
            Console.WriteLine("Notificación push enviada exitosamente a: " + To);
        }
    }
}
