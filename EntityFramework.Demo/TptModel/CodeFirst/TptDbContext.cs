using System;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Demo.TptModel.CodeFirst
{
	public class TptDbContext : DbContext
	{
		public DbSet<PersonTpt> People { get; set; }
		public DbSet<CustomerTpt> Customers { get; set; }
		public DbSet<EmployeeTpt> Employees { get; set; }

		public TptDbContext(DbContextOptions<TptDbContext> options)
			: base(options)
		{
		}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:deme-databases.database.windows.net,1433;Initial Catalog=AdvantureWorks;Persist Security Info=False;User ID=sqladmin;Password=P@$$w0rd;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
        public void SeedData()
		{
			DeleteAll();

			Customers.Add(new CustomerTpt()
								{
									Person = new PersonTpt()
												{
													Id = Guid.NewGuid(),
													FirstName = "John",
													LastName = "Foo"
												},
									DateOfBirth = new DateTime(1980, 1, 1)
								});

			Employees.Add(new EmployeeTpt()
								{
									Person = new PersonTpt()
												{
													Id = Guid.NewGuid(),
													FirstName = "Max",
													LastName = "Bar"
												},
									Turnover = 1000
								});

			SaveChanges();
		}

		private void DeleteAll()
		{
			Customers.RemoveRange(Customers);
			Employees.RemoveRange(Employees);
			People.RemoveRange(People);

			SaveChanges();
		}
	}
}
