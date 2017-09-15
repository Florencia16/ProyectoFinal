﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
    class Controlador : IDPersonaje 
    {
        // IMMPORTANTE FUNCONALIDAD CREAR PERSONAJE
        //Falta ver tema de mayusculas y minusculas con la busqueda de nombre, ver id si se ingresa por consola o averiguar si se debe incrementar automaticamente y ver hacer try catch cuando son letras y tienen que ser numeros 
       
       
        //Funcionalidad para crear Personaje en el Sistema, no deja cargar un nuevo personaje con un mismo nombre ya existente en el sistema.
        public void CrearPersonaje()
        {
            Manejador mp = Manejador.getInstancia();
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("----------------------Alta Personaje------------------------------------");
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine("Ingrese Nombre");
            string elnombre = Console.ReadLine();
            while (mp.NomEsta(elnombre))
            {
                Console.WriteLine("Ya existe en el sistema un Personaje con el ese nombre : {0} por favor ingrese otro", elnombre);
                elnombre = Console.ReadLine();


            }
            Console.WriteLine("Ingrese ID");
            int id = int.Parse(Console.ReadLine());
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

           mp.AgregarPersonaje(new Personaje (id, elnombre,niv,fue,des,con, inte, sab,car));         

        }

        
        public void ModificarPersoaje (){
            Manejador mp = Manejador.getInstancia();
            


        }


    }
}
