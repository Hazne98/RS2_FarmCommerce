using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCommerce.Model.SearchRequests
{
    public class FirmaSearchObject : BaseSearchObject
    {

        public string? Naziv { get; set; }

        public string? Adresa { get; set; }
        public string? Email { get; set; }

        public decimal? Telefon { get; set; }

        public string? SlikaUrl { get; set; }
    }
}
