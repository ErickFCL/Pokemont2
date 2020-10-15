using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancistoCloneWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinancistoCloneWeb.Controllers
{
    public abstract class BaseController : Controller
    {
        private readonly PokemonContext context;
        public BaseController(PokemonContext context)
        {
            this.context = context;
        }

        protected User LoggedUser()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault();
            var user = context.Users.Where(o => o.UserName == claim.Value).FirstOrDefault();
            return user;
        }
    }
}
