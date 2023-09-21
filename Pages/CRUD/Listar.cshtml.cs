using ecommerce_db.Data;
using ecommerce_db.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_db.Pages.CRUD
{
    public class ListarModel : PageModel{

        private readonly AppDbContext _context;

        public ListarModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Clientes> Clientes { get; set; }
        public async Task<IActionResult> OnGet() {
            Clientes = await _context.Cliente.ToListAsync();

              return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? Id)
        {
            var clientesParaDeletar = await _context
                                    .Cliente
                                    .FirstOrDefaultAsync( c => c.Id == Id );
            if ( clientesParaDeletar!= null ) {

                _context.Cliente.Remove(clientesParaDeletar);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Listar");
        }
    }
}
