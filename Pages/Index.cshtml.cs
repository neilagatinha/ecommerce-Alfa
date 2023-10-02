using ecommerce_db.Data;
using ecommerce_db.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_db.Pages
{
    public class IndexModel : PageModel {

        private readonly ILogger<IndexModel> _logger;
        private readonly AppDbContext _context;
        public IList<Produto> Produtos {get ; set;}

        public IndexModel(ILogger<IndexModel> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task Onget(){
            Produtos = await _context.Produtos.ToListAsync();

              
        }
    }
}