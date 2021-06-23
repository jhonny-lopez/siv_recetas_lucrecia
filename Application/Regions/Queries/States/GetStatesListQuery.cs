using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Regions.States
{
    public class GetStatesListQuery : IGetStatesListQuery
    {
        private readonly IDatabaseService _databaseService;

        public GetStatesListQuery(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public List<StateModel> Execute()
        {
            var states = _databaseService.States
                .Select(s => new StateModel()
                {
                    Id = s.Id,
                    Name = s.Name
                });

            return states.ToList();
        }
    }
}
