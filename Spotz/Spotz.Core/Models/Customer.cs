using System.ComponentModel.DataAnnotations;

namespace Spotz.Core.Models
{
	public class Customer
	{
		public Customer()
		{			
			FirstName = "Rod";
			LastName = "Johnson";
			CustomerId = 1;
			Email = "rod@ideafortune.com";
			Password = "1234";
			VerificationCode = "VCode";
				
		}
		public int CustomerId { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }

		[DataType(DataType.Password)]
		public string Password { get; set; }

		public string VerificationCode { get; set; }
	}
}