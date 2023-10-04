using ecommerce_db.Data;
using ecommerce_db.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;

namespace ecommerce_db.Pages
{
    public class IndexModel : PageModel {

        private readonly ILogger<IndexModel> _logger;

        private readonly AppDbContext _context;
        public IList<Produto> Produtos { get; set; }

        private int paginaAtual = 1;
        public int QuantidadePagina{ get;private set; }

        private int qtdProdPorPagina = 12;
        public IndexModel(ILogger<IndexModel> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task Onget(
            [FromQuery(Name = "q")] string TermoBusca,
            [FromQuery(Name = "q")] int? pagina,
            [FromQuery(Name = "q")] int? ordem
            ){
            paginaAtual = pagina ?? 1;

            var query = _context.Produtos.AsQueryable();

            if (!string.IsNullOrEmpty(TermoBusca))
            {
                query = query.Where(
                        p => p.nome.ToLower().Contains(TermoBusca.ToLower())
                );
            }

            if (ordem.HasValue)
            {
                switch (ordem.Value)
                {
                    case 1:
                        query = query.OrderBy(p => p.nome.ToLower());
                        break;
                    case 2:
                        query = query.OrderBy(p => p.preco);
                        break;
                    case 3:
                        query = query.OrderByDescending(p => p.preco);
                        break;
                }
            }

            var stage = query;
            var qtdProdutos = stage.Count();
            double resultado = qtdProdutos / qtdProdPorPagina;
            resultado = Math.Ceiling(resultado);
            Convert.ToInt32(resultado);


            QuantidadePagina = Convert.ToInt32(resultado);

            query = query.Skip(qtdProdPorPagina * (this.paginaAtual - 1)).Take(qtdProdPorPagina);

            Produtos = await query.ToListAsync();


        }
    }
}