using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class formLogin : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario u = new UsuarioLogic().GetOne(this.txtUsuario.Text, this.txtContraseña.Text);
            if (u.NombreUsuario == this.txtUsuario.Text)
            {
                if (u.IDTipo == 1)
                {
                    Server.Transfer("formAdmin.aspx");
                }
                else if (u.IDTipo == 2)
                {
                    Session["usuarioLogueado"] = u;
                    Server.Transfer("formCliente.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Datos incorrectos');</script>");
            }
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Server.Transfer("formRegistro.aspx");
        }
    }
}