using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.Features.Offline
{
    public class OfflineController : Controller
    {
        [Route("Offline", Name = "offline")]
        public IActionResult OfflinePage()
        {
            return View("~/Features/Offline/Offline.cshtml");
        }

        public IActionResult Online()
        {
            return View("~/Features/Offline/Online.cshtml");
        }
    }
}
