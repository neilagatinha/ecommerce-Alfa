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
        public async Task<IActionResult> OnGet(int Id) {

            if(Id == null) {  
                return NotFound(); 
            }

            Produtos = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == Id);

            if (Produtos == null) {
                return NotFound();
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }
            _context.Attach(Produtos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }catch (DbUpdateConcurrencyException error) {
                if (!ProdutoAindaExiste(Produtos.Id))
                {
                    return NotFound();
                } else { throw error; }

            } catch
            {
                return Page();
            }

            return RedirectToPage("./Listar");
        }

        private bool ProdutoAindaExiste(int id) {
            return _context.Produtos.Any(c  => c.Id == id);
        }
    }
}
    

