using System;

namespace LojaConstrucao.Domain
{
    public class ProductDTO
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int idCategory { get; private set; }
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }


    }
}
