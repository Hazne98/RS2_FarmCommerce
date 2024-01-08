using System;
using System.Collections.Generic;

namespace FarmCommerce.Services.Database;

public partial class NarudzbaProizvodum
{
    public int NarudzbaProizvodaId { get; set; }

    public int? KorisnikId { get; set; }

    public int? ProizvodId { get; set; }

    public int? Kolicina { get; set; }

    public decimal? UkupnaCena { get; set; }

    public string? StatusNarudzbe { get; set; }

    public int? LokacijaFirmeId { get; set; }

    public virtual ICollection<Dostava> Dostavas { get; } = new List<Dostava>();

    public virtual Korisnik? Korisnik { get; set; }

    public virtual LokacijaFirme? LokacijaFirme { get; set; }

    public virtual ICollection<Placanje> Placanjes { get; } = new List<Placanje>();

    public virtual Proizvod? Proizvod { get; set; }
}
