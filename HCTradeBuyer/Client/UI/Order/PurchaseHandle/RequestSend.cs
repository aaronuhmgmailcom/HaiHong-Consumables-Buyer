using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Client;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Client.Common;
using Emedchina.TradeAssistant.Client.DAL.His;
using Emedchina.TradeAssistant.Model.Order.PurchaseHandle;

namespace Emedchina.TradeAssistant.Client.UI.Order.PurchaseHandle
{
    public partial class RequestSend : BaseForm
    {
        private string buyerOrgid;  //买方ID
        private string orderId;     //采购申请ID
        DataTable dtTemp = new DataTable();
        DataTable dtRequestSend;
       
        public RequestSend()
        {
            InitializeComponent();
        }

        public RequestSend(bool flag)
        {
            button1.Enabled = flag;
        }

        public string BuyerOrgid
        {
            get { return buyerOrgid; }
            set { buyerOrgid = value; }
        }

        public string OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

        /// <summary>
        /// 浏览按钮的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            dtTemp.Columns.Clear();
            string strCurrentDB = FileOperation.GetNodeValue(FileOperation.GetNodeObject(EmedFunc.GetLocalPersonCfgPath() + @"\HisPurchase.xml", "Config/SourceDB"), "DBType");
            if (string.IsNullOrEmpty(strCurrentDB))
            {
                ComUtil.MsgBox("没有进行字段匹配，无法导入！");
                return;
            }
            //选择待导入的文件
            string strFileName = string.Empty;

            if (strCurrentDB.CompareTo("EXCEL") == 0)
            {
                openFileDialog1.Filter = "Excel文档(*.xls)|*.xls";
            }
            //openFileDialog1.Filter = "DBF文档(*.dbf)|*.dbf|Excel文档(*.xls)|*.xls";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Title = "打开文件";
            openFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            try
            {
                strFileName = openFileDialog1.FileName;
                if (!string.IsNullOrEmpty(strFileName))
                {
                    this.txtImportFilePath.Text = strFileName;
                    ClientConfiguration.HisPath = strFileName;

                    if (strCurrentDB.CompareTo("EXCEL") == 0)
                    {
                        ClientConfiguration.ConnectionString = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + strFileName + ";Extended Properties=Excel 8.0";
                    }
                        
                    ClientConfiguration.Save();

                    string sql = FileOperation.GetNodeObject(EmedFunc.GetLocalPersonCfgPath() + @"\HisPurchase.xml", "Config/Sqls/Sql").InnerText;

                    dtRequestSend = RequestSendDal.GetInstance().GetRequestSend(sql);
                    dtRequestSend.Columns.Add("type");                //采购单明细id
                    dtRequestSend.Columns.Add("state");
                    dtRequestSend.Columns.Add("emedProductId");
                    dtRequestSend.Columns.Add("emedSpecId");
                    dtRequestSend.Columns.Add("emedModelId");
                    dtRequestSend.Columns.Add("emedSenderId");
                    dtRequestSend.Columns.Add("emedSenderName");
                    dtRequestSend.Columns.Add("emedSenderEasy");
                    dtRequestSend.Columns.Add("selfpackage");
                    dtRequestSend.Columns.Add("factoryeasy");
                    dtRequestSend.Columns["Price"].DataType = Type.GetType("System.Double");
                    this.bindingSource1.DataSource = null;
                    this.bindingSource1.DataSource = dtRequestSend;
                    //获取耗材和医院匹配数据
                    SetErpSendMapData();
                    this.button1.Enabled = true;
                    this.btnImport.Enabled = true;
                }
            }
            
