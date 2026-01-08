using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGMAF.Infrastructure
{
    public static class SqliteDatabase
    {
        public static void Initialize(string connectionString)
        {
            using var con = new SqliteConnection(connectionString);
            con.Open();

            // Aquí puedes crear todas las tablas que quieras
            using var cmd = con.CreateCommand();
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS MotosCatalogos (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    IdCatalogo TEXT,
                    IdCategoria TEXT,
                    Nombre TEXT,
                    Descripcion TEXT,
                    Codigo TEXT,
                    CodigoCategoria TEXT,
                    Estado TEXT
                );

                CREATE TABLE IF NOT EXISTS MotosProveedores (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ProveedorId TEXT,
                    Direccion TEXT,
                    Nombre TEXT,
                    Celular TEXT,
                    Estado TEXT
                );
            ";
            cmd.ExecuteNonQuery();
        }

        public static void DeleteDatabase(string connectionString)
        {
            var csb = new SqliteConnectionStringBuilder(connectionString);
            var filePath = csb.DataSource;

            // Si es ruta relativa, convertir a ruta completa (carpeta del .exe)
            if (!Path.IsPathRooted(filePath))
            {
                filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
            }

            if (!File.Exists(filePath))
                return;

            // 🔴 Muy importante: liberar conexiones del pool
            SqliteConnection.ClearAllPools();

            // Pequeño retry por si el SO tarda un poco en soltar el handle
            int retries = 3;
            while (true)
            {
                try
                {
                    File.Delete(filePath);
                    break;
                }
                catch (IOException)
                {
                    retries--;
                    if (retries <= 0)
                        throw; // si sigue bloqueado, ya lanzamos la excepción real

                    Thread.Sleep(100); // esperar 100ms y reintentar
                }
            }
        }

    }
}