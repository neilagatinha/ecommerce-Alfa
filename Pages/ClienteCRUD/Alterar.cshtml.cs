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
        public Cliente clientes { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            clientes = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
            if(clientes == null)
            {
                return NotFound();
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid){
                return Page();
            }
            _context.Attach(clientes).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            }catch (DbUpdateConcurrencyException error){
                if (!ClienteAindaExiste(clientes.Id)){
                    return NotFound();
                } else{
                    throw;
                }

            } catch {
                return Page();
            }

            return RedirectToPage("./Listar");

        
        }       
        private bool ClienteAindaExiste(int? id){
            return _context.Clientes.Any(c => c.Id == id);
        }

    }
}
