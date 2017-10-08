using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
    public interface IDPersonaje
    {
        HabilidadEspecial CrearHabilidadEspecial();
        void ModificarHabilidadEspecial();
        void ListarHabilidadesEspeciales();
        void ListarHabilidadEspecialPorClase();
        void EliminarHabilidadEspecial();
        Clase CrearClase();
        void ModificarClase();
        void ListarClases();
        void EliminarClase();
        Raza CrearRaza();
        void ModificarRaza();
        void ListarRazas();
        void EliminarRaza();
        CaracteristicaVariable CrearCaracteristica();
        void ModificarCarateristica();
        void ListarCaracteristicas();
        void EliminarCaracteristica();
        void CrearPersonaje();
        void ModificarPersonaje();
        void ListarPersonajes();
        void ListarPersonajeRaza();
        void ListarPersonajeClase();
        void EliminarPersonaje();
        void SubirNivel(); 
    }
}
