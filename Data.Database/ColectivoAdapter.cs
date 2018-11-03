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
    public class ColectivoAdapter:Adapter
    {
        public List<Colectivo> GetAll()
        {
            List<Colectivo> coles = new List<Colectivo>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdColectivos = new SqlCommand("select * from Colectivos", SqlConn);
                SqlDataReader drColectivos = cmdColectivos.ExecuteReader();
                while (drColectivos.Read())
                {
                    Colectivo c = new Colectivo();
                    c.ID = (int)drColectivos["id_colectivo"];
                    c.Marca = (string)drColectivos["marca"];
                    c.Modelo = (string)drColectivos["modelo"];
                    c.CantidadAsientos = (int)drColectivos["cantidad_asientos"];
                    coles.Add(c);
                }
                drColectivos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de colectivos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return coles;
        }

        public void Insert(Colectivo c)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into Colectivos(marca,modelo,cantidad_asientos) values(@marca,@modelo,@cantidad_asientos) select @@identity", SqlConn);
                cmdSave.Parameters.Add("@marca", SqlDbType.VarChar, 50).Value = c.Marca;
                cmdSave.Parameters.Add("@modelo", SqlDbType.VarChar, 50).Value = c.Modelo;
                cmdSave.Parameters.Add("@cantidad_asientos", SqlDbType.Int).Value = c.CantidadAsientos;
                c.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear colectivo", Ex);
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
                SqlCommand cmdDelete = new SqlCommand("delete Colectivos where id_colectivo=@id", SqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar colectivo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
