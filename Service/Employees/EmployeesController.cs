using Application.Employees.Commands.CreateEmployee;
using Application.Employees.Commands.UpdateEmployee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Employees
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ICreateEmployeeCommand _createCommand;
        private readonly IUpdateEmployeeCommand _updateCommand;

        public EmployeesController(ICreateEmployeeCommand createCommand, 
            IUpdateEmployeeCommand updateCommand)
        {
            _createCommand = createCommand;
            _updateCommand = updateCommand;
        }

        [HttpPost]
        [Route("add-employee")]
        public IActionResult Create([FromForm] CreateEmployeeModel model)
        {
            _createCommand.Execute(model);

            return Ok();
        }


        //THUNDERCLIENT
        [HttpPut]
        [Route("update-employee")]
        public IActionResult Update([FromBody] UpdateEmployeeModel model)
        {
            _updateCommand.Execute(model);

            return Ok();
        }
    }
}
