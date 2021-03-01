//======================================================================================
//	Copyright (c)  Emedchina
//	文 件 名:	SalerOrderList.cs  
//	创 建 人:	曹杰
//	创建日期:	2007-1-18
//	功能描述:	订单处理主页面
//	修 改 人: 
//	修改日期:
//	主要修改内容:
//=====================================================================================
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using Emedchina.TradeAssistant.Client.Common;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Model.Order.SalerOrder;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Client.Map.Product;
using Emedchina.TradeAssistant.Client.Map.Hospital;
using Emedchina.TradeAssistant.Client.BLL.Order.SalerOrder;
using Emedchina.TradeAssistant.Client.BLL.Gpo;
using Emedchina.TradeAssistant.Client.DAL.Gpo;

namespace Emedchina.TradeAssistant.Client.Order.OrderSaler
{
    public partial class SalerOrderList : MainFormBase
    {
        bool DealFlg = false;
        private DataTable dtList;
        private bool offlineFlag;
        /// <summary>
        /// 构造
        /// </summary>
        public SalerOrderList()
        {
            InitializeComponent();
            offlineFlag = ClientConfiguration.IsOffline;
        }

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetSalerOrderList(); 
        }

        /// <summary>
        /// 取得订单列表
        /// </summary>
        public void GetSalerOrderList()
        {
            if (!offlineFlag)
            {
                int rows;
                DataTable dt = ProxyFactory.SalerOrderProxy.getSalerOrderList(getSearchKey(), out rows);
                //绑定数据源
                this.orderListBindingSource.DataSource = dt;
                pageNavigator1.ItemCount = rows;
            }
            else
            {
                DataTable dt = SalerOrderBLL.GetInstance().getSalerOrderList(base.CurrentUserOrgId);
                dtList = dt;
                string sFilter = GetFilter();
                dt.DefaultView.RowFilter = sFilter;
                InitFromCacheByData(dt);
                //绑定数据源
                this.orderListBindingSource.DataSource = base.gridDataView;
                pageNavigator1.ItemCount = base.cachedDataView.Count;
            }
            
            
            this.NoVisibleBtn();
            this.dgvSalerOrderList.Select();
        }
        /// <summary>
        /// 加载页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SalerOrderList_Load(object sender, EventArgs e)
        {
            InitComboBox.InitOrderState(this.cmbItemState);
            //InitComboBox.InitOrderType(this.cmbOrderType);
            InitComboBox.InitType(this.cmbType);
            this.dtEndDate.Value = DateTime.Now;
            this.dtStartDate.Value = DateTime.Now.AddMonths(-3);
            this.NoVisibleBtn();
            this.AdjustCellStyle();
            btnSearch.Select();
            btnSearch_Click(sender, e);
        }

        /// <summary>
        /// 自动调整列表的样子格式
        /// </summary>
        private void AdjustCellStyle()
        {
            DataGridViewCellStyle currencyCellStyle = new DataGridViewCellStyle();
            currencyCellStyle.Format = "N";
            this.dgvSalerOrderList.Columns["address"].Width = Convert.ToInt16(this.dgvSalerOrderList.Width * 0.2);
            this.dgvSalerOrderList.Columns["BAK_BUYER_NAME"].Width = Convert.ToInt16(this.dgvSalerOrderList.Width*0.2);
            this.dgvSalerOrderList.Columns["sendTime"].Width = Convert.ToInt16(this.dgvSalerOrderList.Width * 0.15);
            this.dgvSalerOrderList.Columns["REQUEST_TOTAL"].Width = Convert.ToInt16(this.dgvSalerOrderList.Width * 0.15);
            this.dgvSalerOrderList.Columns["ORDER_STATE_NAME"].Width = Convert.ToInt16(this.dgvSalerOrderList.Width * 0.15);
           
        }

        /// <summary>
        /// 显示处理与否
        /// </summary>
        private void NoVisibleBtn()
        {
            if (this.dgvSalerOrderList.Rows.Count > 0)
            {
                this.btnDealWith.Enabled = true;
            }
            else
            {
                this.btnDealWith.Enabled = false;
            }
        }

