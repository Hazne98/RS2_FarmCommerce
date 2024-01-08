using System;
using System.Collections.Generic;

namespace FarmCommerce.Services.Database;

public partial class Kategorija
{
    public int KategorijaId { get; set; }

    public string? Naziv { get; set; }

    public virtual ICollection<Oprema> Opremas { get; } = new List<Oprema>();
}
