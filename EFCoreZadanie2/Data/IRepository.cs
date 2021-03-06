﻿using System.Collections.Generic;
using FruitAndVegetableWarehouseManagement.Models;

namespace FruitAndVegetableWarehouseManagement.Data
{
    public interface IRepository
    {
        IEnumerable<Category> Categories();
        void AddCategory(Category category);
        Category GetCategoryById(int categoryId);

        IEnumerable<Supplier> Suppliers();
        void AddSupplier(Supplier supplier);
        Supplier GetSupplierById(int supplierId);

        IEnumerable<Customer> Customers();
        IEnumerable<Customer> CustomersWithInvoices();
        void AddCustomer(Customer customer);
        Customer GetCustomerById(int customerId);

        IEnumerable<Product> Products();
        Product GetProductById(int productId);
        void AddProduct(Product product);
        void UpdateProduct(Product product);

        IEnumerable<Invoice> Invoices();
        void AddInvoice(Invoice invoice);
        void UpdateInvoice(Invoice invoice);
        Invoice GetInvoiceById(int invoiceId);
        IEnumerable<Invoice> InvoicesFromLastNDays(int days);

        IEnumerable<Supply> Supplies();
        void AddSupply(Supply supply);
        void UpdateSupply(Supply supply);
        Supply GetSupplyById(int supplyId);
        IEnumerable<Supply> SuppliesFromLastNDays(int days);

        IEnumerable<KeyValuePair<Customer, decimal>> TopCustomersWithAmountsFromLast(int days, int count);
        IEnumerable<Product> TopProductsWithMostKilogramsInStock(int count);
        IEnumerable<KeyValuePair<Supplier, IEnumerable<Product>>> SuppliersWithProductsRunOutOfStock();
        decimal MaxValueOfProductsOnStock();
    }
}
