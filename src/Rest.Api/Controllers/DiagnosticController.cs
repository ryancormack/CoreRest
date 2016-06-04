using Microsoft.AspNetCore.Mvc;
using Rest.Models;

namespace Rest.Controllers
{
    [Route("api/diagnostic")]
    public class DiagnosticController : Controller
    {
        public IActionResult Info() {
            var ip = HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            return Json(new Diagnostics(ip));
        }
    }
}
