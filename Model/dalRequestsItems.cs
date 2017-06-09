using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Model
{
    public class dalRequestsItems : BaseClass<RequestsItem>
    {
        public override bool Save(bool Insert, RequestsItem obj)
        {
            using (RequestItEntities db = new RequestItEntities())
            {
                if (Insert)
                    db.RequestsItems.Add(obj);
                else
                {
                    db.RequestsItems.Attach(obj);
                    db.Entry(obj).State = EntityState.Modified;
                }
                return (db.SaveChanges() > 0);
            }
        }

        public override bool Delete(RequestsItem obj)
        {
            using (RequestItEntities db = new RequestItEntities())
            {
                RequestsItem requestItem = (from p in db.RequestsItems
                                            where p.id == obj.id
                                            select p).FirstOrDefault();
                db.RequestsItems.Remove(requestItem);
                return (db.SaveChanges() > 0);
            }
        }

        public override RequestsItem Search(int id)
        {
            using (RequestItEntities db = new RequestItEntities())
            {
                var request = (from requests in db.RequestsItems
                               where requests.id == id
                               select requests).FirstOrDefault();
                return request;
            }
        }

        public RequestsItem SearchRequestItem(int requestId, int productId)
        {
            using (RequestItEntities db = new RequestItEntities())
            {
                var request = (from ri in db.RequestsItems
                               where ri.requestId == requestId && ri.productId == productId
                               select ri).FirstOrDefault();
                return request;
            }
        }

        public override List<RequestsItem> SearchAll()
        {
            using (RequestItEntities db = new RequestItEntities())
            {
                return db.RequestsItems.ToList();
            }
        }
        public List<RequestsItem> SearchByRequestId(int requestId)
        {
            using (RequestItEntities db = new RequestItEntities())
            {
                var request = (from ri in db.RequestsItems
                               where ri.requestId == requestId 
                               select ri).ToList();
                return request;
            }
        }
    }
}