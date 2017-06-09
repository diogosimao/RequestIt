using System;
using System.Collections.Generic;
using Model;

namespace Controller
{
    public class balCompoundProducts
    {
        private dalCompoundProducts compoundProduct { get; set; }

        public balCompoundProducts()
        {
            compoundProduct = new dalCompoundProducts();
        }
        public bool Save(bool Insert, CompoundProduct obj)
        {
            if (string.IsNullOrEmpty(obj.quantity.ToString()))
                throw new Exception("Campo quantidade do produto: preenchimento obrigatório.");
            if (obj.quantity <= 0)
                throw new Exception("Campo quantidade do produto: valor deve ser maior que zero.");

            return compoundProduct.Save(Insert, obj);
        }
        public bool Delete(CompoundProduct obj)
        {
            return compoundProduct.Delete(obj);
        }
        public CompoundProduct Search(int id)
        {
            return compoundProduct.Search(id);
        }
        public CompoundProduct SearchCompound(int productId, int compoundProductId)
        {
            return compoundProduct.SearchCompound(productId, compoundProductId);
        }
        public CompoundProduct SearchProductItemOfCompoundProduct(int productId)
        {
            return compoundProduct.SearchProductItemOfCompoundProduct(productId);
        }
        public List<CompoundProduct> SearchAll()
        {
            return compoundProduct.SearchAll();
        }
        public List<CompoundProduct> Search(string description)
        {
            return compoundProduct.Search(description);
        }
    }
}
