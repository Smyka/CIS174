using Microsoft.AspNetCore.Mvc;
using MitchellResponsiveWebAppSmyka.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MitchellResponsiveWebAppSmyka.Controllers
{
    public class FavoriteController : Controller
    {
        public IActionResult Index()
        {
            List<CountryModel> favorites = GetFavoritesFromSession();
            return View(favorites);
        }

        [HttpPost]
        public IActionResult ClearAll()
        {
            HttpContext.Session.Remove("Favorites");
            return RedirectToAction("Index");
        }

        private List<CountryModel> GetFavoritesFromSession()
        {
            string json = HttpContext.Session.GetString("Favorites");
            if (string.IsNullOrEmpty(json))
            {
                return new List<CountryModel>();
            }
            return JsonConvert.DeserializeObject<List<CountryModel>>(json);
        }
    }
}