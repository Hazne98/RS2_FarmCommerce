﻿using FarmCommerce.Model;
using FarmCommerce.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCommerce.Services
{
    public interface IProizvodiService : IService<Model.Proizvodi, ProizvodSearchObject>
    {
    }
}
