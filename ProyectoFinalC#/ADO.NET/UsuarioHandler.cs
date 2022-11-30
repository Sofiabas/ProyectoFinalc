using ProyectoFinalC#.Models;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoFinalC#.ADO.NET
{
    public class UsuarioHandler
    {
        private SqlConnection conexion;
        private string CadenaConexion = "Server=sql.bsite.net\\MSSQL2016;" +
                "Database=sofibas_SampleDB;" +
                "User Id=sofibas_SampleDB;" +
                "Password=3VWMH7xJ@J6bgb8;";;

        public UsuarioHandler() 
        {
            try
            {
                conexion = new SqlConnection(CadenaConexion);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Usuario> GetUsuario() 
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            if (CadenaConexion == null)
            {
                throw new Exception("Conexión no realizada");
            }
            try
            {
                using (SqlCommand command = new SqlCommand ("SELECT * FROM Usuario", conexion))
                {
                    conexion.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Usuario usuario = new Usuario();
                                usuario.Id = Convert.ToInt32(reader["Id"].ToString());
                                usuario.Nombre = reader["Nombre"].ToString();
                                usuario.Apellido = reader["Apellido"].ToString();
                                usuario.NombreUsuario = reader["NombreUsuario"].ToString();
                                usuario.Contraseña = reader["Contraseña"].ToString();
                                usuario.Mail = reader["Mail"].ToString();
                                listaUsuarios.Add(usuario);
                            }
                        }
                    }
                }
                conexion.Close();
            }
            catch (Exception)
            {

                throw;
            }
            return listaUsuarios;
        }
    }
}