            catch (Exception m )
            {
                this.bindingSource1.DataSource = null;
                ComUtil.MsgBox("不是有效的数据文件！");
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 获取耗材和医院匹配数据
        /// </summary>
        private void SetErpSendMapData()
        {
            
            foreach (DataRow dgvr in dtRequestSend.Rows)
            {
                if (dgvr["ProductCode"] == null || dgvr["ProductCode"].ToString() == "")
                {
                    continue;
                }
                string porductCode = "";
                string buyerCode = "";
                IList<ImputPurchaseModel> result = new List<ImputPurchaseModel>();
                //int num = 0;
                if (dgvr["ProductCode"].GetType() == typeof(double))
                {
                    porductCode = int.Parse(dgvr["ProductCode"].ToString()).ToString();
                }
                else
                {
                    porductCode = dgvr["ProductCode"].ToString();
                }
                //判断供应商匹配
                if (dgvr["SenderCode"].GetType() == typeof(double))
                {
                    buyerCode = int.Parse(dgvr["SenderCode"].ToString()).ToString();
                }
                else
                {
                    buyerCode = dgvr["SenderCode"].ToString();
                }
                string emedProductId="";
                string emedSpecId = "";
                string emedModelId = "";
                string emedPrice = "";
                string emedcommonname = "";
                string emedproductname = "";
                string selfpackage = "";
                string factoryname = "";
                string factoryeasy = "";
                string emedHis = "";
                string emedsendername = "";
                string emedsendereasy = "";
                string emedbrand = "";

                DataTable dtproduct = RequestSendDal.GetInstance().GetProductMapData(porductCode,base.CurrentUserOrgId);

                if (dtproduct.Rows.Count >0)
                {
                    emedProductId = dtproduct.Rows[0]["PROJECT_PROD_ID"] == null ? "" : dtproduct.Rows[0]["PROJECT_PROD_ID"].ToString();
                    emedSpecId = dtproduct.Rows[0]["SPEC_ID"] == null ? "" : dtproduct.Rows[0]["SPEC_ID"].ToString();
                    emedModelId = dtproduct.Rows[0]["MODE_ID"] == null ? "" : dtproduct.Rows[0]["MODE_ID"].ToString();
                    emedPrice = dtproduct.Rows[0]["PRICE"] == null ? "0" : dtproduct.Rows[0]["PRICE"].ToString();
                    emedcommonname = dtproduct.Rows[0]["COMMON_NAME"] == null ? "" : dtproduct.Rows[0]["COMMON_NAME"].ToString();
                    emedproductname = dtproduct.Rows[0]["PRODUCT_NAME"] == null ? "" : dtproduct.Rows[0]["PRODUCT_NAME"].ToString();
                    selfpackage = dtproduct.Rows[0]["SELF_PACKAGE"] == null ? "1" : dtproduct.Rows[0]["SELF_PACKAGE"].ToString();
                    factoryname = dtproduct.Rows[0]["MANU_NAME"] == null ? "" : dtproduct.Rows[0]["MANU_NAME"].ToString();
                    factoryeasy = dtproduct.Rows[0]["MANU_NAME_ABBR"] == null ? "" : dtproduct.Rows[0]["MANU_NAME_ABBR"].ToString();
                    emedbrand = dtproduct.Rows[0]["BRAND"] == null ? "" : dtproduct.Rows[0]["BRAND"].ToString();
                }
                DataTable dtsender = RequestSendDal.GetInstance("ClientDB").GetIPMapData(base.CurrentUserOrgId,buyerCode);
                if (dtsender.Rows.Count > 0)
                {
                    emedHis = dtsender.Rows[0]["ORG_ID"] == null ? "" : dtsender.Rows[0]["ORG_ID"].ToString();
                    emedsendername = dtsender.Rows[0]["FULL_NAME"] == null ? "" : dtsender.Rows[0]["FULL_NAME"].ToString();
                    emedsendereasy = dtsender.Rows[0]["EASY_NAME"] == null ? "" : dtsender.Rows[0]["EASY_NAME"].ToString();
                }

                if (string.IsNullOrEmpty(emedProductId))
                {
                    if (string.IsNullOrEmpty(emedHis))
                    {
                        dgvr["type"] = "1";
                        dgvr["state"] = "产品和配送企业未匹配";
                    }
                    else
                    {
                        dgvr["type"] = "2";
                        dgvr["state"] = "产品未匹配";
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(emedHis))
                    {
                        dgvr["type"] = "3";
                        dgvr["state"] = "配送企业未匹配";
                    }
                    else
                    {
                        dgvr["type"] = "0";
                        dgvr["state"] = "匹配成功";
                        dgvr["emedProductId"] = emedProductId;
                        dgvr["emedSpecId"] = emedSpecId;
                        dgvr["emedModelId"] = emedModelId;
                        dgvr["emedSenderId"] = emedHis;
                        dgvr["emedSenderName"] = emedsendername;
                        dgvr["emedSenderEasy"] = emedsendereasy;
                        dgvr["Price"] = double.Parse(emedPrice);
                        dgvr["InstruName"] = emedcommonname;
                        dgvr["ProductName"] = emedproductname;
                        dgvr["FactoryName"] = factoryname;
                        dgvr["factoryeasy"] = factoryeasy;
                        dgvr["selfpackage"] = selfpackage;
                        dgvr["Brand"] = emedbrand;
                    }
                }
                if (!"0".Equals(dgvr["type"].ToString()))
                {
                    button1.Enabled = true;
                }
            }
        }


        /// <summary>
        /// 导入按钮的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {             
                if (button1.Enabled == true)
                {
                   OutUncompared();    //导出未匹配 
                }
                if (this.dgvHisSend.RowCount < 1)
                {
                    XtraMessageBox.Show("无可操作记录！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                IList<ImputPurchaseModel> result = new List<ImputPurchaseModel>();
                foreach (DataRow dgvr in dtRequestSend.Rows)
                {
                    if (dgvr["ProductCode"] == null || dgvr["ProductCode"].ToString() == "")
                    {
                        continue;
                    }
                    if ("0".Equals(dgvr["type"].ToString()))
                    {
                        ImputPurchaseModel model = new ImputPurchaseModel();
                        model.EmedProductId=dgvr["emedProductId"].ToString();
                        model.EmedSpecId = dgvr["emedSpecId"].ToString(); 
                        model.EmedModelId=dgvr["emedModelId"].ToString(); 
                        model.EmedSenderId=dgvr["emedSenderId"].ToString();
                        model.Psqymc = dgvr["emedSenderName"].ToString();
                        model.Psqyjc = dgvr["emedSenderEasy"].ToString();
                        model.Cgsl = dgvr["RequestQty"].ToString();
                        model.Cpmc = dgvr["ProductName"].ToString();
                        model.Scqymc = dgvr["FactoryName"].ToString();
                        model.Scqyjc = dgvr["factoryeasy"].ToString();
                        model.Bzdw = dgvr["SpecUnit"].ToString();                      
                        model.Price = dgvr["Price"].ToString();
                        model.Hcmc = dgvr["InstruName"].ToString();
                        model.Zdbz = dgvr["selfpackage"].ToString();
                        model.Brand = dgvr["Brand"].ToString();
                        result.Add(model);

                    }
                }
                if (result.Count < 1)
                {
                    XtraMessageBox.Show("无可导入数据！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //转到制定采购单
                FormPurchaseCreate frm = new FormPurchaseCreate("新建采购单",null, result);
                frm.ShowDialog(); ;
                frm.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.dgvHisSend.RowCount < 1)
            {
                XtraMessageBox.Show("无可操作记录！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            OutUncompared();    //导出未匹配 
        }
         //导出未匹配
        private void OutUncompared()
        {
            IList<ImputPurchaseModel> resultp = new List<ImputPurchaseModel>();
            foreach (DataRow dgvr in dtRequestSend.Rows)
            {
                if (!"0".Equals(dgvr["type"].ToString()))
                {
                    ImputPurchaseModel requestSendModel = new ImputPurchaseModel();
                    requestSendModel.Psqymc = dgvr["SenderName"].ToString();
                    requestSendModel.Hcbm = dgvr["ProductCode"].ToString();
                    requestSendModel.Psqybm = dgvr["SenderCode"].ToString();
                    requestSendModel.Hcmc = dgvr["ProductName"].ToString();
                    requestSendModel.Xhmc = dgvr["ModeName"].ToString();
                    requestSendModel.Ggmc = dgvr["Spec"].ToString();
                    requestSendModel.Cgsl = dgvr["RequestQty"].ToString();
                    requestSendModel.Bzdw = dgvr["SpecUnit"].ToString();
                    requestSendModel.Scqymc = dgvr["FactoryName"].ToString();
                    requestSendModel.State = dgvr["state"].ToString();
                    requestSendModel.Hcmc = dgvr["InstruName"].ToString();
                    requestSendModel.Brand = dgvr["Brand"].ToString();

                    resultp.Add(requestSendModel);
                }
            }
            if (resultp.Count < 1)
                return;
           HisPlanErrorList frmHisPlanError = new HisPlanErrorList(resultp);
            frmHisPlanError.ShowDialog();
            //未匹配结构导出成功改变按钮颜色，隐藏未匹配数据

            if (!frmHisPlanError.flag)
            {
                button1.Enabled = false;

                dtRequestSend.DefaultView.RowFilter = "type='0'";
            }
        }










    }
}

