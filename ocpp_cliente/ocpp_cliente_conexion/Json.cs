using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ocpp_cliente_conexion
{
    public class Json
    {
        private string Cadena;

        public void Serializar()
        {
            Cliente c = new Cliente();

            c.Nombre = "Orlando";
            c.Apellido = "Dominguez";

            Cadena = JsonConvert.SerializeObject(c);

            Console.WriteLine("SERIALIZAR-------------------");
            Console.WriteLine(Cadena);
            Console.WriteLine("-----------------------------");
        }

        public void DesSerializar()
        {
            Cliente c = JsonConvert.DeserializeObject<Cliente>(Cadena);

            Console.WriteLine("DESSERIALIZAR----------------");
            Console.WriteLine(c.Nombre);
            Console.WriteLine(c.Apellido);
            Console.WriteLine("-----------------------------");
        }
    }
}
