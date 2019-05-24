using Microsoft.EntityFrameworkCore;
using System;
using WebApi.Entities;

namespace WebApi.Context {
    public class WebApiContext : DbContext {
        public DbSet<Book> Book { get; set; }

        public WebApiContext(DbContextOptions<WebApiContext> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Author>().HasData(
                new Author() {
                    Id = 1,
                    Birthday = DateTime.Now - TimeSpan.FromDays(365 * 50),
                    FirstName = "Fake",
                    LastName = "Author",
                    DateOfDeath = DateTime.Now - TimeSpan.FromDays(365 - 1)
                });
            modelBuilder.Entity<Book>().HasData(new Book() {
                Id = 1,
                Title = "Misterious Mr. Crazy",
                Description = "The book represents a series of murders and homicides that have been made by some misterious Guy named Mr. Crazy" +
                   "and calls the attention of two young investigators named Tommy and Tuppence who try to stop him",
                AuthorId = 1
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}