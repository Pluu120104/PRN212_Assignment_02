using BussinessObjectLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetMembers();
        Customer GetUserByEmailAndPassword(string email, string password);
        void Insert(Customer customer);
        void Delete(Customer customer);
        void Update(Customer customer);

        bool Login(string username, string password);
    }
}
