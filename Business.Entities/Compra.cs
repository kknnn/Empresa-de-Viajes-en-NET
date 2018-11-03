using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Compra:BusinessEntity
    {
        private DateTime _FechaCompra;
        private int _IDBoleto;
        private int _IDUsuario;
        private int _IDEstado;

        public DateTime FechaCompra
        {
            get
            {
                return _FechaCompra;
            }

            set
            {
                _FechaCompra = value;
            }
        }

        public int IDBoleto
        {
            get
            {
                return _IDBoleto;
            }

            set
            {
                _IDBoleto = value;
            }
        }

        public int IDUsuario
        {
            get
            {
                return _IDUsuario;
            }

            set
            {
                _IDUsuario = value;
            }
        }

        public int IDEstado
        {
            get
            {
                return _IDEstado;
            }

            set
            {
                _IDEstado = value;
            }
        }
    }
}
