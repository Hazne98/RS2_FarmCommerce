﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCommerce.Model
{
    public partial class KorisniciUloge
    {
        public int KorisnikUlogaId { get; set; }

        public int? KorisnikId { get; set; }

        public int? UlogaId { get; set; }

        public virtual Uloge? Uloga { get; set; }
    }
}
