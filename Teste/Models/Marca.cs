using System.Collections.Generic;
using Teste.Models;

namespace Teste.Controllers
{
    public class Marca
    {
        public int MarcaId { get; set; }
        public string Nome { get; set; }
        public ICollection<Patrimonio> Patrimonio { get; set; } = new List<Patrimonio>();
    }
}

