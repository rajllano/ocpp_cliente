using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ocpp_cliente_modelo
{
    public class Coleccion : ColeccionSensor
    {
        private List<Object> Lista;

        public Coleccion()
        {
            Lista = new List<object>();
        }

        public void Agregar(Object o)
        {
            Lista.Add(o);
        }

        public void Eliminar(Object o)
        {
            Lista.Remove(o);
        }

        public Object Elemento(int Indice)
        {
            return Lista[Indice];
        }

        public int Size()
        {
            return Lista.Count;
        }
    }
}