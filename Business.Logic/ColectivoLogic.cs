using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class ColectivoLogic
    {
        public List<Colectivo> GetAll()
        {
            return new ColectivoAdapter().GetAll();
        }

        public void Insert(Colectivo c)
        {
            new ColectivoAdapter().Insert(c);
        }

        public void Delete(int id)
        {
            new ColectivoAdapter().Delete(id);
        }
    }

}
