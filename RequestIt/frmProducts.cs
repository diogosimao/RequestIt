using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Controller;

namespace RequestIt
{
    public partial class frmProducts : frmBase
    {
        balProducts objProduct = new balProducts();
        balCompoundProducts objCompoundProduct = new balCompoundProducts();
        List<int> compoundProductIdOriginalList = new List<int>();
        List<int> compoundProductIdNewList = new List<int>();

        public frmProducts()
        {
            InitializeComponent();
        }

        public override bool Save()
        {
            try
            {
                Product product = new Product();
                
                if (sStatus == statusRegister.scEdit)
                    product.id = Convert.ToInt32(lblId.Text);
                product.name = txtProductName.Text;
                product.salePrice = Convert.ToDecimal(txtSalePrice.Text);
                product.costPrice = Convert.ToDecimal(txtCostPrice.Text);

                objProduct.Save(sStatus == statusRegister.scInsert, product);

                if (chkBoxCompoundProduct.Checked)
                {
                    product.isCompound = true;
                    foreach (ListViewItem item in listView2.Items)
                    {
                        int productId = Convert.ToInt32(item.SubItems[0].Text);
                        compoundProductIdNewList.Add(productId);
                    }
                    foreach (int i in compoundProductIdOriginalList)
                    {
                        if (!compoundProductIdNewList.Contains(i))
                        {
                            CompoundProduct compoundProductToDelete = new CompoundProduct();
                            compoundProductToDelete = objCompoundProduct.SearchCompound(i, product.id);
                            objCompoundProduct.Delete(compoundProductToDelete);
                        }
                    }
                    foreach (ListViewItem item in listView2.Items)
                    {
                        int productId = Convert.ToInt32(item.SubItems[0].Text);
                        CompoundProduct compoundProduct = new CompoundProduct();
                        if (sStatus == statusRegister.scEdit)
                        {
                            compoundProduct = objCompoundProduct.SearchCompound(productId, product.id);
                            if (compoundProduct == null)
                            {
                                compoundProduct = new CompoundProduct();
                                compoundProduct.compoundProductId = product.id;
                                compoundProduct.productId = productId;
                                compoundProduct.quantity = Convert.ToInt32(item.SubItems[2].Text);
                                objCompoundProduct.Save(true, compoundProduct);
                            }
                            compoundProduct.id = compoundProduct.id;
                        }
                        else
                        {
                            compoundProduct.compoundProductId = product.id;
                            compoundProduct.productId = productId;
                        }
                        compoundProduct.quantity = Convert.ToInt32(item.SubItems[2].Text);
                        objCompoundProduct.Save(sStatus == statusRegister.scInsert, compoundProduct);
                    }
                    objProduct.Save(false, product);
                }
                lblId.Text = "ID";
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
                return false;
            }
        }

        public override bool Delete()
        {
            try
            {
                Product product = new Product();
                product.id = Convert.ToInt32(lblId.Text);
                return objProduct.Delete(product);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
                return false;
            }
        }

        public override bool Search(string text)
        {
            try
            {
                List<Product> productsList = objProduct.Search(text);
                listView1.Items.Clear();
                foreach (Product product in productsList)
                {
                    ListViewItem item = new ListViewItem(product.id.ToString());
                    item.SubItems.Add(product.name);
                    item.SubItems.Add(product.salePrice.ToString());
                    item.SubItems.Add(product.costPrice.ToString());
                    item.SubItems.Add(product.isCompound == true ? "Sim" : "Não" );
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK,
                  MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listView1.HitTest(e.X, e.Y);
            ListViewItem item = info.Item;

            if (item != null)
            {
                Product product = objProduct.Search(Convert.ToInt32(item.SubItems[0].Text));
                lblId.Text = product.id.ToString();
                txtProductName.Text = product.name.ToString();
                txtSalePrice.Text = product.salePrice.ToString();
                txtCostPrice.Text = product.costPrice.ToString();
                chkBoxCompoundProduct.Checked = (product.isCompound == true ? true : false);
                listView2.Items.Clear();
                decimal costPrice = 0;
                foreach (var i in product.CompoundProducts)
                {
                    CompoundProduct cp = objCompoundProduct.Search(i.id);
                    Product subProduct = objProduct.Search(cp.productId);
                    ListViewItem item2 = new ListViewItem(cp.productId.ToString());
                    item2.SubItems.Add(subProduct.name);
                    item2.SubItems.Add(i.quantity.ToString());
                    item2.SubItems.Add(subProduct.costPrice.ToString());
                    listView2.Items.Add(item2);
                    compoundProductIdOriginalList.Add(cp.productId);
                    costPrice += (subProduct.costPrice * i.quantity);
                }
                txtCostPrice.Text = String.Format("{0}", costPrice);
                sStatus = statusRegister.scEdit;
                enableDisableControls(true);
            }
            else
            {
                this.listView1.SelectedItems.Clear();
                MessageBox.Show("Selecione um produto.");
            }
       
        }
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        public override void btnSearch_Click(object sender, EventArgs e)
        {
            Search(txtProductName.Text);
        }

        private void txtSalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = decimalOnly(sender, e);
        }

        private void txtCostPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = decimalOnly(sender, e);
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = integerOnly(e);
        }

        private void updateCostPrice()
        {
            decimal costPrice = 0;
            foreach (ListViewItem item in listView2.Items)
            {
                costPrice += decimal.Parse(item.SubItems[3].Text) * int.Parse(item.SubItems[2].Text);
            }
            txtCostPrice.Text = String.Format("{0}", costPrice);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "")
            {
                MessageBox.Show("Informe a quantidade.");
                return;
            }

            foreach (ListViewItem item in listView1.SelectedItems)
            {
                int subProductId = int.Parse(item.SubItems[0].Text);
                Product subProduct = objProduct.Search(subProductId);
                if (subProduct != null)
                {
                    ListViewItem item2 = new ListViewItem(subProductId.ToString());
                    item2.SubItems.Add(subProduct.name);
                    item2.SubItems.Add(txtQuantity.Text);
                    item2.SubItems.Add(subProduct.costPrice.ToString());
                    listView2.Items.Add(item2);
                }
            }
            updateCostPrice();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedIndices.Count != 0)
            {
                listView2.Items.Remove(listView2.SelectedItems[0]);
            }
            updateCostPrice();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Search("");
        }
    }
}
