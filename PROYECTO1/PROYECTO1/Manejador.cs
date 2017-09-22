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

        public List<Raza> Razas;

        public List<HabilidadEspecial> HabilidadesEspeciales; 

        private Manejador()
        {
            this.Personajes = new List<Personaje>();
            this.Razas = new List<Raza>();
            this.HabilidadesEspeciales = new List<HabilidadEspecial>();
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
            if (!EstaP(p))
            {
                this.Personajes.Add(p);
            }
            else
            {
                throw new Exception("Ya existe un Personaje con ese nombre");
            }
        }

        public bool EstaP (Personaje elpersonaje)
        {
            return (Personajes.Exists(x => x.Nombre == elpersonaje.Nombre));
        }

        public bool NomEstaP(string nombre)
        {
            return (Personajes.Exists(x => x.Nombre == nombre));
        }

        public bool EstaHE (HabilidadEspecial LaHabilidadEspecial)
        {
            return (HabilidadesEspeciales.Exists(x => x.Nombre == LaHabilidadEspecial.Nombre));
        }

        public bool NomEstaHE( string nombre)
        {
            return (HabilidadesEspeciales.Exists(x => x.Nombre == nombre));
        }

        public void AgregarHabilidadEspecial(HabilidadEspecial h)
        {
            if (!EstaHE(h))
            {
                this.HabilidadesEspeciales.Add(h);
            }
            else
            {
                throw new Exception("Ya existe un Habilidad Especial con ese nombre");
            }
        }

    }
}
