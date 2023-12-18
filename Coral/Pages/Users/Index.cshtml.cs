using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coral.Data;
using Coral.Models;

namespace Coral.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly Coral.Data.CoralContext _context;

        public IndexModel(Coral.Data.CoralContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; } = default!;

        public async Task OnGetAsync()
        {
            User = await _context.User.ToListAsync();
        }
    }
}
