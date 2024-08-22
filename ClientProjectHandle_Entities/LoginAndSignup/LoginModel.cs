using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientProjectHandle_Entities.LoginAndSignup
{
	public class LoginDetailModel
	{

		[EmailAddress]
		public string? Email { get; set; }

		[Phone]
		public string? MobilNumber { get; set; }

		[AllowedValues("ADMIN","USER","CLIENT")]
		public string? SystemRole { get; set; }

		public string? RoleId { get; set; } = null;

		public bool IsExist { get; set; } = false;

		public string? ErrorCode { get; set; }

		public string? ErrorDescription { get; set; }

	}

	public class LoginModel
	{
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required!")]
        public string? UserName { get; set; }

        //[MinLength(8, ErrorMessage = "Length should be equal to or greater than 8 letters!")]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required!")]
        public string? Password { get; set; }
    }
}
