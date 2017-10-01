using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
    public class Controlador : IDPersonaje
    {


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
            foreach (HabilidadEspecial HE in mp.HabilidadesEspeciales)
            {
                Console.WriteLine("Id - {0} Nombre - {1} Descripcion - {2} ", HE.Id, HE.Nombre, HE.Descripcion);
            }

        }


        public void ListarHabilidadEspecialPorClase()
        {
            Manejador mp = Manejador.getInstancia();
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


        public void CrearClase()
        {
            Manejador mp = Manejador.getInstancia();
            Console.WriteLine("Ingrese el nombre de la Clase");
            string nombre = Console.ReadLine();
            if (!mp.NomEstaClase(nombre))
            {
                Console.WriteLine("Ingrese una breve descripcion de esta Clase");
                string descricpion = Console.ReadLine();
                mp.AgregarClase(new Clase(nombre, descricpion));
                Console.WriteLine("Desea agregar alguna Habilidad Especial a esta clase ? S/N");
                string res = Console.ReadLine();
                while (res == "S")
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
            else {
                Console.WriteLine("Ya existe una clase con el nombre ingresado.");
            }
        }

        public void ModificarClase()
        {
            Manejador mp = Manejador.getInstancia();
            int pos;
            Console.WriteLine("Ingrese el nombre de la clase a modificar");
            string nombreClase = Console.ReadLine();
            if (mp.NomEstaClase(nombreClase))
            {
                //obtenemos la clase a modificar
                int posicionClase = mp.posicionClase(nombreClase);
                Clase clase = mp.Clases[posicionClase];
                Console.WriteLine("Ingrese el parametro que desea modificar");
                Console.WriteLine("1-Nombre");
                Console.WriteLine("2-Descripcion");
                Console.WriteLine("3-Habilidades Especiales");
                int opcion = int.Parse(Console.ReadLine());

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
                            int posicionHabilidadEspecial = mp.posicionHE(nombreHablidadEspecial);
                            HabilidadEspecial habilidadEspecial = mp.HabilidadesEspeciales[posicionHabilidadEspecial];
                            clase.habilidadesEspeciales.Remove(habilidadEspecial);
                            Console.WriteLine("Modificación realizada con exito!! ");
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
            if (mp.Clases == null)
            {
                Console.WriteLine("La lista de clases no tiene elementos");
            } else
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

                int posicionClase = mp.posicionClase(nombreClase);
                Clase clase = mp.Clases[posicionClase];
                mp.Clases.Remove(clase);
                Console.WriteLine("la clase ha sido eliminada con exito");
            }
            else {
                Console.WriteLine("no se encontro una clase con el nombre ingresado");
            }
        }



        public void CrearRaza()
        {
            Manejador mp = Manejador.getInstancia();
            Console.WriteLine("Ingrese el nombre de la Raza");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese una breve descripcion de esta Raza");
            string descricpion = Console.ReadLine();
            mp.AgregarRaza(new Raza(nombre, descricpion));

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
                    case '2':
                        Console.WriteLine("Ingrese el nombre de la raza a modificar su descripción: ");
                        string nom = Console.ReadLine();
                        pos = mp.posicionR(nom);
                        Console.WriteLine("Ingrese una nueva descripción");
                        mp.Razas[pos].Descripcion = Console.ReadLine();
                        Console.WriteLine("Modificación realizada con exito!! ");
                        break;

                    default: Console.WriteLine("La opción ingresada no es correcta");
                        break;

                }
            }

        }



        public void ListarRazas()
        {
            Manejador mp = Manejador.getInstancia();
            if (mp.Razas == null)
            {
                Console.WriteLine("La lista de razas no tiene ingresado ningún objeto.");
            }
            else
            {
                foreach (Raza R in mp.Razas)
                {
                    Console.WriteLine("Id - {0} Nombre - {1} Descripcion - {2} ", R.Id, R.Nombre, R.Descripcion);
                }

            }
        }

        //lo tenia thalia
        public void EliminarRaza()
        {
            Manejador mp = Manejador.getInstancia();



        }


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

        //LO TENIA THALIA 
        public void ModificarCarateristica()
        {
            Manejador mp = Manejador.getInstancia();



        } 



       
        public void ListarCaracteristicas()
        {
			Manejador mp = Manejador.getInstancia();
            if (mp.caracteristicasVariables == null)
            {
                Console.WriteLine("La lista de Caracteristicas Variables esta vacia ");
            }
            else
            {
                foreach (CaracteristicaVariable CV in mp.caracteristicasVariables)
                {
                    Console.WriteLine("Id - {0} Nombre - {1}  ", CV.Id, CV.Nombre);
                }

            }
        }

        //LO TENIA THALIA 
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
            Console.WriteLine("Dese ingresar la Raza de este personaje? S/N");
            string res = Console.ReadLine();
            if (res.Equals("S"))
            {
                if (mp.Razas == null)
                {
                    Console.WriteLine("No se han ingresado ninguna raza al sistema, crea la raza para ser asignada a este personaje");
                    CrearRaza();
                    //cargar personaje de la lsita de personajes la raza quien tendra id 1 dado que no existia ninguna raza en el sistema

                }
                else
                {
                    ListarRazas();
                    Console.WriteLine("Estas son las razas cargadas en el sistema, favor indica el id  para cargar una existente 0 para crear una nueva raza ");
                    int r = int.Parse(Console.ReadLine());
                    if (r != 0)
                    {
                        while (r > mp.Razas.Count)
                        {
                            Console.WriteLine("El número de id ingresado no es el correcto - favor ingrese nuevamente ");
                            r = int.Parse(Console.ReadLine());
                        }

                        //cargar al personaje de la lista de personajes la raza ya cargada al sistma 
                    }
                    else
                    {

                        Console.WriteLine("No se han ingresado ninguna raza al sistema, crea la raza para ser asignada a este personaje");
                        CrearRaza();
                        //cargar personaje de la lsita de personajes la raza quien tendra id 1 dado que no existia ninguna raza en el sistema
                    }

                }
            }

        }

       
        public void ModificarPersonaje(){
            Manejador mp = Manejador.getInstancia();
            


        }
        public void ListarPersonajes()
        {
			Manejador mp = Manejador.getInstancia();
			foreach (Personaje p in mp.Personajes)
			{
				Console.WriteLine("Id - {0} Nombre - {1} ", p.Id, p.Nombre);
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
