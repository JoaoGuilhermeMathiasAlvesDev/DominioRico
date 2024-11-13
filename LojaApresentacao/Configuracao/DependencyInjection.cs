using AplicationCatalogo.Services;
using CatalogoData;
using CatalogoData.Repository;
using CatelogoDominio;
using CatelogoDominio.Interfaces;
using ServicoCore.Bus;

namespace LojaApresentacao.Configuracao
{
    public static class DependencyInjection
    {

        public static void RegisterServices(this IServiceCollection services) 
        { 
            //Domain Bus
            services.AddScoped<IMediartHandler,MediartHandler>();

            // Catalogo
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoAppServices,ProdutoAppService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<CatalogoContexto>();
        }
    }
}
