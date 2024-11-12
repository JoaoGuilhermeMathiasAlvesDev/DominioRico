using CatelogoDominio.Events;
using CatelogoDominio.Interfaces;
using ServicoCore.Bus;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatelogoDominio
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMediartHandler _bus;

        public EstoqueService(IProdutoRepository produtoRepository,
                                IMediartHandler bus)
        {
            _produtoRepository = produtoRepository;
            _bus = bus;
        }

        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto == null) return false;

            if(!produto.PossuiEstoque(quantidade)) return false;

            produto.DebitarEstoque(quantidade);

            if(produto.Quantidade <10)
                await _bus.PublicarEvento(new ProdutoAbaixoEstoqueEvent(produto.Id,produto.Quantidade));   

            _produtoRepository.Atualizar(produto);
            return await _produtoRepository.UnitofWork.Commit();
        }

        public void Dispose()
        {
            _produtoRepository
                ?.Dispose();
        }

        public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if(produto == null)
                return false;

           produto.ReporEstoque(quantidade);

            _produtoRepository.Atualizar(produto);
            return await _produtoRepository.UnitofWork.Commit();
        }
    }
}
