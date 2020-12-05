using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Muntean_Oana_Lab8.Data;
using Muntean_Oana_Lab8.Models;

namespace Muntean_Oana_Lab8.Pages.Books
{
    public class EditModel : BookCategoriesPageModel
    {
        private readonly Muntean_Oana_Lab8.Data.Muntean_Oana_Lab8Context _context;

        public EditModel(Muntean_Oana_Lab8.Data.Muntean_Oana_Lab8Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.BookCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Book == null)
            {
                return NotFound();
            }
            //apelam PopulateAssignedCategoryData pentru a obtine informatiile necesare check-boxurilor folosind clasa AssignedCategorydata
            PopulateAssignedCategoryData(_context, Book);
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            return Page();
        }
    }
}