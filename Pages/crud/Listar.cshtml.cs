using ecommerce_db.Data;
using ecommerce_db.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_db.Pages.crud{
    public class ListarModel : PageModel{
        private readonly AppDbContext _context;

		public ListarModel(AppDbContext context){
			_context = context;
		}

		public IList<Clientes> clientes {  get; set; }

        public async Task<IActionResult> OnGet() {
            clientes = await _context.Cliente.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int? id){
            //Busca no banco de dados o cliente com o mesmo id procurado
            var cliente = await _context.Cliente.FirstOrDefaultAsync( c => c.Id == id);

            //Verifica se foi retornada algum cliente do banco 
            if (cliente != null){
                _context.Cliente.Remove(cliente);
                await _context.SaveChangesAsync();
            }

            //Redirecionar para a página de listagem de cliente
            return RedirectToPage("./Listar");
        }
    }
}
