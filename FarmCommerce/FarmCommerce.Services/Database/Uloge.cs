using System;
using System.Collections.Generic;

namespace FarmCommerce.Services.Database;

public partial class Uloge
{
    public int UlogaId { get; set; }

    public string? Naziv { get; set; }

    public virtual ICollection<KorisniciUloge> KorisniciUloges { get; } = new List<KorisniciUloge>();
}
