using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drette.Tender.Shared.Models
{
    /// <summary>
    /// The Detail of the Product.
    /// </summary>
    public class Product
    {


        public int Id { get; set; }

        [Display(Name = "Nom de produit")]
        public string Name { get; set; }

        [Display(Name = "Code du produit")]
        public string ProductCode { get; set; }

        public string Description { get; set; }

        public string Notes { get; set; }

        [Display(Name = "Date d'ajout du produit")]
        public DateTime Date { get; set; }

        [Display(Name = "Type de produit")]
        public int ProductTypeId { get; set; }

        [Display(Name = "Numéro d'inventaire")]
        public int InventoryId { get; set; }

        [Display(Name = "Distributeur")]
        public int SupplierId { get; set; }
        public string SupplierProductCode { get; set; }

        public string UserId { get; set; }
        [Display(Name = "Responsable de l'ajout")]
        public User User { get; set; }

        public ProductType ProductType { get; set; }
        public Inventory Inventory { get; set; }
        public Supplier Supplier { get; set; }


    }
}
