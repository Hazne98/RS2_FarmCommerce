using System;
using System.Collections.Generic;

namespace FarmCommerce.Services.Database;

public partial class Favoriti
{
    public int FavoritiId { get; set; }

    public int? KorisnikId { get; set; }

    public int? ProizvodId { get; set; }

    public DateTime? VrijemeDodavanja { get; set; }

    public virtual Korisnik? Korisnik { get; set; }

    public virtual Proizvod? Proizvod { get; set; }
}
