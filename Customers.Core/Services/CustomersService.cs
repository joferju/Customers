

using System.Collections.Generic;
using System.Threading.Tasks;
using Customers.Core.Interfaces;
using Customers.Objects.Objects;

namespace Customers.Core.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly ICustomersRepository _customersRepository;

        public CustomersService(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        
        public async Task<List<CustomersData>> GetInfo(string application)
        {
            return await _customersRepository.GetInfo(application);
        }
    }
}
