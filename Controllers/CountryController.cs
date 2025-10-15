using Microsoft.AspNetCore.Mvc;
using MitchellResponsiveWebAppSmyka.Models;
using System.Diagnostics.Metrics;
using Newtonsoft.Json;

namespace MitchellResponsiveWebAppSmyka.Controllers
{
    public class CountryController : Controller
    {
        public IActionResult Index(string game = "ALL", string category = "ALL")
        {
            List<CountryModel> allCountries = GetAllCountries();

            List<CountryModel> countriesToDisplay = new List<CountryModel>();
            foreach (CountryModel country in allCountries)
            {
                bool gameMatches = (game == "ALL" || country.Game == game);
                bool categoryMatches = (category == "ALL" || country.Category == category);

                if (gameMatches && categoryMatches)
                {
                    countriesToDisplay.Add(country);
                }
            }

            List<string> games = new List<string>();
            games.Add("ALL");
            foreach (CountryModel c in allCountries)
            {
                if (!games.Contains(c.Game))
                {
                    games.Add(c.Game);
                }
            }

            List<string> categories = new List<string>();
            categories.Add("ALL");
            foreach (CountryModel c in allCountries)
            {
                if (!categories.Contains(c.Category))
                {
                    categories.Add(c.Category);
                }
            }

            ViewBag.game = game;
            ViewBag.category = category;
            ViewBag.categories = categories;
            ViewBag.games = games;
            return View(countriesToDisplay);
        }

        [HttpPost]
        public IActionResult AddToFavorites(string name)
        {
            List<CountryModel> allCountries = GetAllCountries();
            CountryModel selected = null;

            foreach (CountryModel c in allCountries)
            {
                if (c.Name == name)
                {
                    selected = c;
                    break;
                }
            }

            if (selected == null)
            {
                return RedirectToAction("Index");
            }

            List<CountryModel> favorites = GetFavoritesFromSession();
            bool alreadyExists = false;

            foreach (CountryModel c in favorites)
            {
                if (c.Name == name)
                {
                    alreadyExists = true;
                    break;
                }
            }

            if (!alreadyExists)
            {
                favorites.Add(selected);
                SaveFavoritesToSession(favorites);
            }
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

        private void SaveFavoritesToSession(List<CountryModel> favorites)
        {
            string json = JsonConvert.SerializeObject(favorites);
            HttpContext.Session.SetString("Favorites", json);
        }
        private List<CountryModel> GetAllCountries()
        {
            List<CountryModel> allCountries = new List<CountryModel> {
                new CountryModel { Name = "Austria", Game = "Paralympics", Sport = "Canoe Sprint", Category = "Outdoor", FlagFileName = "austria.png" },
                new CountryModel { Name = "Brazil", Game = "Summer Olympics", Sport = "Road Cycling", Category = "Outdoor", FlagFileName = "brazil.png" },
                new CountryModel { Name = "Canada", Game = "Winter Olympics", Sport = "Curling", Category = "Indoor", FlagFileName = "canada.png" },
                new CountryModel { Name = "China", Game = "Summer Olympics", Sport = "Diving", Category = "Indoor", FlagFileName = "china.png" },
                new CountryModel { Name = "Cyprus", Game = "Youth Olympic Games", Sport = "Breakdancing", Category = "Indoor", FlagFileName = "cyprus.png" },
                new CountryModel { Name = "Finland", Game = "Youth Olympic Games", Sport = "Skateboarding", Category = "Outdoor", FlagFileName = "finland.png" },
                new CountryModel { Name = "France", Game = "Youth Olympic Games", Sport = "Breakdancing", Category = "Indoor", FlagFileName = "france.png" },
                new CountryModel { Name = "Germany", Game = "Summer Olympics", Sport = "Diving", Category = "Indoor", FlagFileName = "germany.png" },
                new CountryModel { Name = "Great Britain", Game = "Winter Olympics", Sport = "Curling", Category = "Indoor", FlagFileName = "great_britain.png" },
                new CountryModel { Name = "Italy", Game = "Winter Olympics", Sport = "Bobsleigh", Category = "Outdoor", FlagFileName = "italy.png" },
                new CountryModel { Name = "Jamaica", Game = "Winter Olympics", Sport = "Bobsleigh", Category = "Outdoor", FlagFileName = "jamaica.png" },
                new CountryModel { Name = "Japan", Game = "Winter Olympics", Sport = "Bobsleigh", Category = "Outdoor", FlagFileName = "japan.png" },
                new CountryModel { Name = "Mexico", Game = "Summer Olympics", Sport = "Diving", Category = "Indoor", FlagFileName = "mexico.png" },
                new CountryModel { Name = "Netherlands", Game = "Summer Olympics", Sport = "Cycling", Category = "Outdoor", FlagFileName = "netherlands.png" },
                new CountryModel { Name = "Pakistan", Game = "Paralympics", Sport = "Canoe Sprint", Category = "Outdoor", FlagFileName = "pakistan.png" },
                new CountryModel { Name = "Portugal", Game = "Youth Olympic Games", Sport = "Skateboarding", Category = "Outdoor", FlagFileName = "portugal.png" },
                new CountryModel { Name = "Russia", Game = "Youth Olympic Games", Sport = "Breakdancing", Category = "Indoor", FlagFileName = "russia.png" },
                new CountryModel { Name = "Slovakia", Game = "Youth Olympic Games", Sport = "Skateboarding", Category = "Outdoor", FlagFileName = "slovakia.png" },
                new CountryModel { Name = "Sweden", Game = "Winter Olympics", Sport = "Curling", Category = "Indoor", FlagFileName = "sweden.png" },
                new CountryModel { Name = "Thailand", Game = "Paralympics", Sport = "Archery", Category = "Indoor", FlagFileName = "thailand.png" },
                new CountryModel { Name = "Ukraine", Game = "Paralympics", Sport = "Archery", Category = "Indoor", FlagFileName = "ukraine.png" },
                new CountryModel { Name = "Uruguay", Game = "Paralympics", Sport = "Archery", Category = "Indoor", FlagFileName = "uruguay.png" },
                new CountryModel { Name = "USA", Game = "Summer Olympics", Sport = "Road Cycling", Category = "Outdoor", FlagFileName = "usa.png" },
                new CountryModel { Name = "Zimbabwe", Game = "Paralympics", Sport = "Canoe Sprint", Category = "Outdoor", FlagFileName = "zimbabwe.png" }
            };
            return allCountries;
        }
    }
}
