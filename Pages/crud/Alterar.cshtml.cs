using ecommerce_db.Data;
using ecommerce_db.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_db.Pages.crud
{
    public class AlterarModel : PageModel{
        private readonly AppDbContext _context;

		public AlterarModel(AppDbContext context){
			_context = context;
		}
        [BindProperty]
        public Clientes cliente { get; set; }
		public async Task<IActionResult> OnGet(int id){
            cliente = await _context.Cliente.FirstOrDefaultAsync(c  => c.Id == id);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync() {
            _context.Attach(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToPage("./Listar");
        }
    }
}
