using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Boleto:BusinessEntity
    {
        private DateTime _FechaSalida;
        private DateTime _FechaRegreso;
        private int _Precio;
        private int _IDColectivo;
        private Destino _Destino;
        private int _AsientosDisponibles;

        public DateTime FechaSalida
        {
            get
            {
                return _FechaSalida;
            }

            set
            {
                _FechaSalida = value;
            }
        }

        public DateTime FechaRegreso
        {
            get
            {
                return _FechaRegreso;
            }

            set
            {
                _FechaRegreso = value;
            }
        }

        public int Precio
        {
            get
            {
                return _Precio;
            }

            set
            {
                _Precio = value;
            }
        }

        public int IDColectivo
        {
            get
            {
                return _IDColectivo;
            }

            set
            {
                _IDColectivo = value;
            }
        }

        public Destino Destino
        {
            get
            {
                return _Destino;
            }

            set
            {
                _Destino = value;
            }
        }

        public int AsientosDisponibles
        {
            get
            {
                return _AsientosDisponibles;
            }

            set
            {
                _AsientosDisponibles = value;
            }
        }
    }
}
