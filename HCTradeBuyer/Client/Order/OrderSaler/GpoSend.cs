using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Emedchina.Commons;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Client.Common;
using Emedchina.TradeAssistant.Client.DAL.Order.SalerOrder;
using Emedchina.TradeAssistant.Model.Order.SalerOrder;
using Emedchina.TradeAssistant.Model.Map;
using Emedchina.TradeAssistant.Client.BLL.Gpo;
using Emedchina.TradeAssistant.Client.DAL.Gpo;
using Emedchina.TradeAssistant.Client.Map.Product;
using Emedchina.TradeAssistant.Client.Map.Hospital;
using Emedchina.TradeAssistant.Client.BLL.Order.SalerOrder;


namespace Emedchina.TradeAssistant.Client.Order.OrderSaler
{
    /// <summary>
    /// 发货单导入
    /// </summary>
    public partial class GpoSend : FormBase
    {
        private string buyerOrgid;
        private string orderId;
        private string m_flag;
        object pronum;
        object cropnum;
        int count;

        DataTable dtImp = new DataTable();

        public GpoSend()
        {
            InitializeComponent();
        }

        private void ErpSend_Load(object sender, EventArgs e)
        {
            //btnImport.Enabled = false;
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
        public string Flag
        {
            get { return m_flag; }
            set { m_flag = value; }
        }
        /// <summary>
        /// 浏览按钮的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            /******************************************************************
           * 
           * 修改时间：2007-3-21  
           * 修改人：ningbo   
           * 修改原因：
           * 新增代码：EmedFunc.GetLocalPersonCfgPath() + "GpoOrderSend.xml"
           * 
           ******************************************************************/
            string strCurrentDB = FileOperation.GetNodeValue(FileOperation.GetNodeObject(EmedFunc.GetLocalPersonCfgPath() + @"\GpoOrderSend.xml", "Config/SourceDB"), "DBType");

            if (string.IsNullOrEmpty(strCurrentDB))
            {
                MessageBox.Show("没有进行字段匹配，无法导入！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //选择待导入的文件
            string str = "";

            if (strCurrentDB.CompareTo("EXCEL") == 0)
            {
                openFileDialog1.Filter = "Excel文档(*.xls)|*.xls";
            }
            //openFileDialog1.Filter = "DBF文档(*.dbf)|*.dbf|Excel文档(*.xls)|*.xls";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Title = "打开文件";
            openFileDialog1.InitialDirectory = Application.StartupPath;
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

                    if (strCurrentDB.CompareTo("EXCEL") == 0)
                    {
                        ClientConfiguration.ConnectionString = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + str + ";Extended Properties=Excel 8.0";
                    }
                    //ClientConfiguration.ConnectionString = ClientConfiguration.ConnectionString.Replace(ClientConfiguration.HisPath, str);                
                    ClientConfiguration.Save();
                    //ClientConfiguration.Reload();

                    /******************************************************************
                    * 
                    * 修改时间：2007-3-21  
                    * 修改人：ningbo   
                    * 修改原因：
                    * 新增代码：EmedFunc.GetLocalPersonCfgPath() + "GpoOrderSend.xml"
                    * 
                    ******************************************************************/
                    //string sql = FileOperation.GetNodeObject(EmedFunc.GetLocalPersonCfgPath() + @"\GpoOrderSend.xml", "Config/Sqls/Sql").InnerText;

                    //DataTable dt = GpoSendDao.GetInstance().GetErpSend(sql);

                    DataTable dt = GetImportTable();
                    this.bindingSource1.DataSource = null;
                    this.bindingSource1.DataSource = dt;
                    //"导出采购订单"判断业务流程("进销存"企业对接功能)，shangfu 2007-8-24
                    //如果为1就是进销存对接接口     
                    string clientPlat = UserConfigXml.GetConfigInfo("ClientPlat", "type");
                    if (clientPlat.Equals("1"))
                    {
                        //dtImp = dt.Clone();
                        RetOrderItem(out count);
                    }
                    else
                    {
                        setErpSendMapData(out count);
                    }




                    int matchRowsCount = 0;
                    foreach (DataGridViewRow dgvr in dgvErpSend.Rows)
                    {
                        if (dgvr.Cells["type"].Value == "0")
                        {
                            matchRowsCount++;
                        }
                    }
                    if (matchRowsCount > 0)
                    {
                        btnImport.Enabled = true;
                    }
                    else
                    {
                        //btnImport.Enabled = false;
                    }
                    if (count > 0)
                    {
                        lbmess.Text = "有" + count.ToString() + "个产品编码（显示为红色）对应多条数据，请选择一条！";
                        if (dgvErpSend.RowCount > 0)
                            lbmess.Visible = true;
                        else
                            lbmess.Visible = false;
                    }
                }
            }
            catch (Exception)
            {
                this.bindingSource1.DataSource = null;
                MessageBox.Show("不是有效的数据文件！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        /// <summary>
        /// 导入按钮的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            if (this.bindingSource1.DataSource == null) return;

            //"导出采购订单"判断业务流程("进销存"企业对接功能)，shangfu 2007-8-24
            //如果为1就是进销存对接接口     

            int iCount = 0;
            string clientPlat = UserConfigXml.GetConfigInfo("ClientPlat", "type");
            if (clientPlat.Equals("1"))
            {
                RetOrderItem(out iCount);
            }
            else
            {
                DataTable dtNotMapProd = GetImportTable();
                DataTable dtNotMapEnterprise = new DataTable();
                dtNotMapEnterprise = GpoSendBLL.GetInstance().GetNotMapData(ref dtNotMapProd, base.CurrentUserOrgId);

                if (dtNotMapProd.Rows.Count > 0)
                {
                    DataColumn dc = new DataColumn("IsMap");
                    dc.DataType = System.Type.GetType("System.String");
                    dc.DefaultValue = "未匹配";
                    dtNotMapProd.Columns.Add(dc);
                    ProductMapAuto productmapauto = new ProductMapAuto(dtNotMapProd);
                    productmapauto.ShowDialog();
                }
                if (dtNotMapEnterprise.Rows.Count > 0)
                {
                    DataColumn dc = new DataColumn("IsMap");
                    dc.DataType = System.Type.GetType("System.String");
                    dc.DefaultValue = "未匹配";
                    dtNotMapEnterprise.Columns.Add(dc);
                    EnterpriseMapAuto enterprisemapauto = new EnterpriseMapAuto(dtNotMapEnterprise);
                    enterprisemapauto.ShowDialog();
                }

                setErpSendMapData(out iCount);

            }



            IList result = new ArrayList();
            foreach (DataGridViewRow dgvr in dgvErpSend.Rows)
            {

                //"导出采购订单"判断业务流程("进销存"企业对接功能)，shangfu 2007-8-28
                //如果为1就是进销存对接接口     
                if (clientPlat.Equals("1"))
                {
                    if (dgvr.Cells["ordItemId"].Value == null || dgvr.Cells["ordItemId"].Value.ToString() == "")
                    {
                        continue;
                    }
                }
                else
                {
                    if (dgvr.Cells["PRODUCT_CODE"].Value == null || dgvr.Cells["PRODUCT_CODE"].Value.ToString() == "")
                    {
                        continue;
                    }
                }

                if ("0".Equals(dgvr.Cells["type"].Value.ToString()))
                {
                    setOrderItem(dgvr, result);
                }
            }

            SalerOrderItemList frm = new SalerOrderItemList(OrderId, Flag, result);
            frm.ShowDialog();
            this.Close();
        }

        //"导入订单"判断业务流程("进销存"企业对接功能)，shangfu 2007-8-28
        private void RetOrderItem(out int count)
        {
            count = 0;
            //DataColumn dc = new DataColumn("state");
            //dc.DataType = System.Type.GetType("System.String");
            //dc.DefaultValue = "状态";
            //this.dtImp.Columns.Add(dc);

            foreach (DataGridViewRow dgvr in dgvErpSend.Rows)
            {
                string orderItemId = dgvr.Cells["ordItemId"].Value.ToString();
                bool flag = SalerOrderBLL.GetInstance().GetOrderItem(orderItemId);
                if (flag)
                {
                    dgvr.Cells["type"].Value = "0";
                    dgvr.Cells["state"].Value = "匹配成功";
                    dgvr.Cells["EmedProductCode"].Value = "";
                    count++;
                }
                else
                {
                    dgvr.Cells["type"].Value = "1";
                    dgvr.Cells["state"].Value = "匹配失败";
                    dgvr.Cells["EmedProductCode"].Value = "";

                    //DataRow r = this.dtImp.NewRow();
                    ////r["state"] = r["state"].ToString();
                    //r["BUYER_CODE"] = r["BUYER_CODE"].ToString();
                    //r["BUYER_NAME"] = r["BUYER_NAME"].ToString();
                    //r["BUYER_EASY"] = r["BUYER_EASY"].ToString();
                    //r["MEDICAL_CODE"] = r["MEDICAL_CODE"].ToString();
                    //r["MEDICAL_NAME"] = r["MEDICAL_NAME"].ToString();
                    //r["PRODUCT_CODE"] = r["PRODUCT_CODE"].ToString();
                    //r["PRODUCT_NAME"] = r["PRODUCT_NAME"].ToString();
                    //r["MEDICAL_MODE_CODE"] = r["MEDICAL_MODE_CODE"].ToString();
                    //r["MEDICAL_MODE"] = r["MEDICAL_MODE"].ToString();
                    //r["MEDICAL_SPEC_CODE"] = r["MEDICAL_SPEC_CODE"].ToString();
                    //r["MEDICAL_SPEC"] = r["MEDICAL_SPEC"].ToString();
                    //r["SPEC_UNIT_CODE"] = r["SPEC_UNIT_CODE"].ToString();
                    //r["SPEC_UNIT"] = r["SPEC_UNIT"].ToString();
                    //r["FACTORY_CODE"] = r["FACTORY_CODE"].ToString();
                    //r["FACTORY_NAME"] = r["FACTORY_NAME"].ToString();
                    //r["LOT_NO"] = r["LOT_NO"].ToString();
                    //r["RECEIVE_QTY"] = r["RECEIVE_QTY"];
                    //r["INVOICE_NO"] = r["INVOICE_NO"];
                    //r["INVOICE_DATE"] = r["INVOICE_DATE"];
                    //r["INVOICE_TOTAL"] = r["INVOICE_TOTAL"];
                    //r["INVOICE_EXPIRE_DATE"] = r["INVOICE_EXPIRE_DATE"];
                    //r["INVOICE_TRADE_PRICE"] = r["INVOICE_TRADE_PRICE"];
                    //r["INVOICE_RETAIL_PRICE"] = r["INVOICE_RETAIL_PRICE"];
                    //r["READY_REMARK"] = r["READY_REMARK"].ToString();
                    //r["ORD_ITEM_ID"] = r["ORD_ITEM_ID"].ToString();
                    //r["STAND_RATE"] = r["STAND_RATE"];

                    //this.dtImp.Rows.Add(r);
                }
            }
        }

        /// <summary>
        /// 设置发货信息
        /// </summary>
        /// <param name="dgvr"></param>
        /// <param name="result"></param>
        private void setOrderItem(DataGridViewRow dgvr, IList result)
        {
            SalerOrderItemModel model = new SalerOrderItemModel();
            model.ProductId = dgvr.Cells["EmedProductCode"].Value.ToString();
            model.LotNo = dgvr.Cells["LOT_NO"].Value.ToString();
            model.ReceiveQty1 = dgvr.Cells["RECEIVE_QTY"].Value.ToString();
            model.InvoiceNo = dgvr.Cells["INVOICE_NO"].Value.ToString();
            model.InvoiceDate = dgvr.Cells["INVOICE_DATE"].Value.ToString();
            model.InvoiceTotal = dgvr.Cells["INVOICE_TOTAL"].Value.ToString();
            model.InvoiceExpireDate = dgvr.Cells["INVOICE_EXPIRE_DATE"].Value.ToString();
            model.AppNum = dgvr.Cells["PERMIT_NO"].Value.ToString();
            model.InvoiceTradePrice = dgvr.Cells["INVOICE_TRADE_PRICE"].Value.ToString();
            model.InvoiceRetailPrice = dgvr.Cells["INVOICE_RETAIL_PRICE"].Value.ToString();
            model.InvoiceDiscountRate = dgvr.Cells["INVOICE_DISCOUNT_RATE"].Value.ToString();
            model.ReadyRemark = dgvr.Cells["READY_REMARK"].Value.ToString();
            model.ReceiveQty = dgvr.Cells["RECEIVE_QTY"].Value.ToString();
            model.IsChecked = true;
            model.OrderItemState = "1";
            model.RecordId = dgvr.Cells["ordItemId"].Value.ToString();
            result.Add(model);
        }

        private void dgvErpSend_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

        }
        /// <summary>
        /// 获取药品和医院匹配数据
        /// </summary>
        private void setErpSendMapData(out int count)
        {
            count = 0;
            foreach (DataGridViewRow dgvr in dgvErpSend.Rows)
            {
                if (dgvr.Cells["PRODUCT_CODE"].Value == null || dgvr.Cells["PRODUCT_CODE"].Value.ToString() == "")
                {
                    continue;
                }
                string porductCode = "";
                string buyerCode = "";
                if (dgvr.Cells["PRODUCT_CODE"].ValueType == typeof(double))
                {
                    porductCode = int.Parse(dgvr.Cells["PRODUCT_CODE"].Value.ToString()).ToString();
                }
                else
                {
                    porductCode = dgvr.Cells["PRODUCT_CODE"].Value.ToString();
                }
                if (dgvr.Cells["BUYER_CODE"].ValueType == typeof(double))
                {
                    buyerCode = int.Parse(dgvr.Cells["BUYER_CODE"].Value.ToString()).ToString();
                }
                else
                {
                    buyerCode = dgvr.Cells["BUYER_CODE"].Value.ToString();
                }

                string emedProduct = GpoSendBLL.GetInstance().GetProductMapData(porductCode, base.CurrentUserOrgId, out pronum);
                string emedHis = GpoSendBLL.GetInstance().GetCorpMapData(buyerCode, base.CurrentUserOrgId, out cropnum);

                if (int.Parse(pronum.ToString()) > 1)
                {
                    dgvr.Cells["product_code"].Style.SelectionForeColor = Color.Red;
                    dgvr.Cells["product_code"].Style.ForeColor = Color.Red;
                    count++;
                }
                if (string.IsNullOrEmpty(emedProduct))
                {
                    if (string.IsNullOrEmpty(emedHis))
                    {
                        dgvr.Cells["type"].Value = "1";
                        dgvr.Cells["state"].Value = "药品和买方未匹配";
                    }
                    else
                    {
                        dgvr.Cells["type"].Value = "2";
                        dgvr.Cells["state"].Value = "药品未匹配";
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(emedHis))
                    {
                        dgvr.Cells["type"].Value = "3";
                        dgvr.Cells["state"].Value = "买方未匹配";
                    }
                    else if (!emedHis.Equals(BuyerOrgid))
                    {
                        dgvr.Cells["type"].Value = "4";
                        dgvr.Cells["state"].Value = "买方信息不对应";
                    }
                    else
                    {
                        dgvr.Cells["type"].Value = "0";
                        dgvr.Cells["state"].Value = "匹配成功";
                        dgvr.Cells["EmedProductCode"].Value = emedProduct;
                    }
                }
            }
        }

        private void btnAddProductMap_Click(object sender, EventArgs e)
        {
            //int i = 0;
            //foreach (DataGridViewRow dgvr in dgvErpSend.Rows)
            //{
            //    if (dgvr.Cells["PRODUCT_CODE"].Value == null || dgvr.Cells["PRODUCT_CODE"].Value.ToString() == "")
            //    {
            //        continue;
            //    }
            //    if (dgvr.Cells["type"].Value.Equals("1") || dgvr.Cells["type"].Value.Equals("2"))
            //    {
            //        ProductCropModel model = setProduct(dgvr);
            //        //ProxyFactory.ErpSendRemote.AddProductMap(model);
            //        new GpoSendBLL().AddProductMap(model);
            //        i++;
            //    }
            //}
            //if (i > 0)
            //{
            //    MessageBox.Show(i.ToString() + "条药品加入成功，请进入药品匹配功能进行匹配！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

        }
        private ProductCropModel setProduct(DataGridViewRow dgvr)
        {
            ProductCropModel model = new ProductCropModel();
            model.Code = getDgvData(dgvr.Cells["PRODUCT_CODE"]);
            model.Name = dgvr.Cells["PRODUCT_NAME"].Value.ToString();
            model.ModeName = getDgvData(dgvr.Cells["MEDICAL_MODE"]);
            model.SpecName = getDgvData(dgvr.Cells["MEDICAL_SPEC"]);
            model.SpecUnit = getDgvData(dgvr.Cells["SPEC_UNIT"]);
            model.ProducerCode = getDgvData(dgvr.Cells["FACTORY_CODE"]);
            model.Producer = getDgvData(dgvr.Cells["FACTORY_NAME"]);
            model.BuyerID = base.CurrentUserOrgId;

            return model;
        }

        private string getDgvData(DataGridViewCell dgvc)
        {
            string value = "";
            if (dgvc.ValueType == typeof(double))
            {
                value = int.Parse(dgvc.Value.ToString()).ToString();
            }
            else
            {
                value = dgvc.Value.ToString();
            }
            return value;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            if (dgvErpSend.CurrentRow != null)
            {
                if (dgvErpSend.CurrentRow.Cells["PRODUCT_CODE"].Value != null && dgvErpSend.CurrentRow.Cells["PRODUCT_CODE"].Value.ToString().Trim() != "")
                {
                    SelectExpSendItem expitem = new SelectExpSendItem(dgvErpSend.CurrentRow.Cells["PRODUCT_CODE"].Value.ToString().Trim());
                    expitem.ShowDialog();
                    if (expitem.row != null)
                        changeExpSendItem(expitem.row);
                }
            }
        }

        private void changeExpSendItem(DataRow row)
        {
            DataGridViewRow dr = dgvErpSend.CurrentRow;
            dr.Cells["PRODUCT_NAME"].Value = row["PRODUCT_NAME"];
            dr.Cells["MEDICAL_MODE"].Value = row["MODE_NAME"];
            dr.Cells["MEDICAL_SPEC"].Value = row["MEDICAL_SPEC"];
            dr.Cells["SPEC_UNIT"].Value = row["SPEC_UNIT"];
            dr.Cells["FACTORY_CODE"].Value = row["FACTORY_CODE"];
            dr.Cells["FACTORY_NAME"].Value = row["FACTORY_NAME"];
            try
            {
                dr.Cells["LOT_NO"].Value = double.Parse(row["PERMIT_NO"].ToString()); ;
            }
            catch (Exception e)
            {
                dr.Cells["LOT_NO"].Value = DBNull.Value;
            }
            dr.Cells["EmedProductCode"].Value = row["product_id"];
        }
        private void dgvErpSend_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvErpSend.CurrentRow != null && dgvErpSend.CurrentCell != null)
            {
                if (dgvErpSend.CurrentRow.Cells["product_code"].Style.ForeColor == Color.Red)
                {
                    btnselect.Visible = true;
                    string pcode = dgvErpSend.CurrentRow.Cells["PRODUCT_CODE"].Value.ToString().Trim();
                    if (pcode != "")
                    {
                        showMenu(pcode);
                    }
                    lbmess.Text = "＊产品编码对应多条数据，请点击查看或右键选择一条！";
                }
                else
                {
                    btnselect.Visible = false;
                    cms.Close();
                    if (count > 0)
                        lbmess.Text = "有" + count.ToString() + "个产品编码（显示为红色）对应的产品不唯一！";
                }
                if (dgvErpSend.CurrentRow.Cells["PRODUCT_CODE"].Value == null || dgvErpSend.CurrentRow.Cells["PRODUCT_CODE"].Value.ToString().Trim() == "")
                {
                    btnselect.Visible = false;
                    cms.Close();
                    if (count > 0)
                        lbmess.Text = "有" + count.ToString() + "个产品编码（显示为红色）对应的产品不唯一！";
                }
            }
            else
            {
                lbmess.Visible = false;
                btnselect.Visible = false;
                cms.Close();
                if (count > 0)
                    lbmess.Text = "有" + count.ToString() + "个产品编码（显示为红色）对应的产品不唯一！";
            }
        }

