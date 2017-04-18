using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ocpp_cliente_modelo
{
    public class ColeccionEstacion : Coleccion<Estacion>, IColeccionGenerica<Estacion, IteradorColeccionEstacion>
    {
        public void Agregar(Estacion Elemento)
        {
            throw new NotImplementedException();
        }

        public Estacion Elemento(int Indice)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Estacion Elemento)
        {
            throw new NotImplementedException();
        }

        public IIterador<IteradorColeccionEstacion> Iterador()
        {
            throw new NotImplementedException();
        }

        public int Tamano()
        {
            throw new NotImplementedException();
        }
    }
}