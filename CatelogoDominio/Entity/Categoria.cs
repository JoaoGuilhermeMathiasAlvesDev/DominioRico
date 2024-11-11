using ServicoCore;
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

        // EF Relacionamento
        public ICollection<Produto> Produtos { get; set; }

        protected Categoria() { }
       
        public Categoria(string nome , int codigo)
        {
            Nome = nome;
            Codigo = codigo;

            Validar();
        }


        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome da categoria não pode estar vazio");
            Validacoes.ValidarSeIgual(Codigo, 0, "O campo Codigo não pode ser 0");
        }
    }
}
