using ecommerce_db.Data;
using ecommerce_db.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ecommerce_db.Pages.ClienteCRUD.CRUD
{
    public class IncluirModel : PageModel{

        private readonly AppDbContext _context;

        public IncluirModel(AppDbContext context) {

            _context = context;
        }

        [BindProperty]
        public Clientes cliente { get; set; }
        public void OnGet(){
        }

        public async Task<IActionResult> OnPostAsync() {
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();

            return Page();
        }

	}
}
