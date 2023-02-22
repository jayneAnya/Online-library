using System.ComponentModel.DataAnnotations;

namespace PioneerOnlineLibrary.API.ViewModels
{
	public class RegisterModel
	{
		[Required(ErrorMessage = "User Name is required")]
		[RegularExpression(@"^[a-zA-Z0-9_]{4,16}$",
		ErrorMessage = "Invalid User name format.")]
		public string UserName { get; set; } = null!;

		[Required(ErrorMessage = "User Email is required")]
		[RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
		 ErrorMessage = "Please enter a valid email.")]
		public string Email { get; set; } = null!;

		[Required(ErrorMessage = "User Password is required")]
		[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{6,}$",
		 ErrorMessage = "Please enter a valid password.")]
		[StringLength(10)]
		public string Password { get; set; } = null!;

		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
	}
}
