using System.ComponentModel;
using StoreModels;

namespace MvcStore.Models
{
    /// <summary>
    /// Model for the customer index view of my app
    /// </summary>
    public class CustomerIndexVM
    {
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [DisplayName("Email")]
        public string CustomerEmail { get; set; }
    }
}