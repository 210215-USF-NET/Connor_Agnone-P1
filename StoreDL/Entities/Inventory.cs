using System;
using System.Collections.Generic;

#nullable disable

namespace StoreDL.Entities
{
    public partial class Inventory
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        /// <summary>
        /// FK reference to product table
        /// </summary>
        /// <value></value>
        public int? InventoryProduct { get; set; }
        /// <summary>
        /// FK reference to the location table
        /// </summary>
        /// <value></value>
        public int? InventoryLocation { get; set; }

        public virtual Location InventoryLocationNavigation { get; set; }
        public virtual Product InventoryProductNavigation { get; set; }
    }
}
