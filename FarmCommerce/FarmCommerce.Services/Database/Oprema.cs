using System;
using System.Collections.Generic;

namespace FarmCommerce.Services.Database;

public partial class Oprema
{
    public int OpremaId { get; set; }

    public string? Naziv { get; set; }

    public string? Opis { get; set; }

    public decimal? Cena { get; set; }

    public string? SlikaUrl { get; set; }

    public int? KategorijaId { get; set; }

    public int? FirmaId { get; set; }

    public int? LokacijaFirmeId { get; set; }

    public virtual Firma? Firma { get; set; }

    public virtual Kategorija? Kategorija { get; set; }

    public virtual LokacijaFirme? LokacijaFirme { get; set; }

    public virtual ICollection<Recenzija> Recenzijas { get; } = new List<Recenzija>();

    public virtual ICollection<RezervacijaOpreme> RezervacijaOpremes { get; } = new List<RezervacijaOpreme>();
}
