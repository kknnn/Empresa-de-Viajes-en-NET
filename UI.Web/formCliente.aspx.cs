using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;

namespace UI.Web
{
    public partial class formCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
  
        }

        public void LoadGridCompra()
        {
            this.gvCompra.DataSource = new BoletoLogic().GetAll();
            this.gvCompra.DataBind();
        }

        protected void btnCompra_Click(object sender, EventArgs e)
        {
            if (!(this.gvCompra.SelectedRow == null))
            {
                new BoletoLogic().UpdateAsientos(Convert.ToInt32(this.gvCompra.SelectedValue));
                Compra c = new Compra();
                c.FechaCompra = DateTime.Today;
                c.IDBoleto = Convert.ToInt32(gvCompra.SelectedValue);
                Usuario us = (Usuario)Session["usuarioLogueado"];
                c.IDUsuario = us.ID;
                c.IDEstado = 2;
                new ComprasLogic().Insert(c);
                Response.Write("<script>alert('Su compra esta pendiente de ser aceptada por un administrador');</script>");
                this.LoadGridCompra();
            }
        }

        protected void btnBoletos_Click(object sender, EventArgs e)
        {
            this.panelHistorialCompras.Visible = false;
            this.panelCompra.Visible = true;
            this.LoadGridCompra();
        }

        protected void btnHistorialCompras_Click(object sender, EventArgs e)
        {
            this.panelCompra.Visible = false;
            this.panelHistorialCompras.Visible = true;
            this.LoadGridHistorial();
        }

        public void LoadGridHistorial()
        {
            Usuario us = (Usuario)Session["usuarioLogueado"];
            this.gvHistorial.DataSource = new BoletoLogic().GetComprasRealizadas(us.ID);
            this.gvHistorial.DataBind();
        }
    }
}