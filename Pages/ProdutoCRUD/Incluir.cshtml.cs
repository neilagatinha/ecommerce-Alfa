using ecommerce_db.Data;
using ecommerce_db.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;

namespace ecommerce_db.Pages.ProdutoCRUD
{
    public class IncluirModel : PageModel
    {

        private readonly AppDbContext _context;

        public IncluirModel(AppDbContext context)
        {

            _context = context;
        }
        public void OnGet()
        {

        }

        [BindProperty]
        public Produto produto { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();
            }
            catch
            {
                Debug.WriteLine(produto.nome);
            }
            return Page();
        }
    }
}
