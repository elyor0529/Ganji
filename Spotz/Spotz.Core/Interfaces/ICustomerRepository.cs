using Spotz.Core.Models;

namespace Spotz.Core.Interfaces
{
	public interface ICustomerRepository
	{
		Customer GetCustomer(int id);

		Customer GetCustomerByEmail(string EmailId);

		Customer ValidateCustomerLogin(string EmailId, string Password);

		Customer AddNewCustomer(Customer c);

		Customer ForgotPassword(string EmailId);

		Customer ResetPassword(string EmailId, string VerificationCode, string NewPassword);
	}
}
