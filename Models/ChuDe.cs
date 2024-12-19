using Microsoft.AspNetCore.Mvc;

namespace PetShop.Models
{
    public class ChuDe : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
