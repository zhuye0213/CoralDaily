using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Coral.Models;

namespace Coral.Data {
    public class CoralContext(DbContextOptions<CoralContext> options) : DbContext(options) {
        public DbSet<Coral.Models.User> User { get; set; } = default!;
    }
}
