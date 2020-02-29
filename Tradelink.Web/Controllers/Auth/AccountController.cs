
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Tradelink.Application.ViewModels.Auth;
using System.Threading.Tasks;
using System.Linq;
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

      if (viewModel.Username != "test" || viewModel.Password != "test")
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
        new AuthenticationProperties { IsPersistent = false }
      );

      var tokens = await HttpContext.GetTokenAsync(CookieAuthenticationDefaults.AuthenticationScheme);
      return Ok(
        new {
          viewModel = viewModel,
          tokens = tokens
        });
    }

    [HttpGet("Logout")]
    public async Task<ActionResult> Logout()
    {
      await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
      return Ok("Signed out " + CookieAuthenticationDefaults.AuthenticationScheme);
    }

    [AllowAnonymous]
    [HttpGet("LoginInWithGoogle")]
    public ActionResult LoginWithGoogle(string returnUrl = "/") 
    {
      var props = new AuthenticationProperties
      {
        RedirectUri = Url.Action("GoogleLoginCallback"),
        Items = 
        {
          { "returnUrl", returnUrl }
        }
      };
      return Challenge(props, GoogleDefaults.AuthenticationScheme);
    }

    [AllowAnonymous]
    [HttpGet("GoogleLoginCallback")]
    public async Task<ActionResult> GoogleLoginCallback()
    {
      var results = await HttpContext.AuthenticateAsync(
        ExternalAuthenticationDefaults.AuthenticationScheme
      );

      var externalClaim = results.Principal.Claims.ToList();

      var subjectIdClaims = externalClaim.FirstOrDefault(
        x => x.Type == ClaimTypes.NameIdentifier
      );
      var subjectValue = subjectIdClaims.Value;

      var user = new { 
        Id = subjectValue,
        Name = "Mike",
        Role = "Developer",
        Admin = "Mike Test Admin"
      };

      var claims = new List<Claim>
      {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.Name),
        new Claim(ClaimTypes.Role, user.Role),
        new Claim("Mike Admin", user.Admin)
      };

      var identity = new ClaimsIdentity(claims,
        CookieAuthenticationDefaults.AuthenticationScheme
      );
      var principal = new ClaimsPrincipal(identity);

      await HttpContext.SignOutAsync(
        ExternalAuthenticationDefaults.AuthenticationScheme
      );

      await HttpContext.SignInAsync(
        CookieAuthenticationDefaults.AuthenticationScheme, principal
      );

      return Ok(new { 
        principal.Identity,
        externalClaim,
        subjectIdClaims,
        subjectValue,
        user
      });
    }
  }
}