using System;
using System.Windows.Forms;

namespace RequestIt
{
    public partial class Navigation : Form
    {
        public Navigation()
        {
            InitializeComponent();
        }

        private void Navigation_Load(object sender, EventArgs e)
        {
  
        }

        private void simpleProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProducts form = new frmProducts();
            form.MdiParent = this;
            form.Show();
        }

        private void requestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRequests form = new frmRequests();
            form.MdiParent = this;
            form.Show();
        }

        private void requestsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRequestsReport form = new frmRequestsReport();
            form.MdiParent = this;
            form.Show();
        }

        private void storageReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStorageReport form = new frmStorageReport();
            form.MdiParent = this;
            form.Show();
        }
    }
}
