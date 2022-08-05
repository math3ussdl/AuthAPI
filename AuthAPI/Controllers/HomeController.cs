namespace AuthAPI.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api")]
[ApiController]
public class HomeController : ControllerBase
{
	[HttpGet]
	[Route("healthcheck")]
	[AllowAnonymous]
	public ActionResult<string> HealthCheck()
	{
		return "Application status: OK!";
	}

	[HttpGet]
	[Route("me")]
	[Authorize]
	public ActionResult<object> GetMe()
	{
		return new
		{
			Username = User.Identity.Name
		};
	}

	[HttpGet]
	[Route("employee")]
	[Authorize(Roles = "employee,manager")]
	public string Employee() => "Funcionário";

	[HttpGet]
	[Route("manager")]
	[Authorize(Roles = "manager")]
	public string Manager() => "Gerente";
}
