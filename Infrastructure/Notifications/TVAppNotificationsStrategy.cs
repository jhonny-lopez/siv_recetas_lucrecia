using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Notifications
{
    public class TVAppNotificationsStrategy : INotifications
    {
        public string To { get; set; }

        public void Notify(string message)
        {
            //TODO: Implementar código para enviar notificación a TV App
            Console.WriteLine("Se envió el mensaje al televisor");
        }
    }
}
