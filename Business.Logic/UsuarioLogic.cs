using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic
    {
        public Usuario GetOne(string nomUsu, string contra)
        {
            return new UsuarioAdapter().GetOne(nomUsu, contra);
        }

        public void Insert(Usuario u)
        {
            new UsuarioAdapter().Insert(u);
        }
    }
}
