using Coral.Data;
using Microsoft.EntityFrameworkCore;

namespace Coral.Models {
    public class SeedData {

        public static void Initialize(IServiceProvider serviceProvider) {
            using var context = new CoralContext(serviceProvider.GetRequiredService<DbContextOptions<CoralContext>>());
            context.Database.EnsureCreated();

            // Look for any movies.
            if (context.Account.Any()) {
                return;   // DB has been seeded
            }
            context.Add(new Account() {
                UserName = "JackChoo",
                CreationTime = DateTime.Now,
                Email = "zhuye0213@icloud.com",
                Phone = "13800000121",
                Inviter = "无",
                Note = "管理员",
                Salt = Guid.NewGuid().ToString("N"),
                Password = "123456"
            });
            context.SaveChanges();
        }
    }
}
