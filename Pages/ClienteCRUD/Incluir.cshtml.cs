using ecommerce_db.Data;
using ecommerce_db.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace ecommerce_db.Pages.crud
{
    public class IncluirModel : PageModel
    {
        private readonly AppDbContext _context;

        public IncluirModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet(){
           
        }

        [BindProperty]
        public Cliente clientes { get; set; }

        public async Task<IActionResult> OnPostAsync() {

            Debug.WriteLine(ModelState.IsValid);

            var clientes = new Cliente();

            bool validado = await TryUpdateModelAsync<Cliente>(
                                        clientes,
                                        "clientes",
                                        c => c.Nome, c => c.Telefone,c => c.Email
                                    );

            if ( validado ) {
                _context.Clientes.Add(clientes);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Listar");
            }  else {
                return Page();
            }
        }
    }
}
