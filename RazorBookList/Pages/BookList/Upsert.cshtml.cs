using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorBookList.Models;

namespace RazorBookList.Pages.BookList
{
    public class UpsertModel : PageModel
    {
        private ApplicationDbContext _db;

        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }
        public async Task<IActionResult> OnGet(int? Id) //Nullable para o id ser opcional na recepção do parametro
        {
            Book = new Book();
            if (Id == null)
            {
                // Criação
                return Page();
            }

            //Usado para update
            Book = await _db.Book.FirstOrDefaultAsync(u => u.Id == Id); //Se o id for not null vamos ter que pegar o livro da db
            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }

        // Post handler
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Book.Id == 0)
                {
                    _db.Book.Update(Book); // O update é usado para dar um update em toda propriedade do item
                }
                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
