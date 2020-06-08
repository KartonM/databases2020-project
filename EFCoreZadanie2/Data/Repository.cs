using System;
using System.Collections.Generic;
using System.Linq;
using FruitAndVegetableWarehouseManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace FruitAndVegetableWarehouseManagement.Data
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _db;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Category> Categories() => _db.Categories.AsEnumerable();
        public void AddCategory(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
        }

        public Category GetCategoryById(int categoryId) =>
            _db.Categories.FirstOrDefault(c => c.CategoryID == categoryId);

        public IEnumerable<Supplier> Suppliers() =>
            _db.Companies.OfType<Supplier>().Include(s => s.Products).AsEnumerable();

        public void AddSupplier(Supplier supplier)
        {
            _db.Companies.Add(supplier);
            _db.SaveChanges();
        }

        public Supplier GetSupplierById(int supplierId) =>
            _db.Companies.FirstOrDefault(c => c is Supplier && c.CompanyID == supplierId) as Supplier;

        public IEnumerable<Customer> Customers() =>
            _db.Companies.OfType<Customer>().AsEnumerable();

        public IEnumerable<Customer> CustomersWithInvoices() => _db.Companies.OfType<Customer>()
            .Include(c => c.Invoices)
            .ThenInclude(i => i.InvoiceProducts)
            .ThenInclude(ip => ip.Product)
            .AsEnumerable();

        public void AddCustomer(Customer customer)
        {
            _db.Companies.Add(customer);
            _db.SaveChanges();
        }

        public Customer GetCustomerById(int customerId) =>
            _db.Companies.FirstOrDefault(c => c is Customer && c.CompanyID == customerId) as Customer;

        public IEnumerable<Product> Products() =>
            _db.Products.Include(p => p.Supplier).Include(p => p.Category).Include(p => p.SupplyProducts)
                .ThenInclude(sp => sp.Supply).AsEnumerable();

        public Product GetProductById(int productId) =>
            _db.Products.Include(p => p.Supplier).FirstOrDefault(p => p.ProductID == productId);

        public void AddProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _db.Products.Update(product);
            _db.SaveChanges();
        }

        public IEnumerable<Invoice> Invoices() => _db.Invoices
            .Include(i => i.Customer)
            .Include(i => i.InvoiceProducts)
            .ThenInclude(ip => ip.Product).AsEnumerable();

        public void AddInvoice(Invoice invoice)
        {
            _db.Invoices.Add(invoice);
            _db.SaveChanges();
        }

        public void UpdateInvoice(Invoice invoice)
        {
            _db.Invoices.Update(invoice);
            _db.SaveChanges();
        }

        public Invoice GetInvoiceById(int invoiceId) => _db.Invoices
            .Include(i => i.Customer)
            .Include(i => i.InvoiceProducts)
            .ThenInclude(ip => ip.Product)
            .FirstOrDefault(i => i.InvoiceID == invoiceId);

        public IEnumerable<Invoice> InvoicesFromLastNDays(int days) =>
            _db.Invoices.Include(i => i.Customer).Include(i => i.InvoiceProducts).ThenInclude(ip => ip.Product)
                .Where(i => (DateTime.Now - i.Date).Days < days).AsEnumerable();

        public IEnumerable<Supply> Supplies() =>
            _db.Supplies.Include(s => s.Supplier).OrderByDescending(s => s.Date).AsEnumerable();

        public void AddSupply(Supply supply)
        {
            _db.Supplies.Add(supply);
            _db.SaveChanges();
        }

        public void UpdateSupply(Supply supply)
        {
            _db.Supplies.Update(supply);
            _db.SaveChanges();
        }

        public Supply GetSupplyById(int supplyId) => _db.Supplies.Include(s => s.SupplyProducts)
            .ThenInclude(sp => sp.Product).Include(s => s.Supplier).ThenInclude(s => s.Products)
            .FirstOrDefault(s => s.SupplyId == supplyId);

        public IEnumerable<Supply> SuppliesFromLastNDays(int days) =>
            _db.Supplies.Include(s => s.SupplyProducts).ThenInclude(s => s.Product)
                .Where(s => (DateTime.Now - s.Date).Days < days).AsEnumerable();

        public IEnumerable<KeyValuePair<Customer, decimal>> TopCustomersWithAmountsFromLast(int days, int count) => _db
            .Companies
            .OfType<Customer>()
            .Include(c => c.Invoices)
            .ThenInclude(i => i.InvoiceProducts)
            .ThenInclude(ip => ip.Product)
            .ToList()
            .Select(customer => new KeyValuePair<Customer, decimal>(
                customer,
                customer.Invoices.Where(i => (DateTime.Now - i.Date).Days < days).Sum(i => i.Amount())
            ))
            .OrderByDescending(pair => pair.Value)
            .Take(count)
            .ToList();

        public IEnumerable<Product> TopProductsWithMostKilogramsInStock(int count) =>
            _db.Products.OrderByDescending(p => p.KgsInStock).Take(count).ToList();

        public IEnumerable<KeyValuePair<Supplier, IEnumerable<Product>>> SuppliersWithProductsRunOutOfStock() => _db
            .Products
            .Include(p => p.Supplier)
            .Where(p => p.KgsInStock <= 0)
            .GroupBy(p => p.Supplier)
            .Select(grouping => new KeyValuePair<Supplier, IEnumerable<Product>>(
                grouping.Key,
                grouping.AsEnumerable()
            ))
            .ToList();

        public decimal MaxValueOfProductsOnStock() => _db
            .Products
            .Sum(p => p.SellingPricePerKg * p.KgsInStock);
    }
}
