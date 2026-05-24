using lib_servicios_TiendaMusica.Interfaces;
using lib_servicios_TiendaMusica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_servicios_TiendaMusica.Implementaciones
{
    public class PersonasAplicacion : IPersonasAplicacion
    {

        private readonly IConexion _conexion;

        public PersonasAplicacion(IConexion conexion)
        {
            _conexion = conexion;
        }
        public Personas Guardar(Personas persona)
        {
            _conexion.Personas!.Add(persona);
            _conexion.SaveChanges();
            return persona;

        }
    }
}
