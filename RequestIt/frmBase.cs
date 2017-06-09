using System;
using System.Windows.Forms;

namespace RequestIt
{

    public partial class frmBase : Form
    {
        public frmBase()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.Load += new System.EventHandler(this.frmBase_Load);
        }

        public statusRegister sStatus;// = statusRegister.scBrowser;

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void frmBase_Load(object sender, System.EventArgs e)
        {
            sStatus = statusRegister.scBrowser;
            cleanControls();
            enableDisableControls(false);
        }

        public void enableDisableControls(bool Value)
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is ToolStrip)
                    continue;
                if (ctl is ListView)
                    continue;
                ctl.Enabled = Value;
            }

            //habilitado quando não estivermos inserindo ou editando, somente navegando
            btnNew.Enabled = (sStatus == statusRegister.scBrowser);
            //habilitado quando estiver inserindo ou editando
            btnSave.Enabled = ((sStatus == statusRegister.scInsert) ||
             (sStatus == statusRegister.scEdit));
            //habilitado quando estivermos editando
            btnDelete.Enabled = (sStatus == statusRegister.scEdit);
            //habilitado quando não estivermos inserindo ou editando, somente navegando
            btnSearch.Enabled = (sStatus == statusRegister.scBrowser);
            //sempre habilita o sair
            btnSair.Enabled = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            sStatus = statusRegister.scInsert;
            enableDisableControls(true);
        }

        private void cleanControls()
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is TextBox)
                    (ctl as TextBox).Text = "";
                if (ctl is ComboBox)
                    (ctl as ComboBox).SelectedIndex = -1;
                if (ctl is ListBox)
                    (ctl as ListBox).SelectedIndex = -1;
                if (ctl is CheckBox)
                    (ctl as CheckBox).Checked = false;
                if (ctl is ListView)
                    (ctl as ListView).Items.Clear();
            }
        } 

        public enum statusRegister
        {
            scInsert, scBrowser, scEdit
        }

        public virtual bool Save()
        { return true; }
        public virtual bool Delete()
        { return true; }
        public virtual bool Search(string text)
        { return true; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                sStatus = statusRegister.scBrowser;
                enableDisableControls(false);
                cleanControls();
                MessageBox.Show("Registro salvo com sucesso!",
                  "Salvar", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                
            }
        }

        public virtual void btnSearch_Click(object sender, EventArgs e)
        {
            sStatus = statusRegister.scEdit;
        }

        public virtual void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        public bool decimalOnly(object sender, KeyPressEventArgs e)
        {
            // permitindo 0-9, backspace e decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                return true;
            }

            // confirmando que eh apenas um numero decimal
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    return true;
            }
            return false;
        }

        public bool integerOnly(KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8))
            {
                return true; //rejeitando entradas do tipo letra e simbolos
            }
            return false; //aceitando numeros e backspace
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            sStatus = statusRegister.scBrowser;
            cleanControls();
            enableDisableControls(false);
        }
    }
}
