using System;

namespace LojaConstrucao.Domain.Products
{
    public class ProductStore
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Product> _productRepository;

        public ProductStore(IRepository<Product> productRepository, IRepository<Category> categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }
        public void Store(int id, string name, int categoryId, decimal price, int StockQuantity)
        {
            var category = _categoryRepository.GetById(categoryId);
            DomainException.When(category == null, "Category invalid");

            var product = _productRepository.GetById(id);
            if (product == null)
            {
                product = new Product(name, category, price, StockQuantity);
                _productRepository.Save(product);
            }
            else
                product.Update(name, category, price, StockQuantity);
        }
    }
}
