﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models.Interfaces
{
    public interface IPlanetaDTO
    {
        int Id { get; set; }
        string Nome { get; set; }
    }
}