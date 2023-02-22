using System.ComponentModel.DataAnnotations;

namespace PioneerOnlineLibrary.API.ViewModels
{

	public class LoginModel
	{
		[Required(ErrorMessage = "Please enter your User Name")]
		public string UserName { get; set; } = null!;

		[Required(ErrorMessage = "Please enter your Password")]
		public string Password { get; set; } = null!;
	}
}
