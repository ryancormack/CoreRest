using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Rest.Controllers
{
    public class OfflineController : Controller
    {
        // GET: /<controller>/
        [Route("offline")]
        public IActionResult Offline()
        {
            var viewmodel = new OfflineViewModel
            {
                Number = 2
            };
            return View("~/Features/Offline/offline.cshtml",viewmodel);
        }

        [Route("online")]
        public IActionResult Online()
        {
            return View("~/Features/Offline/online.cshtml");
        }

        [Route("home")]
        public IActionResult Home()
        {
            return View("~/Features/Offline/home.cshtml");
        }

        [Route("latest")]
        public IActionResult Latest() {
            return Json(new LatestPost { PostName = "Hello World"});
        }
    }

    public class LatestPost {
        public string PostName { get; set; }
    }

    public class OfflineViewModel {
        public int Number { get; set; }
    }
}
