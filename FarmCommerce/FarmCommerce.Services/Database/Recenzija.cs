using System;
using System.Collections.Generic;

namespace FarmCommerce.Services.Database;

public partial class Recenzija
{
    public int RecenzijaId { get; set; }

    public int? KorisnikId { get; set; }

    public int? ProizvodId { get; set; }

    public int? Ocjena { get; set; }

    public string? Komentar { get; set; }

    public DateTime? VrijemeRecenzije { get; set; }

    public virtual Korisnik? Korisnik { get; set; }

    public virtual Oprema? Proizvod { get; set; }

    public virtual Proizvod? ProizvodNavigation { get; set; }
}
