using System.Web.Http;
using Gamji.Core.Interfaces;
using Gamji.Core.Models;

namespace Gamji.Controllers
{
	public class CustomerManagerController : ApiController
	{
		private readonly ICustomerRepository _customerRepository;

		public CustomerManagerController(ICustomerRepository customerRepository)
		{
			_customerRepository = customerRepository;
		}

		public Customer GetCustomerById(int id)
		{
			return _customerRepository.GetCustomer(id);
		}

		public Customer GetCustomerByEmail(string EmailId)
		{
			return _customerRepository.GetCustomerByEmail(EmailId);
		}

		public Customer ValidateCustomerLogin(string EmailId, string Password)
		{
			return _customerRepository.ValidateCustomerLogin(EmailId, Password);
		}

		[HttpPut]
		public Customer AddNewCustomer(Customer c)  //The added customer's Id.
		{
			return _customerRepository.AddNewCustomer(c);
		}

		public Customer ForgotPassword(string EmailId)
		{ //Id of customer returned back as response.
			return _customerRepository.ForgotPassword(EmailId);
		}

		public Customer ResetPassword(string EmailId, string VerificationCode, string NewPassword)
		{  //The updated row's Id is returned back.

			return _customerRepository.ResetPassword(EmailId, VerificationCode, NewPassword);
		}
	}
}
