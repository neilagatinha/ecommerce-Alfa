using ecommerce_db.Data;
using ecommerce_db.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_db.Pages.CRUD
{
    public class ListarModel : PageModel
    {
        private readonly AppDbContext _context;

		public ListarModel(AppDbContext context) {
			_context = context;
		}

        public IList<Clientes> clientes { get; set; }

		public async Task<IActionResult> OnGet(){
			clientes = await _context.Cliente.ToArrayAsync();

            return Page();
        }
    }
}
