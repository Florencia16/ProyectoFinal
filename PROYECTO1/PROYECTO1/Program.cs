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

				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("                                           `-+s:`                                         ");
				Console.WriteLine("                                        -ohNm+`                                          ");
				Console.WriteLine("                                     :smMMNo`                                              ");
				Console.WriteLine("                                  .omMMMMy.                                              ");
				Console.WriteLine("                                :yNMMMMMh:`                                               ");
				Console.WriteLine("                              `/dNMMMMMms/-..-::..-:/+osyyhhdddmmmNmdhso/-.               ");
				Console.WriteLine("                    .:+syyyo/+dMMMMMMMmyydmmNNNNNNNMMMMMMMMMMNmhyo/-``                    ");
				Console.WriteLine("                   .sddhhNMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMmhs+:-.`                         ");
				Console.WriteLine("                   :-.```oMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNmmmmmdhyso/:.                   ");
				Console.WriteLine("                       `/mMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNs:..```                      ");
				Console.WriteLine("                     `/hNMmdhMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMms-                          ");
				Console.WriteLine("                 `-/ymNms:-+mMMMMMMMMMMNMMMMMMMMMMMMMMMMMMMMMMMMNs.                        ");
				Console.WriteLine("                /dNMMMh/:/dMMMMMMMMMMMMd+oydNMMMMMMMMMMMMMNyydNMMMm+`                      ");
				Console.WriteLine("            `./yNMMMMMMMMMMMMMMMMMmsNMN+s` `-/smMMMMMMMMMMMd.`./ymMMh.                     ");
				Console.WriteLine("        `-+ydNMMMMMMMMMMMMMMMMMMMN+ :dM:       `+mMMMMMMMMMMm.   .+dMm:                    ");
				Console.WriteLine("       -hNMMMMMMMMMMMMMMMMMMNNmds-   `y/         sMMMMMMMMMMMd.    `+dm:                   ");
				Console.WriteLine("       hMMMMMMMNmhyso+++///::-.`      ``      `-oNMMMMMMMMMMMMh`     `+d:                  ");
				Console.WriteLine("      hMMMMMMMNmhyso+++///::-.`      ``      `-oNMMMMMMMMMMMMh`     `+d:                  ");
				Console.WriteLine("      sNMMMMd+-`                       ``.-+sdNMMMMMMMMMMMMMMMo       `:`                 ");
				Console.WriteLine("       /ydh+`               ````..-:+oyhdNMMMMMMMMMMMMMMMMMMMMN-                          ");
				Console.WriteLine("                :ossssssyyhhhdmmNMMMMMMMMMMMMMMMMMMMMMMMMNMMMMMh                          ");
				Console.WriteLine("                 `/hNMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNy/:dMMMMN-                         ");
				Console.WriteLine("                 `-+mMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNd+.   .dMMMM+                         ");
				Console.WriteLine("              `/ymMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNy:       /MMMMy                         ");
				Console.WriteLine("           `/hNMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNh/`         `MMMMs                         ");
				Console.WriteLine("          -yNMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNh+.            `NMMM+                         ");
				Console.WriteLine("        :hMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMmy/`               `MMMm`                         ");
				Console.WriteLine("      .hMMMMMMMMMMMMMMMMMMdo:-.`:dMNmho/.                   .MMm-                          ");
				Console.WriteLine("     /NMMMMMMMMMMMMMMMMMy.    `:/:.`                        /Ny.                           ");
				Console.WriteLine("------------------------------------------------------------------------------");
				Console.WriteLine("---------------------------BIENVENIDO-----------------------------------------");
				Console.WriteLine("------------------------------------------------------------------------------");
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("0- SALIR");
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.WriteLine("OPCIONES HABILIDADES ESPECIALES");
				Console.ForegroundColor = ConsoleColor.Magenta;
				Console.WriteLine("1- CREAR  ");
				Console.WriteLine("2- MODIFICAR  ");
				Console.WriteLine("3- LISTAR  ");
				Console.WriteLine("4- ELIMINAR  ");
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.WriteLine("OPCIONES CLASES");
				Console.ForegroundColor = ConsoleColor.Magenta;
				Console.WriteLine("5- CREAR  ");
				Console.WriteLine("6-  MODIFICAR  ");
				Console.WriteLine("7-  LISTAR");
				Console.WriteLine("8-  ELIMINAR");
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.WriteLine("OPCIONES PERSONAJES");
				Console.ForegroundColor = ConsoleColor.Magenta;
				Console.WriteLine("9- CREAR ");
				Console.WriteLine("10- LISTAR POR CLASE ");
				Console.WriteLine("11- LISTAR POR RAZA");
				Console.WriteLine("12- LISTAR ");
                Console.WriteLine("13- MODIFICAR ");
                Console.WriteLine("14- ELIMINAR");
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.WriteLine("OPCIONES RAZA");
				Console.ForegroundColor = ConsoleColor.Magenta;
				Console.WriteLine("15- CREAR ");
				Console.WriteLine("16- LISTAR ");
				Console.WriteLine("17- MODIFICAR ");
				Console.WriteLine("18- ELIMINAR ");
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.WriteLine("OPCIONES NIVEL");
				Console.ForegroundColor = ConsoleColor.Magenta;
				Console.WriteLine("19- Subir ");
				Console.ForegroundColor = ConsoleColor.Blue;
				Console.WriteLine("OPCIONES CARACTERISTICAS");
				Console.ForegroundColor = ConsoleColor.Magenta;
				Console.WriteLine("20- Crear");
                Console.WriteLine("21- Modificar");
                Console.WriteLine("22- Listar");
				Console.WriteLine("23- Eliminar Caracteristica");
                
                Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("Ingrese la opción deseada:  ");
				Console.ForegroundColor = ConsoleColor.Cyan;
				while (!int.TryParse(Console.ReadLine(), out opcion))
				{
					Console.ForegroundColor = ConsoleColor.DarkGreen;
					Console.WriteLine("La opccion ingresada no es correcta, intente nuevamente por favor ");
				}
				switch (opcion)
				{
					case 0:
						Console.ForegroundColor = ConsoleColor.DarkGreen;
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
                    case 13: controlador.ModificarPersonaje();
                        break;
                    case 14: controlador.EliminarPersonaje();
                        break; 
					case 15:
						controlador.CrearRaza();
						break;
					case 16:
						controlador.ListarRazas();
						break;
					case 17:
						controlador.ModificarRaza();
						break;
					case 18:
						controlador.EliminarRaza();
						break;
                    case 19:  controlador.SubirNivel();
                        break;
                    case 20: controlador.CrearCaracteristica();
                        break;
                    case 21: controlador.ModificarCarateristica();
                        break;
                    case 22: controlador.ListarCaracteristicas();
                        break;
                    case 23: controlador.EliminarCaracteristica();
                        break; 
					default:
						Console.ForegroundColor = ConsoleColor.DarkGreen;
						Console.WriteLine("La opcion ingresada no es correcta - intenta nuevamente!!!");
						break;
				}
				Console.ForegroundColor = ConsoleColor.DarkGreen;
				Console.WriteLine("Presione una tecla para continuar...");
				Console.ReadKey();
			}
		}
	}
}