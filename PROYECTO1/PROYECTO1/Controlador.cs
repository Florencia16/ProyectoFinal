using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{

    public class Controlador : IDPersonaje
    {


        public HabilidadEspecial CrearHabilidadEspecial()
        {
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("----------------------------Alta Habilidad Especial --------------------------");
            Console.WriteLine("------------------------------------------------------------------------------");
            Manejador mp = Manejador.getInstancia();
            Console.WriteLine("Ingrese el nombre de la Habilidad Especial");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese una breve descripcion de esta Habilidad Especial");
            string descricpion = Console.ReadLine();
            int id = mp.HabilidadesEspeciales.Count + 1;
            mp.AgregarHabilidadEspecial(new HabilidadEspecial(id, nombre, descricpion));
            return(new HabilidadEspecial(id, nombre, descricpion));

        }


        public void ModificarHabilidadEspecial()
        {
            Manejador mp = Manejador.getInstancia();
            int pos;
            Console.WriteLine(" Ingrese el nombre: ");
            string nombre = Console.ReadLine();
            if (mp.NomEstaHE(nombre))
            {
                Console.WriteLine("Parametro que desea modificar:  ");
                Console.WriteLine("1- Nombre ");
                Console.WriteLine("2- Descripcion ");
                int opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {

                    case 1:
                        Console.WriteLine("Nombre? ");
                        string n = Console.ReadLine().ToLower();
                        while (mp.NomEstaHE(n))
                        {
                            Console.WriteLine("Ya existe una Habilidad especial con ese nombre ");
                            Console.WriteLine("Ingrese nuevo nombre ");
                            n = Console.ReadLine();
                        }
                        pos = mp.posicionHE(nombre);
                        mp.HabilidadesEspeciales[pos].Nombre = n;
                        Console.WriteLine("Modificación realizada con exito!! ");

                        break;
                    case 2:

                        pos = mp.posicionHE(nombre);
                        Console.WriteLine("Ingrese una nueva descripción");
                        mp.HabilidadesEspeciales[pos].Descripcion = Console.ReadLine();
                        Console.WriteLine("Modificación realizada con exito!! ");
                        break;
                    default: Console.WriteLine("La opcion ingresada no es la correcta");
                        break;
                }
            }
            else
            {
                Console.WriteLine("No hay ninguna habilidad especial con ese nombre!!! ");
            }

        }


        public void ListarHabilidadesEspeciales()
        {
            Manejador mp = Manejador.getInstancia();
            if(mp.HabilidadesEspeciales.Count == 0)
            {
                Console.WriteLine("No se han ingresado habilidades especiales en el Sistema "); 
            }else
            {
                foreach (HabilidadEspecial HE in mp.HabilidadesEspeciales)
                {
                    Console.WriteLine("Id - {0} Nombre - {1} Descripcion - {2} ", HE.Id, HE.Nombre, HE.Descripcion);
                }
            }


        }


        public void ListarHabilidadEspecialPorClase()
        {
            Manejador mp = Manejador.getInstancia();
            if (mp.Clases.Count == 0)
            {
                Console.WriteLine("No se han ingresado Clases en el Sistema ");
            }
            else
            {
                foreach (Clase c in mp.Clases)
                {
                    Console.WriteLine("Clase Id- {0} Nombre - {1} ", c.Id, c.Nombre);
                    Console.WriteLine("Posee las siguientes Habilidades Especiales: ");
                    foreach (HabilidadEspecial h in c.habilidadesEspeciales)
                    {
                        Console.WriteLine("Habilidad Especial Id - {0} Nombre - {1} Descripcion - {2}", h.Id, h.Nombre, h.Descripcion);
                    }
                }
            }
        
        }


        public void EliminarHabilidadEspecial()
        {
            Manejador mp = Manejador.getInstancia();
            Console.WriteLine("Ingrese el nombre de la Habilidad especial a eliminar");
            string nombreHE = Console.ReadLine();
            if (mp.NomEstaHE(nombreHE))
            {

                int posicionHE = mp.posicionHE(nombreHE);
                HabilidadEspecial habilidadEspecial = mp.HabilidadesEspeciales[posicionHE];
                mp.HabilidadesEspeciales.Remove(habilidadEspecial);
                foreach (Clase clase in mp.Clases) {
                    clase.habilidadesEspeciales.Remove(habilidadEspecial);
                }
                Console.WriteLine("La Habilidad Especial ha sido eliminada con exito!!");
            }
            else
            {
                Console.WriteLine("No se encontro una Habilidad Especial con el nombre ingresado");
            }
        }


        public Clase CrearClase()
        {
            Manejador mp = Manejador.getInstancia();

            Console.WriteLine("Ingrese el nombre de la Clase");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese una breve descripcion de esta Clase");
            string descripcion = Console.ReadLine();
            Console.WriteLine("Desea agregar alguna Habilidad Especial a esta clase ? S/N");
            string res = Console.ReadLine().ToLower();
            mp.AgregarClase(new Clase(nombre, descripcion));
            while (res.Equals("s"))
            {
                Console.WriteLine("Ingrese el nombre de la Habilidad Especial");
                string n = Console.ReadLine();
                Console.WriteLine("Ingrese una breve descripcion de esta Habilidad Especial");
                string d = Console.ReadLine();
                int id = mp.HabilidadesEspeciales.Count + 1;
                mp.AgregarHabilidadEspecial(new HabilidadEspecial(id, n, d));
                int pos = mp.posicionC(nombre);
                mp.Clases[pos].habilidadesEspeciales.Add(new HabilidadEspecial(id, n, d));
                Console.WriteLine("Desea agregar alguna otra Habilidad Especial a esta clase ? S/N");
                res = Console.ReadLine().ToLower();
            }

            return (new Clase(nombre, descripcion));
        }



        public void ModificarClase()
		{
			Manejador mp = Manejador.getInstancia();
			Console.WriteLine("Ingrese el nombre de la clase a modificar");
			string nombreClase = Console.ReadLine();
			if (mp.NomEstaClase(nombreClase))
			{
				//obtenemos la clase a modificar
				int posicionClase = mp.posicionC(nombreClase);
				Clase clase = mp.Clases[posicionClase];
				Console.WriteLine("Ingrese el parametro que desea modificar");
				Console.WriteLine("1-Nombre");
				Console.WriteLine("2-Descripcion");
				Console.WriteLine("3-Habilidades Especiales");
				int opcion = 0;
				while (!int.TryParse(Console.ReadLine(), out opcion))
				{
					Console.WriteLine("Lo ingresado no es correcto, lo ingresasado deberá ser un número entre 1 y 10");
				}
				switch (opcion)
				{

					case 1:
						Console.WriteLine("Ingrese el nuevo nombre ");
						string n = Console.ReadLine();
						while (mp.NomEstaClase(n))
						{
							Console.WriteLine("Ya existe una Clase con ese nombre ");
							Console.WriteLine("Ingrese nuevo nombre ");
							n = Console.ReadLine();
						}
						clase.Nombre = n;
						Console.WriteLine("Modificación realizada con exito!! ");
						break;
					case 2:
						Console.WriteLine("Ingrese una nueva descripción");
						clase.Descripcion = Console.ReadLine();
						Console.WriteLine("Modificación realizada con exito!! ");
						break;
					case 3:
						//obtenemos el tipo de operacion a ejectuar
						Console.WriteLine("Que desea hacer?");
						Console.WriteLine("1 - Agregar Habilidad Especial");
						Console.WriteLine("2 - Quitar Habilidad Especial");
						string opcionIngresada = Console.ReadLine();
						if (opcionIngresada == "1")
						{
							Console.WriteLine("Seleccione el nombre de la habilidad especial a agregar");
							ListarHabilidadesEspeciales();
							string nombreHablidadEspecial = Console.ReadLine();
							int posicionHabilidadEspecial = mp.posicionHE(nombreHablidadEspecial);
							HabilidadEspecial habilidadEspecial = mp.HabilidadesEspeciales[posicionHabilidadEspecial];
							clase.habilidadesEspeciales.Add(habilidadEspecial);
							Console.WriteLine("Modificación realizada con exito!! ");
						}
						else if (opcionIngresada == "2")
						{
							Console.WriteLine("Seleccione el nombre de la habilidad especial a quitar");
							ListarHabilidadesEspeciales();
							string nombreHablidadEspecial = Console.ReadLine();

							if (mp.NomEstaHE(nombreHablidadEspecial))
							{
								int posicionHabilidadEspecial = mp.posicionHE(nombreHablidadEspecial);
								HabilidadEspecial habilidadEspecial = mp.HabilidadesEspeciales[posicionHabilidadEspecial];
								clase.habilidadesEspeciales.Remove(habilidadEspecial);
								Console.WriteLine("Modificación realizada con exito!! ");


							}
							else
							{
								Console.WriteLine("No se encontro la habilidad especial ");


							}



						}
						else
						{
							Console.WriteLine("Opcion incorrecta");
						}

						break;
					default:
						Console.WriteLine("La opción ingresada no es correcta");
						break;
				}
			}
			else
			{
				Console.WriteLine("No se encontro una clase con el nombre ingresado");
			}

		}



		public void ListarClases()
		{
			Manejador mp = Manejador.getInstancia();
			if (mp.Clases.Count==0)
			{
				Console.WriteLine("No se han ingresado Clases en el Sistema");
			}
			else
			{
				foreach (Clase C in mp.Clases)
				{
					Console.WriteLine("Id - {0} Nombre - {1} Descripcion - {2} ", C.Id, C.Nombre, C.Descripcion);
				}
			}
		}



		public void EliminarClase()
		{
			Manejador mp = Manejador.getInstancia();
			Console.WriteLine("Ingrese el nombre de la clase a eliminar");
			string nombreClase = Console.ReadLine();
			if (mp.NomEstaClase(nombreClase))
			{

				int posicionClase = mp.posicionC(nombreClase);
				Clase clase = mp.Clases[posicionClase];
				mp.Clases.Remove(clase);
				Console.WriteLine("la clase ha sido eliminada con exito");
			}
			else
			{
				Console.WriteLine("no se encontro una clase con el nombre ingresado");
			}
		}



		public Raza CrearRaza()
		{
			Manejador mp = Manejador.getInstancia();
            int IdCV;
			Console.WriteLine("Ingrese el nombre de la Raza");
			string nombre = Console.ReadLine();
			Console.WriteLine("Ingrese una breve descripcion de esta Raza");
			string descricpion = Console.ReadLine();
            if (mp.caracteristicasVariables.Count == 0)
            {
                Console.WriteLine("No se ha ingrsado ningun caracteristica al sistema, No se podrá realizar el bono por Raza");
            }
            else
            {
                Console.WriteLine("Ingrese el valor de la mejora para esta Raza");
                int bono = int.Parse(Console.ReadLine());
                while (!int.TryParse(Console.ReadLine(), out bono))
                {
                    Console.WriteLine("Lo ingresado no es correcto, lo ingresasado deberá ser un número entre 1 y 5");
                }
                while ((bono < 1) || (bono > 5))
                {
                    Console.WriteLine("El valor de la mejora no se encuentra en el rango 1-5 - Intente nuevamente por favor");
                    bono = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Esta son las CV ingresadas hasta al momento en el Sistema"); 
                foreach(CaracteristicaVariable c in mp.caracteristicasVariables)
                {
                    Console.WriteLine("Id - {0} Nombre - {1} Valor actual: {2}", c.Id , c.Nombre, c.valor.valor);
                }
                Console.WriteLine("Ingrese el Id de la CV que desea realizar la mejora");
                while (!int.TryParse(Console.ReadLine(), out IdCV))
                {
                    Console.WriteLine("Lo ingresado no es correcto, Intente nuevamente por favor");
                }
                mp.caracteristicasVariables[IdCV - 1].BonoRaza = bono;
                Console.WriteLine("Bono cargado con éxito!!!"); 
            }
            mp.AgregarRaza(new Raza(nombre, descricpion));
			return(new Raza(nombre, descricpion));

		}


		public void ModificarRaza()
		{
			Manejador mp = Manejador.getInstancia();
			int pos;
			Console.WriteLine(" Ingrese el nombre: ");
			string nombre = Console.ReadLine();
			if (mp.NomEstaR(nombre))
			{
				Console.WriteLine("Parametro que desea modificar:  ");
				Console.WriteLine("1- Nombre ");
				Console.WriteLine("2- Descripcion ");
				int opcion = 0;
				while (!int.TryParse(Console.ReadLine(), out opcion))
				{
					Console.WriteLine("Lo ingresado no es correcto, lo ingresasado deberá ser un número entre 1 y 10");
				}
				switch (opcion)
				{

					case 1:
						Console.WriteLine("Ingrese nuevo nombre ");
						string n = Console.ReadLine();
						while (mp.NomEstaR(n))
						{
							Console.WriteLine("Ya existe una Raza con ese nombre ");
							Console.WriteLine("Ingrese nuevo nombre ");
							n = Console.ReadLine();
						}
						pos = mp.posicionR(nombre);
						mp.Razas[pos].Nombre = n;
						Console.WriteLine("Modificación realizada con exito!! ");
						break;
					case 2:

						pos = mp.posicionR(nombre);
						Console.WriteLine("Ingrese una nueva descripción");
						mp.Razas[pos].Descripcion = Console.ReadLine();
						Console.WriteLine("Modificación realizada con exito!! ");
						break;

					default:
						Console.WriteLine("La opción ingresada no es correcta");
						break;

				}
			}
			else
			{
				Console.WriteLine("no se encontro una Raza con el nombre ingresado");
			}

		}



		public void ListarRazas()
		{
			Manejador mp = Manejador.getInstancia();
			if (mp.Razas.Count ==0 )
			{
				Console.WriteLine("No se han ingresado Razas en el Sistema");
			}
			else
			{
				foreach (Raza R in mp.Razas)
				{
					Console.WriteLine("Id - {0} Nombre - {1} Descripcion - {2} ", R.Id, R.Nombre, R.Descripcion);
				}

			}
		}

		
		public void EliminarRaza()
		{
			Manejador mp = Manejador.getInstancia();
			Console.WriteLine("Ingrese el nombre de la Raza a eliminar");
			string nombreRaza = Console.ReadLine();
			if (mp.NomEstaR(nombreRaza))
			{

				int posicionR = mp.posicionR(nombreRaza);
			    Raza raza = mp.Razas[posicionR];
				mp.Razas.Remove(raza);
				Console.WriteLine("La Raza ha sido eliminada con exito");
			}
			else
			{
				Console.WriteLine("No se encontro una Raza con el nombre ingresado");
			}


		}


		public CaracteristicaVariable CrearCaracteristica()
		{

			Manejador mp = Manejador.getInstancia();
            Personaje_Caracteristica v = new Personaje_Caracteristica();

            Console.WriteLine("Ingrese el nombre de la Caracteristica Variable");
			string nombre = Console.ReadLine();
			Console.WriteLine("Valor?");
			
			v.valor = int.Parse(Console.ReadLine());
            while ((v.valor < 1) || (v.valor > 10))
            {
                Console.WriteLine("Valor ingresado no válido para esta caracterisitca, debe ser entre el rando 1-10");
                Console.WriteLine("Intente nuevamente");
                v.valor = int.Parse(Console.ReadLine());
            }
            mp.AgregarCaracteristicaVariable(new CaracteristicaVariable(nombre, v));
			return(new CaracteristicaVariable(nombre, v));

		}



		public void ModificarCarateristica()
		{
			Manejador mp = Manejador.getInstancia();
			Console.WriteLine("Ingrese el nombre de la Caracteristica a modificar");
			string nombreCaracteristica = Console.ReadLine();
			if (mp.NomEstaCV(nombreCaracteristica))
			{

				int posicionC = mp.posicionC(nombreCaracteristica);
				Clase clase = mp.Clases[posicionC];
				Console.WriteLine("Ingrese el parametro que desea modificar");
				Console.WriteLine("1-Nombre");
				int opcion = 0;
				while (!int.TryParse(Console.ReadLine(), out opcion))
				{
					Console.WriteLine("Lo ingresado no es correcto, lo ingresasado deberá ser un número entre 1 y 10");
				}
				switch (opcion)
				{

					case 1:
						Console.WriteLine("Ingrese el nuevo nombre ");
						string n = Console.ReadLine();
						while (mp.NomEstaCV(n))
						{
							Console.WriteLine("Ya existe una Caracteristica con ese nombre ");
							Console.WriteLine("Ingrese nuevo nombre ");
							n = Console.ReadLine();
						}
						clase.Nombre = n;
						Console.WriteLine("Modificación realizada con exito!! ");

						break;
					default:
						Console.WriteLine("La opción ingresada no es correcta");
						break;
				}

			}
		}


        public void ListarCaracteristicas()
		{
			Manejador mp = Manejador.getInstancia();
			if (mp.caracteristicasVariables.Count==0)
			{
				Console.WriteLine("No se ha ingresado ninguna Caracteristica Varibale en el Sistema  ");
			}
			else
			{
				foreach (CaracteristicaVariable CV in mp.caracteristicasVariables)
				{
                    CV.ImprimirCV();
				}

			}
		}

		
        
		public void EliminarCaracteristica()
		{
			Manejador mp = Manejador.getInstancia();
			Console.WriteLine("Ingrese el nombre de la Caracteristica a eliminar");
			string nombreCaracteristica = Console.ReadLine();
			if (mp.NomEstaCV(nombreCaracteristica))
			{

				int posicionCaracteristica = mp.posicionC(nombreCaracteristica);
				CaracteristicaVariable caracteristicaVariable = mp.caracteristicasVariables[posicionCaracteristica];
				mp.caracteristicasVariables.Remove(caracteristicaVariable);
				Console.WriteLine("la Caracteristica ha sido eliminada con exito");
			}
			else
			{
				Console.WriteLine("no se encontro una Caracteristica con el nombre ingresado");
			}



		}


		public void CrearPersonaje()
		{
			Manejador mp = Manejador.getInstancia();
			int niv, fue, des, con, sab, inte, car;
            CaracteristicaVariable cvaux = new CaracteristicaVariable();
            Clase claseAux = new Clase(); 
            Personaje_Caracteristica valoraux = new Personaje_Caracteristica();
            Raza razaAux = new Raza(); 
			Console.WriteLine("------------------------------------------------------------------------------");
			Console.WriteLine("----------------------------Alta Personaje------------------------------------");
			Console.WriteLine("------------------------------------------------------------------------------");
			Console.WriteLine("Ingrese Nombre");
			string elnombre = Console.ReadLine().ToLower();
			while (mp.NomEstaP(elnombre))
			{
				Console.WriteLine("Ya existe en el sistema un Personaje con ese nombre : {0} por favor ingrese otro", elnombre);
				elnombre = Console.ReadLine();


			}
			Console.WriteLine("Ingrese Nivel");
			while (!int.TryParse(Console.ReadLine(), out niv))
			{
				Console.WriteLine("El valor del nivel ingresado no es el correcto");
			}
			Console.WriteLine("Ingrese valor Fuerza");
			while (!int.TryParse(Console.ReadLine(), out fue))
			{
				Console.WriteLine("Lo ingresado no es correcto, lo ingresasado deberá ser un número entre 1 y 10");
			}
			while ((fue < 1) || (fue > 10))
			{
				Console.WriteLine("Valor ingresado para Caracteristica Fuerza no es valido, debe ser entre 1 y 10");
                Console.WriteLine("Intente nuevamente por favor, ingrese valor");

                fue = int.Parse(Console.ReadLine());

			}
			Console.WriteLine("Ingrese valor Destreza");
			while (!int.TryParse(Console.ReadLine(), out des))
			{
				Console.WriteLine("Lo ingresado no es correcto, lo ingresasado deberá ser un número entre 1 y 10");
			}
			while ((des < 1) || (des > 10))
			{
				Console.WriteLine("Valor ingresado para Caracteristica Destreaza no es valido, debe ser entre 1 y 10");
                Console.WriteLine("Intente nuevamente por favor, ingrese valor");

                des = int.Parse(Console.ReadLine());

			}
			Console.WriteLine("Ingrese valor Constitucion");
			while (!int.TryParse(Console.ReadLine(), out con))
			{
				Console.WriteLine("Lo ingresado no es correcto, lo ingresasado deberá ser un número entre 1 y 10");
			}
			while ((con < 1) || (con > 10))
			{
				Console.WriteLine("Valor ingresado para Caracteristica Constitución no es valido, debe ser entre 1 y 10");
                Console.WriteLine("Intente nuevamente por favor, ingrese valor");

                con = int.Parse(Console.ReadLine());

			}
			Console.WriteLine("Ingrese valor Inteligencia");
			while (!int.TryParse(Console.ReadLine(), out inte))
			{
				Console.WriteLine("Lo ingresado no es correcto, lo ingresasado deberá ser un número entre 1 y 10");
			}
			while ((inte < 1) || (inte > 10))
			{
				Console.WriteLine("Valor ingresado para Caracteristica Inteligencia no es valido, debe ser entre 1 y 10");
                Console.WriteLine("Intente nuevamente por favor, ingrese valor");

                inte = int.Parse(Console.ReadLine());

			}
			Console.WriteLine("Ingrese valor Sabiduria");
			while (!int.TryParse(Console.ReadLine(), out sab))
			{
				Console.WriteLine("Lo ingresado no es correcto, lo ingresasado deberá ser un número entre 1 y 10");
			}
			while ((sab < 1) || (sab > 10))
			{
				Console.WriteLine("Valor ingresado para Caracteristica Sabiduria no es valido, debe ser entre 1 y 10");
                Console.WriteLine("Intente nuevamente por favor, ingrese valor");

                sab = int.Parse(Console.ReadLine());

			}
			Console.WriteLine("Ingrese valor Carisma");
			while (!int.TryParse(Console.ReadLine(), out car))
			{
				Console.WriteLine("Lo ingresado no es correcto, lo ingresasado deberá ser un número entre 1 y 10");
			}
			while ((car < 1) || (car > 10))
			{
				Console.WriteLine("Valor ingresado para Caracteristica Carisma no es valido, debe ser entre 1 y 10");
                Console.WriteLine("Intente nuevamente por favor, ingrese valor");

                car = int.Parse(Console.ReadLine());

			}
			int id = mp.Personajes.Count + 1;
			mp.AgregarPersonaje(new Personaje(id, elnombre, niv, fue, des, con, inte, sab, car));
            if (mp.caracteristicasVariables.Count == 0)
            {
                Console.WriteLine("No se han creado ninguna Caracteristica Variable en el Sistema para ingresar valor en este Personaje"); 
            }
            else
            {
                Console.WriteLine("Ya se han ingresado caracteristicas en el Sistema que serán ingresadas en este Personaje");
                Console.WriteLine("Ingrese el valor de cada una de ellas para el Personaje {0} ",elnombre); 

                foreach (CaracteristicaVariable cv in mp.caracteristicasVariables)
                {
                    Console.WriteLine("Caracteristica Nombre - {0} ", cv.Nombre);
                    Console.WriteLine("Valor para este Personaje ");
                    valoraux.valor = int.Parse(Console.ReadLine());
                    while((valoraux.valor <1)|| (valoraux.valor>10))
                    {
                        Console.WriteLine("Valor ingresado no válido para esta caracterisitca, debe ser entre el rando 1-10");
                        Console.WriteLine("Intente nuevamente");
                        valoraux.valor = int.Parse(Console.ReadLine());
                    }
                    CaracteristicaVariable caracteristica = mp.obtenerCaracteristivaV(cv.Nombre);
                    caracteristica.valor = valoraux;
                    mp.obtenerPersonaje(elnombre).CaracteristicasVariables.Add(caracteristica); 
                }
            }
            
            Console.WriteLine("Desea cargar una nueva caracteristica variable?");
            Console.WriteLine("S/N");
            string entrada = Console.ReadLine().ToLower();
            if (entrada.Equals("s"))
            {
                cvaux = CrearCaracteristica();
                mp.obtenerPersonaje(elnombre).CaracteristicasVariables.Add(cvaux);
                
                foreach ( Personaje paux in mp.Personajes)
                {
                    if (!(paux == mp.obtenerPersonaje(elnombre)))
                    {
                        cvaux.valor.valor = 1;
                        paux.CaracteristicasVariables.Add(cvaux);
                    }
                    
                }

            }
            Console.WriteLine("Dese ingresar la Raza de este personaje? S/N");
			string res = Console.ReadLine().ToLower();
			if (res.Equals("s"))
			{
				if (mp.Razas.Count == 0)
				{
					Console.WriteLine("No se han ingresado ninguna Raza al sistema, crea la raza para ser asignada a este personaje");
					razaAux = CrearRaza();
                    mp.Personajes[id - 1].LaRaza = razaAux; 
					mp.Razas[0].pertenece.Add(mp.Personajes[id - 1]);
                    Console.WriteLine("Raza cargada con exito");

                }
                else
				{
					ListarRazas();
					Console.WriteLine("Estas son las razas cargadas en el sistema, favor indica el id  para cargar una existente 0 para crear una nueva raza ");
					int idR = int.Parse(Console.ReadLine());
					while ((idR < 0) && (idR > mp.Razas.Count))
					{
						Console.WriteLine("El número de id ingresado no es el correcto - favor ingrese nuevamente ");
						idR = int.Parse(Console.ReadLine());
					}
                    if (idR == 0)
                    {
                        razaAux = CrearRaza();
                        mp.Personajes[id - 1].LaRaza = razaAux;
                        mp.Razas[mp.Razas.Count-1].pertenece.Add(mp.Personajes[id - 1]);
                        Console.WriteLine("Raza cargada con exito"); 
                    }
                    else
                    {
                        mp.Personajes[id - 1].LaRaza = razaAux;
                        mp.Razas[idR - 1].pertenece.Add(mp.Personajes[id - 1]);
                        Console.WriteLine("Raza cargada con exito");


                    }

                }
			}

			Console.WriteLine("Dese ingresar la Clase de este personaje? S/N");
			string consola = Console.ReadLine().ToLower();
			if (consola.Equals("s"))
			{
				if (mp.Clases.Count == 0)
				{
					Console.WriteLine("No se han ingresado ninguna Clase al sistema, crea la Clase para ser asignada a este personaje");
					claseAux = CrearClase();
					mp.Personajes[id - 1].LaClase = claseAux;
					mp.Clases[0].pertenecen.Add(mp.Personajes[id - 1]);
                    Console.WriteLine(" Clase cargada con éxito"); 
				}
				else
				{
					ListarClases();
					Console.WriteLine("Estas son las clases cargadas en el sistema, favor indica el id para cargar una existente 0 para crear una nueva clase ");
					int idC = int.Parse(Console.ReadLine());
					while ((idC < 0) && (idC > mp.Clases.Count))
					{
						Console.WriteLine("El número de id ingresado no es el correcto - favor ingrese nuevamente ");
						idC = int.Parse(Console.ReadLine());
					}
					if (idC==0)
					{
                        claseAux = CrearClase();
                        mp.Personajes[id - 1].LaClase = claseAux;
                        mp.Clases[0].pertenecen.Add(mp.Personajes[id - 1]);
                        Console.WriteLine(" Clase cargada con éxito");
                    }
					else
					{
                        mp.Personajes[id - 1].LaClase = mp.Clases[idC - 1];
                        mp.Clases[idC - 1].pertenecen.Add(mp.Personajes[id - 1]);
                        Console.WriteLine("Clase cargada con éxito"); 
                    }


				}

			}
            
		}


		public void ModificarPersonaje()
		{
			Manejador mp = Manejador.getInstancia();
			int id;
			if (mp.Personajes.Count == 0)
			{
				Console.WriteLine("No se han ingresado ningun personaje en el sistema");
			}
			else
			{
				ListarPersonajes();
				Console.WriteLine("Ingrese el Id del personaje a Modificar");
				while (!int.TryParse(Console.ReadLine(), out id))
				{
					Console.WriteLine("El valor del nivel ingresado no es el correcto");
				}
				while ((id < 0) && (id > mp.Personajes.Count))
				{
					Console.WriteLine("El id  ingresado no es el correcto, intente nuevamente");
					while (!int.TryParse(Console.ReadLine(), out id))
					{
						Console.WriteLine("El valor del nivel ingresado no es el correcto");
					}
				}
				Console.WriteLine("Parametro que desea modificar:  ");
				Console.WriteLine("1- Nombre ");
				Console.WriteLine("2- Nivel ");
				Console.WriteLine("3- Valor de Caracteristica Fuerza ");
				Console.WriteLine("4- Valor de Caracteristica Destreza ");
				Console.WriteLine("5- Valor de Caracteristica Constitución ");
				Console.WriteLine("6- Valor de Caracteristica Inteligencia ");
				Console.WriteLine("7- Valor de Caracteristica Sabiduria ");
				Console.WriteLine("8- Valor de Caracteristica Carisma ");
                Console.WriteLine("9- Modificar datos Clase ");
                Console.WriteLine("10- Modificar datos Raza ");
                Console.WriteLine("11- Modificar datos de Caracteristica Variable ");
                switch (id)
                {
                    case 1:
                        Console.WriteLine("Valor?");
                        string nom = Console.ReadLine();
                        mp.Personajes[id - 1].Nombre = nom;
                        Console.WriteLine("Modificación realizada con exito!");
                        break;
                    case 2:
                        int niv;
                        Console.WriteLine("Valor?");
                        while (!int.TryParse(Console.ReadLine(), out niv))
                        {
                            Console.WriteLine("El valor del nivel ingresado no es el correcto");
                        }
                        mp.Personajes[id - 1].Nivel = niv;
                        Console.WriteLine("Modificación realizada con exito!");
                        break;
                    case 3:
                        int fue;
                        Console.WriteLine("Valor?");
                        while (!int.TryParse(Console.ReadLine(), out fue))
                        {
                            Console.WriteLine("El valor de la caracteristica Fuerza ingresado no es el correcto, intente nuevamente");
                        }
                        mp.Personajes[id - 1].Fuerza = fue;
                        Console.WriteLine("Modificación realizada con exito!");
                        break;
                    case 4:
                        int des;
                        Console.WriteLine("Valor?");
                        while (!int.TryParse(Console.ReadLine(), out des))
                        {
                            Console.WriteLine("El valor de la caracteristica Destreza ingresado no es el correcto, intente nuevamente");
                        }
                        mp.Personajes[id - 1].Destreza = des;
                        Console.WriteLine("Modificación realizada con exito!");
                        break;
                    case 5 :
                        int cons;
                        Console.WriteLine("Valor?");
                        while (!int.TryParse(Console.ReadLine(), out cons))
                        {
                            Console.WriteLine("El valor de la caracteristica Constitución ingresado no es el correcto, intente nuevamente");
                        }
                        mp.Personajes[id - 1].Constitucion = cons;
                        Console.WriteLine("Modificación realizada con exito!");
                        break;
                    case 6:
                        int inte;
                        Console.WriteLine("Valor?");
                        while (!int.TryParse(Console.ReadLine(), out inte))
                        {
                            Console.WriteLine("El valor de la caracteristica Inteligencia ingresado no es el correcto, intente nuevamente");
                        }
                        mp.Personajes[id - 1].Inteligencia = inte;
                        Console.WriteLine("Modificación realizada con exito!");
                        break;
                    case 7:
                        int sab;
                        Console.WriteLine("Valor?");
                        while (!int.TryParse(Console.ReadLine(), out sab))
                        {
                            Console.WriteLine("El valor de la caracteristica Sabiduaria ingresado no es el correcto, intente nuevamente");
                        }
                        mp.Personajes[id - 1].Sabiduria = sab;
                        Console.WriteLine("Modificación realizada con exito!");
                        break;
                    case 8:
                        int car;
                        Console.WriteLine("Valor?");
                        while (!int.TryParse(Console.ReadLine(), out car))
                        {
                            Console.WriteLine("El valor de la caracteristica Carisma ingresado no es el correcto, intente nuevamente");
                        }
                        mp.Personajes[id - 1].Carisma = car;
                        Console.WriteLine("Modificación realizada con exito!");
                        break;
                    case 9: ModificarClase();
                        break;
                    case 10: ModificarRaza();
                        break;
                    case 11: ModificarCarateristica();
                        break;
                    default: Console.WriteLine("Ese comando no esta predeterminado");
                        break;
                    case '0': break;
				}

			}


		}


		public void ListarPersonajes()
		{
			Manejador mp = Manejador.getInstancia();
			if (mp.Personajes.Count == 0)
			{
				Console.WriteLine("--------------------------No hay personajes ingresados en el sistema------------------------- ");
			}
			else
			{
                Console.WriteLine("-----------------------------------------------------------------------------------------");
                Console.WriteLine("---------------------------Personajes del Sistema ---------------------------------------");
                Console.WriteLine("-----------------------------------------------------------------------------------------");

                foreach (Personaje p in mp.Personajes)
				{
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                    Console.WriteLine("Id - {0} Nombre - {1} Nivel {2}", p.Id, p.Nombre, p.Nivel);
                    Console.WriteLine("----Valores Caracteristicas Fijas---------");
                    Console.WriteLine("Fuerza ->> {0}", p.Fuerza);
                    Console.WriteLine("Destreza ->> {0}", p.Destreza);
                    Console.WriteLine("Constitución ->> {0}", p.Constitucion);
                    Console.WriteLine("Inteligencia ->> {0}", p.Inteligencia);
                    Console.WriteLine("Sabiduria ->> {0}", p.Sabiduria);
                    Console.WriteLine("Carisma ->> {0}", p.Carisma);
                    if (p.CaracteristicasVariables.Count == 0)
                    {
                        Console.WriteLine("-----No tiene ninguna caracteristica variable ingresada--------"); 
                    }
                    else
                    {
                        Console.WriteLine("-------------------------Valores Caracteristicas Variables------------------------");
                        foreach (CaracteristicaVariable c in p.CaracteristicasVariables)
                        {
                            c.ImprimirCV();
                        }
                    }
                    if (p.LaClase == null)
                    {
                        Console.WriteLine("---------------------No se ha ingresado una clase en este personaje------------------"); 
                    }
                    else
                    {
                        Console.WriteLine("-----------------------------Pertenece a la Clase------------------------------------");
                        Console.WriteLine("Id - {0} Nombre - {1} Descripción - {2} ", p.LaClase.Id, p.LaClase.Nombre, p.LaClase.Descripcion);
                        if (p.LaClase.habilidadesEspeciales.Count == 0)
                        {
                            Console.WriteLine("No posee este personaje ninguna Habilidad Especial ingresada");
                        }
                        else
                        {
                            foreach(HabilidadEspecial h in p.LaClase.habilidadesEspeciales)
                            {
                                Console.WriteLine("Id - {0} Nombre - {1} Descripción - {2}", h.Id, h.Nombre, h.Descripcion);
                            }
                        }
                        
                    }
                    if (p.LaRaza == null)
                    {
                        Console.WriteLine("---------------------No se ha ingresado una raza en este personaje------------------");
                    }
                    else
                    {
                        Console.WriteLine("-----------------------------Pertenece a la Raza------------------------------------");
                        Console.WriteLine("Id - {0} Nombre - {1} Descripcion - {2} ", p.LaRaza.Id, p.LaRaza.Nombre, p.LaRaza.Descripcion);

                    }
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                    Console.WriteLine("-----------------------------------------------------------------------------------------");

                }
            }
		}


		public void ListarPersonajeClase()
		{
			Manejador mp = Manejador.getInstancia();
            if (mp.Clases.Count == 0)
            {
                Console.WriteLine("No se han ingresado Clases en el Sistema");
            }
            else
            {
                foreach (Clase c in mp.Clases)
                {
                    Console.WriteLine("Clase Id- {0} Nombre- {1} Descripcion {2}", c.Id, c.Nombre, c.Descripcion);
                    Console.WriteLine("Lista de perosnajes que pertenecen a esta clase -------- ");
                    foreach (Personaje p in c.pertenecen)
                    {
                        Console.WriteLine("Personaje Id- {0} Nombre- {1} Nivel- {2}", p.Id, p.Nombre, p.Nivel);
                    }
                }
            }
		}


		public void ListarPersonajeRaza()
		{
			Manejador mp = Manejador.getInstancia();
            if (mp.Razas.Count == 0)
            {
                Console.WriteLine("No se han ingresado Razas en el Sistema ");
            }
            else
            {
                foreach (Raza R in mp.Razas)
                {
                    Console.WriteLine("Raza Id- {0} Nombre- {1} Descripcion {2}", R.Id, R.Nombre, R.Descripcion);
                    Console.WriteLine("Lista de personajes que tienen esta raza  -------- ");
                    foreach (Personaje p in R.pertenece)
                    {
                        Console.WriteLine("Personaje Id- {0} Nombre- {1} Nivel- {2}", p.Id, p.Nombre, p.Nivel);
                    }
                }

            }
			
		}


		public void EliminarPersonaje()
		{
			Manejador mp = Manejador.getInstancia();
			int id;
			if (mp.Personajes == null)
			{
				Console.WriteLine("No hay ningun personaje ingresado");
			}
			else
			{
				Console.WriteLine("Ingrese el Id del Personaje a Eliminar");
				while (!int.TryParse(Console.ReadLine(), out id))
				{
					Console.WriteLine("Lo ingresado no es correcto, lo ingresasado deberá ser un número entre 1 y {0}", mp.Personajes.Count);
				}
				while ((id > mp.Personajes.Count) && (id < 0))
				{
					Console.WriteLine("El id ingresado no es el correcto, intente nuevamente por favor");
					id = int.Parse(Console.ReadLine());
				}
				mp.Personajes.Remove(mp.Personajes[id]);
				Console.WriteLine("Eliminación realzada con exito!");
			}

		}


		public void SubirNivel()
		{
			Manejador mp = Manejador.getInstancia();
			Personaje p = new Personaje();
			int id;
            if (mp.Personajes.Count == 0)
            {
                Console.WriteLine("No se han ingresado ningún personaje al sistema, debe ingresar un personaje primero");
            }
            else
            {
                ListarPersonajes();
                Console.WriteLine("Ingrese el Nombre del Personaje a subir de nivel ");
				string nombrePersonaje = Console.ReadLine();
                while (!mp.NomEstaP(nombrePersonaje))
                {
                    Console.WriteLine("No se encontro el personaje ingresado, intente nuevamente por favor ");
					nombrePersonaje = Console.ReadLine();
				}
				p = mp.obtenerPersonaje(nombrePersonaje);
                p.AumentarNivel();
                Console.WriteLine("El nivel ha sido aumentado con exito al Personaje {0}", p.Nombre); 
            }
		}



	}


}
