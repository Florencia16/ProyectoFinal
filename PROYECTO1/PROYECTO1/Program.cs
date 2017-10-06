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
			int opcion = -1;
			while (opcion != 0)
			{
				Console.Clear();
				Console.WriteLine("------------------------------------------------------------------------------");
				Console.WriteLine("---------------------------BIENVENIDO-----------------------------------------");
				Console.WriteLine("------------------------------------------------------------------------------");
				Console.WriteLine("0- SALIR");
				Console.WriteLine("1- HABILIDAD ESPECIAL CREAR  ");
				Console.WriteLine("2- HABILIDAD ESPECIAL MODIFICAR  ");
				Console.WriteLine("3- HABILIDAD ESPECIAL LISTAR  ");
				Console.WriteLine("4- HABILIDAD ESPECIAL ELIMINAR  ");
				Console.WriteLine("5- CLASE CREAR  ");
				Console.WriteLine("6- CLASE MODIFICAR  ");
				Console.WriteLine("7- CLASE LISTAR");
				Console.WriteLine("8- CLASE ELIMINAR");
				Console.WriteLine("9- CREAR PERSONAJE");
				Console.WriteLine("10- LISTAR PERSONAJE POR CLASE ");
				Console.WriteLine("11- LISTAR PERSONAJE POR RAZA");
				Console.WriteLine("12- LISTAR PERSONAJES");
				Console.WriteLine("13- CREAR RAZA");
				Console.WriteLine("14- LISTAR RAZA");
				Console.WriteLine("15- MODIFICAR RAZA");
				Console.WriteLine("16- ELIMINAR RAZA");

				Console.WriteLine("Ingrese la opción deseada:  ");
				while (!int.TryParse(Console.ReadLine(), out opcion))
				{
					Console.WriteLine("El valor ingresado de Id no es correcto, intente nuevamente por favor ");
				}
				switch (opcion)
				{
					case 0:
						Console.WriteLine("El programa ah finalizado");
						break;
					case 1:
						controlador.CrearHabilidadEspecial();

						break;
					case 2:
						controlador.ModificarHabilidadEspecial();
						break;
					case 3:
						controlador.ListarHabilidadesEspeciales();

						break;
					case 4:
						controlador.EliminarHabilidadEspecial();
						break;
					case 5:
						controlador.CrearClase();
						break;
					case 6:
						controlador.ModificarClase();

						break;
					case 7:
						controlador.ListarClases();
						Console.ReadKey();
						break;
					case 8:
						controlador.EliminarClase();
						break;
					case 9:
						controlador.CrearPersonaje();
						break;
					case 10:
						controlador.ListarPersonajeClase();
						break;
					case 11:
						controlador.ListarPersonajeRaza();
						break;
					case 12:
						controlador.ListarPersonajes();
						break;
					case 13:
						controlador.CrearRaza();
						break;
					case 14:
						controlador.ListarRazas();
						break;
					case 15:
						controlador.ModificarRaza();
						break;
					case 16:
						controlador.EliminarRaza();
						break;
					default:
						Console.WriteLine("La opcion ingresada no es correcta - intenta nuevamente!!!");
						break;
				}
				Console.WriteLine("Presione una tecla para continuar...");
				Console.ReadKey();
			}
		}
	}
}