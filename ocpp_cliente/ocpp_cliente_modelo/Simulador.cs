using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ocpp_cliente_modelo
{
    public class Simulador
    {

        public ColeccionElectrolinera ColeccionElectrolinera
        {
            get
            {
                return this.ColeccionElectrolinera;
            }

            set
            {
                this.ColeccionElectrolinera = value;
            }
        }
    }
}