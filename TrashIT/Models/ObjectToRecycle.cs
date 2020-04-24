using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace TrashIT.Models
{
    public class ObjectToRecycle : LazyEntity
    {
        public ObjectToRecycle(ILazyLoader lazyLoader) : base(lazyLoader)
        {
        }

        [Key]
        public string Barcode { get; set; }

        [Required]
        public string Material { get; set; }

        [Required]
        public string Description { get; set; }


        public ObjectToRecycle(string Barcode, string Material, string Description)
        {
            this.Barcode = Barcode;
            this.Material = Material;
            this.Description = Description;
        }
    }
}
