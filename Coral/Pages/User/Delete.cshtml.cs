using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coral.Data;
using Coral.Models;

namespace Coral.Pages.User
{
    public class DeleteModel : PageModel
    {
        private readonly Coral.Data.CoralContext _context;

        public DeleteModel(Coral.Data.CoralContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Account Account { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Account.FirstOrDefaultAsync(m => m.Id == id);

            if (account == null)
            {
                return NotFound();
            }
            else
            {
                Account = account;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Account.FindAsync(id);
            if (account != null)
            {
                Account = account;
                _context.Account.Remove(Account);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
