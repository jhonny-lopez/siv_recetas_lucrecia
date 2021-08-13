using Application.Interfaces;
using Domain.Events;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Events.Queries.GetEventsCategoriesList
{
    public class GetEventsCategoriesListQuery : IGetEventsCategoriesListQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetEventsCategoriesListQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<ICollection<EventCategory>> ExecuteAsync()
        {
            return await _databaseService.EventsCategories
                .OrderBy(it => it.Name)
                .ToListAsync();
        }
    }
}
