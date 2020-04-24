using System;
namespace TrashIT.Models.Requests
{
    public class NewBasketRequest
    {
        public string MacAddress { get; set; }
        public string Location { get; set; }
    }
}
