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
    public class ObjectController : ControllerBase
    {
        private readonly TrashITContext trashITContext;

        public ObjectController(TrashITContext trashITContext)
        {
            this.trashITContext = trashITContext;
        }

        [HttpPost("add")]
        public IActionResult AddObject([FromBody] NewObjectRequest newObjectRequest)
        {
            if (newObjectRequest.Barcode == null || newObjectRequest.Material == null || newObjectRequest.Description == null)
            {
                return BadRequest();
            }

            if (trashITContext.Objects.FirstOrDefault(o => o.Barcode == newObjectRequest.Barcode) != null)
            {

                return StatusCode(409, "Object with barcode " + newObjectRequest.Barcode + " already exists.");
            }
            else
            {
                try
                {
                    ObjectToRecycle o = new ObjectToRecycle(newObjectRequest.Barcode, newObjectRequest.Material, newObjectRequest.Description);
                    trashITContext.Objects.Add(o);
                    trashITContext.SaveChanges();
                    return Ok();
                }
                catch (Exception)
                {
                    return StatusCode(500, "There is something wrong with creating the object in the DB.");
                }
            }
        }

        [HttpGet("getByBarcode")]
        public IActionResult GetByBarcode(string Barcode)
        {
            String m = trashITContext.Objects.Where(ob => ob.Barcode == Barcode).Select(ob => ob.Material).FirstOrDefault();

            if (m != null)
            {
                var data = new { Material = m };
                return Ok(data);
            }
            else
            {
                return NotFound("There isn't any object in the DB");
            }
        }
    }
}
