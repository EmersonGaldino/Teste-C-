using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Teste.Controllers;
using System.Web.Configuration;

namespace Teste.Models
{
    public class RepositorioMarca : IDisposable
    {
        private SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["Teste"].ConnectionString);

        public void Dispose()
        {
            connection.Close();
        }

        public void Post(string nome)
        {
            SqlCommand query = new SqlCommand();
            connection.Open();
            query.Connection = connection;
            query.CommandText = @"INSERT INTO MARCA VALUES (@nome)";

            query.Parameters.AddWithValue("@nome", nome);

            query.ExecuteNonQuery();

        }

        public List<Marca> Get()
        {
            List<Marca> marcas = new List<Marca>();
            SqlCommand query = new SqlCommand();
            connection.Open();
            query.Connection = connection;
            query.CommandText = @"SELECT * FROM Marca ORDER BY Nome ASC";

            SqlDataReader leitura = query.ExecuteReader();

            while (leitura.Read())
            {
                Marca marca = new Marca();
                marca.MarcaId = (int)leitura["MarcaId"];
                marca.Nome = (string)leitura["Nome"];

                marcas.Add(marca);
            }
            return marcas;
        }

        public List<Marca> Get(int marcaId)
        {
            List<Marca> marcas = new List<Marca>();
            SqlCommand query = new SqlCommand();
            connection.Open();
            query.Connection = connection;
            query.CommandText = @"SELECT * FROM Marca WHERE MarcaId=@marcaId ORDER BY Nome ASC";

            query.Parameters.AddWithValue("@marcaId", marcaId);

            SqlDataReader leitura = query.ExecuteReader();

            while (leitura.Read())
            {
                Marca marca = new Marca();
                marca.MarcaId = (int)leitura["MarcaId"];
                marca.Nome = (string)leitura["Nome"];

                marcas.Add(marca);
            }
            return marcas;
        }

        public List<Patrimonio> GetComposto(int marcaId)
        {
            List<Marca> marcas = new List<Marca>();
            List<Patrimonio> patrimonios = new List<Patrimonio>();
            SqlCommand query = new SqlCommand();
            connection.Open();
            query.Connection = connection;
            query.CommandText = @"SELECT Patrimonio.Nome, Patrimonio.MarcaId, NumeroTombo, Descricao FROM Marca INNER JOIN Patrimonio ON  Marca.MarcaId = Patrimonio.MarcaId  WHERE Marca.MarcaId = @marcaId;";

            query.Parameters.AddWithValue("@marcaId", marcaId);

            SqlDataReader leitura = query.ExecuteReader();

            while (leitura.Read())
            {
                Marca marca = new Marca();
                Patrimonio patrimonio = new Patrimonio();
                patrimonio.Nome = (string)leitura["Nome"];
                patrimonio.MarcaId = (int)leitura["MarcaId"];
                patrimonio.NumeroTombo = (int)leitura["NumeroTombo"];
                patrimonio.Descricao = (string)leitura["Descricao"];

                patrimonios.Add(patrimonio);

            }
            return patrimonios;
        }

        public void Delete(int marcaId)
        {
            SqlCommand query = new SqlCommand();
            connection.Open();
            query.Connection = connection;
            query.CommandText = @"DELETE FROM Marca WHERE MarcaId=@marcaId";

            query.Parameters.AddWithValue("@marcaId", marcaId);

            query.ExecuteNonQuery();

        }

        public void Put(int marcaId, string nome)
        {
            SqlCommand query = new SqlCommand();
            connection.Open();
            query.Connection = connection;
            query.CommandText = @"UPDATE Marca SET Nome = @nome WHERE MarcaId = @marcaId";

            query.Parameters.AddWithValue("@marcaId", marcaId);
            query.Parameters.AddWithValue("@nome", nome);

            query.ExecuteNonQuery();
        }
    }
}