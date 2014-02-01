using Gamji.Core.Models;

namespace Gamji.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(int id);
    }
}
