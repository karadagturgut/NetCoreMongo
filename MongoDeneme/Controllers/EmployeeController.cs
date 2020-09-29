using Microsoft.AspNetCore.Mvc;

namespace MongoDeneme.Controllers
{
    public class EmployeeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}