using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ocpp_cliente_modelo
{
    public interface IIterador<T>
    {
        T Siguiente();

        bool tieneSiguiente();
    }
}