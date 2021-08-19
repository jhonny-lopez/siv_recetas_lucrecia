using Application.Interfaces;
using Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Events.Commands.CreateEventWithoutDTO
{
    public class CreateEventCommand : ICreateEventCommandWithoutDTO
    {
        private readonly IDatabaseService _databaseService;

        public CreateEventCommand(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task ExecuteAsync(Event evnt)
        {
            evnt.Id = Guid.NewGuid();
            evnt.IsActive = true;

            await _databaseService.Events.AddAsync(evnt);

            _databaseService.Save();
        }
    }
}
