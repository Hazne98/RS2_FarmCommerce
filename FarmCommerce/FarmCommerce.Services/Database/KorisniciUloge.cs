using System;
using System.Collections.Generic;

namespace FarmCommerce.Services.Database;

public partial class KorisniciUloge
{
    public int KorisnikUlogaId { get; set; }

    public int? KorisnikId { get; set; }

    public int? UlogaId { get; set; }

    public virtual Korisnik? Korisnik { get; set; }

    public virtual Uloge? Uloga { get; set; }
}
