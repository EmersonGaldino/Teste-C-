using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Teste.Models
{
    public class RepositorioPatrimonio : IDisposable
    {
        private SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Teste"].ConnectionString);

        public void Dispose()
        {
            connection.Close();
        }
        public void Post(int marcaId, string nome, string descricao)
        {
            SqlCommand query = new SqlCommand();
            connection.Open();
            query.Connection = connection;
            query.CommandText = @"INSERT INTO Patrimonio VALUES (@marcaId, @nome, @descricao)";

            query.Parameters.AddWithValue("@marcaId", marcaId);
            query.Parameters.AddWithValue("@nome", nome);
            query.Parameters.AddWithValue ("@descricao", descricao);

            query.ExecuteNonQuery();
        }

        public List<Patrimonio> Get()
        {
            List<Patrimonio> patrimonios = new List<Patrimonio>();
            SqlCommand query = new SqlCommand();
            connection.Open();
            query.Connection = connection;
            query.CommandText = @"SELECT * FROM Patrimonio ORDER BY Nome ASC";

            SqlDataReader leitura = query.ExecuteReader();

            while (leitura.Read())
            {
                Patrimonio patrimonio = new Patrimonio();
                patrimonio.MarcaId = (int)leitura["MarcaId"];
                patrimonio.Nome = (string)leitura["Nome"];
                patrimonio.Descricao = (string)leitura["Descricao"];
                patrimonio.NumeroTombo = (int)leitura["NumeroTombo"];

                patrimonios.Add(patrimonio);
            }
            return patrimonios;
        }

        public List<Patrimonio> Get(int marcaId)
        {
            List<Patrimonio> patrimonios = new List<Patrimonio>();
            SqlCommand query = new SqlCommand();
            connection.Open();
            query.Connection = connection;
            query.CommandText = @"SELECT * FROM Patrimonio WHERE MarcaId=@marcaId ORDER BY Nome ASC";

            query.Parameters.AddWithValue("@marcaId", marcaId);

            SqlDataReader leitura = query.ExecuteReader();

            while (leitura.Read())
            {
                Patrimonio patrimonio = new Patrimonio();
                patrimonio.MarcaId = (int)leitura["MarcaId"];
                patrimonio.Nome = (string)leitura["Nome"];
                patrimonio.Descricao = (string)leitura["Descricao"];
                patrimonio.NumeroTombo = (int)leitura["NumeroTombo"];

                patrimonios.Add(patrimonio);
            }
            return patrimonios;
        }

        public void Delete(int marcaId)
        {
            SqlCommand query = new SqlCommand();
            connection.Open();
            query.Connection = connection;
            query.CommandText = @"DELETE FROM Patrimonio WHERE MarcaId=@marcaId";

            query.Parameters.AddWithValue("@marcaId", marcaId);

            query.ExecuteNonQuery();
        }

        public void Put(int marcaId, string nome, string descricao)
        {
            SqlCommand query = new SqlCommand();
            connection.Open();
            query.Connection = connection;
            query.CommandText = @"UPDATE Patrimonio SET Nome = @nome, Descricao = @descricao WHERE MarcaId = @marcaId";

            query.Parameters.AddWithValue("@marcaId", marcaId);
            query.Parameters.AddWithValue("@nome", nome);
            query.Parameters.AddWithValue("@descricao", descricao);

            query.ExecuteNonQuery();
        }
    }
}