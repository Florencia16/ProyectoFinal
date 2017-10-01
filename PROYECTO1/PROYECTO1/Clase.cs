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
        public List<HabilidadEspecial> habilidadesEspeciales { get; set; }
        public List<Personaje> pertenecen { get; set; }

        public Clase (string nombre , string descripcion){
            this.Nombre = nombre;
            this.Descripcion = descripcion;
			habilidadesEspeciales = new List<HabilidadEspecial>();
			this.Id = Manejador.getInstancia().Clases.Count + 1;
            this.pertenecen = new List<Personaje>();
		}
	}
}
