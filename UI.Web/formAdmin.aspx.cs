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
    public partial class formAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LoadGridColectivos();
            this.LoadGridCompras();
        }

        public void LoadGridCompras()
        {
            this.gvCompras.DataSource = new ComprasLogic().GetComprasPendientes();
            this.gvCompras.DataBind();
        }

        public void LoadGridColectivos()
        {
            this.gvColectivos.DataSource = new ColectivoLogic().GetAll();
            this.gvColectivos.DataBind();
        }

        protected void btnHistorial_Click(object sender, EventArgs e)
        {
            this.panelColectivos.Visible = false;
            this.panelDestinos.Visible = false;
            this.panelCompras.Visible = true;
        }

        protected void btnColectivos_Click(object sender, EventArgs e)
        {
            this.panelColectivos.Visible = true;
            this.panelDestinos.Visible = false;
            this.panelCompras.Visible = false;
        }

        protected void btnDestinos_Click(object sender, EventArgs e)
        {
            this.panelColectivos.Visible = false;
            this.panelDestinos.Visible = true;
            this.panelCompras.Visible = false;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            this.panelNuevoColectivo.Visible = true;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Colectivo c = new Colectivo();
            c.Marca = this.txtMarca.Text;
            c.Modelo = this.txtModelo.Text;
            c.CantidadAsientos = Convert.ToInt32(this.txtCantidadAsientos.Text);
            new ColectivoLogic().Insert(c);
            this.panelNuevoColectivo.Visible = false;
            this.LoadGridColectivos();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!(this.gvColectivos.SelectedRow == null))
            {
                new ColectivoLogic().Delete(Convert.ToInt32(this.gvColectivos.SelectedValue));
                this.LoadGridColectivos();
            }
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            if (!(this.gvCompras.SelectedRow == null))
            {
                new ComprasLogic().HabilitarCompra(Convert.ToInt32(this.gvCompras.SelectedValue));
                this.LoadGridCompras();
            }
        }

        protected void btnEliminarCompra_Click(object sender, EventArgs e)
        {
            if (!(this.gvCompras.SelectedRow == null))
            {
                new ComprasLogic().Delete(Convert.ToInt32(this.gvCompras.SelectedValue));
                this.LoadGridCompras();
            }
        }
    }
}