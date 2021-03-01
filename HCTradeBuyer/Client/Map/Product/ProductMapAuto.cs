/***************************
�� �� ��:	�½���

��������:	2007-8-22
��������:	��Ʒ�Զ�ƥ��
 **************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emedchina.TradeAssistant.Client.Base;
using System.Collections;
using Emedchina.TradeAssistant.Model.Map;
using Emedchina.Commons;
using Emedchina.Commons.WinForms;
using Emedchina.TradeAssistant.Client.BLL.Map.Product;


namespace Emedchina.TradeAssistant.Client.Map.Product
{
    public partial class ProductMapAuto : FormBase    
    {

        private DataTable dtNotMap = new DataTable();   //δƥ���Ʒ��
        private Hashtable hashMap = new Hashtable();    //ƥ���ϣ��
        private Hashtable hashSave = new Hashtable();   //�ѱ����ϣ��
        private bool bSave = false;                     //�����־
        public ProductMapAuto()
        {
            InitializeComponent();
        }
        public ProductMapAuto(DataTable dt)
        {
            InitializeComponent();
            dtNotMap = dt;          
         
        }
      
        /// <summary>
        /// ƥ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMap_Click(object sender, EventArgs e)
        {
            if (dgvEmedProduct.CurrentRow != null && dgvERPdprolist.CurrentRow != null && dgvERPdprolist.CurrentRow.Cells["IsMap"].Value.ToString() == "δƥ��")
            {
                Gpo_Product_MapModel model = new Gpo_Product_MapModel();
                model.ProductID = dgvEmedProduct.CurrentRow.Cells["product_id"].Value.ToString().Trim();
                model.Map_Orgid = ClientSession.GetInstance().CurrentUser.UserOrg.Reg_org_id;
                model.Factory_Id = dgvEmedProduct.CurrentRow.Cells["factory_id"].Value.ToString().Trim();
                model.Sender_Id = dgvEmedProduct.CurrentRow.Cells["sender_id"].Value.ToString().Trim();
                model.ProductCode = dgvERPdprolist.CurrentRow.Cells["product_code"].Value.ToString().Trim();
                model.CommonName = dgvERPdprolist.CurrentRow.Cells["product_name"].Value.ToString().Trim();
                model.Mode_Name = dgvERPdprolist.CurrentRow.Cells["medical_mode"].Value.ToString().Trim();
                model.Stand_Rate = dgvERPdprolist.CurrentRow.Cells["stand_rate"].Value.ToString().Trim();
                model.Spec_Unit = dgvERPdprolist.CurrentRow.Cells["spec_unit"].Value.ToString().Trim(); //��װ��λ
                model.Medical_Spec = dgvERPdprolist.CurrentRow.Cells["medical_spec"].Value.ToString().Trim();//�������
                model.Factory_Code = dgvERPdprolist.CurrentRow.Cells["factory_code"].Value.ToString().Trim();
                model.Factory_Name = dgvERPdprolist.CurrentRow.Cells["factory_name"].Value.ToString().Trim();
                model.ProcessFlag = "1";
                model.IsMap = "1";

                if (!hashMap.Contains(model.ProductCode))
                {
                    hashMap.Add(model.ProductCode, model);
                    dtNotMap.Select("product_code ='" + dgvERPdprolist.CurrentRow.Cells["product_code"].Value + "'")[0]["IsMap"] = "��ƥ��";
                    bSave = false;
                }
            }          
           
        } 
        /// <summary>
        /// ȡ��ƥ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelMap_Click(object sender, EventArgs e)
        {
            if (dgvERPdprolist.CurrentRow != null && dgvEmedProduct.CurrentRow != null && dgvERPdprolist.CurrentRow.Cells["IsMap"].Value.ToString() == "��ƥ��")
            {
                if (hashMap.ContainsKey(dgvERPdprolist.CurrentRow.Cells["product_code"].Value))
                {
                    hashMap.Remove(dgvERPdprolist.CurrentRow.Cells["product_code"].Value);
                }
                //����ѱ����
                if (hashSave.ContainsKey(dgvERPdprolist.CurrentRow.Cells["product_code"].Value))
                {
                    ProductCodeCompareBLL.GetInstance().CancelComparion(hashSave[dgvERPdprolist.CurrentRow.Cells["product_code"].Value].ToString());
                    hashSave.Remove(dgvERPdprolist.CurrentRow.Cells["product_code"].Value);
                    dgvERPdprolist_RowEnter(sender, new DataGridViewCellEventArgs(0,0));
                }
                dtNotMap.Select("product_code ='" + dgvERPdprolist.CurrentRow.Cells["product_code"].Value + "'")[0]["IsMap"] = "δƥ��";
                bSave = false;
            }
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!bSave)
            {
                ArrayList arrayExec = new ArrayList();
                foreach (Gpo_Product_MapModel model in hashMap.Values)
                {
                    string sRecord_ID = string.Empty;
                    //����Ѵ���ƥ������
                    if (ProductCodeCompareBLL.GetInstance().JudgeProductCode(model.ProductCode,model.Map_Orgid,ref sRecord_ID))
                    {
                        try
                        {
                            ProductCodeCompareBLL.GetInstance().UpdateProductMap(sRecord_ID,model.ProductID);
                        }
                        catch(Exception me)
                        {
                            MessageBox.Show(me.Message);
                        }
                    }
                    else
                    {                        
                        arrayExec.Add(ProductCodeCompareBLL.GetInstance().CreateProductComprison(model, out sRecord_ID));
                    }
                    if(!hashSave.ContainsKey(model.ProductCode))
                        hashSave.Add(model.ProductCode, sRecord_ID);                
                }
                try
                {
                    string[] sExecs = new string[arrayExec.Count];
                    arrayExec.CopyTo(sExecs);
                    if (ProductCodeCompareBLL.GetInstance().Add_Gpo_Product_Map_Batch(sExecs))
                    {
                        MessageBox.Show("����ɹ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        hashMap.Clear();
                        HideSaveData();
                        bSave = true;
                    }
                }
                catch
                {
                    MessageBox.Show("����ʧ�ܣ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.labNoMap.Text = dgvERPdprolist.Rows.Count.ToString() + "����¼";
            }
        }
        /// <summary>
        /// �����ѱ����ƥ���¼
        /// </summary>
        private void HideSaveData()
        {
            StringBuilder sFilter = new StringBuilder();
            sFilter.Append("1=1");
            foreach (string  product_code in hashSave.Keys)
            {              
                foreach (DataGridViewRow drvr in dgvERPdprolist.Rows)
                {
                    if (drvr.Cells["product_code"].Value.ToString().Trim() == product_code.Trim())
                    {
                        sFilter.AppendFormat(" and product_code <> '{0}'", product_code);                    
                    }       
                }          
            }
            sFilter.Append(" and IsMap = 'δƥ��'");
            dtNotMap.DefaultView.RowFilter = sFilter.ToString();
            cmbMapStutas.Text = "δƥ��";
        }
        /// <summary>
        /// �ر�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {           
            this.Close();
            GC.Collect();            
        }  

       
        /// <summary>
        /// ��ҳ
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void pageNavigator1_PageIndexOrPageSizeChanged(object source, Emedchina.Commons.WinForms.PageChangedEventArgs e)
        {
            InitGridTableView(pageNavigator1.CurrentPageIndex,pageNavigator1.PageSize);
            EmedbindingSource.DataSource = base.gridDataView;
            pageNavigator1.ItemCount = base.cachedDataView.Count;
        }
        
        /// <summary>
        /// ��ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnquerry_Click(object sender, EventArgs e)
        {
            string sProductName = StringUtils.repalceSepStr(txtERPProduct.Text.Trim());
            string sFactoryName = StringUtils.repalceSepStr(txtERPFactory.Text.Trim());
            string sIsMap = this.cmbMapStutas.Text.Trim();
            StringBuilder sFilter = new StringBuilder();
            sFilter.Append(" 1=1 ");
            if (!string.IsNullOrEmpty(sProductName))
            {
                sFilter.AppendFormat(" and product_name like '%{0}%'",sProductName);
            }
            if (!string.IsNullOrEmpty(sFactoryName))
            {
                sFilter.AppendFormat(" and factory_name like '%{0}%'",sFactoryName);
            }
            if (!string.IsNullOrEmpty(sIsMap) && sIsMap!="ȫ��")
            {
                sFilter.AppendFormat(" and ismap = '{0}'",sIsMap);
            }
            dtNotMap.DefaultView.RowFilter = sFilter.ToString();

        }       
       
        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductMapAuto_Load(object sender, EventArgs e)
        {
            this.ERPbindingSource.DataSource = dtNotMap.DefaultView;
            InitFromCacheByData(ProductCodeCompareBLL.GetInstance("ClientDB").GetGpoHitCommList());
            EmedbindingSource.DataSource = base.gridDataView;
            pageNavigator1.ItemCount = base.cachedDataView.Count;
            this.labNoMap.Text = dgvERPdprolist.Rows.Count.ToString() + "����¼";
            this.cmbMapStutas.Text = "ȫ��";
        }   
        /// <summary>
        /// ���ù�������
        /// </summary>
        private void Filter()
        {
            string producter = StringUtils.repalceSepStr(this.txtemedFactory.Text.Trim());      //������ҵ
            string productname = StringUtils.repalceSepStr(this.txtEmedProduct.Text.Trim());  //Ʒ��
            StringBuilder sFilter = new StringBuilder();
            sFilter.Append("1=1");
            if (!string.IsNullOrEmpty(productname))
                sFilter.AppendFormat(" and (medical_name like '%{0}%' or medical_wubi like '%{0}%' or medical_pinyin like '%{0}%' or spell_abbr like '%{0}%' or name_wb like '%{0}%' or trade_name like '%{0}%')", productname.ToUpper());
            if (!string.IsNullOrEmpty(producter))
                sFilter.AppendFormat(" and (factory_name like '%{0}%' or factory_easy like '%{0}%' or factory_wubi like '%{0}%' or factory_pinyin like '%{0}%')", producter);
            base.cachedDataView.RowFilter = sFilter.ToString();

            InitFromCacheByData(base.cachedDataView.Table);

            this.EmedbindingSource.DataSource = base.gridDataView;
            pageNavigator1.ItemCount = base.cachedDataView.Count;


        }
        /// <summary>
        /// ��Ʒ���ı��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEmedProduct_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }
        /// <summary>
        /// ������ҵ�ı��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtemedFactory_TextChanged(object sender, EventArgs e)
        {
            Filter();
        }
        /// <summary>
        /// ɾ��ƥ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvERPdprolist.CurrentRow != null  && hashSave.ContainsKey(dgvERPdprolist.CurrentRow.Cells["product_code"].Value))
            {
                if (MessageBox.Show("ȷʵҪɾ����", "��ʾ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    ProductCodeCompareBLL.GetInstance().DeleteGpo_Product(hashSave[dgvERPdprolist.CurrentRow.Cells["product_code"].Value].ToString());
                    string sCode = dgvERPdprolist.CurrentRow.Cells["product_code"].Value.ToString();
                    dtNotMap.DefaultView.RowFilter = " product_code <> '" + sCode + "'";
                    dtNotMap.Select("product_code = '" + sCode + "'")[0]["IsMap"] = "δƥ��";
                    bSave = false;
                    this.cmbMapStutas.Text = "δƥ��";
                }
            }
        }
        /// <summary>
        /// �еý���ʱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvERPdprolist_RowEnter(object sender, DataGridViewCellEventArgs e)
        {          
            if (dgvERPdprolist.Rows[e.RowIndex] != null && dgvERPdprolist.Rows[e.RowIndex].Cells["IsMap"].Value.ToString() == "��ƥ��" && hashSave.ContainsKey(dgvERPdprolist.Rows[e.RowIndex].Cells["product_code"].Value))
            {
                btnDel.Enabled = true;
            }
            else 
            {
                btnDel.Enabled = false;
            }
        }
    }
}