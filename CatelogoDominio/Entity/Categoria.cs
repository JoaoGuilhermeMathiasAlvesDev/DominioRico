using ServicoCore.EntityBase.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatelogoDominio.Entity
{
    public class Categoria :EntityBase
    {
        public string Nome { get;private set; }
        public int Codigo { get;private set; }

        public Categoria(string nome , int codigo)
        {
            Nome = nome;
            Codigo = codigo;
        }
    }
}
