using System;
using System.Collections.Generic;

namespace FarmCommerce.Services.Database;

public partial class Dostava
{
    public int DostavaId { get; set; }

    public int? NarudzbaProizvodaId { get; set; }

    public string? StatusDostave { get; set; }

    public DateTime? VrijemeDostave { get; set; }

    public int? LokacijaFirmeId { get; set; }

    public virtual LokacijaFirme? LokacijaFirme { get; set; }

    public virtual NarudzbaProizvodum? NarudzbaProizvoda { get; set; }
}
