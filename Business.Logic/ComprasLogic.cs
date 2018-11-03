using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ComprasLogic
    {
        public List<Compra> GetComprasPendientes()
        {
            return new CompraAdapter().GetComprasPendientes();
        }

        public void HabilitarCompra(int id)
        {
            new CompraAdapter().HabilitarCompra(id);
        }

        public void Delete(int id)
        {
            new CompraAdapter().Delete(id);
        }

        public void Insert(Compra c)
        {
            new CompraAdapter().Insert(c);
        }
    }
}
