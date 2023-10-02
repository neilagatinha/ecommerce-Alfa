using CodigoApoio;
using ecommerce_db.Data;
using ecommerce_db.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ecommerce_db.Pages.ProdutoCRUD
{
    public class AlterarProduto : PageModel {

        private readonly AppDbContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;

        //[BindProperty]
        //public Produto Produto { get; set; }
        public string CaminhoImagem { get; set; }

        [BindProperty]
        [Display(Name = "Imagem do Produto")]
        public IFormFile ImagemProduto { get; set; }
        public AlterarProduto(AppDbContext context, IWebHostEnvironment webHostEnvironment) {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public Produto Produtos { get; set; }
        public async Task<IActionResult> OnGet(int Id) {

            if(Id == null) {  
                return NotFound(); 
            }

            Produtos = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == Id);

            if (Produtos == null) {
                return NotFound();
            }

            CaminhoImagem = $"~/img/produto/{Produtos.Id:D6}.jpg";

            return Page();
        }
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }
            _context.Attach(Produtos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                //Se há uma imagem de produto submetida
                if (ImagemProduto != null)
                    await AppUtils.ProcessarArquivoDeImagem(Produtos.Id, ImagemProduto, _webHostEnvironment);

            }catch (DbUpdateConcurrencyException error) {
                if (!ProdutoAindaExiste(Produtos.Id))
                {
                    return NotFound();
                } else { throw error; }

            } catch
            {
                return Page();
            }

            return RedirectToPage("./Listar");
        }

        private bool ProdutoAindaExiste(int id) {
            return _context.Produtos.Any(c  => c.Id == id);
        }
    }
}
    

