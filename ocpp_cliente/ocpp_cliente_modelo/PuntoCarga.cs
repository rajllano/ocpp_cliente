﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ocpp_cliente_modelo
{
    public class PuntoCarga 
    {
        public int Id { get; set; }

        public string NumeroSerie { get; set; }

        public string Marca { get; set; }

        public string Modelo { get; set; }
    }
}