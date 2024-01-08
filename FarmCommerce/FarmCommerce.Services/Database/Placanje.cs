using System;
using System.Collections.Generic;

namespace FarmCommerce.Services.Database;

public partial class Placanje
{
    public int PlacanjeId { get; set; }

    public int? NarudzbaProizvodaId { get; set; }

    public int? RezervacijaOpremeId { get; set; }

    public decimal? UkupanIznos { get; set; }

    public string? TipPlacanja { get; set; }

    public string? StatusPlacanja { get; set; }

    public virtual NarudzbaProizvodum? NarudzbaProizvoda { get; set; }

    public virtual RezervacijaOpreme? RezervacijaOpreme { get; set; }
}
