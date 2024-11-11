using CatelogoDominio.Entity;
using CatelogoDominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using ServicoCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoData.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CatalogoContexto _catalogoContexto;

        public ProdutoRepository(CatalogoContexto catalogoContexto)
        {
            _catalogoContexto = catalogoContexto;
        }
        public IUnitofWork UnitofWork => _catalogoContexto;

        public void Adicionar(Produto produto)
        {
            _catalogoContexto.Produtos.Add(produto);
        }

        public void Adicionar(Categoria categoria)
        {
            _catalogoContexto.Categorias.Add(categoria);
        }

        public void Atualizar(Produto produto)
        {
            _catalogoContexto.Produtos.Update(produto);
        }

        public void Atualizar(Categoria categoria)
        {
            _catalogoContexto.Categorias.Update(categoria); 
        }

        public void Dispose()
        {
            _catalogoContexto?.Dispose();
        }

        public async Task<IEnumerable<Categoria>> ObterCategorias()
        {
            return await _catalogoContexto.Categorias.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterPorCategoria(int codigo)
        { 
            return await _catalogoContexto.Produtos.AsNoTracking().Include(p=>p.Categoria)
                .Where(c=> c.Categoria.Codigo == codigo).ToListAsync();
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
            return await _catalogoContexto.Produtos.FirstAsync(p =>  p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            return await _catalogoContexto.Produtos.AsNoTracking().ToListAsync();
        } 
    }
}
