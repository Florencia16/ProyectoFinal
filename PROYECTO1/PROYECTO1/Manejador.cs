using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
    class Manejador
    {
        public List<Personaje> Personajes;

        private Manejador()
        {
            this.Personajes = new List<Personaje>(); 
        }
        private static Manejador instancia;

        public static Manejador getInstancia()
        {
            if (instancia == null)
            {
                instancia = new Manejador();
            }
            return instancia;
        }

        public void AgregarPersonaje(Personaje p)
        {
            if (!Esta(p))
            {
                this.Personajes.Add(p);
            }
            else
            {
                throw new Exception("Ya existe un Personaje con ese nombre");
            }
        }

        public bool Esta (Personaje elpersonaje)
        {
            return (Personajes.Exists(x => x.Nombre == elpersonaje.Nombre));
        }

        public bool NomEsta(string nombre)
        {
            return (Personajes.Exists(x => x.Nombre == nombre));
        }

    }
}
