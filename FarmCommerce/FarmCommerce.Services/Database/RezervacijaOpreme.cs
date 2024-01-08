using System;
using System.Collections.Generic;

namespace FarmCommerce.Services.Database;

public partial class RezervacijaOpreme
{
    public int RezervacijaOpremeId { get; set; }

    public int? KorisnikId { get; set; }

    public int? OpremaId { get; set; }

    public DateTime? DatumRezervacije { get; set; }

    public DateTime? VremePocetka { get; set; }

    public DateTime? VremeZavrsetka { get; set; }

    public string? StatusRezervacije { get; set; }

    public int? LokacijaFirmeId { get; set; }

    public virtual Korisnik? Korisnik { get; set; }

    public virtual LokacijaFirme? LokacijaFirme { get; set; }

    public virtual Oprema? Oprema { get; set; }

    public virtual ICollection<Placanje> Placanjes { get; } = new List<Placanje>();
}
