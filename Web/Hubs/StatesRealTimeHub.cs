using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Hubs
{
    public class StatesRealTimeHub : Hub
    {
        public async Task UpdateStatesTableAsync(string message, string stateName)
        {
            await Clients.All.SendAsync("UpdateStatesTable", message, stateName);
        }
    }
}
