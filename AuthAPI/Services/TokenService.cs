namespace AuthAPI.Services;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Models;

public static class TokenService
{
	public static string GenerateToken(UserModel user)
	{
		IConfiguration config = new ConfigurationBuilder()
			.AddJsonFile("appsettings.json")
			.Build();

		var tokenHandler = new JwtSecurityTokenHandler();
		var key = Encoding.ASCII.GetBytes(config.GetSection("Secret").ToString());
		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(new Claim[]
			{
				new Claim(ClaimTypes.Name, user.Username.ToString()),
				new Claim(ClaimTypes.Role, user.Role.ToString())
			}),
			Expires = DateTime.UtcNow.AddHours(2),
			SigningCredentials = new SigningCredentials(
				new SymmetricSecurityKey(key),
				SecurityAlgorithms.HmacSha256Signature
			)
		};

		var token = tokenHandler.CreateToken(tokenDescriptor);
		return tokenHandler.WriteToken(token);
	}
}
