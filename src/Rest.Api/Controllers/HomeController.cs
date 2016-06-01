using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Restival.Controllers
{
    [Route("api/")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Json(new Person("Ryan"));
        }
    }

    public class Person {
        public Person(string name) {
            Name = name;
        }

        public string Name { get; }
    }
}
