using System;
namespace TrashIT.Models.Requests
{
    public class NewObjectRequest
    {
        public string Description { get; set; }
        public string Material { get; set; }
        public string Barcode { get; set; }
    }
}
