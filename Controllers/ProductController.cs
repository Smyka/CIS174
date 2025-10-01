using Microsoft.AspNetCore.Mvc;
using FutureValue.Models;
public class ProductController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return Content("Index");
    }
    [HttpGet]
    public IActionResult Apple()
    {
        return Content("Apple page");
    }
}
