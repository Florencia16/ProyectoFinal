using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
    public class Clase
    {
        public int Id { get; set; } 
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
		public List<Personaje> personajes { get; set; }
		public List<HabilidadEspecial> habilidadesEspeciales { get; set; }
	}
}
