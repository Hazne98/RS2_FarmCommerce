using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCommerce.Model
{
    public class Proizvodi
    {
        public int ProizvodId { get; set; }

        public string? Naziv { get; set; }

        public string? Opis { get; set; }

        public decimal? Cena { get; set; }

        public string? SlikaUrl { get; set; }

        public int? FirmaId { get; set; }
    }
}
