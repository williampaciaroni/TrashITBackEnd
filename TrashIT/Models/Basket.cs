using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace TrashIT.Models
{
    public class Basket : LazyEntity
    {
        public Basket(ILazyLoader lazyLoader) : base(lazyLoader)
        {
        }

        [Key]
        public int IdBasket { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string MacAddress { get; set; }

        public Basket(string Location, string MacAddress)
        {
            this.Location = Location;
            this.MacAddress = MacAddress;
        }
    }
}
