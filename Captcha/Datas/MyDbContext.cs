using Microsoft.EntityFrameworkCore;

namespace Captcha.Datas
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }
        #region
        public DbSet<TT> TTs { get; set; }
        #endregion
    }
}
