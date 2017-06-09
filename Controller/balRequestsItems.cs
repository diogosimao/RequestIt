using System.Collections.Generic;
using Model;

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
        public bool DeleteByRequestId(int requestId)
        {
            return requestItem.DeleteByRequestId(requestId);
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
        public RequestsItem SearchProductItemOfRequestItem(int productId)
        {
            return requestItem.SearchProductItemOfRequestItem(productId);
        }
    }
}
