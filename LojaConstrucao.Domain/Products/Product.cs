using System;

namespace LojaConstrucao.Domain
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public Category Category { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }

        public Product(string aName, Category aCategory, decimal aPrice, int aStockQuantity)
        {
            ValidadeValues(aName, aCategory, aPrice, aStockQuantity);
            SetProperties(aName, aCategory, aPrice, aStockQuantity);
        }

        public void Update(string aName, Category aCategory, decimal aPrice, int aStockQuantity)
        {
            ValidadeValues(aName, aCategory, aPrice, aStockQuantity);
            SetProperties(aName, aCategory, aPrice, aStockQuantity);
        }

        private void SetProperties(string aName, Category aCategory, decimal aPrice, int aStockQuantity)
        {
            Name = aName;
            Category = aCategory;
            Price = aPrice;
            StockQuantity = aStockQuantity;
        }

        private static void ValidadeValues(string aName, Category aCategory, decimal aPrice, int aStockQuantity)
        {
            DomainException.When(string.IsNullOrEmpty(aName), "Nome é requerido");
            DomainException.When(aCategory == null, "Categoria é requerida");
            DomainException.When(aPrice < 0, "Preço não pode ser menor do que 0");
            DomainException.When(aStockQuantity < 0, "Estoque não pode ser negativo");
        }
    }
}
