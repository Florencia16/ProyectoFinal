using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
   public class Personaje
    {
        
        public int Id { get; set;}
        public string Nombre { get; set; }
        public int Nivel { get; set; }
        public int Fuerza { get; set; }
        public int Destreza { get; set; }
        public int Constitucion { get; set; }
        public int Inteligencia { get; set; }
        public int Sabiduria { get; set; }
        public int Carisma { get; set; } 
        //ACA PARA MI IRIA UNA LISTA DE CARACTERISTICAS VARIABLES Y UNA OBJETO DE TIPO CLASE CON UNA LISTA DE HABILIDADES ESPECIALES POR CLASE DADO QUE UN PERSONAJE ES DE UNA CLASE
        // Y TAMBIEN IRIA UN OBJETO DE TIPO RAZA DADO QUE UN PERSONAJE PERTENECE A UNA RAZA Y CON ESO SE REALIZA LA MEJORA 

		public List<HabilidadEspecial> habilidadesEspeciales { get; set; }
        

        public Personaje(int id, string nombre, int nivel, int fuerza, int destreza, int constitucion, int inteligencia, int sabiduria, int carisma)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Nivel = nivel;
            this.Fuerza = fuerza;
            this.Destreza = destreza;
            this.Constitucion = constitucion;
            this.Inteligencia = inteligencia;
            this.Sabiduria = sabiduria;
            this.Carisma = carisma;
		
        }

    }
}
