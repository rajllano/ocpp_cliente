using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ocpp_cliente_modelo
{
    public class Reserva
    {
        public int Id { get; set; }

        public PuntoCarga PuntoCarga { get; set; }

        public Vehiculo Vehiculo { get; set; }

        public DateTime FechaHora { get; set; }

        public int Tiempo { get; set; }

        public double ValorRecarga { get; set; }

        public double EnergiaRecarga { get; set; }

        public DateTime FechaRegistro { get; set; }
        
    }

}