using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RequestIt
{
    public partial class frmRequests : frmBase
    {
        balProducts objProduct = new balProducts();
        balRequests objRequests = new balRequests();
        balRequestsItems objRequestsItem = new balRequestsItems();
        List<Product> productList = new List<Product> { };
        List<RequestsItem> requestItemList = new List<RequestsItem> { }; 
        List<int> productIdOriginalList = new List<int>();
        List<int> productIdNewList = new List<int>();

        public frmRequests()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.frmRequests_Load);
        }

        private void frmRequests_Load(object sender, EventArgs e)
        {
            productList = objProduct.SearchAll();
            AutoCompleteStringCollection ProductsNameCollection = new AutoCompleteStringCollection();
            foreach (Product product in productList)
            {
                ProductsNameCollection.Add(product.name);
            }
            txtProductName.AutoCompleteCustomSource = ProductsNameCollection;
        }

        private void bttAdd_Click(object sender, EventArgs e)
        {
            foreach (Product product in productList)
            {
                if (product.name.ToLower() == txtProductName.Text.ToLower())
                {
                    ListViewItem item = new ListViewItem(product.id.ToString());
                    item.SubItems.Add(product.name);
                    item.SubItems.Add(txtQtde.Text);
                    item.SubItems.Add(product.costPrice.ToString());
                    item.SubItems.Add(String.Format("{0}", int.Parse(txtQtde.Text) * product.costPrice));
                    listView1.Items.Add(item);
                }
            }
        }

        public void SearchAll()
        {
            List<Request> requestsList = objRequests.SearchAll();
            listView2.Items.Clear();
            listView1.Items.Clear();
            foreach (Request request in requestsList)
            {
                ListViewItem item = new ListViewItem(request.id.ToString());
                item.SubItems.Add(request.employeeName);
                item.SubItems.Add(request.requestDate.ToString());
                listView2.Items.Add(item);
            }
        }

        public override void btnSearch_Click(object sender, EventArgs e)
        {
            SearchAll();
        }

        public override bool Save()
        {
            Request request = new Request();
            if (sStatus == statusRegister.scEdit)
                request.id = Convert.ToInt32(lblId.Text);
            request.employeeName = txtEmployeeName.Text;
            request.requestDate = dateTimePicker1.Value;
            productIdNewList.Clear();
            if (objRequests.Save(sStatus == statusRegister.scInsert, request))
            {
                foreach (ListViewItem item in listView1.Items)
                {
                    int productId = Convert.ToInt32(item.SubItems[0].Text);
                    productIdNewList.Add(productId);
                }
                foreach (int i in productIdOriginalList)
                {
                    if (!productIdNewList.Contains(i))
                    {
                        RequestsItem itemToDelete = new RequestsItem();
                        itemToDelete = objRequestsItem.SearchRequestItem(request.id, i);
                        objRequestsItem.Delete(itemToDelete);
                    }
                }
                foreach ( ListViewItem item in listView1.Items)
                {
                    int productItemId = Convert.ToInt32(item.SubItems[0].Text);
                    int quantity = Convert.ToInt32(item.SubItems[2].Text);
                    RequestsItem requestItem = objRequestsItem.SearchRequestItem(request.id, productItemId);
                    if (requestItem == null)
                    {
                        requestItem = new RequestsItem();
                        requestItem.productId = productItemId;
                        requestItem.requestId = request.id;
                        requestItem.quantity = quantity;
                        objRequestsItem.Save(true, requestItem);
                    }
                    else
                    {
                        requestItem.quantity = quantity;
                        objRequestsItem.Save(false, requestItem);
                    }
                }
                return true;
            }
            return false;
        }

        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listView2.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;
            productIdOriginalList.Clear();
            if (item != null)
            {
                Request request = objRequests.Search(int.Parse(item.SubItems[0].Text));
                if (request != null)
                {
                    lblId.Text = request.id.ToString();
                    txtEmployeeName.Text = request.employeeName;
                    dateTimePicker1.Value = Convert.ToDateTime(request.requestDate);
                    requestItemList = objRequestsItem.SearchByRequestId(request.id);
                    foreach (RequestsItem requestItem in requestItemList)
                    {
                        Product product = objProduct.Search(requestItem.productId);
                        ListViewItem item2 = new ListViewItem(product.id.ToString());
                        item2.SubItems.Add(product.name);
                        item2.SubItems.Add(requestItem.quantity.ToString());
                        item2.SubItems.Add(product.costPrice.ToString());
                        item2.SubItems.Add(String.Format("{0}", requestItem.quantity * product.costPrice));
                        listView1.Items.Add(item2);
                        productIdOriginalList.Add(product.id);
                    }
                }
            }
            sStatus = statusRegister.scEdit;
            enableDisableControls(true);
        }

        private void bttRemove_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }
    }
}
