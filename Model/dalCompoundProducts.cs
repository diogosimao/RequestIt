using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Model
{
    public class dalCompoundProducts : BaseClass<CompoundProduct>
    {
        public override bool Save(bool Insert, CompoundProduct obj)
        {
            using (RequestItEntities db = new RequestItEntities())
            {
                if (Insert)
                    db.CompoundProducts.Add(obj);
                else
                {
                    db.CompoundProducts.Attach(obj);
                    db.Entry(obj).State = EntityState.Modified;
                }
                return (db.SaveChanges() > 0);
            }
        }

        public override bool Delete(CompoundProduct obj)
        {
            using (RequestItEntities db = new RequestItEntities())
            {
                CompoundProduct compoundProduct = (from cp in db.CompoundProducts
                                                   where cp.id == obj.id
                                                   select cp).FirstOrDefault();
                db.CompoundProducts.Remove(compoundProduct);
                return (db.SaveChanges() > 0);
            }
        }

        public override CompoundProduct Search(int id)
        {
            using (RequestItEntities db = new RequestItEntities())
            {
                var cpc =  (from cp in db.CompoundProducts
                        where cp.id == id
                        join p in db.Products
                        on cp.productId equals p.id
                        select cp).FirstOrDefault();
                return cpc;
            }
        }

        public CompoundProduct SearchCompound(int productId, int compoundProductId)
        {
            using (RequestItEntities db = new RequestItEntities())
            {
                var cpc = (from cp in db.CompoundProducts
                           where (cp.compoundProductId == compoundProductId) && (cp.productId == productId)
                           select cp).FirstOrDefault();
                return cpc;
            }
        }

        public override List<CompoundProduct> SearchAll()
        {
            using (RequestItEntities db = new RequestItEntities())
            {
                return db.CompoundProducts.ToList();
            }
        }
    }
}
