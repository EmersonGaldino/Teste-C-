using System;
using System.Collections.Generic;
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
                using (PatrimonioRepository conexao = new PatrimonioRepository())
                {
                    patrimonios = conexao.Get();
                    return patrimonios;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public List<Patrimonio> Get(int marcaId)
        {
            try
            {
                using (PatrimonioRepository conexao = new PatrimonioRepository())
                {
                    patrimonios = conexao.Get(marcaId);
                    return patrimonios;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Post(int marcaId, string nome, string descricao)
        {
            try
            {
                using (PatrimonioRepository conexao = new PatrimonioRepository())
                    conexao.Post(marcaId, nome, descricao);

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
                using (PatrimonioRepository conexao = new PatrimonioRepository())
                    conexao.Delete(marcaId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void Put(int marcaId, string nome, string descricao)
        {
            try
            {
                using (PatrimonioRepository conexao = new PatrimonioRepository())
                    conexao.Put(marcaId, nome, descricao);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
