using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Emedchina.Commons;
using Emedchina.TradeAssistant.Model.User;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using System.Web.UI.WebControls;

namespace Emedchina.TradeAssistant.Client.Base
{
    public partial class BaseForm : DevExpress.XtraEditors.XtraForm
    {
        public BaseForm()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }


        protected DataTable newsTable;
        protected DataTable gridTable;
        protected DataView cachedDataView;
        protected DataView gridDataView;
        private static readonly int defaultPageSize = 20;
        private ComBase comBase = new ComBase();
        protected LogedInUser user;

        /// <summary>
        /// 设置金额的小数位数
        /// </summary>
        /// <param name="numText">必须是数值</param>
        /// <returns></returns>
        protected string SetNumFormat(string numText)
        {
            string val;
            string formatStr;
            int points = int.Parse(ClientConfiguration.DotSetting);
            if (points == 0)
                formatStr = "##,##0";
            else
                formatStr = "##,##0." + "0".PadLeft(points, '0');

            val = double.Parse(numText).ToString(formatStr);
            return val;
        }
        /// <summary>
        /// 设置小数点位数
        /// 在load中调用此方法，要显示小数的列的FormatType属性必须设为Numeric
        /// </summary>
        /// <param name="gridView">gridview对象名</param>
        protected void SetColumn(DevExpress.XtraGrid.Views.Grid.GridView gridView)
        {
            string formatStr;
            int points = int.Parse(ClientConfiguration.DotSetting);
            if (points == 0)
                formatStr = "##,##0";
            else
                formatStr = "##,##0." + "0".PadLeft(points, '0');
            foreach (GridColumn col in gridView.Columns)
            {
                if (col.DisplayFormat.FormatType == FormatType.Numeric)
                {
                    if (!("1").Equals(col.Tag))
                        col.DisplayFormat.FormatString = formatStr;
                    col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Far;
                    col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Far;
                }
                else
                {
                    col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                    col.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
                    if (col.Caption.Equals("选择"))
                        col.Width = 45;
                }
                col.OptionsFilter.AllowFilter = false;
            }
        }

