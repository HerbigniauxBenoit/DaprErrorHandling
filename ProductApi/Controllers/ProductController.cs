using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace ProductApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static readonly List<Product> products = new List<Product>() {
            new Product() { Id="1", Name="ProductA" },
            new Product() { Id="2", Name="ProductB" },
            new Product() { Id="3", Name="ProductC" },
        };

        [HttpGet]
        public ActionResult<Product> Get()
        {
            Console.WriteLine("Oh quelqu'un a appelé l'api");
            Random random = new();
            int rand = random.Next(0, 100);
            if (rand < 25)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Une erreur inconnue est arrivée !");
            }
            else if (rand > 25 && rand < 50)
            {
                return StatusCode((int)HttpStatusCode.RequestTimeout, "Request timout...");
            }
            else
            {
                return Ok(products);
            }            
        }
    }
}
