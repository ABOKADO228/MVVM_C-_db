using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Collections.ObjectModel;

namespace MVVM.Database
{
    public class SQLiteHelper
    {
        private readonly string _connectionString;
        private readonly string _databasePath;

        public SQLiteHelper(string databaseName = "Warehouse.db")
        {
            _databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, databaseName);
            _connectionString = $"Data Source={_databasePath};Version=3;";
        }

        public async Task EnableForeignKeysAsync()
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection))
                {
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
        public SQLiteConnection CreateConnection()
        {
            return new SQLiteConnection(_connectionString);
        }

        // Выполнение запроса без возврата результата (INSERT, UPDATE, DELETE)
        public int ExecuteNonQuery(string sql, Dictionary<string, object> parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var command = new SQLiteCommand(sql, connection))
                {
                    AddParameters(command, parameters);
                    return command.ExecuteNonQuery();
                }
            }
        }

        // Выполнение скалярного запроса
        public object ExecuteScalar(string sql, Dictionary<string, object> parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var command = new SQLiteCommand(sql, connection))
                {
                    AddParameters(command, parameters);
                    return command.ExecuteScalar();
                }
            }
        }

        // Выполнение запроса с возвратом DataTable
        public DataTable GetDataTable(string sql, Dictionary<string, object> parameters = null)
        {
            var dataTable = new DataTable();

            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var command = new SQLiteCommand(sql, connection))
                {
                    AddParameters(command, parameters);

                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        // Выполнение запроса с возвратом списка объектов
        public List<T> ExecuteReader<T>(string sql, Func<SQLiteDataReader, T> mapFunction,
            Dictionary<string, object> parameters = null)
        {
            var results = new List<T>();

            using (var connection = CreateConnection())
            {
                connection.Open();
                using (var command = new SQLiteCommand(sql, connection))
                {
                    AddParameters(command, parameters);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(mapFunction(reader));
                        }
                    }
                }
            }

            return results;
        }

        // Проверка существования базы данных
        public bool DatabaseExists()
        {
            return File.Exists(_databasePath);
        }

        // Создание резервной копии
        public void CreateBackup(string backupPath)
        {
            if (DatabaseExists())
            {
                File.Copy(_databasePath, backupPath, true);
            }
        }
        public ObservableCollection<string> GetAllTables()
        {
            ObservableCollection<string> tableNames = new ObservableCollection<string>();
            using (var connection = CreateConnection())
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT name FROM sqlite_master WHERE type='table';";
                
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tableNames.Add(reader.GetString(0)); // Получаем имя таблицы из первого столбца
                    }
                }
            }
            return tableNames;
        }
        private void AddParameters(SQLiteCommand command, Dictionary<string, object> parameters)
        {
            if (parameters == null) return;

            foreach (var param in parameters)
            {
                command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
            }
        }

        
    }
}

