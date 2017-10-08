using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
    public class CaracteristicaVariable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Personaje_Caracteristica valor { get; set; }
        public int BonoRaza { get; set; }
        public CaracteristicaVariable(string n, Personaje_Caracteristica v)
        {
            this.Nombre = n;
            this.valor = new Personaje_Caracteristica();
            valor = v;
			this.Id = Manejador.getInstancia().caracteristicasVariables.Count + 1;
		}
        public CaracteristicaVariable()
        {

        }

        public void ImprimirCV()
        {
            Console.WriteLine("Id - {0} Nombre - {1} Valor {2} " , this.Id, this.Nombre, this.valor.valor + this.BonoRaza); 
        }
    }
}
