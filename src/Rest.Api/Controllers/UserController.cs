using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using Rest.ApiModels;
using Rest.DAL.Repository;

namespace Rest.Api.Controllers
{
    [Route("api/user")]
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        public UserController(IUserRepository userRepository) {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var people = userRepository.GetAllProfiles();
            return Json(people);
        }

        [HttpGet]
        [Route("first")]
        public IActionResult FirstPerson() {
            var person = userRepository.GetAllProfiles().FirstOrDefault();
            return Json(person);
        }

        [HttpGet]
        [Route("{userId:guid}")]
        public IActionResult UserById(Guid userId)
        {
            if (userId == Guid.Empty) {
                return Json("Not a valid ID for a user");
            }

            var user = userRepository.GetUserById(userId);

            var person = new UserApiModel(user);
            return Json(person);
        }

        [HttpPost]     
        [Route("update/{userId:guid}")]   
        public IActionResult UpdateUser(Guid userId, [FromBody]UserApiModel userApiModel)
        {
            if (!ModelState.IsValid) {
                return BadRequest();
            }

            var user = userRepository.GetUserById(userId);

            return Json("user " + userId + " was successfully updated");
        }
    }
}
