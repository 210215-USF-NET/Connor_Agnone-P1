using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using StoreModels;

namespace MvcStore.Models
{
    /// <summary>
    /// Customer View Model for creating and reading customers
    /// </summary>
    public class CustomerCRVM
    {
        [DisplayName("Customer Name")]
        [Required]
        public string CustomerName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string CustomerEmail { get; set; }
    }
}