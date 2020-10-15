using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancistoCloneWeb.Models
{
    public class UsuarioPokemonGo
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdPokemonGo { get; set; }
        public PokemonGo PokemonGos { get; set; }
        public User Users { get; set; }

    }
}
