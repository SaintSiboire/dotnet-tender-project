using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Drette.Tender.Shared.Models
{
    /// <summary>
    /// Represents the inventory of a product.
    /// </summary>
    public class Inventory
    {

        public Inventory()
        {
            InventoryInputs = new List<InventoryInput>();
            InventoryOutputs = new List<InventoryOutput>();
        }

        [Display(Name = "Numéro d'inventaire")]
        public int Id { get; set; }
        [Display(Name ="Compté en inventaire")]
        public bool Counted { get; set; }
        [Display(Name = "Suivi dans l'inventaire")]
        public bool Followed { get; set; }
        [Display(Name = "Coût total")]
        public decimal TotalCost { get; set; }
        [Display(Name = "Coût unitaire")]
        public decimal AverageCost { get; set; }
        [Display(Name = "Nombre d'unité")]
        public int UnitQty { get; set; }
        [Display(Name = "Quantité par unité")]
        public int UnitQtyByLot { get; set; }
        [Display(Name = "Quantité minimum en inventaire")]
        public int UnitMinQty { get; set; }
        [Display(Name = "Quantité maximum en inventaire")]
        public int UnitMaxQty { get; set; }
        [Display(Name = "Commande minimum")]
        public int OrderMinQty { get; set; }
        [Display(Name = "Emplacement")]
        public string Location { get; set; }
        [Display(Name = "Précision de l'emplacement")]
        public string LocationPrecision { get; set; }
        public string Notes { get; set; }


        public string UserId { get; set; }
        public User User { get; set; }

        public int UnitId { get; set; }
        public Unit Unit { get; set; }

        public ICollection<InventoryInput> InventoryInputs { get; set; }
        public ICollection<InventoryOutput> InventoryOutputs { get; set; }


    }
}