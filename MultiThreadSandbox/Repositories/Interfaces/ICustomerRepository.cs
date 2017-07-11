using System.Collections.Generic;
using MultiThreadSandbox.Models;

namespace MultiThreadSandbox.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        IList<CustomerModel> GetAll();
        void Add(CustomerModel customerModel);
    }
}