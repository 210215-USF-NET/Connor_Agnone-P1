using StoreModels;

namespace MvcStore.Models
{
    public class Mapper : IMapper
    {
        public CustomerIndexVM cast2CustomerIndexVM(Customer customer2BCasted)
        {
            return new CustomerIndexVM
            {
                CustomerName = customer2BCasted.CustomerName,
                CustomerEmail = customer2BCasted.CustomerEmail
            };
        }
        public Customer cast2Customer(CustomerCRVM customer2bCasted)
        {
            return new Customer
            {
                CustomerName = customer2bCasted.CustomerName,
                CustomerEmail = customer2bCasted.CustomerEmail
            };
        }
        public CustomerCRVM cast2CustomerCRVM(Customer customer)
        {
            return new CustomerCRVM
            {
                CustomerName = customer.CustomerName,
                CustomerEmail = customer.CustomerEmail
            };
        }
    }
}