using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drette.Tender.Shared.Models
{
    /// <summary>
    /// The Shop of the Item
    /// </summary>
    public class Supplier
    {
        public Supplier()
        {
            Products = new List<Product>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string WebSite { get; set; }


        public ICollection<Product> Products { get; set; }



    }
}
