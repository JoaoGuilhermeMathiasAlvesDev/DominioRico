using ServicoCore.E.EntityBase;
using ServicoCore.EntityBase.EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatelogoDominio.Entity
{
    public class Produto : EntityBase, IAgregatRoot
    {
        public Guid CategoriaId { get; private set; }
        public string Nome { get; private set; }

        public string Descricao { get; private set; }

        public bool Ativo { get; private set; }

        public decimal valor { get; private set; }

        public DateTime DataCadastro { get; private set; }

        public string Imagem { get; private set; }

        public int Quantidade { get; private set; }


        public Categoria Categoria { get; private set; }

        protected Produto() { }

        public Produto(string nome, string descricao, bool ativo, decimal valor, Guid categoriaId, DateTime datacadastro, string imagem)
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            CategoriaId = categoriaId;
            DataCadastro = datacadastro;
            Imagem = imagem;
        }

        public void Ativar() => Ativo = true;
        public void Desativa() => Ativo = false;

        public void AlterarCategoria(Categoria categoria)
        {
            Categoria = categoria;
            CategoriaId = categoria.Id;
        }

        public void AlterarDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public void DebitarEstoque(int quantidade)
        {
            if (quantidade < 0) quantidade *= -1;
            quantidade -= quantidade;
        }

        public void ReporEstoque(int quantidade)
        {
            Quantidade += quantidade;
        }

        public bool PossuiEstoque (int quantidade)
        {
            return Quantidade >= quantidade;
        }

        public void Validar()
        {

        }

    }
}
