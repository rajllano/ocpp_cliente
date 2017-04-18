using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ocpp_cliente_modelo
{
    public class ColeccionPuntoCarga : Coleccion<PuntoCarga>, IColeccionGenerica<PuntoCarga, IteradorColeccionPuntoCarga>
    {
        public void Agregar(PuntoCarga Elemento)
        {
            throw new NotImplementedException();
        }

        public PuntoCarga Elemento(int Indice)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(PuntoCarga Elemento)
        {
            throw new NotImplementedException();
        }

        public IIterador<IteradorColeccionPuntoCarga> Iterador()
        {
            throw new NotImplementedException();
        }

        public int Tamano()
        {
            throw new NotImplementedException();
        }
    }
}