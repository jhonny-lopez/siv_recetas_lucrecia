using Application.Events.Commands.CreateEventWithDTO;
using Application.Events.Commands.CreateEventWithoutDTO;
using Application.Events.Queries.GetEventDetailsById;
using AutoMapper;
using Domain.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Events.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Events
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private ICreateEventWithDTOCommand _createCommandWithDTO;
        private ICreateEventCommandWithoutDTO _createCommandWithoutDTO;
        private IGetEventDetailsByIdQuery _getDetailsQuery;
        private IMapper _mapper;

        public EventsController(ICreateEventWithDTOCommand createCommand, ICreateEventCommandWithoutDTO createCommandWithoutDTO, IMapper mapper, IGetEventDetailsByIdQuery getDetailsQuery)
        {
            _createCommandWithDTO = createCommand;
            _createCommandWithoutDTO = createCommandWithoutDTO;
            _mapper = mapper;
            _getDetailsQuery = getDetailsQuery;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create([FromBody] CreateEventDTO model)
        {
            try
            {
                await _createCommandWithDTO.ExecuteAsync(model);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-without-dto")]
        public async Task<IActionResult> Create([FromBody] CreateEventModel model)
        {
            Event evt = _mapper.Map<Event>(model);

            await _createCommandWithoutDTO.ExecuteAsync(evt);

            return Ok();
        }

        [HttpGet("details/{id}")]
        public async Task<EventDetailDTO> Details(Guid id)
        {
            var eventDTO = await _getDetailsQuery.ExecuteAsync(id);

            return eventDTO;
        }
    }
}
