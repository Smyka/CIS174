using Microsoft.AspNetCore.Mvc;
using FutureValue.Models;
public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        ViewBag.FV = 0;
        return View();
    }
    [HttpGet]
    [Route("About")]
    public IActionResult About()
    {
        return Content("About page");
    }
    [HttpPost]
    public IActionResult Index(FutureValueModel model)
    {
        if (ModelState.IsValid)
        {
            ViewBag.FV = model.AgeThisYear();
        }
        else
        {
            ViewBag.FV = 0;
        }
        return View(model);
    }
}
