using ecommerce_db.Data;
using ecommerce_db.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_db.Pages.CRUD{
    public class AlterarModel : PageModel{
        private readonly AppDbContext _context;

        public AlterarModel(AppDbContext context) {
            _context = context;

        }
          
        public Clientes cliente { get; set; }

        public async Task<IActionResult> OnGet(int id) {
            cliente = await _context
                               .Cliente
                               .FirstOrDefaultAsync(cliente => id == id);

            return Page();


        }
        
    }
}
