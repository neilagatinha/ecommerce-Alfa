using ecommerce_db.Data;
using ecommerce_db.Models;
using ecommerce_db.Pages.crud;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_db.Pages.produto_crud
{
    public class ListarModel : PageModel{
        
        private readonly AppDbContext _context;

        public ListarModel(AppDbContext context){ 
            
            _context = context; 
        }
        public IList<Produto> Produtos {  get; set; }

        public async Task<IActionResult> OnGet(){
            Produtos = await _context.Produtos.ToListAsync();
            
            return Page();

        }

        public async Task<IActionResult> OnPostDeleteAsync(int? id) {
            var ProdutoParaDeletar = await _context
                                    .Produtos
                                    .FirstOrDefaultAsync(p => p.Id == id);
            if (ProdutoParaDeletar != null){
                _context.Produtos.Remove(ProdutoParaDeletar);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Listar"); 
        }    

    }
}
