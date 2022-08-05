namespace AuthAPI.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using Services;

[Route("api")]
[ApiController]
public class AuthController : ControllerBase
{
	[HttpPost]
	[Route("login")]
	public ActionResult<dynamic> Authenticate([FromBody] UserModel model)
	{
		var user = UserRepository.Get(model.Username, model.Password);

		if (user == null)
			return NotFound(new { message = "Usuário ou senha inválidos" });

		var token = TokenService.GenerateToken(user);

		user.Password = "";

		return new
		{
			user,
			token
		};
	}
}

