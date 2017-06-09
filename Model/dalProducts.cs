using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class dalProducts: BaseClass<Product>
    {
        public override bool Save(bool Insert, Product obj)
        {
            using (RequestItEntities db = new RequestItEntities())
            {
                if (Insert)
                    db.Products.Add(obj);
                else
                {
                    db.Products.Attach(obj);
                    db.Entry(obj).State = EntityState.Modified;
                }
                return (db.SaveChanges() > 0);
            }
        }

        public override bool Delete(Product obj)
        {
            using (RequestItEntities db = new RequestItEntities())
            {
                Product product = (from p in db.Products
                                   where p.id == obj.id
                                   select p).FirstOrDefault();
                db.Products.Remove(product);
                return (db.SaveChanges() > 0);
            }
        }

        public override Product Search(int id)
        {
            using (RequestItEntities db = new RequestItEntities())
            {
                var products = (from product in db.Products
                                where product.id == id
                                select product).Include(cp => cp.CompoundProducts).FirstOrDefault();
                return products;
            }
        }

        public override List<Product> SearchAll()
        {
            using (RequestItEntities db = new RequestItEntities())
            {
                return db.Products.ToList();
            }
        }

        public override List<Product> Search(string description)
        {
            using (RequestItEntities db = new RequestItEntities())
            {
                if (description != "")
                {
                    return (from p in db.Products
                            where p.name.ToUpper().Contains(description.ToUpper())
                            select p).ToList();
                }
                else
                {
                    return SearchAll();
                }
            }
        }
    }
}
