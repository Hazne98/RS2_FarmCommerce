using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCommerce.Model.Requests
{
    public class KorisnikUpdateRequest
    {
        public string Ime { get; set; } = null!;

        public string Prezime { get; set; } = null!;

        public string Adresa { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Grad { get; set; } = null!;
    }
}
