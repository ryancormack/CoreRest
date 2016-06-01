using Microsoft.AspNetCore.Mvc;
using Restival.Models;
using System.Collections.Generic;

namespace Restival.Controllers
{
    [Route("api/")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Json(new List<Person> { new Person("Ryan"), new Person("Mark")});
        }
    }    
}
