using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Rest.Controllers
{
    public class OfflineController : Controller
    {
        // GET: /<controller>/
        [Route("offline")]
        public IActionResult Index()
        {
            var viewmodel = new OfflineViewModel
            {
                Number = 1
            };
            return View(viewmodel);
        }
    }

    public class OfflineViewModel {
        public int Number { get; set; }
    }
}
