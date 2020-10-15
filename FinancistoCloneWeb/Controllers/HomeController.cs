using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FinancistoCloneWeb.Models;
using System.Globalization;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace FinancistoCloneWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

       /* private List<PokemonGo> accounts = new List<PokemonGo>
        {
            new PokemonGo {Id = 1, Name = "Efectivo"},
            new PokemonGo {Id = 2, Name = "Tarjeta Credito BCP"},
            new PokemonGo {Id = 3, Name = "Tarjeta Credito Interbank"},
            new PokemonGo {Id = 4, Name = "Chanchito"},
            new PokemonGo {Id = 5, Name = "Bajo el colchon"}
        };*/

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }     

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {            
            return View();
        }

        [HttpPost]

        public IActionResult Create(PokemonGo account)
        {
            if (string.IsNullOrEmpty(account.Nombre))
                ModelState.AddModelError("Name", "Nombre es requerido");            

            if (ModelState.IsValid)
            {
                //Guardar
                return RedirectToAction("Index");
            }

            return View(account);
            // No guardar
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       /* public List<PokemonGo> BuscarPorNombre(string name)
        {
            //name = name.Replace("é", "e");
            return accounts.Where(o => string.Compare(
        RemoveAccents(o.Name), RemoveAccents(name), StringComparison.InvariantCultureIgnoreCase) == 0).ToList();
        }*/

        private static string RemoveAccents(string s)
        {
            Encoding destEncoding = Encoding.GetEncoding("utf-8");

            return destEncoding.GetString(
                Encoding.Convert(Encoding.UTF8, destEncoding, Encoding.UTF8.GetBytes(s)));
        }
    }
}
