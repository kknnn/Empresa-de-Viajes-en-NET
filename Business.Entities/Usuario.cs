using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Usuario:BusinessEntity
    {
        private string _NombreUsuario;
        private string _Contraseña;
        private string _Nombre;
        private string _Apellido;
        private int _IDTipo;

        public string NombreUsuario
        {
            get
            {
                return _NombreUsuario;
            }

            set
            {
                _NombreUsuario = value;
            }
        }

        public string Contraseña
        {
            get
            {
                return _Contraseña;
            }

            set
            {
                _Contraseña = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _Nombre;
            }

            set
            {
                _Nombre = value;
            }
        }

        public string Apellido
        {
            get
            {
                return _Apellido;
            }

            set
            {
                _Apellido = value;
            }
        }

        public int IDTipo
        {
            get
            {
                return _IDTipo;
            }

            set
            {
                _IDTipo = value;
            }
        }
    }
}
