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
    public partial class frmStorageReport : Form
    {
        public frmStorageReport()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            this.DataTable1TableAdapter.Fill(this.DataSet2.DataTable1, dateTimePicker1.Value, dateTimePicker2.Value);
            this.reportViewer1.RefreshReport();
        }

        private void bttSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void frmStorageReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet2.DataTable1' table. You can move, or remove it, as needed.
            LoadData();
        }
    }
}
