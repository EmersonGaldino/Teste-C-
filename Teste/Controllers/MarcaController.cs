using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Http;
using Teste.Models;

namespace Teste.Controllers
{
    public class MarcaController : ApiController
    {
        private static List<Marca> marcas = new List<Marca>();
        private static List<Patrimonio> patrimonios = new List<Patrimonio>();

        public List<Marca> Get()
        {
            try
            {
                using (RepositorioMarca conexao = new RepositorioMarca())
                {
                    marcas = conexao.Get();
                    return marcas;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Marca> Get(int marcaId)
        {
            try
            {
                using (RepositorioMarca conexao = new RepositorioMarca())
                {
                    marcas = conexao.Get(marcaId);
                    return marcas;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [Route("api/marca/patrimonio")]
        public List<Patrimonio> GetComposto(int marcaId)
        {
            try
            {
                using (RepositorioMarca conexao = new RepositorioMarca())
                {
                    patrimonios = conexao.GetComposto(marcaId);
                    return patrimonios;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Post(string nome)
        {
            try
            {
                using (RepositorioMarca conexao = new RepositorioMarca())
                    conexao.Post(nome);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Delete(int marcaId)
        {
            try
            {
                using (RepositorioMarca conexao = new RepositorioMarca())
                    conexao.Delete(marcaId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Put(int marcaId, string nome)
        {
            try
            {
                using (RepositorioMarca conexao = new RepositorioMarca())
                    conexao.Put(marcaId, nome);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
