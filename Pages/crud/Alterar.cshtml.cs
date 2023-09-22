using ecommerce_db.Data;
using ecommerce_db.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_db.Pages.crud
{
    public class AlterarModel : PageModel {
        private readonly AppDbContext _context;

        public AlterarModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Clientes clientes { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            clientes = await _context.cliente.FirstOrDefaultAsync(c => c.Id == id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {
            _context.Attach(clientes).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Listar");
        }
    }
}
