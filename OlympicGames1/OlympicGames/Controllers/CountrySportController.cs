using Microsoft.AspNetCore.Mvc;
using OlympicGames.Models;
using System.Linq;

namespace OlympicGames.Controllers
{
    public class CountrySportController : Controller
    {
        private readonly ICountrySportService _service;

        public CountrySportController(ICountrySportService service)
        {
            _service = service;
        }

        // Index Action to show all countries and filter by game and type
        public IActionResult Index(string selectedGame = "ALL", string selectedType = "ALL")
        {
            var countries = _service.GetAll();

            // Apply filtering based on the selected game
            if (selectedGame != "ALL")
            {
                countries = countries.Where(c => c.Game == selectedGame).ToList();
            }

            // Apply filtering based on the selected type (Indoor/Outdoor)
            if (selectedType != "ALL")
            {
                countries = countries.Where(c => c.Type == selectedType).ToList();
            }

            // Pass the selected filters to the View
            ViewBag.SelectedGame = selectedGame;
            ViewBag.SelectedType = selectedType;

            return View(countries);
        }

        // Filter countries by selected game
        public IActionResult FilterByGame(string game)
        {
            var sports = _service.GetByGame(game);
            return View("Index", sports);  // Return the filtered results to the Index view
        }

        // Filter countries by selected type (Indoor/Outdoor)
        public IActionResult FilterByType(string type)
        {
            var sports = _service.GetByType(type);
            return View("Index", sports);  // Return the filtered results to the Index view
        }
    }
}
