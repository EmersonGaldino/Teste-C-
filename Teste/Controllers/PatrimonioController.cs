using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Http;
using Teste.Models;

namespace Teste.Controllers
{
    public class PatrimonioController : ApiController
    {
        private static List<Patrimonio> patrimonios = new List<Patrimonio>();

        public List<Patrimonio> Get()
        {
            try
            {
                using (RepositorioPatrimonio conexao = new RepositorioPatrimonio())
                {
                    patrimonios = conexao.Get();
                    return patrimonios;
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<Patrimonio> Get(int marcaId)
        {
            try
            {
                using (RepositorioPatrimonio conexao = new RepositorioPatrimonio())
                {
                    patrimonios = conexao.Get(marcaId);
                    return patrimonios;
                }
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Post(int marcaId, string nome, string descricao)
        {
            try
            {
                using (RepositorioPatrimonio conexao = new RepositorioPatrimonio())
                    conexao.Post(marcaId, nome, descricao);

            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Delete(int marcaId)
        {
            try
            {
                using (RepositorioPatrimonio conexao = new RepositorioPatrimonio())
                    conexao.Delete(marcaId);
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Put(int marcaId, string nome, string descricao)
        {
            try
            {
                using (RepositorioPatrimonio conexao = new RepositorioPatrimonio())
                    conexao.Put(marcaId, nome, descricao);
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
