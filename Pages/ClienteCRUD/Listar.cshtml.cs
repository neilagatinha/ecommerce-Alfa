using ecommerce_db.Data;
using ecommerce_db.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ecommerce_db.Pages.crud
{
    public class ListarModel : PageModel {

        private readonly AppDbContext _context;
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public ListarModel(AppDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager){
            _context = context;
			_userManager = userManager;
			_roleManager = roleManager;
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

		public async Task<IActionResult> OnPostDelAdminAsync(int? id) {
			if (id == null) {
				return NotFound();
			}

			var cliente = await _context.Clientes.FindAsync(id);

			if (cliente != null) {
				AppUser usuario = await _userManager.FindByNameAsync(cliente.Email);
				if (usuario != null) {
					await _userManager.RemoveFromRoleAsync(usuario, "admin");
				}
			}

			return RedirectToPage("./Listar");
		}

		public async Task<IActionResult> OnPostSetAdminAsync(int? id) {
			if (id == null) {
				return NotFound();
			}

			var cliente = await _context.Clientes.FindAsync(id);

			if (cliente != null) {
				AppUser usuario = await _userManager.FindByNameAsync(cliente.Email);
				if (usuario != null) {
					if (!await _roleManager.RoleExistsAsync("admin"))
						await _roleManager.CreateAsync(new IdentityRole("admin"));

					await _userManager.AddToRoleAsync(usuario, "admin");
				}
			}

			return RedirectToPage("./Listar");
		}
	}
}
