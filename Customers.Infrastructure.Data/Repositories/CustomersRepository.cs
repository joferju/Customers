using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Customers.Core.Interfaces;
using Customers.Infrastructure.Data.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Customers.Objects.Objects;

namespace Customers.Infrastructure.Data.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly ICustomersContext _customersContext;
        public CustomersRepository(
            ICustomersContext customersContext)
        {
            _customersContext = customersContext;
        }

        public async  Task<List<CustomersData>> GetInfo(string application)
        {
            return await _customersContext.CustomersData.ToListAsync();
        }
    }
}
