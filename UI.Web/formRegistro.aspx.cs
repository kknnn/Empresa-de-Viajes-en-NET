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
    public partial class formRegistro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario();
            if (Validar())
            {
                u.NombreUsuario = this.txtNombreUsuario.Text;
                u.Contraseña = this.txtContraseña.Text;
                u.Nombre = this.txtNombre.Text;
                u.Apellido = this.txtApellido.Text;
                u.IDTipo = 2;
                new UsuarioLogic().Insert(u);
                Response.Write("<script>alert('Usted se ha registrado correctamente');</script>");
                Server.Transfer("formLogin.aspx");
            }
            else
            {
                Response.Write("<script>alert('No puede haber campos vacios');</script>");
            }
            
        }

        public bool Validar()
        {
            if(this.txtApellido.Text=="" || this.txtContraseña.Text=="" || this.txtNombre.Text=="" || this.txtNombreUsuario.Text == "")
            {
                return false;
            }
            return true;
        }
    }
}