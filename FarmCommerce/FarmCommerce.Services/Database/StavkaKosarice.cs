using System;
using System.Collections.Generic;

namespace FarmCommerce.Services.Database;

public partial class StavkaKosarice
{
    public int StavkaKosariceId { get; set; }

    public int? KosaricaId { get; set; }

    public int? ProizvodId { get; set; }

    public int? Kolicina { get; set; }

    public virtual Kosarica? Kosarica { get; set; }

    public virtual Proizvod? Proizvod { get; set; }
}
