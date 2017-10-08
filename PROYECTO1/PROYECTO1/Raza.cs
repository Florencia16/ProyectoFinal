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
        public List<Personaje> pertenece { get; set; }
		public CaracteristicaVariable caracteristicaVariable;
        public Raza (string n, string d, CaracteristicaVariable cv)
        {
            this.Nombre = n;
            this.Descripcion = d; 
			this.Id = Manejador.getInstancia().Razas.Count + 1;
            this.pertenece = new List<Personaje>();
			this.caracteristicaVariable = cv;
		}
        public Raza()
        {

        }
	}
}
