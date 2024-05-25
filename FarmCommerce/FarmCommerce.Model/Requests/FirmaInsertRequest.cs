using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCommerce.Model.Requests
{
    public class FirmaInsertRequest
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ime firme je obavezan")]
        public string? Naziv { get; set; }

        public string? Adresa { get; set; }
        public string? Email { get; set; }
        public string? Telefon { get; set; }


    }
}
