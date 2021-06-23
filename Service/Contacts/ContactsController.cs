using Application.Contacts.Commands.CreateContactCommand;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Contacts
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly ICreateContactCommand _createCommand;

        public ContactsController(ICreateContactCommand createCommand)
        {
            _createCommand = createCommand;
        }

        [HttpPost("add")]
        public ActionResult CreateContact([FromForm]ContactModel model)
        {
            _createCommand.Execute(model);

            return Ok();
        }
    }
}
