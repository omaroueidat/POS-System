using Entities.Models.SuperMarketModels;
using Entities.Models.EmployeeModels;
using Entities.Models.CustomerModels;
using Entities.Models.InvoiceModels;
using Entities.Models.ProductModels;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace Entities.Database_Context
{
    public class AppDbContext : IdentityDbContext<SuperMarket,IdentityRole<Guid>,Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<SuperMarket> SuperMarkets { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeePasscode> EmployeePasscodes { get; set; }
        public DbSet<EmployeeLog> EmployeeLogs { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetailss { get; set; }
        public DbSet<CustomerInvoice> CustomerInvoices { get; set; }
        public DbSet<SalesHistory> SalesHistories { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SuperMarket>().Property(e => e.Id).HasDefaultValueSql("NEWID()");

            // Set the Foriegn Keys
            modelBuilder.Entity<Employee>()
                .HasOne<SuperMarket>()
                .WithMany(s => s.Employees)
                .HasForeignKey(e => e.SupermarketId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmployeeLog>()
                .HasOne<Employee>()
                .WithMany(e => e.EmployeeLogs)
                .HasForeignKey(el => el.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmployeePasscode>()
                .HasOne<Employee>()
                .WithOne(e => e.EmployeePasscode)
                .HasForeignKey<EmployeePasscode>(code => code.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<InvoiceDetails>()
                .HasOne<Invoice>()
                .WithMany(i => i.InvoiceDetails)
                .HasForeignKey(id => id.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);

            // Set the table names
            modelBuilder.Entity<SuperMarket>().ToTable(nameof(SuperMarket));

            modelBuilder.Entity<Employee>().ToTable(nameof(Employee));

            modelBuilder.Entity<EmployeePasscode>().ToTable(nameof(EmployeePasscode));

            modelBuilder.Entity<EmployeeLog>().ToTable(nameof(EmployeeLog));

            modelBuilder.Entity<Customer>().ToTable(nameof(Customer));

            modelBuilder.Entity<Invoice>().ToTable(nameof(Invoice));

            modelBuilder.Entity<Product>().ToTable(nameof(Product));

            modelBuilder.Entity<InvoiceDetails>().ToTable(nameof(InvoiceDetails));

            modelBuilder.Entity<CustomerInvoice>().ToTable(nameof(CustomerInvoice));

            modelBuilder.Entity<SalesHistory>().ToTable(nameof(SalesHistory));

            modelBuilder.Entity<Stock>().ToTable(nameof(Stock));


            // Seeding Data to the Database

            // Seed Supermarkets
            string supermarketJson = System.IO.File.ReadAllText("DummyData/Supermarket.json");
            List<SuperMarket>? supermarkets = System.Text.Json.JsonSerializer.Deserialize<List<SuperMarket>>(supermarketJson);

            foreach (var supermarket in supermarkets)
            {
                modelBuilder.Entity<SuperMarket>().HasData(supermarket);
            }

            // Seed Employees
            string employeeJson = System.IO.File.ReadAllText("DummyData/Employee.json");
            List<Employee>? employees = System.Text.Json.JsonSerializer.Deserialize<List<Employee>>(employeeJson);
            
            foreach (var employee in employees)
            {
                modelBuilder.Entity<Employee>().HasData(employee);
            }

            // Seed EmployeePassCodes
            string codeJson = System.IO.File.ReadAllText("DummyData/EmployeePassCode.json");
            List<EmployeePasscode>? codes = System.Text.Json.JsonSerializer.Deserialize<List<EmployeePasscode>>(codeJson);
            foreach (var code in codes)
            {
                modelBuilder.Entity<EmployeePasscode>().HasData(code);
            }

            // Seed Customers
            string customerJson = System.IO.File.ReadAllText("DummyData/Customer.json");
            List<Customer>? customers = System.Text.Json.JsonSerializer.Deserialize<List<Customer>>(customerJson);
            foreach (var customer in customers)
            {
                modelBuilder.Entity<Customer>().HasData(customer);
            }

            // Seed Invoices
            string invoiceJson = System.IO.File.ReadAllText("DummyData/Invoice.json");
            List<Invoice>? invoices = System.Text.Json.JsonSerializer.Deserialize<List<Invoice>>(invoiceJson);
            foreach (var invoice in invoices)
            {
                modelBuilder.Entity<Invoice>().HasData(invoice);
            }

            // Seed Products
            string productJson = System.IO.File.ReadAllText("DummyData/Product.json");
            List<Product>? products = System.Text.Json.JsonSerializer.Deserialize<List<Product>>(productJson);
            foreach (var product in products)
            {
                modelBuilder.Entity<Product>().HasData(product);
            }

            // Seed Stocks
            string stockJson = System.IO.File.ReadAllText("DummyData/Stock.json");
            List<Stock>? stocks = System.Text.Json.JsonSerializer.Deserialize<List<Stock>>(stockJson);
            foreach (var stock in stocks)
            {
                modelBuilder.Entity<Stock>().HasData(stock);
            }


            // Seed EmployeeLogs
            string employeeLogJson = System.IO.File.ReadAllText("DummyData/EmployeeLog.json");
            List<EmployeeLog>? employeeLogs = System.Text.Json.JsonSerializer.Deserialize<List<EmployeeLog>>(employeeLogJson);
            foreach (var employeeLog in employeeLogs)
            {
                modelBuilder.Entity<EmployeeLog>().HasData(employeeLog);
            }

            // Seed CustomerInvoices
            string customerInvoiceJson = System.IO.File.ReadAllText("DummyData/CustomerInvoice.json");
            List<CustomerInvoice>? customerInvoices = System.Text.Json.JsonSerializer.Deserialize<List<CustomerInvoice>>(customerInvoiceJson);
            foreach (var customerInvoice in customerInvoices)
            {
                modelBuilder.Entity<CustomerInvoice>().HasData(customerInvoice);
            }

        }


    }
}
