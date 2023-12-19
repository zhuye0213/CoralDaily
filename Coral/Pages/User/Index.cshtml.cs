using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Coral.Data;
using Coral.Models;
using AutoMapper;

namespace Coral.Pages.User {
    public class IndexModel(CoralContext context, IMapper mapper) : PageModel {
        private readonly Coral.Data.CoralContext _context = context;

        public IList<AccountVm> AccountVm { get; set; } = default!;

        public async Task OnGetAsync() {

            AccountVm = await _context.Account.Select(p => mapper.Map<AccountVm>(p)).ToListAsync();
        }
    }
}
