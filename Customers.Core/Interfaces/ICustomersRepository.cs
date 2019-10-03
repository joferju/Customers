
using System.Collections.Generic;
using System.Threading.Tasks;
using Customers.Objects.Objects;

namespace Customers.Core.Interfaces
{
    public interface ICustomersRepository
    {
        Task<List<CustomersData>> GetInfo(string application);
    }
}
