using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinancistoCloneWeb.Models
{
    public class PokemonGo
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Imagen { get; set; }

        public int UserId { get; set; }
        public int TipoId { get; set; }

        // relaciones
        public Tipo Tipo { get; set; }
        public List<UsuarioPokemonGo> UsuarioPokemonGos { get; set; }

    }
}
