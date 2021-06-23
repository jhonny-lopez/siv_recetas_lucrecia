using Application.Regions.States;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Regions
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly IGetStatesListQuery _listQuery;

        public StatesController(IGetStatesListQuery listQuery)
        {
            _listQuery = listQuery;
        }

        [Route("get")]
        public IEnumerable<StateModel> Get()
        {
            return _listQuery.Execute();
        }
    }
}