        /// <summary>
        /// 设置控件属性
        /// </summary>
        public void setXtraControls(Control.ControlCollection p_Controls)
        {

            //foreach (object ctl in this.p_Controls)
            //{
            //    DevExpress.XtraGrid.GridControl flpan = ctl as DevExpress.XtraGrid.GridControl;
            //    if (flpan != null)
            //    {
            //        DevExpress.XtraGrid.Views.Grid.GridView gv = (DevExpress.XtraGrid.Views.Grid.GridView)flpan.Views[0];
            //        string flpann = flpan.Name;
            //        gv.OptionsSelection.EnableAppearanceFocusedCell = false;
            //        gv.OptionsView.EnableAppearanceEvenRow = true;
            //        gv.OptionsView.EnableAppearanceOddRow = true;
            //        gv.Appearance.EvenRow.BackColor = Color.Beige;
            //        SetPoint(gv);
            //        continue;
            //    }
            //    DevExpress.XtraEditors.LabelControl lab = ctl as DevExpress.XtraEditors.LabelControl;
            //    if (lab != null)
            //    {
            //        if (lab.Text.Contains(":"))
            //            lab.Text = lab.Text.Replace(":", "：");
            //        continue;
            //    }

            //}


            foreach (object ctl in p_Controls)
            {
                DevExpress.XtraGrid.GridControl flpan = ctl as DevExpress.XtraGrid.GridControl;
                if (flpan != null)
                {
                    DevExpress.XtraGrid.Views.Grid.GridView gv = (DevExpress.XtraGrid.Views.Grid.GridView)flpan.Views[0];
                    string flpann = flpan.Name;
                    gv.OptionsSelection.EnableAppearanceFocusedCell = false;
                    //gv.IndicatorWidth = 50;
                    
                    gv.OptionsView.EnableAppearanceEvenRow = true;
                    gv.OptionsView.EnableAppearanceOddRow = true;
                    gv.OptionsMenu.EnableColumnMenu = false;
                    gv.Appearance.EvenRow.BackColor = Color.FromArgb(int.Parse(ClientConfiguration.EvenColor));
                    gv.Appearance.OddRow.BackColor = Color.FromArgb(int.Parse(ClientConfiguration.OddColor));
                    SetColumn(gv);
                    
                    gv.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(gridView_CustomDrawRowIndicator);
                    //gv.DataSourceChanged += new System.EventHandler(gridView_DataSourceChanged);
                    gv.RowCountChanged += new System.EventHandler(gridView_RowCountChanged);
                    if (gv.DataRowCount > 9999)
                        gv.IndicatorWidth = 50;
                    else if (gv.DataRowCount > 999)
                        gv.IndicatorWidth = 45;
                    else if (gv.DataRowCount > 99)
                        gv.IndicatorWidth = 40;
                    else
                        gv.IndicatorWidth = 30;
                    continue;
                }
                DevExpress.XtraEditors.LabelControl lab = ctl as DevExpress.XtraEditors.LabelControl;
                if (lab != null)
                {
                    if (lab.Text.Contains(":"))
                        lab.Text = lab.Text.Replace(":", "：");
                    continue;
                }
                TableLayoutPanel tlp = ctl as TableLayoutPanel;
                if (tlp != null)
                {
                    setXtraControls(tlp.Controls);
                    continue;
                }

                DevExpress.XtraEditors.PanelControl pc = ctl as DevExpress.XtraEditors.PanelControl;
                if (pc != null)
                {
                    setXtraControls(pc.Controls);
                    continue;
                }

                DevExpress.XtraTab.XtraTabControl tc = ctl as DevExpress.XtraTab.XtraTabControl;
                if (tc != null)
                {
                    setXtraControls(tc.Controls);
                    continue;
                }

                DevExpress.XtraTab.XtraTabPage tp = ctl as DevExpress.XtraTab.XtraTabPage;
                if (tp != null)
                {
                    setXtraControls(tp.Controls);
                    continue;
                }

                DevExpress.XtraEditors.GroupControl gc = ctl as DevExpress.XtraEditors.GroupControl;
                if (gc != null)
                {
                    setXtraControls(gc.Controls);
                    continue;
                }

                DevExpress.XtraEditors.LookUpEdit lue = ctl as DevExpress.XtraEditors.LookUpEdit;
                if (lue != null)
                {
                    lue.Properties.DropDownRows = 5;
                    continue;
                }

                DevExpress.XtraEditors.TextEdit te = ctl as DevExpress.XtraEditors.TextEdit;
                if (te != null)
                {
                    te.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textEdit_KeyPress);
                    continue;
                }
            }
        }


        //设置控件属性
        private void FormBase_Load(object sender, EventArgs e)
        {
            this.Text = "海虹医疗器械电子商务耗材交易系统";          
            

        }
        protected void CheckInputCom(object sender)
        {

            //转换特殊字符
            comBase.CheckControls(sender);
        }
        protected void CheckInputAll()
        {

            //设置控件属性
            comBase.CheckAllControls(this.Controls);
        }
        protected void CheckTextBox(object sender, EventArgs e)
        {
            //转换特殊字符
            comBase.CheckControls(sender);
        }
        ///// <summary>
        ///// 从缓存中取得数据 不用分页
        ///// </summary>
        ///// <param name="TableName"></param>
        protected void InitFromCacheByData(string TableName)
        {
            newsTable = ClientCache.CachedDS.Tables[TableName];
            gridTable = newsTable.Clone();
            cachedDataView = newsTable.DefaultView;
            //gridDataView = gridTable.DefaultView;
        }

        ///// <summary>
        ///// 从缓存中取得数据
        ///// </summary>
        ///// <param name="TableName"></param>
        protected void InitFromCache(string TableName)
        {
            newsTable = ClientCache.CachedDS.Tables[TableName];
            gridTable = newsTable.Clone();
            cachedDataView = newsTable.DefaultView;
            InitGridTableView(1, defaultPageSize);
        }
        /// <summary>
        /// 从缓存中取得数据
        /// </summary>
        /// <param name="TableName"></param>
        protected void InitFromCacheByData(DataTable dt)
        {

            newsTable = dt;
            gridTable = newsTable.Clone();
            cachedDataView = newsTable.DefaultView;
            InitGridTableView(1, defaultPageSize);
        }
        /// <summary>
        /// 从缓存中取得数据
        /// </summary>
        /// <param name="TableName"></param>
        protected void InitFromCacheByData(DataTable dt, int pageNum, int pageSize)
        {

            newsTable = dt;
            gridTable = newsTable.Clone();
            cachedDataView = newsTable.DefaultView;
            InitGridTableView(pageNum, pageSize);
        }
        ///// <summary>
        ///// 从缓存中取得子表数据
        ///// </summary>
        ///// <param name="mainTableName">主表名</param>
        ///// <param name="childTableName">子表名</param>
        ///// <param name="relation">主表与子表的关系名</param>
        ///// <param name="id">主表Id</param>
        //protected void InitFromCache(string TableName,string  childTableName,string relation, string id)
        //{
        //    newsTable = ClientCache.CachedDS.Tables[childTableName].Clone();
        //    DataRow row = ClientCache.CachedDS.Tables[TableName].Rows.Find(id);
        //    DataRow[] rows = row.GetChildRows(relation);
        //    foreach (DataRow rowChild in rows)
        //    {
        //        newsTable.Rows.Add(rowChild.ItemArray);
        //    }
        //    gridTable = newsTable.Clone();
        //    cachedDataView = newsTable.DefaultView;
        //    InitGridTableView(1, defaultPageSize);
        //}
        ///// <summary>
        ///// 从缓存中取得子表数据
        ///// </summary>
        ///// <param name="mainTableName">主表名</param>
        ///// <param name="childTableName">子表名</param>
        ///// <param name="relation">主表与子表的关系名</param>
        ///// <param name="id">主表Id</param>
        //protected DataTable GetChildTable(string mainTableName,string childTableName, string relation, string id)
        //{

        //    DataRow row = ClientCache.CachedDS.Tables[mainTableName].Rows.Find(id);
        //    DataRow[] rows = row.GetChildRows(relation);
        //    DataTable table = ClientCache.CachedDS.Tables[childTableName].Clone();
        //    foreach (DataRow rowChild in rows)
        //    {
        //        table.Rows.Add(rowChild.ItemArray);
        //    }
        //    return table;
        //}
        /// <summary>
        /// 分页操作
        /// </summary>
        /// <param name="pageNum"></param>
        /// <param name="pageSize"></param>
        protected void InitGridTableView(int pageNum, int pageSize)
        {
            int start = PageUtils.GetLowIndexOfPage(pageNum, pageSize);
            int end = PageUtils.GetHighIndexOfPage(pageNum, pageSize);
            //PageChangedEventArgs pageNavigator = this.Controls["pageNavigator1"] as PageChangedEventArgs;
            gridTable.Clear();
            if (cachedDataView.Count < pageSize)
            {
                for (int i = 0; i < cachedDataView.Count; i++)
                {
                    DataRowView drw = cachedDataView[i];
                    gridTable.ImportRow(drw.Row);
                }
            }
            else
            {
                for (int i = start; i < end + 1; i++)
                {
                    if (i <= cachedDataView.Count)
                    {
                        DataRowView drw = cachedDataView[i - 1];
                        gridTable.ImportRow(drw.Row);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            gridDataView = gridTable.DefaultView;
        }

        //sunhl added,2006.6.24 15:15

        /// <summary>
        /// Gets the current user id.
        /// </summary>
        /// <value>The current user id.</value>
        protected virtual string CurrentUserId
        {
            get { return ClientSession.GetInstance().CurrentUser.UserInfo.Id; }
        }

        /// <summary>
        /// Gets the name of the current user.
        /// </summary>
        /// <value>The name of the current user.</value>
        protected virtual string CurrentUserName
        {
            get { return ClientSession.GetInstance().CurrentUser.UserInfo.Name; }
        }

        /// <summary>
        /// Gets the current user org id.
        /// </summary>
        /// <value>The current user org id.</value>
        protected virtual string CurrentUserOrgId
        {
            get { return ClientSession.GetInstance().CurrentUser.UserOrg.Id; }
        }

        /// <summary>
        /// Gets the name of the current user org.
        /// </summary>
        /// <value>The name of the current user org.</value>
        protected virtual string CurrentUserOrgName
        {
            get { return ClientSession.GetInstance().CurrentUser.UserOrg.Name; }
        }

        /// <summary>
        /// Gets the current user region id.
        /// </summary>
        /// <value>The current user region id.</value>
        protected virtual string CurrentUserRegionId
        {
            get { return ClientSession.GetInstance().CurrentUser.UserInfo.Region_id; }
        }

        /// <summary>
        /// Gets the current user single region id.
        /// </summary>
        /// <value>The current user single region id.</value>
        protected virtual string CurrentUserSingleRegionId
        {
            get { return ClientSession.GetInstance().CurrentUser.SingleRegionId; }
        }

        /// <summary>
        /// Gets the current user role id.
        /// </summary>
        /// <value>The current user role id.</value>
        protected virtual string CurrentUserRoleId
        {
            get { return ClientSession.GetInstance().CurrentUser.UserInfo.Role_id; }
        }

        /// <summary>
        /// Gets the current user reg org id.
        /// </summary>
        /// <value>The current user reg org id.</value>
        protected virtual string CurrentUserRegOrgId
        {
            get { return ClientSession.GetInstance().CurrentUser.UserOrg.Reg_org_id; }
        }

        /// <summary>
        /// 取得当前用户对象
        /// </summary>
        protected virtual LogedInUser CurrentUser
        {
            get { return ClientSession.GetInstance().CurrentUser; }
        }

        /// <summary>
        /// 取得高位id
        /// </summary>
        protected virtual int CurrentUserHighID
        {
            get { return ClientSession.GetInstance().CurrentUser.HighId; }
        }

        /// <summary>
        /// 取得机构简称
        /// </summary>
        protected virtual string CurrentUserOrgAbbr
        {
            get { return ClientSession.GetInstance().CurrentUser.UserOrg.Abbr; }
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            setXtraControls(this.Controls);
        }


        /// <summary>
        /// 加入序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            int rowIndex = e.RowHandle;
            if (rowIndex >= 0)
            {
                rowIndex++;
                e.Info.DisplayText = rowIndex.ToString();
                e.Info.Appearance.TextOptions.HAlignment = HorzAlignment.Far;
            }
            
            e.Info.ImageIndex = -1;


        }
        private void gridView_RowCountChanged(object sender, EventArgs e)
        //private void gridView_DataSourceChanged(object sender, EventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView gv = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            if (gv.DataRowCount > 9999)
                gv.IndicatorWidth = 50;
            else if (gv.DataRowCount > 999)
                gv.IndicatorWidth = 45;
            else if (gv.DataRowCount > 99)
                gv.IndicatorWidth = 40;
            else 
                gv.IndicatorWidth = 30;
        }


        private void textEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString().Equals("'") || e.KeyChar.ToString().Equals("%") || e.KeyChar.ToString().Equals("_") || e.KeyChar.ToString().Equals("[") || e.KeyChar.ToString().Equals("]") || e.KeyChar.ToString().Equals("^"))
                e.Handled = true;

        }
    }
}