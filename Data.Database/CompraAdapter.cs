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
    public class CompraAdapter:Adapter
    {
        public List<Compra> GetComprasPendientes()
        {
            List<Compra> compras = new List<Compra>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdCompra = new SqlCommand("select * from Compras c inner join Estados e on c.id_estado=e.id_estado where descripcion='Pendiente'", SqlConn);
                SqlDataReader drCompra = cmdCompra.ExecuteReader();
                while (drCompra.Read())
                {
                    Compra c = new Compra();
                    c.ID = (int)drCompra["id_compra"];
                    c.FechaCompra = (DateTime)drCompra["fecha_compra"];
                    c.IDBoleto = (int)drCompra["id_boleto"];
                    c.IDUsuario = (int)drCompra["id_usuario"];
                    c.IDEstado = (int)drCompra["id_estado"];
                    compras.Add(c);
                }
                drCompra.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de compras", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return compras;
        }

        public void HabilitarCompra(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE Compras SET id_estado = @id_estado WHERE id_compra=@id", SqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmdSave.Parameters.Add("@id_estado", SqlDbType.Int).Value = 1;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al habilitar compra", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete Compras where id_compra=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar compra", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Insert(Compra c)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into Compras(fecha_compra,id_boleto,id_usuario,id_estado) values(@fecha_compra,@id_boleto,@id_usuario,@id_estado) select @@identity", SqlConn);
                cmdSave.Parameters.Add("@fecha_compra", SqlDbType.DateTime).Value = c.FechaCompra;
                cmdSave.Parameters.Add("@id_boleto", SqlDbType.Int).Value = c.IDBoleto;
                cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = c.IDUsuario;
                cmdSave.Parameters.Add("@id_estado", SqlDbType.Int).Value = c.IDEstado;
                c.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear compra", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
