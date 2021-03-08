using System.Collections.Generic;
namespace StoreModels
{
    public class Location
    {
        public string LocationName { get; set; }
        public string LocationAddress { get; set; }
        public List<Inventory> Inventory { get; set; }
        public int Id { get; set; }
    }
}