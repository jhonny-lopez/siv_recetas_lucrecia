using Application.Events.Queries.GetEventsCategoriesList;
using Domain.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Events
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsCategoriesController : ControllerBase
    {
        private readonly IGetEventsCategoriesListQuery _listQuery;

        public EventsCategoriesController(IGetEventsCategoriesListQuery listQuery)
        {
            _listQuery = listQuery;
        }
        
        //Método asíncrono, todo el stack es asíncrono
        [HttpGet("list")]
        public async Task<ICollection<EventCategory>> GetEventCategories()
        {
            return await _listQuery.ExecuteAsync();
        }
    }
}