        #region 取得检索条件
        /// <summary>
        /// 取得检索条件
        /// </summary>        
        private SalerOrderListModel getSearchKey()
        {
            //检索条件
            SalerOrderListModel model = new SalerOrderListModel();

            model.Order_state = this.cmbItemState.SelectedValue.ToString();
            //model.Order_type = this.cmbOrderType.SelectedValue.ToString();
            //model.Medical_name = this.txtProductName.Text;

            switch (cmbType.SelectedValue.ToString())
            {
                case "1":
                    model.BuyerName = StringUtils.repalceSepStr(this.txtName.Text.ToString());
                    break;

                case "2":
                    model.OrderCode = StringUtils.repalceSepStr(this.txtName.Text.ToString());
                    break;
            }

            if (this.dtStartDate.Checked == true)
            {
                model.StartDate = ComUtil.formatDate(this.dtStartDate.Text.ToString());
            }
            else
            {
                model.StartDate = null;
            }
            if (this.dtEndDate.Checked == true)
            {
                model.EndDate = ComUtil.formatDate(this.dtEndDate.Text.ToString());
            }
            else
            {
                model.EndDate = null;
            }
            model.OrgId = this.CurrentUserOrgId;
            model.AreaList = this.CurrentUserAreaList;
            model.IsFactory = this.CurrentUserIsFactory;
            model.UserId = this.CurrentUserId;
            model.PageNum = this.pageNavigator1.CurrentPageIndex;
            model.PageSize = this.pageNavigator1.PageSize;
            return model;
        }
        #endregion

        /// <summary>
        /// 处理按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDealWith_Click(object sender, EventArgs e)
        {
            
            string orderId = this.dgvSalerOrderList.CurrentRow.Cells["order_id"].Value.ToString();
            string state = this.dgvSalerOrderList.CurrentRow.Cells["orderState"].Value.ToString();
            //string type = this.dgvSalerOrderList.CurrentRow.Cells["SWITCH_FLAG"].Value.ToString();
            if (!DealFlg)
            {
                SalerOrderItemList frm = new SalerOrderItemList(orderId,state,this);
                frm.ShowDialog();
            }
            else
            {
                SalerOrderItemList frm = new SalerOrderItemList(orderId, true,this);
                frm.ShowDialog();
            }
            
        }

        /// <summary>
        /// 关闭按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// 打印按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //OrderItemListPrint frm;
            //if (!offlineFlag)
            //{
            //    DataTable dt = (DataTable)orderListBindingSource.DataSource;
            //    frm = new OrderListPrint(dt, "订单列表", this.CurrentUserName);
            //}
            //else
            //{
            //    frm = new OrderListPrint(dtList, "订单列表", this.CurrentUserName);
            //}
            
