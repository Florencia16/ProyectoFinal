﻿using System;
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

        public List<CaracteristicaVariable> caracteristicasVariables;
        public List<HabilidadEspecial> HabilidadesEspeciales;
		public List<Personaje_Caracteristica> Personaje_Caracteristicas;
		public List<Clase> Clases;
        private Manejador()
        {
            this.Personajes = new List<Personaje>();
            this.Razas = new List<Raza>();
            this.HabilidadesEspeciales = new List<HabilidadEspecial>();
            this.Clases = new List<Clase>();
            this.caracteristicasVariables = new List<CaracteristicaVariable>();
			this.Personaje_Caracteristicas = new List<Personaje_Caracteristica>();
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
                Console.WriteLine("Ya existe un Personaje con ese nombre");
            }
        }

        public bool EstaP(Personaje elpersonaje)
        {
            return (Personajes.Exists(x => x.Nombre == elpersonaje.Nombre));
        }

        public bool NomEstaP(string nombre)
        {
            return (Personajes.Exists(x => x.Nombre == nombre));
        }

        public bool EstaHE(HabilidadEspecial LaHabilidadEspecial)
        {
            return (HabilidadesEspeciales.Exists(x => x.Nombre == LaHabilidadEspecial.Nombre));
        }

        public bool NomEstaHE(string nombre)
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
                Console.WriteLine("Ya existe un Habilidad Especial con ese nombre");
            }
        }
        public void AgregarClase(Clase h)
        {
            if (!(Clases.Exists(x => x.Nombre == h.Nombre)))
            {
                this.Clases.Add(h);
            }
            else
            {
                Console.WriteLine("Ya existe una clase con ese nombre");

            }
			
        }

	

		public void AgregarRaza(Raza r)
        {
            if (!(Razas.Exists(x => x.Nombre == r.Nombre)))
            {
                this.Razas.Add(r);
            }
            else
            {
                Console.WriteLine("Ya existe una Raza con ese nombre");

            }
        }

        public bool NomEstaR(string nombre)
        {
            return (Razas.Exists(x => x.Nombre == nombre));
        }

		public bool NomEstaCV(string nombre)
		{
			return (caracteristicasVariables.Exists(x => x.Nombre == nombre));
		}
       

		public int posicionR(String nombre)
        {
            int pos = 0;
            foreach (Raza r in Razas)
            {
                if (r.Nombre != nombre)
                {
                    pos++;
                }
                else
                {
                    return pos;
                }

            }
            return pos;
        }


		public void AgregarCaracteristicaVariable(CaracteristicaVariable h)
        {
            if (!(caracteristicasVariables.Exists(x => x.Nombre == h.Nombre)))
            {
                this.caracteristicasVariables.Add(h);
            }
            else
            {
                Console.WriteLine("Ya existe una CaracteristicaVariable con ese nombre");

            }
        }

        public int posicionHE(String nombre)
        {
            int pos = 0;
            foreach (HabilidadEspecial h in HabilidadesEspeciales)
            {
                if (h.Nombre != nombre)
                {
                    pos++;
                }
                else
                {
                    return pos;
                }

            }
            return pos;
        }

		public int posicionC(String nombre)
         {
             int pos = 0;
             foreach (Clase c in Clases)
             {
                 if (c.Nombre != nombre)
                 {
                     pos++;
                 }
                 else
                 {
                     return pos;
                 }
 
             }
             return pos;
         }


		public bool NomEstaClase(string nombre)
		{
			return (Clases.Exists(x => x.Nombre == nombre));
		}

		public Personaje obtenerPersonaje(string nombre) {
			foreach (Personaje personaje in Personajes) {
				if (personaje.Nombre == nombre) return personaje;
			}
			return null;
		}

		public List<Personaje_Caracteristica> obtenerPersonaje_CaracteristicasPorPersonaje(string nombre)
		{
			List<Personaje_Caracteristica> personajes_caracteristicas = new List<Personaje_Caracteristica>();
			foreach (Personaje_Caracteristica personaje_caracteristica in Personaje_Caracteristicas)
			{
				if (personaje_caracteristica.personaje.Nombre == nombre)
                {
                    personajes_caracteristicas.Add(personaje_caracteristica);
                }
                    
			}
			return personajes_caracteristicas;
		}

		public Personaje_Caracteristica obtenerPersonaje_CaracteristicasPorPersonajeYCaracteristica(string nombrePersonaje, string nombreCaracteristica)
		{
			foreach (Personaje_Caracteristica personaje_caracteristica in Personaje_Caracteristicas)
			{
                if ((personaje_caracteristica.personaje.Nombre == nombrePersonaje) && (personaje_caracteristica.caracteristicaVariable.Nombre == nombreCaracteristica))
                {
                    return personaje_caracteristica;
                }
			}
			return null;
		}

		public Raza obtrenerRazaPorId(int idRaza)
		{
			foreach (Raza raza in Razas)
			{
				if (raza.Id == idRaza) return raza;
			}
			return null;
		}

		public CaracteristicaVariable obtenerCaracteristicaVariablePorId(int idCaracteristicaVariable) {
			foreach (CaracteristicaVariable caracteristicasVariable in caracteristicasVariables)
			{
				if (caracteristicasVariable.Id == idCaracteristicaVariable) return caracteristicasVariable;
			}
			return null;
		}
	}
}

    


