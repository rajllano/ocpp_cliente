using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ocpp_cliente_modelo
{
    public class Cliente
    {
        private static Cliente Instancia = null;

        public ColeccionEstacion ColeccionEstacion
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public static Cliente getInstancia()
        {
            if (Instancia == null)
                Instancia = new ocpp_cliente_modelo.Cliente();

            return Instancia;
        }
    }
}