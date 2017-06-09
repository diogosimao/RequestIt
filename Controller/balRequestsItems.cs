using Model;
using System.Collections.Generic;

namespace Controller
{
    public class balRequestsItems
    {
        private dalRequestsItems requestItem { get; set; }

        public balRequestsItems()
        {
            requestItem = new dalRequestsItems();
        }
        public bool Save(bool Insert, RequestsItem obj)
        {
            return requestItem.Save(Insert, obj);
        }
        public bool Delete(RequestsItem obj)
        {
            return requestItem.Delete(obj);
        }
        public RequestsItem Search(int id)
        {
            return requestItem.Search(id);
        }
        public RequestsItem SearchRequestItem(int requestId, int productId)
        {
            return requestItem.SearchRequestItem(requestId, productId);
        }
        public List<RequestsItem> SearchAll()
        {
            return requestItem.SearchAll();
        }
        public List<RequestsItem> SearchByRequestId(int requestId)
        {
            return requestItem.SearchByRequestId(requestId);
        }
    }
}
