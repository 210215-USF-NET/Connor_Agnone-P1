using StoreModels;

namespace MvcStore.Models
{
    public interface IMapper
    {
        CustomerIndexVM cast2CustomerIndexVM(Customer customer2BCasted);
        Customer cast2Customer(CustomerCRVM customer2bCasted);
        CustomerCRVM cast2CustomerCRVM(Customer customer);
    }
}