using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
    public class HabilidadEspecial
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public HabilidadEspecial (int id, string nombre, string descripcion)
        {
            this.Id = id; 
            this.Nombre = nombre;
            this.Descripcion = descripcion;
			this.Id = Manejador.getInstancia().HabilidadesEspeciales.Count + 1;
		}

       
    }
}
