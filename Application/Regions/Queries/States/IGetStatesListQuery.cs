using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Regions.States
{
    public interface IGetStatesListQuery
    {
        public List<StateModel> Execute();
    }
}
