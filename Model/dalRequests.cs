using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class dalRequests : BaseClass<Request>
    {
        public override bool Save(bool Insert, Request obj)
        {
            using (RequestItEntities db = new RequestItEntities())
            {
                if (Insert)
                    db.Requests.Add(obj);
                else
                {
                    db.Requests.Attach(obj);
                    db.Entry(obj).State = EntityState.Modified;
                }
                return (db.SaveChanges() > 0);
            }
        }

        public override bool Delete(Request obj)
        {
            using (RequestItEntities db = new RequestItEntities())
            {
                Request product = (from r in db.Requests
                                   where r.id == obj.id
                                   select r).FirstOrDefault();
                db.Requests.Remove(product);
                return (db.SaveChanges() > 0);
            }
        }

        public override Request Search(int id)
        {
            using (RequestItEntities db = new RequestItEntities())
            {
                var request = (from requests in db.Requests
                                where requests.id == id
                                select requests).FirstOrDefault();
                return request;
            }
        }

        public override List<Request> SearchAll()
        {
            using (RequestItEntities db = new RequestItEntities())
            {
                return db.Requests.ToList();
            }
        }

        public override List<Request> Search(string employeeName)
        {
            using (RequestItEntities db = new RequestItEntities())
            {
                if (employeeName != "")
                {
                    return (from r in db.Requests
                            where r.employeeName.ToUpper().Contains(employeeName.ToUpper())
                            select r).ToList();
                }
                else
                {
                    return SearchAll();
                }
            }
        }
    }
}
