using Microsoft.AspNetCore.Mvc;
using Rest.Core.Enums;
using Rest.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Rest.Api.Controllers
{
    [Route("api/")]
    public class HomeController : Controller
    {
        private readonly List<Person> people;
        public HomeController() {
            this.people = new List<Person> {
                new Person("Ryan", new List<Skills> {
                    Skills.DotNet
                }),
                new Person("Mark", new List<Skills> {
                    Skills.DotNet,
                    Skills.Java
                })
            };
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(people);
        }

        [HttpGet]
        [Route("first")]
        public IActionResult FirstPerson() {
            return Json(people.First());
        }
    }    
}
