﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
    public class Controlador : IDPersonaje
    {

        //terminada :) 
        public void CrearHabilidadEspecial()
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

        }

        // solo me falta y la clase 
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
                Console.WriteLine("3- A que clase pertenece ");
                int opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    
                    case 1:
                        Console.WriteLine("Valor? ");
                        string n = Console.ReadLine();
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
                        Console.WriteLine("Ingrese el nombre de la Habilidad Especial a modificar su descripción: ");
                        string nom = Console.ReadLine();
                        pos = mp.posicionHE(nom);
                        Console.WriteLine("Ingrese una nueva descripción");
                        mp.HabilidadesEspeciales[pos].Descripcion = Console.ReadLine();
                        Console.WriteLine("Modificación realizada con exito!! ");
                        break;
                    case 3:
                            Console.WriteLine("Esta Habilidad Especial pertence a: ");
                            
                            
                            ListarClases();
                            Console.WriteLine("Ingrese valor Id de la nueva clase a la pasa a pertenecer ");
                            int id = int.Parse(Console.ReadLine());
                            pos = mp.posicionHE(nombre);
                            mp.Clases[id - 1].habilidadesEspeciales.Add(mp.HabilidadesEspeciales[pos]); 
                            
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
    
        

        //terminada :) 
        public void ListarHabilidadesEspeciales()
        {
            Manejador mp = Manejador.getInstancia();
            foreach (HabilidadEspecial HE in mp.HabilidadesEspeciales)
            {
                Console.WriteLine("Id - {0} Nombre - {1} Descripcion - {2} ", HE.Id, HE.Nombre, HE.Descripcion); 
            }

        }

        //terminada :) 
        public void ListarHabilidadEspecialPorClase()
        {
            Manejador mp = Manejador.getInstancia();
            foreach( Clase c in mp.Clases)
            {
                Console.WriteLine("Clase Id- {0} Nombre - {1} ", c.Id, c.Nombre);
                Console.WriteLine("Posee las siguientes Habilidades Especiales");
                foreach (HabilidadEspecial h in c.habilidadesEspeciales)
                {
                    Console.WriteLine("Habilidad Especial Id - {0} Nombre - {1} Descripcion - {2}" , h.Id, h.Nombre, h.Descripcion);
                }
            }
        }

        public void EliminarHabilidadEspecial()
        {
            Manejador mp = Manejador.getInstancia();



        }
        //terminada :) 
        public void CrearClase()
        {
			Manejador mp = Manejador.getInstancia();
			Console.WriteLine("Ingrese el nombre de la Clase");
			string nombre = Console.ReadLine();
			Console.WriteLine("Ingrese una breve descripcion de esta Clase");
			string descricpion = Console.ReadLine();
            mp.AgregarClase(new Clase(nombre, descricpion));
            Console.WriteLine("Desea agregar alguna Habilidad Especial a esta clase ? S/N");
            string res = Console.ReadLine();
            while(res == "S")
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
                res = Console.ReadLine();
            }
            
            
        }

        public void ModificarClase()
        {
            Manejador mp = Manejador.getInstancia();



        }
        //terminada :) 
        public void ListarClases()
        {
			Manejador mp = Manejador.getInstancia();
			foreach (Clase HE in mp.Clases)
			{
				Console.WriteLine("Id - {0} Nombre - {1} Descripcion - {2} ", HE.Id, HE.Nombre, HE.Descripcion);
			}



		}
        public void EliminarClase()
        {
            Manejador mp = Manejador.getInstancia();



        }
        //terminada :) 
        public void CrearRaza()
        {
			Manejador mp = Manejador.getInstancia();
			Console.WriteLine("Ingrese el nombre de la Raza");
			string nombre = Console.ReadLine();
			Console.WriteLine("Ingrese una breve descripcion de esta Raza");
			string descricpion = Console.ReadLine();
            mp.AgregarRaza(new Raza(nombre, descricpion));

		}
        //terminada :) 
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
                int opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                  
                    case '1':
                        Console.WriteLine("Valor? ");
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
                    case '2' :
                        Console.WriteLine("Ingrese el nombre de la raza a modificar su descripción: ");
                        string nom = Console.ReadLine();
                        pos = mp.posicionR(nom);
                        Console.WriteLine("Ingrese una nueva descripción");
                        mp.Razas[pos].Descripcion = Console.ReadLine();
                        Console.WriteLine("Modificación realizada con exito!! ");
                        break;

                    default:    Console.WriteLine("La opción ingresada no es correcta"); 
                                break; 

                }
            }

        }
        //terminada :)
        public void ListarRazas()
        {
			Manejador mp = Manejador.getInstancia();
			foreach (Raza HE in mp.Razas)
			{
				Console.WriteLine("Id - {0} Nombre - {1} Descripcion - {2} ", HE.Id, HE.Nombre, HE.Descripcion);
			}



		}
        public void EliminarRaza()
        {
            Manejador mp = Manejador.getInstancia();



        }
        //terminada :)
        public void CrearCaracteristica()
        {

			Manejador mp = Manejador.getInstancia();
			Console.WriteLine("Ingrese el nombre de la Caracteristica Variable");
			string nombre = Console.ReadLine();
            Console.WriteLine(" Valor?");
            Personaje_Caracteristica v = new Personaje_Caracteristica();
            v.valor = int.Parse(Console.ReadLine());
            mp.AgregarCaracteristicaVariable(new CaracteristicaVariable(nombre, v));
				
		}


        public void ModificarCarateristica()
        {
            Manejador mp = Manejador.getInstancia();



        }
        //terminada :) 
        public void ListarCaracteristicas()
        {
			Manejador mp = Manejador.getInstancia();
			foreach (CaracteristicaVariable HE in mp.caracteristicasVariables)
			{
				Console.WriteLine("Id - {0} Nombre - {1}  ", HE.Id, HE.Nombre);
			}



		}
        public void EliminarCaracteristica()
        {
            Manejador mp = Manejador.getInstancia();



        }
        // IMMPORTANTE FUNCONALIDAD CREAR PERSONAJE
        //Falta ver tema de mayusculas y minusculas con la busqueda de nombre, ver id si se ingresa por consola o averiguar si se debe incrementar automaticamente y ver hacer try catch O TRY PARSE cuando son letras y tienen que ser numeros 


        //Funcionalidad para crear Personaje en el Sistema, no deja cargar un nuevo personaje con un mismo nombre ya existente en el sistema.
        public void CrearPersonaje()
        {
            Manejador mp = Manejador.getInstancia();
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("----------------------------Alta Personaje------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("Ingrese Nombre");
            string elnombre = Console.ReadLine();
            while (mp.NomEstaP(elnombre))
            {
                Console.WriteLine("Ya existe en el sistema un Personaje con ese nombre : {0} por favor ingrese otro", elnombre);
                elnombre = Console.ReadLine();


            }
            Console.WriteLine("Ingrese Nivel");
            int niv = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese valor Fuerza");
            int fue = int.Parse(Console.ReadLine());
            while ((fue < 1) || (fue > 10)){
                Console.WriteLine("Valor ingresado para Caracteristica Fuerza no es valido, debe ser entre 1 y 10");
                fue = int.Parse(Console.ReadLine());

            }
            Console.WriteLine("Ingrese valor Destreza");
            int des = int.Parse(Console.ReadLine());
            while ((des < 1) || (des > 10))
            {
                Console.WriteLine("Valor ingresado para Caracteristica Destreaza no es valido, debe ser entre 1 y 10");
                des = int.Parse(Console.ReadLine());

            }
            Console.WriteLine("Ingrese valor Constitucion");
            int con = int.Parse(Console.ReadLine());
            while ((con < 1) || (con > 10))
            {
                Console.WriteLine("Valor ingresado para Caracteristica Constitución no es valido, debe ser entre 1 y 10");
                con = int.Parse(Console.ReadLine());

            }
            Console.WriteLine("Ingrese valor Inteligencia");
            int inte = int.Parse(Console.ReadLine());
            while ((inte < 1) || (inte > 10))
            {
                Console.WriteLine("Valor ingresado para Caracteristica Inteligencia no es valido, debe ser entre 1 y 10");
                inte = int.Parse(Console.ReadLine());

            }
            Console.WriteLine("Ingrese valor Sabiduria");
            int sab = int.Parse(Console.ReadLine());
            while ((sab < 1) || (sab > 10))
            {
                Console.WriteLine("Valor ingresado para Caracteristica Sabiduria no es valido, debe ser entre 1 y 10");
                sab = int.Parse(Console.ReadLine());

            }
            Console.WriteLine("Ingrese valor Carisma");
            int car = int.Parse(Console.ReadLine());
            while ((car < 1) || (car > 10))
            {
                Console.WriteLine("Valor ingresado para Caracteristica Carisma no es valido, debe ser entre 1 y 10");
                car = int.Parse(Console.ReadLine());

            }
            int id = mp.Personajes.Count + 1;

           mp.AgregarPersonaje(new Personaje (id, elnombre,niv,fue,des,con, inte, sab,car));         

        }

       
        public void ModificarPersonaje(){
            Manejador mp = Manejador.getInstancia();
            


        }
        public void ListarPersonajes()
        {
			Manejador mp = Manejador.getInstancia();
			foreach (Personaje HE in mp.Personajes)
			{
				Console.WriteLine("Id - {0} Nombre - {1} ", HE.Id, HE.Nombre);
			}



		}
        public void ListarPersonajeClase()
        {
            Manejador mp = Manejador.getInstancia();



        }
        public void ListarPersonajeRaza()
        {
            Manejador mp = Manejador.getInstancia();



        }
        public void EliminarPersonaje()
        {
            Manejador mp = Manejador.getInstancia();



        }

       
    }
}
