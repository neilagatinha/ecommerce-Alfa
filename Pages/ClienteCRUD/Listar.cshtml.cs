using ecommerce_db.Data;
using ecommerce_db.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_db.Pages.crud
{
    public class ListarModel : PageModel {

        private readonly AppDbContext _context;

        public ListarModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<Clientes> clientes { get; set; }
        public async Task<IActionResult> OnGet() {
            clientes = await _context.cliente.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? id){

            var cliente = await _context.cliente.FirstOrDefaultAsync( c => c.Id == id);

            //Verifica se foi retornado algum cliente do banco de dados
            if (cliente != null) {
                _context.cliente.Remove(cliente);
                await _context.SaveChangesAsync();

            }

            //Redireciona para a página de listagem de cliente
            return RedirectToPage("./Listar");

        }
    }
}
