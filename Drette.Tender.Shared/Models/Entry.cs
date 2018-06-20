using System;
using System.ComponentModel.DataAnnotations;

namespace Drette.Tender.Shared.Models
{
    /// <summary>
    /// Represents an Item that has been logged in the Tender app.
    /// </summary>
    public class Entry
    {
        public Entry()
        {
        }

        /// <summary>
        /// Constructor for creating entries.
        /// </summary>
        /// <param name="user">The User of the entry</param>
        /// <param name="year">The year (1 through 9999) for the entry date.</param>
        /// <param name="month">The month (1 through 12) for the entry month.</param>
        /// <param name="day">The day (1 through the number of days for the month) for the entry day.</param>
        /// <param name="item">The item for the entry.</param>
        /// <param name="price">The price we pay for the item (in CAD).</param>
        public Entry(User user, int year, int month, int day, Item item, 
            decimal price)
        {
            UserId = user.Id;
            Date = new DateTime(year, month, day);
            Item = item;
            Price = price;
        }

        /// <summary>
        /// The User Id of the Entry
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// The User of the Entry
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// The ID of the entry.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The date of the entry. Should not include a time portion.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The item ID for the entry. The ID value should map to an ID in the items collection.
        /// </summary>
        [Display(Name = "Item")]
        public int ItemId { get; set; }

        /// <summary>
        /// The item for the entry.
        /// </summary>
        public Item Item { get; set; }

        /// <summary>
        /// The price for the entry (in minutes).
        /// </summary>
        public decimal Price { get; set; }


    }
}