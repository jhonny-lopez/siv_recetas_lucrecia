using Application.Employees.Commands.CreateEmployee;
using Application.Employees.Queries.GetEmployeesList;
using Common.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Web.Areas.Identity.Data;
using Web.Models.Employees;

namespace Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IGetEmployeesListQuery _listQuery;
        private readonly ICreateEmployeeCommand _createCommand;
        private readonly UserManager<MyIdentityUser> _userManager;
        private readonly IEmailSender _emailSender;
        private readonly GeneralOptions _generalOptions;

        public EmployeesController(IGetEmployeesListQuery listQuery, 
            ICreateEmployeeCommand createCommand, 
            UserManager<MyIdentityUser> userManager, 
            IEmailSender emailSender, 
            IOptions<GeneralOptions> generalOptions)
        {
            _listQuery = listQuery;
            _createCommand = createCommand;
            _userManager = userManager;
            _emailSender = emailSender;
            _generalOptions = generalOptions.Value;
        }

        public IActionResult Index()
        {
            var model = new IndexViewModel();

            model.Employees = _listQuery.Execute().ToList();

            return View(model);
        }

        public IActionResult Create()
        {
            var model = new CreateEmployeeViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeViewModel model)
        {
            _createCommand.Execute(new CreateEmployeeModel()
            {
                EmailAddress = model.EmailAddress,
                FirstName = model.FirstName,
                LastName = model.LastName
            });

            var identityUser = new MyIdentityUser();
            identityUser.Email = model.EmailAddress;
            identityUser.UserName = model.EmailAddress;
            identityUser.LockoutEnabled = false;
            identityUser.DisplayName = $"{model.FirstName} {model.LastName}";

            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    await model.ImageFile.CopyToAsync(ms);

                    identityUser.Image = Convert.ToBase64String(ms.ToArray());
                }
            }

            await _userManager.CreateAsync(identityUser);

            var code = await _userManager.GenerateEmailConfirmationTokenAsync(identityUser);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            
            var callbackUrl = _generalOptions.BaseUrl + Url.Action("ConfirmAndSetPassword", "Accounts", new 
            { 
                userId = identityUser.Id, 
                code = code, 
                returnUrl = "/" 
            });

            await _emailSender.SendEmailAsync(model.EmailAddress, "Confirme su usuario y establezca su contraseña",
                        $"Por favor confirme su cuenta y establezca su contraseña <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>haciendo clic aquí</a>.");

            return RedirectToAction("Index");
        }
    }
}
