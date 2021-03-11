using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using StoreModels;

namespace MvcStore.Models
{
    public class CustomerEditVM
    {
        [Required]
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string CustomerEmail { get; set; }

        public int CustomerId { get; set; }
    }
}