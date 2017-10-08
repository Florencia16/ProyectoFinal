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
        public int BonoRaza { get; set; }
        public CaracteristicaVariable(string n)
        {
            this.Nombre = n;
			this.Id = Manejador.getInstancia().caracteristicasVariables.Count + 1;
		}
        public CaracteristicaVariable()
        {

        }

        public void ImprimirCV()
        {
            Console.WriteLine("Id - {0} Nombre - {1} " , this.Id, this.Nombre); 
        }
    }
}
