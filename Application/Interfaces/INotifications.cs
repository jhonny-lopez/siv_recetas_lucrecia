using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface INotifications
    {
        public string To { get; set; }
        void Notify(string message);
    }
}
