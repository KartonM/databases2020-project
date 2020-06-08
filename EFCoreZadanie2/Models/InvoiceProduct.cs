namespace FruitAndVegetableWarehouseManagement.Models
{
    public class InvoiceProduct
    {
        public int InvoiceID { get; set; }
        public Invoice Invoice { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int Kilograms { get; set; }

        public decimal Amount() => Product.PricePerKg * Kilograms;
    }
}
