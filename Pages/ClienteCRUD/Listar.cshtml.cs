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

        public IList<Cliente> clientes { get; set; }
        public async Task<IActionResult> OnGet() {
            clientes = await _context.Clientes.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? id){
            if (id == null){
                return Page();  

            }

            var cliente = await _context.Clientes.FirstOrDefaultAsync( c => c.Id == id);

            //Verifica se foi retornado algum cliente do banco de dados
            if (cliente != null) {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();

            }

            //Redireciona para a página de listagem de cliente
            return RedirectToPage("./Listar");

        }
    }
}
