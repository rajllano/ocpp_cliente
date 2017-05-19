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
    public static class Json
    {
        private static string Cadena;

        public static Reserva DeserializarReservas(string vNumeroSeriePuntoCarga)
        {
            PuntoCarga p = new PuntoCarga();
            p.NumeroSerie = vNumeroSeriePuntoCarga;
            Conexion.enviarMensajeServidor(JsonConvert.SerializeObject(p));


            Reserva c = new Reserva();           
            return c;           
        }

        public static void DesSerializar()
        {  
            Cliente c = JsonConvert.DeserializeObject<Cliente>(Cadena);
        }

        public static string SerializarReserva(ReservaJson objReserva)
        {
            ReservaJson c = new ReservaJson();
            Cadena = JsonConvert.SerializeObject(objReserva);
            return Cadena;
        }

        public static ReservaJson DeserializarReservasMartillado(string pCadena)
        {
            ReservaJson p = JsonConvert.DeserializeObject<ReservaJson>(pCadena);
            
            return p;
        }
    }
}
