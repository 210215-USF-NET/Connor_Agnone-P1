using System.ComponentModel;
using StoreModels;
namespace MvcStore.Models
{
    public class LocationIndexVM
    {
        [DisplayName("Location Name")]
        public string LocationName { get; set; }

        [DisplayName("Location Address")]
        public string LocationAddress { get; set; }

        public int LocationID { get; set; }
    }
}