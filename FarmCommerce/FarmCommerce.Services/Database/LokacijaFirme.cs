using System;
using System.Collections.Generic;

namespace FarmCommerce.Services.Database;

public partial class LokacijaFirme
{
    public int LokacijaFirmeId { get; set; }

    public int? FirmaId { get; set; }

    public string? Adresa { get; set; }

    public string? Grad { get; set; }

    public string? Drzava { get; set; }

    public string? PostanskiBroj { get; set; }

    public virtual ICollection<Dostava> Dostavas { get; } = new List<Dostava>();

    public virtual Firma? Firma { get; set; }

    public virtual ICollection<NarudzbaProizvodum> NarudzbaProizvoda { get; } = new List<NarudzbaProizvodum>();

    public virtual ICollection<Oprema> Opremas { get; } = new List<Oprema>();

    public virtual ICollection<RezervacijaOpreme> RezervacijaOpremes { get; } = new List<RezervacijaOpreme>();
}
