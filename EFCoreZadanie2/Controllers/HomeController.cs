using System;
using System.Diagnostics;
using System.Linq;
using FruitAndVegetableWarehouseManagement.Data;
using FruitAndVegetableWarehouseManagement.Models;
using FruitAndVegetableWarehouseManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FruitAndVegetableWarehouseManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repo;

        public HomeController(IRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Suppliers()
        {
            return View(_repo.Suppliers());
        }

        [HttpGet]
        public IActionResult AddSupplier()
        {
            return View(new AddSupplierViewModel());
        }

        [HttpPost]
        public IActionResult AddSupplier(AddSupplierViewModel model)
        {
            var newSupplier = new Supplier()
            {
                CompanyName = model.CompanyName,
                BankAccountNumber = model.BankAccountNumber,
                Street = model.Street,
                ZipCode = model.ZipCode,
                City = model.City
            };
            _repo.AddSupplier(newSupplier);

            return RedirectToAction("Suppliers");
        }

        public IActionResult Customers()
        {
            return View(_repo.CustomersWithInvoices());
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View(new AddCustomerViewModel() {DiscountPercentage = 0});
        }

        [HttpPost]
        public IActionResult AddCustomer(AddCustomerViewModel model)
        {
            var customer = new Customer()
            {
                CompanyName = model.CompanyName,
                DiscountPercentage = model.DiscountPercentage,
                Street = model.Street,
                ZipCode = model.ZipCode,
                City = model.City
            };
            _repo.AddCustomer(customer);

            return RedirectToAction("Customers");
        }

        public IActionResult Invoices()
        {
            return View(_repo.Invoices());
        }

        [HttpGet]
        public IActionResult AddInvoice()
        {
            return View(new AddInvoiceViewModel()
            {
                Customers = _repo.Customers()
            });
        }

        [HttpPost]
        public IActionResult AddInvoice(AddInvoiceViewModel model)
        {
            var customer = _repo.GetCustomerById(model.CustomerId);

            var newInvoice = new Invoice()
            {
                Customer = customer,
                InvoiceNumber = model.InvoiceNumber,
                Date = DateTime.Now
            };

            _repo.AddInvoice(newInvoice);

            return RedirectToAction("InvoiceDetails", new {invoiceId = newInvoice.InvoiceID});
        }

        public IActionResult InvoiceDetails(int invoiceId)
        {
            return View(_repo.GetInvoiceById(invoiceId));
        }

        [HttpGet]
        public IActionResult AddInvoiceProduct(int invoiceId)
        {
            return View(new AddInvoiceProductViewModel()
            {
                Invoice = _repo.GetInvoiceById(invoiceId),
                Products = _repo.Products()
            });
        }

        [HttpPost]
        public IActionResult AddInvoiceProduct(AddInvoiceProductViewModel model)
        {
            var invoice = _repo.GetInvoiceById(model.InvoiceId);
            var product = _repo.GetProductById(model.ProductId);

            if (product.KgsInStock < model.Kilograms)
            {
                ModelState.AddModelError("", $"W magazynie zostało {product.KgsInStock} sztuk produktu {product.Name}");
                model.Invoice = invoice;
                model.Products = _repo.Products();
                return View(model);
            }

            invoice.InvoiceProducts.Add(new InvoiceProduct()
            {
                ProductID = model.ProductId,
                Kilograms = model.Kilograms
            });

            product.KgsInStock -= model.Kilograms;

            _repo.UpdateInvoice(invoice);
            _repo.UpdateProduct(product);

            return RedirectToAction("InvoiceDetails", new {invoiceId = model.InvoiceId});
        }

        public IActionResult Categories()
        {
            return View(_repo.Categories());
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View(new AddCategoryViewModel());
        }

        [HttpPost]
        public IActionResult AddCategory(AddCategoryViewModel model)
        {
            var newCategory = new Category()
            {
                Name = model.Name
            };
            _repo.AddCategory(newCategory);

            return RedirectToAction("Categories");
        }

        public IActionResult Products()
        {
            return View(_repo.Products());
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View(new AddProductViewModel()
            {
                Categories = _repo.Categories(),
                Suppliers = _repo.Suppliers()
            });
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductViewModel model)
        {
            var category = _repo.GetCategoryById(model.CategoryId);
            var supplier = _repo.GetSupplierById(model.SupplierId);

            var newProduct = new Product()
            {
                Name = model.Name,
                SellingPricePerKg = model.SellingPricePerKg,
                BuyingPricePerKg = model.BuyingPricePerKg,
                KgsInStock = 0,
                Category = category,
                Supplier = supplier
            };

            _repo.AddProduct(newProduct);

            return RedirectToAction("Products");
        }

        public IActionResult Stats()
        {
            var monthlySales = _repo.InvoicesFromLastNDays(30).Sum(i => i.Amount());
            var monthlySupplyCosts = _repo.SuppliesFromLastNDays(30).Sum(s => s.Cost());

            var weeklySales = _repo.InvoicesFromLastNDays(7).Sum(i => i.Amount());
            var weeklySupplyCosts = _repo.SuppliesFromLastNDays(7).Sum(s => s.Cost());

            return View(new StatsViewModel()
            {
                MonthlyBalance = monthlySales - monthlySupplyCosts,
                MonthlyBestCustomers = _repo.TopCustomersWithAmountsFromLast(30, 3),
                WeeklyBalance = weeklySales - weeklySupplyCosts,
                WeeklyBestCustomers = _repo.TopCustomersWithAmountsFromLast(7, 3),
                MostUnitsInStock = _repo.TopProductsWithMostKilogramsInStock(3),
                SuppliersWithProductsRunOutOfStock = _repo.SuppliersWithProductsRunOutOfStock(),
                MaxValueOfStockProducts = _repo.MaxValueOfProductsOnStock()
            });
        }

        public IActionResult AddSupply(int supplierId)
        {
            var supplier = _repo.GetSupplierById(supplierId);

            var supply = new Supply()
            {
                Supplier = supplier,
                Date = DateTime.Now
            };

            _repo.AddSupply(supply);

            return RedirectToAction("SupplyDetails", new {supplyId = supply.SupplyId});
        }

        public IActionResult SupplyDetails(int supplyId)
        {
            return View(_repo.GetSupplyById(supplyId));
        }

        [HttpGet]
        public IActionResult AddSupplyProduct(int supplyId)
        {
            return View(new AddSupplyProductViewModel()
            {
                Supply = _repo.GetSupplyById(supplyId)
            });
        }

        [HttpPost]
        public IActionResult AddSupplyProduct(AddSupplyProductViewModel model)
        {
            var supply = _repo.GetSupplyById(model.SupplyId);
            var product = _repo.GetProductById(model.ProductId);


            supply.SupplyProducts.Add(new SupplyProduct()
            {
                ProductId = model.ProductId,
                Kilograms = model.Kilograms
            });

            product.KgsInStock += model.Kilograms;

            _repo.UpdateSupply(supply);
            _repo.UpdateProduct(product);

            return RedirectToAction("SupplyDetails", new {supplyId = supply.SupplyId});
        }

        public IActionResult Supplies()
        {
            return View(_repo.Supplies());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
