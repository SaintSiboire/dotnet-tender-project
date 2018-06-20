using System.Collections.Generic;

namespace Drette.Tender.Shared.Models
{
    /// <summary>
    /// Represents an Item.
    /// </summary>
    public class Item
    {

        public Item()
        {
            Entries = new List<Entry>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ModelId { get; set; }
        public decimal Price { get; set; }

        /// <summary>
        /// The entries associated with this item.
        /// </summary>
        public IList<Entry> Entries { get; set; }
    }
}