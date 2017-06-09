using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class balRequests
    {
        private dalRequests request { get; set; }

        public balRequests()
        {
            request = new dalRequests();
        }
        public bool Save(bool Insert, Request obj)
        {
            if (string.IsNullOrEmpty(obj.employeeName))
                throw new Exception("Campo nome do funcionário: preenchimento obrigatório.");

            return request.Save(Insert, obj);
        }
        public bool Delete(Request obj)
        {
            return request.Delete(obj);
        }
        public Request Search(int id)
        {
            return request.Search(id);
        }
        public List<Request> SearchAll()
        {
            return request.SearchAll();
        }
        public List<Request> Search(string employeeName)
        {
            return request.Search(employeeName);
        }
    }
}
