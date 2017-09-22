using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
    class Program
    {
        static void Main(string[] args)
        {
            Fabrica fabrica = new Fabrica();
            IDPersonaje controlador = fabrica.GetControladorPersonaje();
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("---------------------------BIENVENIDO-----------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("1- PERSONAJE ");
            Console.WriteLine("2- CARACTERISTIVA VARIABLE ");
            Console.WriteLine("2- RAZA");
            Console.WriteLine("3- CLASE ");
            Console.WriteLine("4- HABILIDAD ESPECIAL");
            
            Console.WriteLine("Ingrese la opción deseada:  ");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case '1':   
                            break;
                case '2':
                            break;
                case '3':
                            break;
                case '4':
                            break;
                default:Console.WriteLine("La opcion ingresada no es correcta - intenta nuevamente!!!"); 
                    break; 

            }

            controlador.CrearHabilidadEspecial();
         
            controlador.ListarHabilidadesEspeciales();
            Console.ReadKey();

        }
    }
}
