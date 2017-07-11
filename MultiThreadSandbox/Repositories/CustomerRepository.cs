using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using MultiThreadSandbox.Models;
using MultiThreadSandbox.Repositories.Interfaces;

namespace MultiThreadSandbox.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ConcurrentBag<CustomerModel> _customerModels;
        
        public CustomerRepository()
        {
            _customerModels = new ConcurrentBag<CustomerModel>();
        }

        public IList<CustomerModel> GetAll()
        {
            return _customerModels.ToList();
        }

        public void Add(CustomerModel customerModel)
        {
            _customerModels.Add(customerModel);
        }
    }
}