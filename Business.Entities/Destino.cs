using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Destino:BusinessEntity
    {
        private string _Descripcion;

        public override String ToString()
        {
            return this.Descripcion.ToString();
        }

        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }

            set
            {
                _Descripcion = value;
            }
        }
    }
}
