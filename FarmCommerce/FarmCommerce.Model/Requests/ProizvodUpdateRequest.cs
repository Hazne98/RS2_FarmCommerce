using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCommerce.Model.Requests
{
    public class ProizvodUpdateRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ime proizvoda je obavezan")]
        public string? Naziv { get; set; }

        public string? Opis { get; set; }

        public decimal? Cena { get; set; }

        public string? SlikaUrl { get; set; }

        //public int? FirmaId { get; set; }
    }
}
