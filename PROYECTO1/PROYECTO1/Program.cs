using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
    class Program
    {
        static void Main(string[] args)
        {
            Fabrica fabrica = new Fabrica();
            IDPersonaje controlador = fabrica.GetControladorPersonaje();
            controlador.CrearPersonaje();
        }
    }
}
