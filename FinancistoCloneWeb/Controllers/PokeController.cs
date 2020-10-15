using FinancistoCloneWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FinancistoCloneWeb.Controllers
{
    [Authorize]
    public class PokeController : BaseController
    {
        private PokemonContext _context;
        public IHostEnvironment _hostEnv;

        public PokeController(PokemonContext context, IHostEnvironment hostEnv):base(context)
        {
            _context = context;
            _hostEnv = hostEnv;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var account = new PokemonGo();            
            var accounts = _context.PokemonGos
                .Where(o => o.UserId == LoggedUser().Id)
                .Include(o => o.Tipo)
                .ToList();
          
            return View(accounts);            
        }


        [HttpGet]
        public ActionResult Create() // GET
        {
            ViewBag.Tipos = _context.TiposL.ToList();
            return View("Create", new PokemonGo());
        }

        [HttpPost]
        public ActionResult Create(PokemonGo pokemonGo, IFormFile image) // POST
        {
            
                
            pokemonGo.UserId = LoggedUser().Id;
          
            if (ModelState.IsValid)
            {
                 pokemonGo.Imagen = SaveImage(image);


                    _context.PokemonGos.Add(pokemonGo);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                
            }
            ViewBag.Tipos = _context.TiposL.ToList();
            return View("Create", pokemonGo);
        }
        [HttpGet]
        public ActionResult Capturar(int pokemon)
        {
            var captura = new UsuarioPokemonGo
            {
                IdPokemonGo = pokemon,
                IdUser = LoggedUser().Id
            };
            _context.UsuarioPokemonGos.Add(captura);
            _context.SaveChanges();
            RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var account = _context.PokemonGos.Where(o => o.Id == id).FirstOrDefault();
            _context.PokemonGos.Remove(account);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        private string SaveImage(IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                var basePath = _hostEnv.ContentRootPath + @"\wwwroot";
                var ruta = @"\files\" + image.FileName;

                using (var strem = new FileStream(basePath + ruta, FileMode.Create))
                {
                    image.CopyTo(strem);
                    return ruta;
                }
            }
            return null;
        }

    }
}
