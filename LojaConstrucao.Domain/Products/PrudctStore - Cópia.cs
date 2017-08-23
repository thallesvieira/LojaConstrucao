using System;

namespace LojaConstrucao.Domain
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
        public void Store(ProductDTO dto)
        {
            var category = _categoryRepository.GetById(dto.idCategory);
            DomainException.When(category == null, "Categoria inválida");

            var product = _productRepository.GetById(dto.Id);
        }
    }
}
