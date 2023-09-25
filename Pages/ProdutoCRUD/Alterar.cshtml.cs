using ecommerce_db.Data;
using ecommerce_db.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_db.Pages.ProdutoCRUD
{
    public class AlterarProduto : PageModel {
        private readonly AppDbContext _context;

        public AlterarProduto(AppDbContext context) {
            _context = context;
        }

        [BindProperty]
        public Produto Produtos { get; set; }
        public async Task<IActionResult> OnGet(int id) {
            Produtos = await _context
                              .Produtos
                              .FirstOrDefaultAsync(p => p.Id == id);

            return Page();
        }
        public async Task<IActionResult> OnPostAsync() {
            _context.Attach(Produtos).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Alterar");
        }

    }
}
    

