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
        public Produto produto { get; set; }
        public async Task<IActionResult> OnGet(int id) {
            produto = await _context.Produtos.FirstOrDefaultAsync(c => c .Id == id);

            return Page();
        }
        public async Task<IActionResult> OnPostAsync() {
            _context.Attach(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Alterar");
        }
    }
}
    

