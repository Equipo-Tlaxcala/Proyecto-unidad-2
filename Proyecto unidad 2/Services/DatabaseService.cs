using MySql.Data.MySqlClient;
using Proyecto_unidad_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_unidad_2.Services
{
    public class DatabaseService
    {
        private const string connectionString = "server=bibsouaoz5d6nmxetzik-mysql.services.clever-cloud.com;database=bibsouaoz5d6nmxetzik;uid=unrnq6quqtyjzf3t;pwd=YiZxfyaoYp3JRhpqe7Ry;";

        public async Task<List<Persona>> ObtenerPersonasAsync()
        {
            var personas = new List<Persona>();
            using var conn = new MySqlConnection(connectionString);
            await conn.OpenAsync();
            var cmd = new MySqlCommand("SELECT * FROM Personas", conn);
            using var reader = await cmd.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                personas.Add(new Persona
                {
                    id_nombre = Convert.ToInt32(reader["id_nombre"]),
                    Nombre = reader["Nombre"].ToString(),
                    Correo = reader["Correo"].ToString(),
                    Telefono = reader["telefono"].ToString()
                });
            }
            return personas;
        }

        public async Task AgregarPersonaAsync(Persona persona)
        {
            using var conn = new MySqlConnection(connectionString);
            await conn.OpenAsync();
            string query = "INSERT INTO Personas (Nombre, Correo, telefono) VALUES (@Nombre, @Correo, @Telefono)";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Nombre", persona.Nombre);
            cmd.Parameters.AddWithValue("@Correo", persona.Correo);
            cmd.Parameters.AddWithValue("@Telefono", persona.Telefono);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task ActualizarPersonaAsync(Persona persona)
        {
            using var conn = new MySqlConnection(connectionString);
            await conn.OpenAsync();
            string query = "UPDATE Personas SET Nombre = @Nombre, Correo = @Correo, telefono = @Telefono WHERE id_nombre = @Id";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Nombre", persona.Nombre);
            cmd.Parameters.AddWithValue("@Correo", persona.Correo);
            cmd.Parameters.AddWithValue("@Telefono", persona.Telefono);
            cmd.Parameters.AddWithValue("@Id", persona.id_nombre);
            await cmd.ExecuteNonQueryAsync();
        }

        public async Task EliminarPersonaAsync(int id)
        {
            using var conn = new MySqlConnection(connectionString);
            await conn.OpenAsync();
            string query = "DELETE FROM Personas WHERE id_nombre = @Id";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            await cmd.ExecuteNonQueryAsync();
        }
    }
}
