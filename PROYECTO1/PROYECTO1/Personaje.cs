using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
    public class Personaje
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Nivel { get; set; }
        public int Fuerza { get; set; }
        public int Destreza { get; set; }
        public int Constitucion { get; set; }
        public int Inteligencia { get; set; }
        public int Sabiduria { get; set; }
        public int Carisma { get; set; }
        public List<CaracteristicaVariable> CaracteristicasVariables { get; set; }
        public Raza LaRaza { get; set; }
        public Clase LaClase { get; set; }

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
            this.Id = Manejador.getInstancia().Personajes.Count + 1;
            this.CaracteristicasVariables = new List<CaracteristicaVariable>();
        }
        public Personaje()
        {

        }

        public void AumentarNivel()
        {
            List<HabilidadEspecial> listAux = new List<HabilidadEspecial>();
            Manejador m = Manejador.getInstancia();
            foreach (HabilidadEspecial HE in m.HabilidadesEspeciales)
            {
                foreach (HabilidadEspecial h in LaClase.habilidadesEspeciales)
                {
                    if (!HE.Nombre.Equals(h.Nombre))
                    {
                        listAux.Add(HE);
                    }
                }
            }
            if (listAux.Count == 0)
            {
                Console.WriteLine("Este Personaje ya tiene cargadas todas las HE que posee ");
            }
            else
            {
                foreach (HabilidadEspecial h in listAux)
                {
                    Console.WriteLine(" Habilidad Especial Id-{0} Nombre-{1} Descripcion- {2}", h.Id, h.Nombre, h.Descripcion);
                }
                Console.WriteLine("Ingrese el Id de la HE que desea agregara este personaje por subir de nivel");
                int idHE = int.Parse(Console.ReadLine());
                LaClase.habilidadesEspeciales.Add(m.HabilidadesEspeciales[idHE - 1]);


            }

            if ((Nivel % 2 != 0) && (Nivel != 1))
            {
                if (CaracteristicasVariables.Count == 0)
                {
                    Console.WriteLine("No se han ingresado ninguna caracteristica variable a este personaje");
                }
                Console.WriteLine("Eliga una CV para aumentar al subir de nivel");
                Console.WriteLine("Caracteristicas Variables existentes en este Personaje: ");
                foreach (CaracteristicaVariable c in CaracteristicasVariables)
                {
                    if (!(c.valor.valor == 10))
                    {
                        c.ImprimirCV();

                    }
                }
                Console.WriteLine("Id de CV a aumentar?");
                int idCV = int.Parse(Console.ReadLine());
                while ((idCV < 0) || (idCV > m.caracteristicasVariables.Count))
                {
                    Console.WriteLine("El valor ingresado no es el correcto");
                    idCV = int.Parse(Console.ReadLine());
                }
                CaracteristicasVariables[idCV].valor.valor++;
                
               
            }
            Nivel++; 
        }
    }
}

