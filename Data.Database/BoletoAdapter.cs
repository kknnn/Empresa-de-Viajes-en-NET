using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;
using System.Data;

namespace Data.Database
{
    public class BoletoAdapter:Adapter
    {
        public List<Boleto> GetAll()
        {
            List<Boleto> boletos = new List<Boleto>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdBoleto = new SqlCommand("select * from Boletos b inner join Destinos d on b.id_destino=d.id_destino where asientos_disponibles>0", SqlConn);
                SqlDataReader drBoleto = cmdBoleto.ExecuteReader();
                while (drBoleto.Read())
                {
                    Boleto b = new Boleto();
                    b.ID = (int)drBoleto["id_boleto"];
                    b.FechaSalida = (DateTime)drBoleto["fecha_salida"];
                    b.FechaRegreso = (DateTime)drBoleto["fecha_regreso"];
                    b.Precio = (int)drBoleto["precio"];
                    b.IDColectivo = (int)drBoleto["id_colectivo"];
                    b.AsientosDisponibles = (int)drBoleto["asientos_disponibles"];
                    Destino d = new Destino();
                    d.ID = (int)drBoleto["id_destino"];
                    d.Descripcion = (string)drBoleto["descripcion"];
                    b.Destino = d;
                    boletos.Add(b);
                }
                drBoleto.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de boletos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return boletos;
        }

        public void UpdateAsientos(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE Boletos SET asientos_disponibles = @asientos_disponibles WHERE id_boleto=@id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmdSave.Parameters.Add("@asientos_disponibles", SqlDbType.Int).Value = this.GetCantidadAsientos(id);
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public int GetCantidadAsientos(int id)
        {
            int asientos;
            SqlCommand cmdCantidad = new SqlCommand("select asientos_disponibles from Boletos where id_boleto=@id", SqlConn);
            cmdCantidad.Parameters.Add("@id", SqlDbType.Int).Value = id;
            asientos = Convert.ToInt32(cmdCantidad.ExecuteScalar());
            asientos--;
            return asientos;
        }

        public DataTable GetComprasRealizadas(int id)
        {
            this.OpenConnection();
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from Compras c inner join Boletos b on c.id_boleto=b.id_boleto inner join Destinos d on b.id_destino=d.id_destino inner join Estados e on c.id_estado=e.id_estado where id_usuario=@id", SqlConn);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            SqlDataAdapter adap = new SqlDataAdapter(cmd);
            adap.Fill(dt);
            this.CloseConnection();
            return dt;
        }
    }
}
