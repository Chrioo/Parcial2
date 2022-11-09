using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculador.Datos
{
    internal class ClsConexion
    {
        private string connectionString = "Data Source=ASUS\\MSSQLSERVER01; Initial Catalog=Registro; Integrated Security=SSPI";


        public bool Ok()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(connectionString);
                conexion.Open();
            }
            catch
            {

                return false;
            }
            return true;
        }

        public List<ClsEstudiante> Get()
        {
            List<ClsEstudiante> estudiantes = new List<ClsEstudiante>();

            string query = "select id,Nombre,Apellido,Carrera,Asignatura,Promedio1,Promedio2,Promedio3,PromedioFinal from ClsEstudiante";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ClsEstudiante oClsEstudiante = new ClsEstudiante();
                        oClsEstudiante.id = reader.GetInt32(0);
                        oClsEstudiante.Nombre = reader.GetString(1);
                        oClsEstudiante.Apellido = reader.GetString(2);
                        oClsEstudiante.Carrera = reader.GetString(3);
                        oClsEstudiante.Asignatura = reader.GetString(4);
                        oClsEstudiante.Promedio1 = reader.GetInt32(5);
                        oClsEstudiante.Promedio2 = reader.GetInt32(6);
                        oClsEstudiante.Promedio3 = reader.GetInt32(7);
                        oClsEstudiante.PromedioFinal = reader.GetInt32(8);
                        estudiantes.Add(oClsEstudiante);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Hay un error en la Base de Datos" + ex.Message);
                }
            }

            return estudiantes;
        }

        public ClsEstudiante Get(int Id)
        {


            string query = "select id,Nombre,Apellido,Carrera,Asignatura,Promedio1,Promedio2,Promedio3,PromedioFinal from people" + "where is=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", Id);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();

                    ClsEstudiante oestudiante = new ClsEstudiante();
                    oestudiante.id = reader.GetInt32(0);
                    oestudiante.Nombre = reader.GetString(1);
                    oestudiante.Apellido = reader.GetString(2);
                    oestudiante.Carrera = reader.GetString(3);
                    oestudiante.Asignatura = reader.GetString(4);
                    oestudiante.Promedio1 = reader.GetInt32(5);
                    oestudiante.Promedio2 = reader.GetInt32(6);
                    oestudiante.Promedio3 = reader.GetInt32(7);
                    oestudiante.PromedioFinal = reader.GetInt32(8);
                    Clsconexion.Add(oestudiante);
                    return oestudiante;



                }
                catch (Exception ex)
                {

                    MessageBox.Show("Hay un error en la Base de Datos" + ex.Message);
                }

                return null;
            }


        }

            public void Add(int Id, string Nombre, string Apellido,string carrera,string Asignatura, decimal Promedio1, decimal Promedio2, decimal Promedio3,decimal PromedioFinal)
            {
                string query = "insert into estudiante (id,Nombre,Apellido,Carrera,Asignatura,Promedio1,Promedio2,Promedio3,PromedioFinal from ClsEstudiante) values" + "(@id,@Nombre,@Apellido,@Carrera,@Asignatura,@Promedio1,@Promedio2,@Promedio3,@PromedioFinal from ClsEstudiante)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@id", Id);
                    command.Parameters.AddWithValue("@Nombre", Nombre);
                    command.Parameters.AddWithValue("@Apellido", Apellido);
                    command.Parameters.AddWithValue("@Carrera", carrera);
                    command.Parameters.AddWithValue("@Asignatura", Asignatura);
                    command.Parameters.AddWithValue("@Promedio1", Promedio1);
                    command.Parameters.AddWithValue("@Promedio2", Promedio2);
                    command.Parameters.AddWithValue("@Promedio3", Promedio3);
                    command.Parameters.AddWithValue("@PromedioFinal", PromedioFinal);
                try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();

                        connection.Close();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Hay un error en la Base de Datos" + ex.Message);
                    }
                }






            }
        }
    }
}