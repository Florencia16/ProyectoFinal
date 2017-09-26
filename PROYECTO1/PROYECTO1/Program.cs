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
            Console.WriteLine("1- HABILIDAD ESPECIAL CREAR  ");
            Console.WriteLine("2- HABILIDAD ESPECIAL MODIFICAR  ");
            Console.WriteLine("2- HABILIDAD ESPECIAL LISTAR HABILIDADES ESPECIALES ");
            Console.WriteLine("3- ELIMINAR  ");
            
            Console.WriteLine("Ingrese la opción deseada:  ");
            int opcion = int.Parse(Console.ReadLine());
            switch (opcion)
            {
                case '1':
                    controlador.CrearHabilidadEspecial();

                    break;
                case '2':
                    controlador.ModificarHabilidadEspecial();
                    break;
                case '3':
                    controlador.ListarHabilidadesEspeciales();

                    break;
                case '4':
                    Console.WriteLine("Tranqui GERARDO aún no tenemos la funcionalidad Eliminar jeje");
                    break;
                default:
                    Console.WriteLine("La opcion ingresada no es correcta - intenta nuevamente!!!");
                    break;
            }
            Console.ReadKey();
        }
    }
}