        ContextMenuStrip cms = new ContextMenuStrip();
        DataTable dt;
        private void showMenu(string procode)
        {
            //dt = ProxyFactory.ErpSendRemote.GetErpProductByProcode(procode, base.CurrentUserOrgId);
            dt = GpoSendBLL.GetInstance().GetErpProductByProcode(procode, base.CurrentUserOrgId);

            cms.ShowImageMargin = false;
            cms.Items.Clear();
            cms.DropShadowEnabled = true;
            string str = "";
            foreach (DataRow dr in dt.Rows)
            {
                str = "产品名称：" + dr["PRODUCT_NAME"].ToString().Trim() + " 剂型：" + dr["MODE_NAME"].ToString().Trim() + " 规格：" + dr["MEDICAL_SPEC"].ToString().Trim() + " 包装单位：" + dr["SPEC_UNIT"].ToString().Trim() + " 生产企业：" + dr["FACTORY_NAME"].ToString().Trim() + " 批号：" + dr["PERMIT_NO"].ToString().Trim();
                cms.Items.Add(str);
                cms.ItemClicked += new ToolStripItemClickedEventHandler(cms_ItemClicked);
            }
        }

        void cms_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int itemindex = cms.Items.IndexOf(e.ClickedItem);
            changeExpSendItem(dt.Rows[itemindex]);
        }

        private void dgvErpSend_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && btnselect.Visible == true)
                if (dgvErpSend.CurrentCellAddress.Y == e.RowIndex)
                    cms.Show(MousePosition.X - 20, MousePosition.Y + 15);
        }
        /// <summary>
        /// 获取导入的发货列表
        /// </summary>
        /// <returns></returns>
        private DataTable GetImportTable()
        {
            string sql = FileOperation.GetNodeObject(EmedFunc.GetLocalPersonCfgPath() + @"\GpoOrderSend.xml", "Config/Sqls/Sql").InnerText;
            return GpoSendDao.GetInstance().GetErpSend(sql);
        }

    }
}