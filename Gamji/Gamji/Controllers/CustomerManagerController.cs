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
	}
}
