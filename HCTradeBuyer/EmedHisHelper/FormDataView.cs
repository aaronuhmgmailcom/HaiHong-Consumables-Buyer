using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EmedHisHelper
{
    public partial class FormDataView : DevExpress.XtraEditors.XtraForm
    {
        private DataSet DSView;

        public FormDataView()
        {
            InitializeComponent();
        }

        public FormDataView(DataSet inData)
        {
            this.components = null;
            this.InitializeComponent();
            this.DSView = inData;
        }

        private void FormDataView_Load(object sender, EventArgs e)
        {
            this.dataGridView.DataSource = this.DSView.Tables[0];
            this.DSView.Tables[0].DefaultView.AllowNew = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDataView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }


    }
}