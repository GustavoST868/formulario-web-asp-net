using System;
using System.Data;
using Npgsql;

public class DatabaseHelper
{
    private string connectionString;

    public DatabaseHelper(string host, string database, string username, string password, int port = 5432)
    {
        connectionString = $"Host={host};Port={port};Database={database};Username={username};Password={password}";
    }
    //CRUD(CREATE - GET READ UPDATE DELETE)
    public DataTable GetPessoas()
    {
        DataTable resultTable = new DataTable();
        string query = "SELECT * FROM Pessoa";

        try
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new NpgsqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        resultTable.Load(reader);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao executar o SELECT na tabela Pessoa: {ex.Message}");
        }

        return resultTable;
    }

    public bool InsertPessoa(string name, string cpf, string rg, string email, DateTime dateBirth, string gender, string nationality, string maritalStatus)
    {
        string query = @"
            INSERT INTO Pessoa (name, cpf, rg, e_mail, date_birth, gender, nationality, marital_status) 
            VALUES (@name, @cpf, @rg, @e_mail, @date_birth, @gender, @nationality, @marital_status)";

        try
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@cpf", cpf);
                    command.Parameters.AddWithValue("@rg", rg);
                    command.Parameters.AddWithValue("@e_mail", email);
                    command.Parameters.AddWithValue("@date_birth", dateBirth);
                    command.Parameters.AddWithValue("@gender", gender);
                    command.Parameters.AddWithValue("@nationality", nationality);
                    command.Parameters.AddWithValue("@marital_status", maritalStatus);
                    command.ExecuteNonQuery();
                }
            }

            Console.WriteLine("Dados inseridos com sucesso.");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao inserir os dados: {ex.Message}");
            return false;
        }

       
    }

    public bool deletePeople(string cpf)
    {
        string query = @"
                DELETE FROM PESSOA 
                WHERE cpf = @cpf;
            ";

        try
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@cpf", cpf);
                    command.ExecuteNonQuery();
                }
            }
            Console.WriteLine("Dados deletados com sucesso");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public bool EditPeople(string name, string cpf, string rg, string email, DateTime dateBirth, string gender, string nationality, string maritalStatus)
    {
        string query = @"
            UPDATE Pessoa
            SET name = @name, 
                rg = @rg, 
                e_mail = @e_mail, 
                date_birth = @date_birth, 
                gender = @gender, 
                nationality = @nationality, 
                marital_status = @marital_status
            WHERE cpf = @cpf";

        try
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@cpf", cpf);
                    command.Parameters.AddWithValue("@rg", rg);
                    command.Parameters.AddWithValue("@e_mail", email);
                    command.Parameters.AddWithValue("@date_birth", dateBirth);
                    command.Parameters.AddWithValue("@gender", gender);
                    command.Parameters.AddWithValue("@nationality", nationality);
                    command.Parameters.AddWithValue("@marital_status", maritalStatus);
                    command.ExecuteNonQuery();
                }
            }

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao editar os dados: {ex.Message}");
            return false;
        }
    }
}
