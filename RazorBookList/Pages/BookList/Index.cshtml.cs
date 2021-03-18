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
    public class IndexModel : PageModel
    {
        // Esse index é um diferente do outro index de Pages
        private readonly ApplicationDbContext _db;

        // Construtor,   esse applicationDbContext iremos pegar usando dependency injection
        public IndexModel(ApplicationDbContext db)
        {
            _db = db; // Sem o dependency injection você teria que criar um novo objeto
        }

        public IEnumerable<Book> Books { get; set; }

        public async Task OnGet() // Usar async task quando usar async
        {
            Books = await _db.Book.ToListAsync();
        }
    }
}
