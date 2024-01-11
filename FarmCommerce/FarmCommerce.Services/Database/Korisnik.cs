using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmCommerce.Services.Database;

public partial class Korisnik
{
    public int KorisnikId { get; set; }

    public string? Ime { get; set; }

    public string? Prezime { get; set; }

    public string? Email { get; set; }

    public string? Lozinka { get; set; }

    public string? Telefon { get; set; }

    public string? Adresa { get; set; }

    public string? Grad { get; set; }

    public string? Drzava { get; set; }

    public string? PostanskiBroj { get; set; }
    public string? LozinkaHash { get; set; }
    public string? LozinkaSalt { get; set; }

    public virtual ICollection<Favoriti> Favoritis { get; } = new List<Favoriti>();

    public virtual ICollection<KorisniciUloge> KorisniciUloges { get; } = new List<KorisniciUloge>();

    public virtual ICollection<Kosarica> Kosaricas { get; } = new List<Kosarica>();

    public virtual ICollection<NarudzbaProizvodum> NarudzbaProizvoda { get; } = new List<NarudzbaProizvodum>();

    public virtual ICollection<Recenzija> Recenzijas { get; } = new List<Recenzija>();

    public virtual ICollection<RezervacijaOpreme> RezervacijaOpremes { get; } = new List<RezervacijaOpreme>();
}
