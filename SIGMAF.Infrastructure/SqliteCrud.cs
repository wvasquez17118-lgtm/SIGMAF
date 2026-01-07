using Microsoft.Data.Sqlite;
using SIGMAF.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SIGMAF.Infrastructure
{
    /// <summary>
    /// Clase genérica de CRUD para SQLite.
    /// Supone que la tabla tiene una PK INTEGER llamada "Id".
    /// </summary>
    public class SqliteCrud<T> where T : class, IEntity, new()
    {
        private readonly string _connectionString;
        private readonly string _tableName;
        private readonly Func<SqliteDataReader, T> _mapFromReader;
        private readonly Func<T, Dictionary<string, object?>> _toDictionary;
        private readonly string _primaryKeyColumn;

        public SqliteCrud(
            string connectionString,
            string tableName,
            Func<SqliteDataReader, T> mapFromReader,
            Func<T, Dictionary<string, object?>> toDictionary,
            string primaryKeyColumn = "Id")
        {
            _connectionString = connectionString;
            _tableName = tableName;
            _mapFromReader = mapFromReader;
            _toDictionary = toDictionary;
            _primaryKeyColumn = primaryKeyColumn;
        }

        private SqliteConnection GetConnection()
            => new SqliteConnection(_connectionString);



        public int InsertMany(IEnumerable<T> entities)
        {
            // Si la lista viene vacía, no hacemos nada
            var lista = entities?.ToList() ?? new List<T>();
            if (lista.Count == 0)
                return 0;

            using var con = GetConnection();
            con.Open();
            using var tx = con.BeginTransaction();

            int totalInsertados = 0;

            // Preparamos SQL solo una vez con base en el primer elemento
            var firstData = _toDictionary(lista[0]);
            var keys = firstData.Keys.ToList();

            string columns = string.Join(", ", keys);
            string paramNames = string.Join(", ", keys.Select(k => "@" + k));

            string sql = $"INSERT INTO {_tableName} ({columns}) " +
                         $"VALUES ({paramNames}); " +
                         "SELECT last_insert_rowid();";

            using var cmd = con.CreateCommand();
            cmd.Transaction = tx;
            cmd.CommandText = sql;

            foreach (var entity in lista)
            {
                // Diccionario de valores para esta entidad
                var data = _toDictionary(entity);

                cmd.Parameters.Clear();
                foreach (var key in keys)
                {
                    var value = data[key];
                    cmd.Parameters.AddWithValue("@" + key, value ?? DBNull.Value);
                }

                // Ejecutamos: inserta y devuelve el Id generado
                var result = cmd.ExecuteScalar();
                int newId = Convert.ToInt32(result);
                entity.Id = newId;       // actualizamos el Id en el objeto

                totalInsertados++;
            }

            tx.Commit();
            return totalInsertados;
        }

        // CREATE (INSERT)
        public int Insert(T entity)
        {
            using var con = GetConnection();
            con.Open();

            var data = _toDictionary(entity); // columnas excepto Id
            var columns = string.Join(", ", data.Keys);
            var paramNames = string.Join(", ", data.Keys.Select(k => "@" + k));

            var sql = $"INSERT INTO {_tableName} ({columns}) " +
                      $"VALUES ({paramNames}); " +
                      "SELECT last_insert_rowid();";

            using var cmd = con.CreateCommand();
            cmd.CommandText = sql;

            foreach (var kv in data)
            {
                cmd.Parameters.AddWithValue("@" + kv.Key, kv.Value ?? DBNull.Value);
            }

            var result = cmd.ExecuteScalar();
            var lastId = Convert.ToInt32(result);
            entity.Id = lastId; // actualizamos la entidad

            return lastId;
        }

        // READ - obtener por Id
        public T? GetById(int id)
        {
            using var con = GetConnection();
            con.Open();

            var sql = $"SELECT * FROM {_tableName} WHERE {_primaryKeyColumn} = @Id;";

            using var cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@Id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return _mapFromReader(reader);
            }

            return null;
        }

        // READ - obtener todos
        public List<T> GetAll()
        {
            using var con = GetConnection();
            con.Open();

            var sql = $"SELECT * FROM {_tableName};";

            using var cmd = con.CreateCommand();
            cmd.CommandText = sql;

            using var reader = cmd.ExecuteReader();
            var list = new List<T>();

            while (reader.Read())
            {
                list.Add(_mapFromReader(reader));
            }

            return list;
        }

        // UPDATE
        public int Update(T entity)
        {
            using var con = GetConnection();
            con.Open();

            var data = _toDictionary(entity); // columnas excepto Id
            var setClause = string.Join(", ", data.Keys.Select(k => $"{k} = @{k}"));

            var sql = $"UPDATE {_tableName} SET {setClause} WHERE {_primaryKeyColumn} = @Id;";

            using var cmd = con.CreateCommand();
            cmd.CommandText = sql;

            foreach (var kv in data)
            {
                cmd.Parameters.AddWithValue("@" + kv.Key, kv.Value ?? DBNull.Value);
            }

            cmd.Parameters.AddWithValue("@Id", entity.Id);

            return cmd.ExecuteNonQuery();
        }

        // DELETE
        public int Delete(int id)
        {
            using var con = GetConnection();
            con.Open();

            var sql = $"DELETE FROM {_tableName} WHERE {_primaryKeyColumn} = @Id;";

            using var cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@Id", id);

            return cmd.ExecuteNonQuery();
        }
    }
}