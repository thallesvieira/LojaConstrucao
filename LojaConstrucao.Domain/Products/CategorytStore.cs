using System;

namespace LojaConstrucao.Domain
{
    public class CategorytStore
    {
        private readonly IRepository<Category> _categoryRepository;
        
        public CategorytStore(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public void Store(int id, string name)
        {
            var category =  id != 0 ?_categoryRepository.GetById(id): null;
            if (category == null)
            {
                category = new Category(name);
                _categoryRepository.Save(category);
            }
            else
            {
                category.Update(name);
            }
        }
    }
}
