using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorBookList.Models;

namespace RazorBookList.Pages.BookList
{
    public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        // Property Binding, ele automaticamente assume que no post voce vai estar pegando o Book
        [BindProperty]
        public Book Book { get; set; }
        public void OnGet()
        {

        }

        // ActionResult para redirecionar como resultado de uma ação
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Book.AddAsync(Book);
                await _db.SaveChangesAsync(); //Jogar os dados no banco
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
