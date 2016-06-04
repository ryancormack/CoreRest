using Microsoft.AspNetCore.Mvc;
using Rest.Core.DatabaseModels;
using Rest.Core.Enums;
using System.Collections.Generic;
using System.Linq;
using Rest.Database;
using System;

namespace Rest.Api.Controllers
{
    [Route("api/profile")]
    public class ProfileController : Controller
    {
        private readonly FakeDataStore database;
        public ProfileController() {
            this.database = new FakeDataStore();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var people = database.GetAllProfiles();
            return Json(people);
        }

        [HttpGet]
        [Route("first")]
        public IActionResult FirstPerson() {
            var person = database.GetAllProfiles().FirstOrDefault();
            return Json(person);
        }

        [HttpGet]
        [Route("{guid}")]
        public IActionResult PersonById(string guid)
        {
            Guid parsedGuid;
            Guid.TryParse(guid, out parsedGuid);

            if (parsedGuid == Guid.Empty) {
                return Json("Not a valid ID for a user");
            }

            var person = database.GetAllProfiles().FirstOrDefault();
            return Json(person);
        }
    }    
}
