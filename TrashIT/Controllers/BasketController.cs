using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TrashIT.Context;
using TrashIT.Models;
using TrashIT.Models.Requests;

namespace TrashIT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
       

        private readonly TrashITContext trashITContext;


        public BasketController(TrashITContext trashITContext)
        {
            this.trashITContext = trashITContext;
        }

        [HttpPost("add")]
        public IActionResult AddBasket([FromBody] NewBasketRequest newBasketRequest)
        {
            if (newBasketRequest.Location == null || newBasketRequest.MacAddress == null)
            {
                return BadRequest();
            }

            if (trashITContext.Baskets.FirstOrDefault(b => b.MacAddress == newBasketRequest.MacAddress) != null)
            {

                return StatusCode(409, "Basket with mac address " + newBasketRequest.MacAddress + " already exists.");
            }
            else
            {
                try {
                    Basket b = new Basket(newBasketRequest.Location, newBasketRequest.MacAddress);
                    trashITContext.Baskets.Add(b);
                    trashITContext.SaveChanges();
                    return Ok();
                }
                catch(Exception e)
                {
                    return StatusCode(500, "There is something wrong with creating the smart bin in the DB.");
                }
            }
        }

        [HttpGet("getByLocation")]
        public IActionResult GetByLocation(string Location)
        {
            String b = trashITContext.Baskets.Where(bS => bS.Location == Location).Select(bS => bS.MacAddress).FirstOrDefault();

            if (b != null)
            {
                var data = new { Mac = b };
                return Ok(data);
            }
            else
            {
                return NotFound("There isn't any basket in this area");
            }
        }

    }
}
