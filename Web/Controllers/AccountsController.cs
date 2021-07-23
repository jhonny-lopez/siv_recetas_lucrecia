using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Web.Models.Accounts;

namespace Web.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountsController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult ConfirmAndSetPassword(string userId, string code, string returnUrl)
        {
            var user = _userManager.Users
                .Where(it => it.Id == userId)
                .FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            var model = new ConfirmAndSetPasswordViewModel();
            model.Code = code;
            model.ReturnUrl = returnUrl;
            model.UserId = userId;
            model.Email = user.Email;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmAndSetPassword(ConfirmAndSetPasswordViewModel model)
        {
            var user = _userManager.Users
                .Where(it => it.Id == model.UserId)
                .FirstOrDefault();

            if (user == null)
            {
                return NotFound();
            }

            string token = WebUtility.UrlDecode(model.Code);
            token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));

            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                var addPasswordResult = await _userManager.AddPasswordAsync(user, model.Password);

                if (addPasswordResult.Succeeded)
                {
                    var loginResult = await _signInManager.PasswordSignInAsync(user.UserName, model.Password, true, false);

                    if (loginResult.Succeeded)
                    {
                        return Redirect(model.ReturnUrl ?? "/");
                    }
                }
            }

            return Unauthorized();
        }
    }
}
