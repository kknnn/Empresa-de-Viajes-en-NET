using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;
using System.Data;

namespace Business.Logic
{
    public class BoletoLogic
    {
        public List<Boleto> GetAll()
        {
            return new BoletoAdapter().GetAll();
        }

        public void UpdateAsientos(int id)
        {
            new BoletoAdapter().UpdateAsientos(id);
        }

        public DataTable GetComprasRealizadas(int id)
        {
            return new BoletoAdapter().GetComprasRealizadas(id);
        }
    }
}
