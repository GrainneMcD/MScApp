using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MScApp.Core;

namespace MScApp
{
    public class MScAppDbContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<AnswerAttempt> AnswerAttempts { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<QuestionTest> QuestionTests { get; set; }
        public DbSet<AppUserTest> AppUserTests { get; set; }
        public DbSet<TestAttempt> TestAttempts { get; set; }

        public MScAppDbContext(DbContextOptions<MScAppDbContext> options)
            : base(options)
        {

        }
        public MScAppDbContext()
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);


            builder.Entity<QuestionTest>().HasKey(qt => new { qt.QuestionID, qt.TestID });

            builder.Entity<AppUserTest>().HasKey(at => new { at.AppUserID, at.TestID });

            builder.Entity<AppUser>(b =>
            {
                b.ToTable("AppUsers");
            });

            builder.Entity<IdentityUserClaim<string>>(b =>
            {
                b.ToTable("AppUserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(b =>
            {
                b.ToTable("AppUserLogins");
            });

            builder.Entity<IdentityUserToken<string>>(b =>
            {
                b.ToTable("AppUserTokens");
            });

            builder.Entity<IdentityRole>(b =>
            {
                b.ToTable("AppRoles");
            });

            builder.Entity<IdentityRoleClaim<string>>(b =>
            {
                b.ToTable("AppRoleClaims");
            });

            builder.Entity<IdentityUserRole<string>>(b =>
             {
                 b.ToTable("AppUserRoles");
             });
        }
    }
}

