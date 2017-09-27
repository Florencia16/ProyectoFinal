using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
    public class CaracteristicaVariable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Personaje_Caracteristica valor { get; set; }

        public CaracteristicaVariable(string n, Personaje_Caracteristica v)
        {
            this.Nombre = n;
            this.valor = v;
        }
    }
}
