using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCommerce.Model
{
    public class Firma
    {
        public int FirmaId { get; set; }

        public string? Naziv { get; set; }

        public string? Adresa { get; set; }
        public string? Email { get; set; }

        public decimal? Telefon { get; set; }

        public string? SlikaUrl { get; set; }

    }
}
