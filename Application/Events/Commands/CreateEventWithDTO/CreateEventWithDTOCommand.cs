using Application.Interfaces;
using Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Events.Commands.CreateEventWithDTO
{
    public class CreateEventWithDTOCommand : ICreateEventWithDTOCommand
    {
        private readonly IDatabaseService _databaseService;

        public CreateEventWithDTOCommand(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task ExecuteAsync(CreateEventDTO eventDTO)
        {
            var evnt = eventDTO.GetEvent();

            await _databaseService.Events.AddAsync(evnt);

            _databaseService.Save();
        }
    }
}
