using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
    class Controlador : IDPersonaje 
    {


        public void CrearPersonaje()
        {
           
            Console.WriteLine("Alta Personaje---------------");
            Console.WriteLine("Ingrese ID");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese Nombre");
            string elnombre = Console.ReadLine();
            Console.WriteLine("Ingrese Nivel");
            int niv = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese valor Fuerza");
            int fue = int.Parse(Console.ReadLine());
            // if (fue <1) || (fue > 10){
            //pedir que ingrese nuevamente 
            //  }
            Console.WriteLine("Ingrese valor Destreza");

            int des = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese valor Constitucion");
            int con = int.Parse(Console.ReadLine()); 

            Console.WriteLine("Ingrese valor Inteligencia");
            int inte = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese valor Sabiduria");
            int sab = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese valor Carisma");
            int car = int.Parse(Console.ReadLine());
       

            Personaje nuevoPersonaje = new Personaje(id, elnombre,niv,fue,des,con, inte, sab,car);
            return nuevoPersonaje;
            
        }



    }
}
