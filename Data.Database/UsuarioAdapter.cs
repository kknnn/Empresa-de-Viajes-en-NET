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
    public class UsuarioAdapter:Adapter
    {
        public Usuario GetOne(string nomUsu, string contra)
        {
            Usuario usr = new Usuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdUsuarios = new SqlCommand("select * from Usuarios where nombre_usuario=@nombre_usuario and contraseña=@contraseña", SqlConn);
                cmdUsuarios.Parameters.Add("@nombre_usuario", SqlDbType.VarChar).Value = nomUsu;
                cmdUsuarios.Parameters.Add("@contraseña", SqlDbType.VarChar).Value = contra;
                SqlDataReader drUsuarios = cmdUsuarios.ExecuteReader();
                if (drUsuarios.Read())
                {
                    usr.ID = (int)drUsuarios["id_usuario"];
                    usr.NombreUsuario = (string)drUsuarios["nombre_usuario"];
                    usr.Contraseña = (string)drUsuarios["contraseña"];
                    usr.Nombre = (string)drUsuarios["nombre"];
                    usr.Apellido = (string)drUsuarios["apellido"];
                    usr.IDTipo = (int)drUsuarios["id_tipo"];
                }
                drUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return usr;
        }

        public void Insert(Usuario usuario)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into Usuarios(nombre_usuario,contraseña,nombre,apellido,id_tipo) values(@nombre_usuario,@contraseña,@nombre,@apellido,@id_tipo) select @@identity", SqlConn);
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@contraseña", SqlDbType.VarChar, 50).Value = usuario.Contraseña;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@id_tipo", SqlDbType.Int).Value = usuario.IDTipo;
                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
    }
}
