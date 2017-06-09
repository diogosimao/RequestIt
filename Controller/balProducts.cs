using System;
using System.Collections.Generic;
using Model;

namespace Controller
{
    public class balProducts
    {
        private dalProducts product { get; set; }

        public balProducts()
        {
            product = new dalProducts();
        }
        public bool Save(bool Insert, Product obj)
        {
            if (string.IsNullOrEmpty(obj.name))
                throw new Exception("Campo nome do produto: preenchimento obrigatório.");
            if (obj.salePrice <= 0)
                throw new Exception("Campo preço de venda do produto: valor deve ser maior que zero.");
            if (obj.costPrice <= 0)
                throw new Exception("Campo preço de custo do produto: valor deve ser maior que zero.");

            return product.Save(Insert, obj);
        }
        public bool Delete(Product obj)
        {
            return product.Delete(obj);
        }
        public Product Search(int id)
        {
            return product.Search(id);
        }
        public List<Product> SearchAll()
        {
            return product.SearchAll();
        }
        public List<Product> Search(string description)
        {
            return product.Search(description);
        }
    }
}
