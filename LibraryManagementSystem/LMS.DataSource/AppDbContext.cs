using LMS.DataSource.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LMS.DataSource
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Author> Author { get; set; }
        public DbSet<BookDetail> BookDetail { get; set; }
        public DbSet<BookDetailAuthor> BookDetailAuthor { get; set; }
        public DbSet<BookIdentification> BookIdentification { get; set; }
        public DbSet<Borrowing> Borrowing { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Librarian> Librarian { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Shelve> Shelve { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<WishList> WishList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder build)
        {

<<<<<<< Updated upstream
            string SQLConnectionString = "Server=DESKTOP-1TKFKA1\\SQLEXPRESS;Database=LMSDatabase;Trusted_Connection=true";
=======
            string SQLConnectionString = "Server=DESKTOP-EK4IBKP;Database=LMSDatabase;Trusted_Connection=true";
>>>>>>> Stashed changes

            build.UseSqlServer(SQLConnectionString);

            base.OnConfiguring(build);
        }
    }
}
