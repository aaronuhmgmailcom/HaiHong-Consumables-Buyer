/*****************************************************************************
创 建 人:	罗澜涛
创建日期:	2007-5-21
功能描述:	查看产品编码对照
 ********************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Client.Common;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Model.His;
using Emedchina.TradeAssistant.Client.BLL.His.Product;

using Emedchina.TradeAssistant.Model.User;
using Emedchina.TradeAssistant.Client.DAL.His;

namespace Emedchina.TradeAssistant.Client.His.Product
{
    public partial class ProImpHisPlan : FormBase
    {
        #region 构造函数
        public ProImpHisPlan()
        {
            InitializeComponent();
        }
        #endregion

        #region 选择文件事件
        private void btnView_Click(object sender, EventArgs e)
        {
            string strCurrentDB = FileOperation.GetNodeValue(FileOperation.GetNodeObject(EmedFunc.GetLocalPersonCfgPath() + @"\HisProductMapList.xml", "Config/SourceDB"), "DBType");

            if (string.IsNullOrEmpty(strCurrentDB))
            {
                ComUtil.MsgBox("没有进行字段匹配，无法导入！");
                return;
            }
            //选择待导入的文件
            string str = "";

            if (strCurrentDB.CompareTo("EXCEL") == 0)
            {
                openFileDialog1.Filter = "Excel文档(*.xls)|*.xls";
            }
            if (strCurrentDB.CompareTo("ACCESS") == 0)
            {
                openFileDialog1.Filter = "MDB文档(*.mdb)|*.mdb";
            }
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Title = "打开文件";
            openFileDialog1.InitialDirectory = EmedFunc.GetLocalPersonCfgPath();
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            try
            {
                str = openFileDialog1.FileName;
                if (!string.IsNullOrEmpty(str))
                {
                    this.txtImportFilePath.Text = str;
                    ClientConfiguration.HisPath = str;
                    string sql = string.Empty;

                    if (strCurrentDB.CompareTo("EXCEL") == 0)
                    {
                        ClientConfiguration.ConnectionString = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + str + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1'";
                        sql = FileOperation.GetNodeObject(EmedFunc.GetLocalPersonCfgPath() + @"\HisProductMapList.xml", "Config/Sqls/Sql").InnerText;

                    }

                    if (strCurrentDB.CompareTo("ACCESS") == 0)
                    {
                        string password = SecretUtil.DeSecret(FileOperation.GetNodeValue(FileOperation.GetNodeObject(EmedFunc.GetLocalPersonCfgPath() + @"/HisProductMapList.xml", "Config/DestDB"), "Password"));
                        ClientConfiguration.ConnectionString = " Provider = Microsoft.Jet.OLEDB.4.0 ;Jet OLEDB:Database Password=" + password + "; Data Source = " + str + ";";
                        sql = FileOperation.GetNodeObject(EmedFunc.GetLocalPersonCfgPath() + @"\HisProductMapList.xml", "Config/ASqls/Sql").InnerText;
                    }

                    ClientConfiguration.Save();

                   
                    DataTable dt = RequestSendDal.GetInstance().GetRequestSend(sql);

                    dt.DefaultView.RowFilter = " PRODUCT_CODE is not null";
                    this.bindingSource1.DataSource = null;
                    this.bindingSource1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                this.bindingSource1.DataSource = null;
                ComUtil.MsgBox("不是有效的数据文件！");
            }
        }
        #endregion

        #region 选择事件
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.dataGridView.Rows.Count == 0)
                return;

            bool chkflag = this.chkAll.Checked;

            foreach(DataGridViewRow dgv in this.dataGridView.Rows)
            {
                dgv.Cells["clmKey"].Value = chkflag;
                dgv.Cells["clmKey"].Selected = chkflag;
            }
        }
        #endregion

        #region 导入操作
        private void btnImport_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count == 0)
                return;

            bool flag = true;
            IList<Gpo_Product_MapModel> productModelList = new List<Gpo_Product_MapModel>();

            try
            {            
                foreach (DataGridViewRow row in this.dataGridView.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString().ToLower() == "true")
                    {
                        Gpo_Product_MapModel model = new Gpo_Product_MapModel();
                        model.ProductCode = row.Cells["PRODUCT_CODE"].Value.ToString();
                        model.MedicalCode = row.Cells["MEDICAL_CODE"].Value.ToString();
                        model.CommonName = row.Cells["COMMON_NAME"].Value.ToString();
                        model.Product_Name = row.Cells["PRODUCT_NAME"].Value.ToString();
                        model.Mode_ID = row.Cells["MODE_ID"].Value.ToString();
                        model.Mode_Name = row.Cells["MODE_NAME"].Value.ToString();
                        model.Medical_Spec_Id = row.Cells["MEDICAL_SPEC_ID"].Value.ToString();
                        model.Medical_Spec = row.Cells["MEDICAL_SPEC"].Value.ToString();
                        model.UseUnitCode = row.Cells["USE_UNIT_ID"].Value.ToString();
                        model.Use_Unit = row.Cells["USE_UNIT"].Value.ToString();
                        model.Spec_Unit_Id = row.Cells["SPEC_UNIT_ID"].Value.ToString();
                        model.Spec_Unit = row.Cells["SPEC_UNIT"].Value.ToString();

                        model.Stand_Rate = row.Cells["STAND_RATE"].Value.ToString();
                        model.Factory_Code = row.Cells["FACTORY_CODE"].Value.ToString();
                        model.Factory_Name = row.Cells["FACTORY_NAME"].Value.ToString();
                        model.ProductID = row.Cells["product_id"].Value.ToString();
                        model.DataProductID = row.Cells["data_product_id"].Value.ToString();

                        model.Permit_No = row.Cells["PERMIT_NO"].Value.ToString();
                        model.Saler_Code = row.Cells["SALER_CODE"].Value.ToString();
                        model.Saler_Name = row.Cells["SALER_NAME"].Value.ToString();
                        model.Sender_Code = row.Cells["SENDER_CODE"].Value.ToString();
                        model.Sender_Name = row.Cells["SENDER_NAME"].Value.ToString();
                        //model.Category_Id = row.Cells["CATEGORY_ID"].Value.ToString();
                        //model.Category_Name = row.Cells["CATEGORY_NAME"].Value.ToString();
                        model.Stock_Id = row.Cells["STOCK_ID"].Value.ToString();
                        model.Stock_Name = row.Cells["STOCK_NAME"].Value.ToString();
                        model.Package_Rate = string.IsNullOrEmpty(row.Cells["PACKAGE_RATE"].Value.ToString()) ? "1" : row.Cells["PACKAGE_RATE"].Value.ToString();

                        productModelList.Add(model);
                    }
                }

                if (productModelList.Count == 0)
                {
                    ComUtil.MsgBox("请选择所要的导入产品信息！");
                    return;
                }
                //获取当前用户ORGID
                string orgid = ClientSession.GetInstance().CurrentUser.UserOrg.Reg_org_id.ToString();

                flag = ProductCodeCompareBLL.GetInstance("ClientDB").Import_Gpo_Product(orgid, productModelList);

                if (flag == true)
                    ComUtil.MsgBox("导入产品信息成功！");
                else
                    ComUtil.MsgBox("导入产品信息失败！");
            }catch(Exception ex)
            {
                ComUtil.MsgBox("导入产品信息失败！");
                //throw ex;
            }
        }
        #endregion

        #region 关闭按钮事件
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}