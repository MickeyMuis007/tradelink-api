
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Tradelink.Application.ViewModels.Auth;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Claims;

namespace Tradelink.Web.Controllers.Auth
{
  [ApiController]
  [Route("account")]
  public class AccountController : ControllerBase
  {
    [HttpGet("loggedIn")]
    [AllowAnonymous]
    public string CheckLogin() {
      return "Logged in 1";
    }

    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<ActionResult> Login(LoginViewModel viewModel) {

      if (viewModel.Username != "test" && viewModel.Password != "test")
        return Unauthorized();

      var claims = new List<Claim>
      {
        new Claim(ClaimTypes.NameIdentifier, viewModel.Username),
        new Claim(ClaimTypes.Name, viewModel.Username),
        new Claim(ClaimTypes.Role, "Admin"),
        new Claim("FavoriteColor", "Blue")
      };

      var identity = new ClaimsIdentity(claims, 
        CookieAuthenticationDefaults.AuthenticationScheme);
      var principal = new ClaimsPrincipal(identity);

      await HttpContext.SignInAsync(
        CookieAuthenticationDefaults.AuthenticationScheme,
        principal,
        new AuthenticationProperties { IsPersistent = true }
      );

      var tokens = await HttpContext.GetTokenAsync(CookieAuthenticationDefaults.AuthenticationScheme);
      return Ok(
        new {
          viewModel = viewModel,
          tokens = tokens
        });
    }
  }
}