            //frm.ShowDialog();
        }


        private void dtEndDate_CloseUp(object sender, EventArgs e)
        {
            this.dtEndDate.Format = DateTimePickerFormat.Long; 
        }

        private void dtStartDate_CloseUp(object sender, EventArgs e)
        {
            this.dtStartDate.Format = DateTimePickerFormat.Long;
        }

        private void dgvSalerOrderList_RowEnter(object sender, DataGridViewCellEventArgs e)
        {            
            if (dgvSalerOrderList.Rows.Count == 0)
            {
                return;
                //btnSearch.Select();
            }
            if (dgvSalerOrderList.Rows[e.RowIndex].Cells["ORDER_STATE_NAME"].Value != null)
            {

                if (dgvSalerOrderList.Rows[e.RowIndex].Cells["ORDER_STATE_NAME"].Value.ToString().Equals("完成"))
                {
                    btnDealWith.Text = "查看(&V)";
                    DealFlg = true;
                    //btnDealWith.Select();
                }
                else
                {
                    btnDealWith.Text = "处理(&D)";
                    DealFlg = false;
                    //btnDealWith.Select();
                }
            }
            else
            {
                if (dgvSalerOrderList.Rows[0].Cells["ORDER_STATE_NAME"].Value != null)
                {
                    if (dgvSalerOrderList.Rows[0].Cells["ORDER_STATE_NAME"].Value.ToString().Equals("完成"))
                    {
                        btnDealWith.Text = "查看(&V)";
                        DealFlg = true;
                        //btnDealWith.Select();
                    }
                    else
                    {
                        btnDealWith.Text = "处理(&D)";
                        DealFlg = false;
                        //btnDealWith.Select();
                    }
                }
            }
        }

        private void dgvSalerOrderList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }

        private void pageNavigator1_PageIndexOrPageSizeChanged(object source, Emedchina.Commons.WinForms.PageChangedEventArgs e)
        {
            if (!offlineFlag)
            {
                SearchReturnList();
            }
            else
            {
                this.InitGridTableView(pageNavigator1.CurrentPageIndex, pageNavigator1.PageSize);
                orderListBindingSource.DataSource = base.gridDataView;
                this.pageNavigator1.ItemCount = base.cachedDataView.Count;
            }
        }


        /// <summary>
        /// 查询并绑定退货单列表
        /// </summary>
        private void SearchReturnList()
        {
            int rows;
            DataTable dt = ProxyFactory.SalerOrderProxy.getSalerOrderList(getSearchKey(), out rows);
            this.orderListBindingSource.DataSource = dt;
            pageNavigator1.ItemCount = rows;
        }

        private void SalerOrderList_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                dgvSalerOrderList.Select();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                btnSearch.Select();
                btnSearch_Click(sender, e);
            }
        }

        /// <summary>
        /// 回车键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSalerOrderList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDealWith_Click(sender, e);
            }            
        }

        /// <summary>
        /// 双击处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSalerOrderList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSalerOrderList.CurrentRow.Index >= 0)
            {
                btnDealWith_Click(sender, e);
            }
        }
        /// <summary>
        /// 订单导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExpOrder_Click(object sender, EventArgs e)
        {
            int iCount = 0;
            string sOrderID = string.Empty;//订单ID            
            string sOrgID = base.CurrentUserOrgId;//卖方机构ID
            if (this.dgvSalerOrderList.CurrentRow == null)
            {
                MessageBox.Show("请选择订单！" , "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.dgvSalerOrderList.CurrentRow.Cells["order_id"].Value != null)
                sOrderID = this.dgvSalerOrderList.CurrentRow.Cells["order_id"].Value.ToString();
            //JudgeCropDataList(sOrderID, sOrgID);
            //判断是否有未匹配的数据

            //"导出采购订单"判断业务流程("进销存"企业对接功能)，shangfu 2007-8-24
            //如果为1就是进销存对接接口     

            string clientPlat = UserConfigXml.GetConfigInfo("ClientPlat", "type");

            if (IfHasNotMapData(sOrderID, sOrgID) && !clientPlat.Equals("1"))
            {
                MessageBox.Show("存在未匹配数据，导出失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
               
                //DataTable mapdt = ProxyFactory.ErpSendRemote.GetOrderExpData(orderid);

                DataTable mapdt = GpoSendBLL.GetInstance().GetOrderExpData(sOrderID, base.CurrentUserOrgId,clientPlat);
                DataTable dt = new DataTable();

                //"导出采购订单"判断业务流程("进销存"企业对接功能)，shangfu 2007-8-29
                if ("1".Equals(clientPlat))
                {

                    if (mapdt == null || mapdt.Rows.Count == 0) return;
                    dt = mapdt.DefaultView.ToTable().Copy();
                   
                    
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("导出失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
                else
                {
                    if (mapdt == null || mapdt.Rows.Count == 0) return;
                    mapdt.DefaultView.RowFilter = " productid is not null";                   
                    dt = mapdt.DefaultView.ToTable().Copy();
                    mapdt.DefaultView.RowFilter = " productid is null";

                }

                iCount = mapdt.DefaultView.Count;
                IList result = new ArrayList();

                foreach (DataColumn dc in dt.Columns)
                {
                    string newColName = getMapColName(dc.ColumnName.ToUpper());
                    if (!string.IsNullOrEmpty(newColName))
                    {
                        dc.ColumnName = newColName;
                    }
                    else
                    {
                        result.Add(dc.ColumnName);
                    }
                }
                for (int i = 0; i < result.Count; i++)
                {
                    dt.Columns.Remove(result[i].ToString());
                }
                string str = "";
                /******************************************************************
               * 
               * 修改时间：2007-3-21  
               * 修改人：ningbo   
               * 修改原因：
               * 新增代码：EmedFunc.GetLocalPersonCfgPath()+"GpoOrderExport.xml"
               * 
               ******************************************************************/
                string strCurrentDB = FileOperation.GetNodeValue(FileOperation.GetNodeObject(EmedFunc.GetLocalPersonCfgPath() + @"/GpoOrderExport.xml", "Config/DestDB"), "DBType");
                this.saveFileDialog1.FilterIndex = 1;
                saveFileDialog1.Title = "保存文件为";
                saveFileDialog1.InitialDirectory = Application.StartupPath;
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.FileName = "ORD" + dgvSalerOrderList.CurrentRow.Cells["ORDER_CODE"].Value.ToString();
                if (strCurrentDB.Equals("EXCEL"))
                {
                    this.saveFileDialog1.Filter = "Excel文档(*.xls)|*.xls";
                    if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
                    {
                        str = saveFileDialog1.FileName;
                        bool flg = FileOperation.ExportExcelFile(dt, str);
                        if (flg)
                        {
                            string mess = "";
                            if (iCount > 0)
                                mess = "有" + iCount.ToString() + "条数据未被导出";
                            MessageBox.Show("导出完毕！" + mess, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                //导出订单到SQLServer
                else if (strCurrentDB.Equals("SQLSERVER"))
                {
                    bool flag = false;
                    try
                    {
                        //获得SQLServer服务数据
                        string server = FileOperation.GetNodeValue(FileOperation.GetNodeObject(EmedFunc.GetLocalPersonCfgPath() + @"/GpoOrderExport.xml", "Config/DestDB"), "ServerName");
                        string database = FileOperation.GetNodeValue(FileOperation.GetNodeObject(EmedFunc.GetLocalPersonCfgPath() + @"/GpoOrderExport.xml", "Config/DestDB"), "DataBase");
                        string user = FileOperation.GetNodeValue(FileOperation.GetNodeObject(EmedFunc.GetLocalPersonCfgPath() + @"/GpoOrderExport.xml", "Config/DestDB"), "User");
                        string password = SecretUtil.DeSecret(FileOperation.GetNodeValue(FileOperation.GetNodeObject(EmedFunc.GetLocalPersonCfgPath() + @"/GpoOrderExport.xml", "Config/DestDB"), "Password"));

                        //获得表明
                        string tableName = FileOperation.GetNodeValue(FileOperation.GetNodeObject(EmedFunc.GetLocalPersonCfgPath() + @"/GpoOrderExport.xml", "Config/DestDB/DestTable"), "TableName");

                        //导出操作
                        flag = GpoSendDao.ExportErpToMSS(tableName, GetConString(server, database, user, password), dt);

                    }
                    catch
                    {
                        flag = false;
                    }
                    if (flag)
                    {
                        string mess = "";
                        if (iCount > 0)
                            mess = "有" + iCount.ToString() + "条数据未被导出";
                        MessageBox.Show("导出完毕！" + mess, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("导出失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }             
            }
        }
        /// <summary>
        /// 发货导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnErpSend_Click(object sender, EventArgs e)
        {
            GpoSend frm = new GpoSend();
            //组织订单ID和SWITCH_FLAG
            if (this.dgvSalerOrderList.CurrentRow != null)
            {
                frm.OrderId = this.dgvSalerOrderList.CurrentRow.Cells["order_id"].Value.ToString();
                //frm.Flag = this.dgvSalerOrderList.CurrentRow.Cells["SWITCH_FLAG"].Value.ToString();
                if (this.dgvSalerOrderList.CurrentRow.Cells.Contains(dgvSalerOrderList.CurrentRow.Cells["BUYER_ORGID"]))
                    frm.BuyerOrgid = this.dgvSalerOrderList.CurrentRow.Cells["BUYER_ORGID"].Value.ToString();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("请选择订单！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        /// <summary>
        /// 判断是否有未匹配的数据
        /// </summary>
        /// <param name="sOrderID"></param>
        /// <param name="sOrgID"></param>
        /// <returns></returns>
        private bool IfHasNotMapData(string sOrderID, string sOrgID)
        {
            bool bHasNotMap = false;
            DataTable dtCrop = new DataTable();
            DataTable dtProd = new DataTable();
            dtCrop = SalerOrderBLL.GetInstance().GetNotMapCorp(sOrderID, sOrgID);
            dtProd = SalerOrderBLL.GetInstance().GetNotMapProd(sOrderID, sOrgID);
            if (dtCrop.Rows.Count > 0 || dtProd.Rows.Count> 0)
            {
                bHasNotMap = true;
            }
            return bHasNotMap;
        }
        /// <summary>
        /// 判断订单中未匹配的产品和企业
        /// </summary>
        /// <param name="sOrderID"></param>
        /// <param name="sOrgID"></param>
        //private void JudgeCropDataList(string sOrderID, string sOrgID)
        //{
        //    DataTable dtCrop = new DataTable();
        //    DataTable dtProd = new DataTable();
        //    dtCrop = SalerOrderBLL.GetInstance().GetNotMapCorp(sOrderID, sOrgID);
        //    if (dtCrop.Rows.Count > 0)
        //    {
        //        FormCropMapExp formexpmap = new FormCropMapExp(dtCrop);
        //        formexpmap.ShowDialog();
        //    }
        //    dtProd = SalerOrderBLL.GetInstance().GetNotMapProd(sOrderID, sOrgID);
        //    if (dtProd.Rows.Count > 0)
        //    {
        //        FormProMapExp formpromap = new FormProMapExp(dtProd);
        //        formpromap.ShowDialog();
        //    }


        //}
        
        /// <summary>
        /// 获取对应的列名
        /// </summary>
        /// <param name="colName"></param>
        /// <returns></returns>
        private string getMapColName(string colName)
        {
            string result;
            /******************************************************************
           * 
           * 修改时间：2007-3-21  
           * 修改人：ningbo   
           * 修改原因：
           * 新增代码：EmedFunc.GetLocalPersonCfgPath()+"GpoOrderSend.xml"
           * 
           ******************************************************************/
            XmlNodeList nodeList = FileOperation.GetNodeObject(EmedFunc.GetLocalPersonCfgPath() + @"/GpoOrderExport.xml", "Config/ContrastList").ChildNodes;

            foreach (XmlNode xn in nodeList)
            {
                XmlElement xe = (XmlElement)xn;
                if (colName.Equals(xe.GetAttribute("SourceField").ToUpper()))
                {
                    if (!string.IsNullOrEmpty(xe.GetAttribute("DestField")))
                    {
                        return xe.GetAttribute("DestField");
                    }
                }


            }
            return "";
        }
        /// <summary>
        /// 组织SQLSERVER连接字符串
        /// </summary>
        /// <param name="strServer"></param>
        /// <param name="strDataBase"></param>
        /// <param name="strUsr"></param>
        /// <param name="strPwd"></param>
        /// <returns></returns>
        private string GetConString(string strServer, string strDataBase, string strUsr, string strPwd)
        {
            string strCon = "";

            strCon = "server=" + strServer + ";database=" + strDataBase + ";user id=" + strUsr + ";password=" + strPwd;

            return strCon;
        }
        /// <summary>
        /// 获取过滤条件
        /// </summary>
        /// <returns></returns>
        private string GetFilter()
        {
            StringBuilder sFilter = new StringBuilder();

            sFilter.Append(" 1=1 ");         

            string sOrder_State = this.cmbItemState.SelectedValue.ToString();

            string dtStar = dtStartDate.Checked ? this.dtStartDate.Value.ToLongDateString(): "";
            string dtEnd = dtEndDate.Checked? this.dtEndDate.Value.AddDays(1).ToLongDateString():"";
            string sType = this.cmbType.SelectedValue.ToString();
            string sTypeValue = StringUtils.repalceSepStr(this.txtName.Text.ToString());
            bool isfactory = this.CurrentUserIsFactory;
            string AreaList = this.CurrentUserAreaList;
            string UserId = this.CurrentUserId;

            if (!string.IsNullOrEmpty(sOrder_State))
            {
                if (sOrder_State.Equals("-1"))
                {
                    sFilter.Append("and order_state <> '3' ");
                }
                else
                {
                    sFilter.Append("and order_state = '").Append(sOrder_State).Append("' ");
                }
            }         
            if (!string.IsNullOrEmpty(sTypeValue))
            {
                //买方企业
                if (sType.Equals( "1"))
                {
                    sFilter.AppendFormat(" and (BAK_BUYER_NAME like '%{0}%' or BAK_BUYER_EASY like '%{0}%' or BAK_BUYER_FAST like '%{0}%' or BAK_BUYER_WUBI LIKE '%{0}%')", sTypeValue.ToUpper());
                }
                else
                {
                    sFilter.AppendFormat(" AND ORDER_CODE  LIKE '%{0}%'", sTypeValue);

                }
            }
            if (!string.IsNullOrEmpty(dtStar))
                sFilter.AppendFormat(" AND CREATE_DATE >= '{0}'", dtStar);
            if (!string.IsNullOrEmpty(dtEnd))
                sFilter.AppendFormat(" AND CREATE_DATE < '{0}'", dtEnd);
            if (!isfactory)
            {
                sFilter.AppendFormat(" and area_id in (").Append(AreaList).Append(")");
            }
            else
            {

                if (SalerOrderBLL.GetInstance().isfactory(UserId))
                {
                    sFilter.AppendFormat(" and area_id in (").Append(AreaList).Append(")");
                }
            }
            return sFilter.ToString();
        }
    }
}