using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNETWebAPI_Course.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNETWebAPI_Course.Data
{
	public class AppDbContext : DbContext//Базовый класс, который позволяет связать C# модели с SQL сервером
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
			
		}


		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Описание отношения Many to many FluentAPI
			modelBuilder.Entity<Book_Author>()
				.HasOne(b => b.Book)
				.WithMany(ba => ba.Book_Authors)
				.HasForeignKey(bi => bi.BookId);

			modelBuilder.Entity<Book_Author>()
				.HasOne(b => b.Author)
				.WithMany(ba => ba.Book_Authors)
				.HasForeignKey(bi => bi.AuthorId);
		}

		public DbSet<Book> Books { get; set; }
		public DbSet<Publisher> Publishers { get; set; }
		public DbSet<Author> Authors { get; set; }
		public DbSet<Book_Author> Books_Authors { get; set; }
	}
}
