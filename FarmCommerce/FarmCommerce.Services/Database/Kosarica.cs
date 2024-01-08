using System;
using System.Collections.Generic;

namespace FarmCommerce.Services.Database;

public partial class Kosarica
{
    public int KosaricaId { get; set; }

    public int? KorisnikId { get; set; }

    public DateTime? DatumDodavanja { get; set; }

    public virtual Korisnik? Korisnik { get; set; }

    public virtual ICollection<StavkaKosarice> StavkaKosarices { get; } = new List<StavkaKosarice>();
}
