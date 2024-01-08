using System;
using System.Collections.Generic;

namespace FarmCommerce.Services.Database;

public partial class Firma
{
    public int FirmaId { get; set; }

    public string? Naziv { get; set; }

    public string? Adresa { get; set; }

    public string? Telefon { get; set; }

    public string? Email { get; set; }

    public string? SlikaUrl { get; set; }

    public virtual ICollection<LokacijaFirme> LokacijaFirmes { get; } = new List<LokacijaFirme>();

    public virtual ICollection<Oprema> Opremas { get; } = new List<Oprema>();

    public virtual ICollection<Proizvod> Proizvods { get; } = new List<Proizvod>();
}
