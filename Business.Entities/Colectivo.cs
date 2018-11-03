using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Colectivo:BusinessEntity
    {
        private string _Marca;
        private string _Modelo;
        private int _CantidadAsientos;

        public string Marca
        {
            get
            {
                return _Marca;
            }

            set
            {
                _Marca = value;
            }
        }

        public string Modelo
        {
            get
            {
                return _Modelo;
            }

            set
            {
                _Modelo = value;
            }
        }

        public int CantidadAsientos
        {
            get
            {
                return _CantidadAsientos;
            }

            set
            {
                _CantidadAsientos = value;
            }
        }
    }
}
