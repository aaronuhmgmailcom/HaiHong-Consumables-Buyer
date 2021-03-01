/*****************************************************************************
创 建 人:	yb
创建日期:	2007-5-14
功能描述:	到货信息显示
 ****************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Client.Base;
using Emedchina.TradeAssistant.Client.DAL.Query;
using Emedchina.TradeAssistant.Client.Common;
using System.IO;
using System.Xml;
using DevExpress.XtraEditors;
using DevExpress.Utils;
namespace Emedchina.TradeAssistant.Client.UI.TradeManage.DoWithOrder
{
    public partial class OutOrderReceive : BaseForm
    {
        private DataTable dtReceive = null;
        private DataTable dttmp = null;
        public OutOrderReceive()
        {
            InitializeComponent();
        }

        #region 页面加载
        private void OutOrderReceive_Load(object sender, EventArgs e)
        {
            dtStartDate.EditValue = DateTime.Now.AddMonths(-1);
            dtEndDate.EditValue = DateTime.Now;
            SearchReceiveData();
            Filter();
        }
        #endregion

      
        #region 查询到货信息
        /// <summary>
        /// 查询到货信息
        /// </summary>
        private void SearchReceiveData()
        {
            //获取查询条件
            UserInfo usr = new UserInfo();
            usr.AreaId = base.CurrentUserSingleRegionId;
            usr.OrgId = base.CurrentUserRegOrgId;
            //string startDate = ComUtil.formatDate(this.dtStartDate.Text);
            //string endDate = ComUtil.formatDate(this.dtEndDate.Value.AddDays(1).ToString());

            string startDate =  ComUtil.formatDate(this.dtStartDate.Text) ;
            string endDate =  ComUtil.formatDate(this.dtEndDate.Text) ;

            string medicalName = this.txtmedicalName.Text.Trim();
            string salerName = this.txtSalerName.Text.Trim();
           
            

            //获取查询数据集
            //dtReceive = OutOrderReceiveDao.GetInstance().GetOrderReceive(usr, startDate, endDate, medicalName, salerName);
            dtReceive = OutOrderReceiveDao.GetInstance().GetOrderReceive(usr);
            InitFromCacheByData(dtReceive);

            
            this.cachedDataView.Sort = " ID desc ";

            this.bindingSource1.DataSource = dtReceive.DefaultView;
        }
        #endregion

        #region 翻页事件
        private void pageNavigator1_PageIndexOrPageSizeChanged(object source, Emedchina.Commons.WinForms.PageChangedEventArgs e)
        {
           
        }
        #endregion

        #region 查询按钮事件
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchReceiveData();
            Filter();
        }
        #endregion

        #region 关闭
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 导出到货信息接口
        private void btnAllExport_Click(object sender, EventArgs e)
        {
            bool flag = true;

            if (this.gridView3.RowCount == 0)
            {
                XtraMessageBox.Show("无可操作记录！", Constant.MsgTitle, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
                return;
            }

            string strCurrentDB = FileOperation.GetNodeValue(FileOperation.GetNodeObject(EmedFunc.GetLocalPersonCfgPath() + @"/HisOrderReceive.xml", "Config/DestDB"), "DBType");

            if (strCurrentDB.Equals("EXCEL"))
            {
                //选择导出文件
                string ExpFilePath = this.SelectExportFile();

                if (ExpFilePath.Length == 0)
                    return;

                try
                {
                    //dttmp = (DataTable)(this.bindingSource1.List[0]);

                    DataRow[] drArray = dtReceive.DefaultView.Table.Select(dtReceive.DefaultView.RowFilter,
                    dtReceive.DefaultView.Sort,
                    dtReceive.DefaultView.RowStateFilter);

                    dttmp = dtReceive.DefaultView.Table.Clone();
                    foreach (DataRow dr in drArray)
                    {
                        dttmp.Rows.Add(dr.ItemArray);   
                    }
                    //原代码全导出无法查询导出
                    //flag = OutOrderReceiveDao.GetInstance().ExportReceive(ExpFilePath, dtReceive);
                    //修改后
                    flag = OutOrderReceiveDao.GetInstance().ExportReceive(ExpFilePath, dttmp);
                    if (flag)
                    {
                        XtraMessageBox.Show("导出到货信息文件成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
              
                        
                    }
                    else
                    {
 
                        XtraMessageBox.Show("导出到货信息文件失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              
                        return;
                    }

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("导出到货信息文件出错！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              
                    return;
                }
            }

            string receiveIdstr = string.Empty;
            string receiveHisIdstr = string.Empty;

            foreach (DataRow dr in dtReceive.Rows)
            {
                if (dr["TYPE"].ToString().Equals("1"))
                {
                    receiveIdstr += "'" + dr["ID"].ToString() + "',";
                }
                else
                {
                    receiveHisIdstr += "'" + dr["ID"].ToString() + "',";
                }
            }

            //OutOrderReceiveDao.GetInstance().UpdateOrderReceive(receiveIdstr, receiveHisIdstr);

        }

        /// <summary>
        /// 设定导出文件
        /// </summary>
        /// <returns></returns>
        private string SelectExportFile()
        {
            string tmpPath = "";
            try
            {
                this.saveFileDialog1.Filter = "Excel文件(*.xls)|*.xls|dbf文件(*.dbf)|*.dbf|文本文件(*.txt)|*.txt|所有文件 (*.*)|*.*";

                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (this.saveFileDialog1.FileName == "")
                    {

                        XtraMessageBox.Show("请设置到货导出文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              
                        return "";
                    }
                    return this.saveFileDialog1.FileName;
                }
            }
            catch (Exception e)
            {
                tmpPath = "";
            }
            return tmpPath;

        }
        #endregion

        private void txtmedicalName_EditValueChanged(object sender, EventArgs e)
        {
            Filter();
        }


        /// <summary>
        /// 查询过滤方法
        /// </summary>
        private void Filter()
        {
            string strCode = this.txtmedicalName.Text.Trim();
            string strSearchKey = this.txtSalerName.Text.Trim();

            string strStartDate = this.dtStartDate.DateTime.ToShortDateString();
            string strEndDate = this.dtEndDate.DateTime.ToShortDateString();

            StringBuilder StrFilter = new StringBuilder();

            StrFilter.Append(" 1=1");


            //品名
            if (!string.IsNullOrEmpty(strCode))
            {
                StrFilter.AppendFormat(" AND cpmc2 LIKE '%{0}%' or product_name LIKE '%{0}%'", strCode);
            }

            //企业
            if (!string.IsNullOrEmpty(strSearchKey))
            {
                StrFilter.AppendFormat(" AND (seller_name LIKE '%{0}%' or seller_shortname LIKE '%{0}%')", strSearchKey);
            }

            //开始时间
            if (!string.IsNullOrEmpty(strStartDate))
            {
                StrFilter.AppendFormat(" AND receive_date_short >= '{0}'", strStartDate + " 00:00:00");
            }

            //结束时间
            if (!string.IsNullOrEmpty(strEndDate))
            {
                StrFilter.AppendFormat(" AND receive_date_short <= '{0}'", strEndDate + " 23:59:59");
            }

            if (dtReceive != null)
            {
                dtReceive.DefaultView.RowFilter = StrFilter.ToString();
                this.bindingSource1.DataSource = null;
                this.bindingSource1.DataSource = dtReceive.DefaultView;
            }

        }

        private void txtSalerName_EditValueChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void dtStartDate_EditValueChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void dtEndDate_EditValueChanged(object sender, EventArgs e)
        {
            Filter();
        }

        private void toolTipLocationControl_ToolTipLocationChanged(string senderName)
        {
            ToolTipControllerShowEventArgs args = toolTipController1.CreateShowArgs();
            args.ToolTip = senderName;
            args.IconType = ToolTipIconType.Information;
            args.ImageIndex = -1;
            args.IconSize = ToolTipIconSize.Small;
            toolTipController1.ShowHint(args);
        }

        private void gridView3_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            if (dr != null)
            {
                if (gridView3.FocusedColumn.FieldName == "seller_shortname")
                    toolTipLocationControl_ToolTipLocationChanged(dr["seller_name"].ToString());

            }


        }

        private void OutOrderReceive_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
            {
                this.Close();
            }
        }

    }
}