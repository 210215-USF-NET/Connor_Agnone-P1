using StoreModels;

namespace MvcStore.Models
{
    public interface IMapper
    {
        //Customer mappers
        CustomerIndexVM cast2CustomerIndexVM(Customer customer2BCasted);
        Customer cast2Customer(CustomerCRVM customer2bCasted);
        CustomerCRVM cast2CustomerCRVM(Customer customer);
        CustomerEditVM cast2CustomerEditVM(Customer customer);
        Customer cast2Customer(CustomerEditVM customer2BCasted);
        //Location mappers
        LocationIndexVM cast2LocationIndexVM(Location location2BCasted);
        Inventory cast2Inventory(LocationIVM inventory2BCasted);
        LocationIVM cast2LocationIVM(Inventory inventory2BCasted);
        Inventory cast2Inventory(LocationEditVM inventory2BCasted);
        LocationEditVM cast2LocationEditVM(Inventory inventory);
        //Order mappers
        CheckoutVM cast2CheckoutVM(OrderItems orderItems);

    }
}