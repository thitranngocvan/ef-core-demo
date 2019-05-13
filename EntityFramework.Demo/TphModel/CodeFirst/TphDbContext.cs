using System;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Demo.TphModel.CodeFirst
{
	public class TphDbContext : DbContext
	{
		public DbSet<PersonTph> People { get; set; }
		public DbSet<CustomerTph> Customers { get; set; }
		public DbSet<EmployeeTph> Employees { get; set; }

		public TphDbContext(DbContextOptions<TphDbContext> options)
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

			Customers.Add(new CustomerTph()
								{
									Id = Guid.NewGuid(),
									FirstName = "John",
									LastName = "Foo",
									DateOfBirth = new DateTime(1980, 1, 1)
								});

			Employees.Add(new EmployeeTph()
								{
									Id = Guid.NewGuid(),
									FirstName = "Max",
									LastName = "Bar",
									Turnover = 1000
								});

			SaveChanges();
		}

		private void DeleteAll()
		{
			Customers.RemoveRange(Customers);
			Employees.RemoveRange(Employees);

			SaveChanges();
		}
	}
}
