using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
   public class Raza
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
		public CaracteristicaVariable caracteristicaVariable { get; set; }
		public List<Personaje> personajes { get; set; }
    }
}
