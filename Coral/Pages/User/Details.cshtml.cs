﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly Coral.Data.CoralContext _context;

        public DetailsModel(Coral.Data.CoralContext context)
        {
            _context = context;
        }

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
    }
}
