namespace AuthAPI.Repositories;

using Models;
using Models.Structs;

public static class UserRepository
{
	public static UserModel Get(string username, string password)
	{
		var users = new List<UserModel>
		{
			new UserModel
			{
				Id = 1,
				Username = "John Doe",
				Password = "doe.!9018",
				Role = UserRole.Manager
			},

			new UserModel
			{
				Id = 2,
				Username = "Marcos Lopez",
				Password = "malopez1902",
				Role = UserRole.Employee
			}
		};

		return users
			.Where(u =>
				u.Username.ToLower() == username.ToLower() &&
				u.Password.ToLower() == password.ToLower()
			).FirstOrDefault();
	}
}
