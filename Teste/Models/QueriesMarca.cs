using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Teste.Controllers;

namespace Teste.Models
{
    public class QueriesMarca
    {
        Conexaocs conexao = new Conexaocs();
        public void InserirMarca(string nome)
        {
            SqlCommand query = new SqlCommand();
            conexao.ConectaBD();
            SqlConnection connection = new SqlConnection();
            query.Connection = connection;
            query.CommandText = @"INSERT INTO MARCA VALUES (@nome)";

            query.Parameters.AddWithValue("@nome", nome);

            query.ExecuteNonQuery();
        }
        public List<Marca> consultaMarcas()
        {
            List<Marca> marcas = new List<Marca>();
            SqlCommand query = new SqlCommand();
            conexao.ConectaBD();
            SqlConnection connection = new SqlConnection();
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
        public void RemoverMarca(int marcaId)
        {
            SqlCommand query = new SqlCommand();
            conexao.ConectaBD();
            SqlConnection connection = new SqlConnection();
            query.Connection = connection;
            query.CommandText = @"DELETE FROM Marca WHERE MarcaId=@marcaId";

            query.Parameters.AddWithValue("@marcaId", marcaId);

            query.ExecuteNonQuery();
        }
        public void AtualizaMarca(int marcaId, string nome)
        {
            SqlCommand query = new SqlCommand();
            conexao.ConectaBD();
            SqlConnection connection = new SqlConnection();
            query.Connection = connection;
            query.CommandText = @"UPDATE Marca SET Nome = @nome WHERE MarcaId = @marcaId";

            query.Parameters.AddWithValue("@marcaId", marcaId);
            query.Parameters.AddWithValue("@nome", nome);

            query.ExecuteNonQuery();
        }
    }
}