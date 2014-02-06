using System.Web.Http;
using Spotz.Core.Interfaces;
using Spotz.Core.Models;

namespace Spotz.Controllers
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
		///Only CustomerId is returned back
		[HttpGet]
		public int ValidateCustomerLogin(string EmailId, string Password)
		{
			return _customerRepository.ValidateCustomerLogin(EmailId, Password).CustomerId;
		}

		[HttpPut]
		//The added customer's Id.
		public int AddNewCustomer(Customer c)  //The added customer's Id.
		{
			return _customerRepository.AddNewCustomer(c).CustomerId;
		}
		
		//Id of customer returned back as response.
		public int ForgotPassword(string EmailId)
		{ 
			return _customerRepository.ForgotPassword(EmailId).CustomerId;
		}

		public int ResetPassword(string EmailId, string VerificationCode, string NewPassword)
		{  //The updated row's Id is returned back.

			return _customerRepository.ResetPassword(EmailId, VerificationCode, NewPassword).CustomerId;
		}
	}
}
