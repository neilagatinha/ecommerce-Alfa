using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ecommerce_db.Pages.crud
{
    public class IndexModel : PageModel
    {
        public string Nome { get; set; }
        public int? Num { get; set; } 
        public void OnGet(string nome, int? num){
            Nome = nome;
            Num = num;
        }
    }
}
