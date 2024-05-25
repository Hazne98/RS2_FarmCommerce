using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCommerce.Model.Requests
{
    public class ProizvodInsertRequest
    {
        [Required(AllowEmptyStrings = false)] //ne moze se poslat u nazivu samo space
        public string? Naziv { get; set; }

        public string? Opis { get; set; }

        public decimal? Cena { get; set; }

        public string? SlikaUrl { get; set; }

        public int? FirmaId { get; set; }

    }
}
