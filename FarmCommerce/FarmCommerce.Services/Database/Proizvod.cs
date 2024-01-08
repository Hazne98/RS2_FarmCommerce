using System;
using System.Collections.Generic;

namespace FarmCommerce.Services.Database;

public partial class Proizvod
{
    public int ProizvodId { get; set; }

    public string? Naziv { get; set; }

    public string? Opis { get; set; }

    public decimal? Cena { get; set; }

    public string? SlikaUrl { get; set; }

    public int? FirmaId { get; set; }

    public virtual ICollection<Favoriti> Favoritis { get; } = new List<Favoriti>();

    public virtual Firma? Firma { get; set; }

    public virtual ICollection<NarudzbaProizvodum> NarudzbaProizvoda { get; } = new List<NarudzbaProizvodum>();

    public virtual ICollection<Recenzija> Recenzijas { get; } = new List<Recenzija>();

    public virtual ICollection<StavkaKosarice> StavkaKosarices { get; } = new List<StavkaKosarice>();
}
