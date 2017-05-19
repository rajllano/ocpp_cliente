using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ocpp_cliente_modelo;
using ocpp_cliente_control;
using NetworksApi.TCP.CLIENT;

namespace ocpp_cliente_control
{
    public class Json
    {
        private string Cadena;

        public Reserva DeserializarReservas(string vNumeroSeriePuntoCarga)
        {
            PuntoCarga p = new PuntoCarga();
            p.NumeroSerie = vNumeroSeriePuntoCarga;
            Conexion.enviarMensajeServidor("SOL_RESERVA" + JsonConvert.SerializeObject(p));
            Reserva c = new Reserva();           
            return c;           
        }

        public void DesSerializar()
        {  
            Cliente c = JsonConvert.DeserializeObject<Cliente>(Cadena);
        }
    }
}
