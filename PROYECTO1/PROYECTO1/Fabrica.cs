using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
    class Fabrica
    {
        public IDPersonaje GetControladorPersonaje()
        {
            return new Controlador();
        }
    }
}
